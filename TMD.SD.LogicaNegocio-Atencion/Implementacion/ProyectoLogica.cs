using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

namespace TMD.SD.LogicaNegocio_Atencion.Implementacion
{
 
    public class ProyectoLogica : IProyectoLogica
    {
        private readonly IProyectoData _proyectoData;
        public ProyectoLogica(IProyectoData proyectoData)
        {
            _proyectoData = proyectoData;
        }


        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        public List<Proyecto> listaProyectosUsuarioCliente(int codigoUsuarioCliente)
        {
            return _proyectoData.listaProyectosUsuarioCliente(codigoUsuarioCliente);
        }

        public List<Proyecto> listaProyectosUsuarioClienteServicio(int codigoCliente, int codigoUsuarioCliente, int codigoServicio)
        {
            return _proyectoData.listaProyectosUsuarioClienteServicio(codigoCliente, codigoUsuarioCliente, codigoServicio);
        }

    }

}
