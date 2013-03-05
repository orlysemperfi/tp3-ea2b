using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

namespace TMD.SD.LogicaNegocio_Atencion.Contrato
{
  

        public interface IServicioLogica
        {

            /// <summary>
            /// Lista todos los analistas de un proyecto.
            /// </summary>
            /// <param name="codigoProyecto">Codigo del Proyecto</param>
            /// <returns>Lista Analista</returns>
            List<Servicio> listaServiciosUsuarioCliente(int codigoCliente, int codigoUsuarioCliente);
            ProyectoServicioSede datosServicioSLA(int codigoProyecto, int codigoServicio, int codigoSede);
        }
  
}
