using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.SD.AccesoDatos_Atencion.Contrato
{
   
    public interface IServicioData
    {

        List<Servicio> listaServiciosUsuarioCliente(int codigoCliente, int codigoUsuarioCliente);
        ProyectoServicioSede datosServicioSLA(int codigoProyecto, int codigoServicio, int codigoSede);

    }
}
