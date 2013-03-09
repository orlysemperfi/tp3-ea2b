using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;


namespace TMD.CF.Site.Controladora.CF
{
    class SolicitudCambioControladora : Base
    {
        private static readonly ISolicitudCambioLogica SolicitudCambioLogica = new SolicitudCambioLogica(new SolicitudCambioData(BaseDatos));

        public static void Agregar(SolicitudCambio solicitudCambio)
        {
            SolicitudCambioLogica.Agregar(solicitudCambio);
        }

        public static void Aprobar(SolicitudCambio solicitudCambio)
        {
            SolicitudCambioLogica.Aprobar(solicitudCambio);
        }

        public static List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            return SolicitudCambioLogica.ListarPorProyectoLineaBase(solicitudCambio);
        }

        public static SolicitudCambio ObtenerPorId(int id)
        {
            return SolicitudCambioLogica.ObtenerPorId(id);
        }
    }
}