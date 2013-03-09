using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.MP.Comun
{
    public class Constantes
    {
        #region "DB"

        public static String TMD_MP_DATABASE = "TMD";

        #endregion

        #region "ACTIONS"
        public static int ACTION_INSERT = 0;
        public static int ACTION_UPDATE = 1;
        #endregion

        #region "TIPO PROPUESTA"
        public static String TIPO_PROPUESTA_PROBLEMA = "Problema";
        public static String TIPO_PROPUESTA_MEJORA = "Mejora";
        #endregion

        #region "ESTADO PROPUESTA"
        public static String ESTADO_PROPUESTA_REGISTRADA = "Registrada";
        public static String ESTADO_PROPUESTA_APROBADA = "Aprobada";
        public static String ESTADO_PROPUESTA_RECHAZADA = "Rechazada";
        public static String ESTADO_PROPUESTA_ELIMINADA = "Eliminada";
        public static String ESTADO_PROPUESTA_ESTIMADA = "Estimada";
        public static String ESTADO_PROPUESTA_ASIGNADA = "Asignada";
        public static String ESTADO_PROPUESTA_DESARROLLO = "Desarrollo";
        public static String ESTADO_PROPUESTA_FINALIZADA = "Finalizada";
        #endregion
    }
}
