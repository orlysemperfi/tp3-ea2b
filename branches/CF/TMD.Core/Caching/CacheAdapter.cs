using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace TMD.Core.Caching
{
    public class CacheAdapter : ICacheAdapter
    {
        private static readonly ObjectCache _objectCache = MemoryCache.Default;

        /// <summary>
        /// Agrega un item en cache
        /// </summary>
        /// <typeparam name="T">Tipo a agregar</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="minutes">Numero de minutos en cache</param>
        /// <param name="value">Objeto a agregar</param>
        public void AddItem<T>(string name, T value, Double minutes = 1440)//1440 = Cantidad de minutos en un dia
        {
            if (value != null)
            {
                _objectCache.Add(name, value, DateTime.Now.AddMinutes(minutes));
            }
        }

        /// <summary>
        /// Inserta un item en cache
        /// </summary>
        /// <typeparam name="T">Tipo a agregar</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="minutes">Numero de minutos en cache</param>
        /// <param name="value">Objeto a agregar</param>
        public void SetItem<T>(string name, T value, Double minutes = 1440)//1440 = Cantidad de minutos en un dia
        {
            if (value != null)
            {
                _objectCache.Set(name, value, DateTime.Now.AddMinutes(minutes));
            }
        }

        /// <summary>
        /// Obtiene un item de la cache
        /// </summary>
        /// <typeparam name="T">Tipo a obtener</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <returns>T</returns>
        public T GetItem<T>(string name)
        {
            return (T)_objectCache.Get(name);
        }

        /// <summary>
        /// Agrega y obtiene un objeto en cache
        /// </summary>
        /// <typeparam name="R">Tipo del parametro</typeparam>
        /// <typeparam name="T">Tipo a obtener</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="param">Parametro a pasar</param>
        /// <param name="methodCall">Metodo a llamar</param>
        /// <returns>T</returns>
        public T Resolve<R, T>(string name, R param, Func<R, T> methodCall)
        {
            var item = (T)_objectCache.Get(name);
            if (item == null)
            {
                item = methodCall.Invoke(param);
                if (item != null)
                {
                    AddItem<T>(name, item);
                }
            }

            return item;
        }

        /// <summary>
        /// Agrega y obtiene un objeto en cache
        /// </summary>
        /// <typeparam name="T">Tipo a obtener</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="methodCall">Metodo a llamar</param>
        /// <returns>T</returns>
        public T Resolve<T>(string name, Func<T> methodCall)
        {
            var item = (T)_objectCache.Get(name);
            if (item == null)
            {
                item = methodCall.Invoke();
                if (item != null)
                {
                    AddItem<T>(name, item);
                }
            }

            return item;
        }

        /// <summary>
        /// Agrega y obtiene un objeto dentro de una Lista en cache
        /// </summary>
        /// <typeparam name="R">Tipo del parametro</typeparam>
        /// <typeparam name="T">Tipo a obtener</typeparam>
        /// <param name="name">Nombre del parametro</param>
        /// <param name="param">Parametro a pasar</param>
        /// <param name="methodCall">Metodo a llamar</param>
        /// <param name="validation">Metodo para seleccionar</param>
        /// <returns>T</returns>
        public T ResolveList<R, T>(string name, R param, Func<R, T> methodCall, Func<T, bool> validation)
        {
            List<T> listItem = (List<T>)_objectCache.Get(name);
            if (listItem == null)
            {
                listItem = new List<T>();
                AddItem<List<T>>(name, listItem);
            }

            T item = listItem.SingleOrDefault(validation);

            if (item == null)
            {
                item = methodCall.Invoke(param);
                if (item != null)
                {
                    listItem.Add(item);

                    SetItem<List<T>>(name, listItem);
                }
            }

            return item;
        }
    }
}
