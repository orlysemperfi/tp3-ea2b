using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using System.Transactions;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementa  la Logica de Negocios de la entidad Linea Base.
    /// </summary>
    public class LineaBaseLogica : ILineaBaseLogica
    {
        private readonly ILineaBaseData _lineaBaseData;
        private readonly ILineaBaseElementoConfiguracionData _lineaBaseECSData;
        private readonly IUsuarioProyectoData _usuarioProyectoData;

        public LineaBaseLogica(ILineaBaseData lineaBaseData, ILineaBaseElementoConfiguracionData lineaBaseECSData, IUsuarioProyectoData usuarioProyectoData)
        {
            _lineaBaseData = lineaBaseData;
            _lineaBaseECSData = lineaBaseECSData;
            _usuarioProyectoData = usuarioProyectoData;
        }

        /// <summary>
        /// Agrega un registro a la tabla LineaBase.
        /// </summary>
        /// <param name="lineaBase">LineaBase</param>
        public void Agregar(LineaBase lineaBase, UsuarioProyecto usuarioProyecto)
        {         
            using (var scope = new TransactionScope())
            {
                List<UsuarioProyecto> listaUsuarioProyecto = new List<UsuarioProyecto>();
                listaUsuarioProyecto = _usuarioProyectoData.ListaUsuarioProyecto(usuarioProyecto.Id);
                //if (listaUsuarioProyecto.ToString() == "JP")
                //{
                //}
                _lineaBaseData.Agregar(lineaBase, usuarioProyecto);
                lineaBase.LineaBaseECS.ForEach(ecs => _lineaBaseECSData.Agregar(ecs));

                scope.Complete();
            }            
        }

        /// <summary>
        /// Lista las lineas base de una fase de un proyecto.
        /// </summary>
        /// <param name="proyectoFase">ProyectoFase</param>
        /// <returns>Lista LineaBase</returns>
        public List<LineaBase> ListarPorProyecto(Proyecto proyecto, Usuario usuario = null)
        {
            return _lineaBaseData.ListarPorProyecto(proyecto, usuario);
        }

        /// <summary>
        /// Obtiene una Linea Base por el Codigo Proyecto Fase
        /// </summary>
        /// <param name="proyectoFase">Objeto ProyectoFase</param>
        /// <returns>Objeto LineaBase</returns>
        public LineaBase ObtenerPorProyectoFase(ProyectoFase proyectoFase, Usuario usuario = null)
        {
            LineaBase lineaBase = _lineaBaseData.ObtenerPorProyectoFase(proyectoFase);
            lineaBase.LineaBaseECS = _lineaBaseECSData.ListaPorLineaBase(lineaBase,usuario);

            return lineaBase;
        }

        /// <summary>
        /// Actualiza una Linea Base
        /// </summary>
        /// <param name="lineaBase">Objeto LineaBase</param>
        public void Actualizar(LineaBase lineaBase)
        {
            using (var scope = new TransactionScope())
            {
                _lineaBaseData.Actualizar(lineaBase);

                _lineaBaseECSData.Eliminar(lineaBase);
                lineaBase.LineaBaseECS.ForEach(ecs => _lineaBaseECSData.Agregar(ecs));

                scope.Complete();
            }   
        }

        /// <summary>
        /// Actualiza el archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="elemento">Objeto LineaBaseElementoConfiguracion</param>
        public void ActualizarArchivo(LineaBaseElementoConfiguracion elemento)
        {
            using (var scope=new TransactionScope())
            {
                _lineaBaseECSData.ActualizarArchivo(elemento);

                scope.Complete();
            }
        }

        /// <summary>
        /// Recupera un archivo de un Elemento de Configuracion
        /// </summary>
        /// <param name="id">Id del elemento de configuracion</param>
        /// <returns>byte[]</returns>
        public LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            LineaBaseElementoConfiguracion elementoConfiguracion = null;

            using (var scope = new TransactionScope())
            {
                elementoConfiguracion = _lineaBaseECSData.ObtenerArchivo(id);
                scope.Complete();
                
            }

            return elementoConfiguracion;
        }
    }
}
