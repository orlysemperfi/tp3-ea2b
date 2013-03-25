using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TMD.DBO.LogicaNegocio_Atencion.Contrato;
using TMD.Entidades;
using TMD.DBO.AccesoDatos_Atencion.Contrato;


namespace TMD.DBO.LogicaNegocio_Atencion.Implementacion
{
    public class IntegranteLogica:IIntegranteLogica
    {
        private readonly IIntegranteData _integranteData;
        public IntegranteLogica(IIntegranteData integranteData)
        {
            _integranteData = integranteData;
        }


        /// <summary>
        /// Lista todos los analistas de un proyecto.
        /// </summary>
        /// <param name="codigoProyecto">Codigo del Proyecto</param>
        /// <returns>Lista Analista</returns>
        public List<Integrante> listaAnalistas(int codigoProyecto)
        {
            return _integranteData.listaAnalistas(codigoProyecto);
        }
        public List<Integrante> listaEspecialistaProyectoServicioSede(int CodigoProyecto, int CodigoServicio, int CodigoSede)
        {
            return _integranteData.listaEspecialistaProyectoServicioSede( CodigoProyecto, CodigoServicio, CodigoSede);
        }
        public List<Integrante> listaEspecialistaProyectoServicioSedeCarga(int CodigoProyecto, int CodigoServicio, int CodigoSede)
        {
            return _integranteData.listaEspecialistaProyectoServicioSedeCarga(CodigoProyecto, CodigoServicio, CodigoSede);
        }

        public List<Equipo> listaEquiposEspecialista(int CodigoProyecto, int CodigoServicio, int CodigoSede, int CodigoEmpleado)
        {
            return _integranteData.listaEquiposEspecialista(CodigoProyecto,  CodigoServicio,  CodigoSede,  CodigoEmpleado);
        }

        public List<Integrante> listaIntegrantesCompleta(string nivel)
        {
            return _integranteData.listaIntegrantesCompleta(nivel);
        }


    }
}
