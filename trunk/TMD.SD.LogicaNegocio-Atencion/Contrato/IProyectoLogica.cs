using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.DBO.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.DBO.AccesoDatos_Atencion.Contrato;

namespace TMD.DBO.LogicaNegocio_Atencion.Contrato
{
  
    public interface IProyectoLogica
    {

        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        List<Proyecto> listaProyectosUsuarioCliente(int codigoUsuarioCliente);
        List<Proyecto> listaProyectosUsuarioClienteServicio(int codigoCliente, int codigoUsuarioCliente, int codigoServicio);
    }
}
