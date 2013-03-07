using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.LogicaNegocios;
using TMD.Entidades;

namespace TMD.MP.Controlador
{
    public class SolucionMejoraControlador
    {
        public PropuestaMejoraLogica propuestaMejoraLogica = new PropuestaMejoraLogica();

        public List<PropuestaMejoraEntidad> ObtenerPropuestaMejoraListadoPorFiltros(PropuestaMejoraEntidad oPropuestaMejoraFiltro)
        {
            return propuestaMejoraLogica.ObtenerPropuestaMejoraListadoPorFiltros(oPropuestaMejoraFiltro);
        }

        public PropuestaMejoraEntidad ObtenerPropuestaMejoraPorCodigo(int codigo)
        {
            return propuestaMejoraLogica.ObtenerPropuestaMejoraPorCodigo(codigo);
        }

        public void ActualizarEstadoPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            propuestaMejoraLogica.ActualizarEstadoPropuestaMejora(oPropuestaMejora);
        }

        public void ActualizarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            propuestaMejoraLogica.ActualizarPropuestaMejora(oPropuestaMejora);
        }

        public void InsertarPropuestaMejora(PropuestaMejoraEntidad entidad)
        {
            propuestaMejoraLogica.InsertarPropuestaMejora(entidad);
        }

        public String BorrarPropuestaMejora(PropuestaMejoraEntidad oPropuestaMejora)
        {
            return propuestaMejoraLogica.BorrarPropuestaMejora(oPropuestaMejora);
        }
    }
}
