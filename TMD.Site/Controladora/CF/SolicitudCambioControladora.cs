using System.Collections.Generic;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;
using TMD.Core;


namespace TMD.CF.Site.Controladora.CF
{
    class SolicitudCambioControladora : Base
    {
        private static readonly ISolicitudCambioLogica SolicitudCambioLogica = new SolicitudCambioLogica(new SolicitudCambioData(BaseDatos));

        public static List<Parametro> ListarEstado()
        {
            return
                new List<Parametro>
                    {
                        new Parametro{Id = 0, Nombre = "--Seleccione--"},
                        new Parametro{Id = Constantes.EstadoAprobado, Nombre = "Aprobado"},
                        new Parametro{Id = Constantes.EstadoDesaprobado, Nombre = "Desaprobado"},
                        new Parametro{Id = Constantes.EstadoPendiente, Nombre = "Pendiente"}
                    };
        }

        public static List<Parametro> ListarPrioridad()
        {
            return
                new List<Parametro>
                    {
                        new Parametro{Id = 0, Nombre = "--Seleccione--"},
                        new Parametro{Id = Constantes.PrioridadBaja, Nombre = "Baja"},
                        new Parametro{Id = Constantes.PrioridadMedia, Nombre = "Media"},
                        new Parametro{Id = Constantes.PrioridadAlta, Nombre = "Alta"}
                    };
        }

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