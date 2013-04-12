using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.GM.AccesoDatos
{
    public class ComparerExcept<T> : IEqualityComparer<T>
    {
        #region IEqualityComparer<Contact> Members

        public bool Equals(T x, T y)
        {
            if (typeof(T) == typeof(PLAN_MANTENIMIENTO_DETALLE))
            {
                if ((x as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD == 0)
                    return false;
                return (x as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD.Equals((y as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD);
            }
            else if (typeof(T) == typeof(SOLICITUD_DETALLE))
            {
                if ((x as SOLICITUD_DETALLE).ID_ACTIVIDAD == 0)
                    return false;
                return (x as SOLICITUD_DETALLE).ID_ACTIVIDAD.Equals((y as SOLICITUD_DETALLE).ID_ACTIVIDAD);
            }
            else if (typeof(T) == typeof(ORDEN_TRABAJO_DETALLE))
            {
                if ((x as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD == 0)
                    return false;
                return (x as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD.Equals((y as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD);
            }
            else
                throw new NotImplementedException();
            return false;
        }

        public int GetHashCode(T obj)
        {
            if (typeof(T) == typeof(PLAN_MANTENIMIENTO_DETALLE))
                return (obj as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD.GetHashCode();
            else if (typeof(T) == typeof(SOLICITUD_DETALLE))
                return (obj as SOLICITUD_DETALLE).ID_ACTIVIDAD.GetHashCode();
            else if (typeof(T) == typeof(ORDEN_TRABAJO_DETALLE))
                return (obj as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD.GetHashCode();
            else
                throw new NotImplementedException();
            return obj.GetHashCode();
        }

        #endregion
    }
    public class ComparerDistinct<T> : IEqualityComparer<T>
    {
        #region IEqualityComparer<Contact> Members

        public bool Equals(T x, T y)
        {
            if (typeof(T) == typeof(PLAN_MANTENIMIENTO_DETALLE))
            {
                if ((x as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD == 0)
                    return true;
                return (x as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD.Equals((y as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD);
            }
            else if (typeof(T) == typeof(ACTIVIDAD_TIPO))
            {
                if ((x as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD == 0)
                    return true;
                return (x as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD.Equals((y as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD);
            }
            else if (typeof(T) == typeof(ORDEN_TRABAJO_DETALLE))
            {
                if ((x as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD == 0)
                    return true;
                return (x as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD.Equals((y as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD);
            }
            else
                throw new NotImplementedException();
            return false;
        }

        public int GetHashCode(T obj)
        {
            if (typeof(T) == typeof(PLAN_MANTENIMIENTO_DETALLE))
                return (obj as PLAN_MANTENIMIENTO_DETALLE).ID_ACTIVIDAD.GetHashCode();
            else if (typeof(T) == typeof(ORDEN_TRABAJO_DETALLE))
                return (obj as ORDEN_TRABAJO_DETALLE).ID_ACTIVIDAD.GetHashCode();
            else
                throw new NotImplementedException();
            return obj.GetHashCode();
        }

        #endregion
    }
}
