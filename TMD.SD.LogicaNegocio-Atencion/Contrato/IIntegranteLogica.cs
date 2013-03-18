using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.SD.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.SD.AccesoDatos_Atencion.Contrato;

  
namespace TMD.SD.LogicaNegocio_Atencion.Contrato
{
    public interface IIntegranteLogica
    {

        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        List<Integrante> listaAnalistas(int codigoProyecto);
        List<Integrante> listaEspecialistaProyectoServicioSede(int CodigoProyecto, int CodigoServicio, int CodigoSede);
        List<Integrante> listaEspecialistaProyectoServicioSedeCarga(int CodigoProyecto, int CodigoServicio, int CodigoSede);
        List<Equipo> listaEquiposEspecialista(int CodigoProyecto, int CodigoServicio, int CodigoSede, int CodigoEmpleado);
        List<Integrante> listaIntegrantesCompleta(string nivel);
    }
}
