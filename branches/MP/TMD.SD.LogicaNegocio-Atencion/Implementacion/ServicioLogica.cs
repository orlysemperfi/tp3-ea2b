using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

namespace TMD.SD.LogicaNegocio_Atencion.Implementacion
{
  
    public class ServicioLogica : IServicioLogica
    {
        private readonly IServicioData _servicioData;
        public ServicioLogica(IServicioData servicioData)
        {
            _servicioData = servicioData;
        }


        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        public List<Servicio> listaServiciosUsuarioCliente(int codigoCliente, int codigoUsuarioCliente)
        {
            return _servicioData.listaServiciosUsuarioCliente(codigoCliente, codigoUsuarioCliente);
        }

        public ProyectoServicioSede datosServicioSLA(int codigoProyecto, int codigoServicio, int codigoSede)
        {
            return _servicioData.datosServicioSLA(codigoProyecto, codigoServicio, codigoSede);
        }

    }



    
}
