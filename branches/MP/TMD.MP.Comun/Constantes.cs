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
        public static String ESTADO_PROPUESTA_REGISTRADA = "REGISTRADA";
        public static String ESTADO_PROPUESTA_APROBADA = "APROBADA";
        public static String ESTADO_PROPUESTA_RECHAZADA = "RECHAZADA";
        public static String ESTADO_PROPUESTA_ELIMINADA = "ELIMINADA";
        public static String ESTADO_PROPUESTA_ESTIMADA = "ESTIMADA";
        public static String ESTADO_PROPUESTA_ASIGNADA = "ASIGNADA";
        public static String ESTADO_PROPUESTA_DESARROLLO = "DESARROLLO";
        public static String ESTADO_PROPUESTA_FINALIZADA = "FINALIZADA";
        #endregion
    }
}
