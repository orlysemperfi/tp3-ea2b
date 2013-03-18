using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;


namespace TMD.SD.AccesoDatos_Atencion.Contrato
{

    /// <summary>
    /// Contrato  del Acceso a datos de la entidad Integrante.
    /// </summary>
    
    public interface IIntegranteData
    {

        /// <summary>
        /// Lista todos los analistas de un proyecto
        /// </summary>
        /// /// <param name="CodigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Integrante</returns>
        List<Integrante> listaAnalistas(int codigoProyecto);
        List<Integrante> listaIntegrantesCompleta(string nivel);
        List<Integrante> listaEspecialistaProyectoServicioSede(int CodigoProyecto, int CodigoServicio, int CodigoSede);
        List<Integrante> listaEspecialistaProyectoServicioSedeCarga(int CodigoProyecto, int CodigoServicio, int CodigoSede);
        List<Equipo> listaEquiposEspecialista(int CodigoProyecto, int CodigoServicio, int CodigoSede, int CodigoEmpleado);

    }


}
