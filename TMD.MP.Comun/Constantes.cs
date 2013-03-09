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

        public enum ESTADO_PROPUESTA
        {
            REGISTRADA = 1,
            APROBADA = 2,
            RECHAZADA = 3,
            ELIMINADA = 4,
            ESTIMADA = 5,
            ASIGNADA = 6,
            DESARROLLO = 7,
            FINALIZADA = 8
        }
        #endregion

        #region "INDICADOR"
        public static String ESTADO_INDICADOR_ACTIVO    = "ACTIVO";
        public static String ESTADO_INDICADOR_INACTIVO = "INACTIVO";
        public static String ESTADO_INDICADOR_ELIMINADO = "ELIMINADO";
        
        public enum ESTADO_INDICADOR
        {
            ACTIVO = 20,
            INACTIVO = 21,
            ELIMINADO = 22,
        }

        #endregion
    }
}
