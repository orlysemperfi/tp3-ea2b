using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TMD.Entidades;

namespace TMD.MP.Comun
{
    public class Sesiones
    {
        #region "Usuario"

        private const String usuarioLogueado = "usuarioLogueado";

        #region "UsuarioLogueado"

        public static UsuarioEntidad UsuarioLogueado
        {
            get
            {
                return (UsuarioEntidad)HttpContext.Current.Session[usuarioLogueado];
            }
            set
            {
                HttpContext.Current.Session[usuarioLogueado] = value;
            }
        }

        public static bool UsuarioLogueadoEsNulo()
        {
            return (HttpContext.Current.Session[usuarioLogueado] == null);
        }

        public static void UsuarioLogueadoRemover()
        {
            HttpContext.Current.Session.Remove(usuarioLogueado);
        }

        #endregion

        #endregion

        #region "PropuestaMejora"

        private const String propuestaMejoraListado = "propuestaMejoraListado";
        private const String propuestaMejoraSeleccionada = "propuestaMejoraSeleccionada";

        #region "PropuestaMejoraListado"

        public static List<PropuestaMejoraEntidad> PropuestaMejoraListado
        {
            get
            {
                return (List<PropuestaMejoraEntidad>)HttpContext.Current.Session[propuestaMejoraListado];
            }
            set
            {
                HttpContext.Current.Session[propuestaMejoraListado] = value;
            }
        }

        public static bool PropuestaMejoraListadoEsNulo()
        {
            return HttpContext.Current.Session[propuestaMejoraListado] == null;
        }

        public static void PropuestaMejoraListadoRemover()
        {
            HttpContext.Current.Session.Remove(propuestaMejoraListado);
        }

        #endregion

        #region "PropuestaMejoraSeleccionada"

        public static PropuestaMejoraEntidad PropuestaMejoraSeleccionada
        {
            get
            {
                return (PropuestaMejoraEntidad)HttpContext.Current.Session[propuestaMejoraSeleccionada];
            }
            set
            {
                HttpContext.Current.Session[propuestaMejoraSeleccionada] = value;
            }
        }

        public static bool PropuestaMejoraSeleccionadaEsNula()
        {
            return (HttpContext.Current.Session[propuestaMejoraSeleccionada] == null);
        }

        public static void PropuestaMejoraSeleccionadaRemover()
        {
            HttpContext.Current.Session.Remove(propuestaMejoraSeleccionada);
        }

        #endregion

        #endregion

        #region "Indicador"

        private const String indicadorListado = "indicadorListado";

        #region "IndicadorListado"

        public static List<IndicadorEntidad> IndicadorListado
        {
            get
            {
                return (List<IndicadorEntidad>)HttpContext.Current.Session[indicadorListado];
            }
            set
            {
                HttpContext.Current.Session[indicadorListado] = value;
            }
        }

        public static bool IndicadorListadoEsNulo()
        {
            return HttpContext.Current.Session[indicadorListado] == null;
        }

        public static void IndicadorListadoRemover()
        {
            HttpContext.Current.Session.Remove(indicadorListado);
        }

        #endregion

        #region "IndicadorSeleccionado"

        private const String indicadorSeleccionado = "indicadorSeleccionado";

        public static IndicadorEntidad IndicadorSeleccionado
        {
            get
            {
                return (IndicadorEntidad)HttpContext.Current.Session[indicadorSeleccionado];
            }
            set
            {
                HttpContext.Current.Session[indicadorSeleccionado] = value;
            }
        }

        public static bool IndicadorSeleccionadoEsNulo()
        {
            return (HttpContext.Current.Session[indicadorSeleccionado] == null);
        }

        public static void IndicadorSeleccionadoRemover()
        {
            HttpContext.Current.Session.Remove(indicadorSeleccionado);
        }

        #endregion

        #endregion

        #region "SolucionMejora"

        private const String solucionMejoraListado = "solucionMejoraListado";
        private const String solucionMejoraSeleccionada = "solucionMejoraSeleccionada";

        #region "SolucionMejoraListado"

        public static List<SolucionMejoraEntidad> SolucionMejoraListado
        {
            get
            {
                return (List<SolucionMejoraEntidad>)HttpContext.Current.Session[solucionMejoraListado];
            }
            set
            {
                HttpContext.Current.Session[solucionMejoraListado] = value;
            }
        }

        public static bool SolucionMejoraListadoEsNulo()
        {
            return HttpContext.Current.Session[solucionMejoraListado] == null;
        }

        public static void SolucionMejoraListadoRemover()
        {
            HttpContext.Current.Session.Remove(solucionMejoraListado);
        }

        #endregion

        #region "SolucionMejoraSeleccionada"

        public static SolucionMejoraEntidad SolucionMejoraSeleccionada
        {
            get
            {
                return (SolucionMejoraEntidad)HttpContext.Current.Session[solucionMejoraSeleccionada];
            }
            set
            {
                HttpContext.Current.Session[solucionMejoraSeleccionada] = value;
            }
        }

        public static bool SolucionMejoraSeleccionadaEsNula()
        {
            return (HttpContext.Current.Session[solucionMejoraSeleccionada] == null);
        }

        public static void SolucionMejoraSeleccionadaRemover()
        {
            HttpContext.Current.Session.Remove(solucionMejoraSeleccionada);
        }

        #endregion

        #endregion

        #region "Piloto"

        private const String pilotoListado = "pilotoListado";
        private const String pilotoSeleccionada = "pilotoSeleccionada";

        #region "PilotoListado"

        public static List<PilotoEntidad> PilotoListado
        {
            get
            {
                return (List<PilotoEntidad>)HttpContext.Current.Session[pilotoListado];
            }
            set
            {
                HttpContext.Current.Session[pilotoListado] = value;
            }
        }

        public static bool PilotoListadoEsNulo()
        {
            return HttpContext.Current.Session[pilotoListado] == null;
        }

        public static void PilotoListadoRemover()
        {
            HttpContext.Current.Session.Remove(pilotoListado);
        }

        #endregion

        #region "PilotoSeleccionada"

        public static PilotoEntidad PilotoSeleccionada
        {
            get
            {
                return (PilotoEntidad)HttpContext.Current.Session[pilotoSeleccionada];
            }
            set
            {
                HttpContext.Current.Session[pilotoSeleccionada] = value;
            }
        }

        public static bool PilotoSeleccionadaEsNula()
        {
            return (HttpContext.Current.Session[pilotoSeleccionada] == null);
        }

        public static void PilotoSeleccionadaRemover()
        {
            HttpContext.Current.Session.Remove(pilotoSeleccionada);
        }

        #endregion

        #endregion

    }
}