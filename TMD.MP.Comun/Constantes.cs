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
        public static int ACTION_VIEW = 2;
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

        #region "ESTADO SOLUCION"
        public static String ESTADO_SOLUCION_GENERADA = "GENERADA";
        public static String ESTADO_SOLUCION_FINALIZADA = "FINALIZADA";
        public static String ESTADO_SOLUCION_RECHAZADA = "RECHAZADA";
        public static String ESTADO_SOLUCION_CORRECCION = "CORRECCION";
        public static String ESTADO_SOLUCION_APROBADA = "APROBADA";
        public static String ESTADO_SOLUCION_ELIMINADA = "ELIMINADA";

        public enum ESTADO_SOLUCION
        {
            GENERADA = 9,
            FINALIZADA = 10,
            RECHAZADA = 11,
            CORRECCION = 12,
            APROBADA = 13,
            ELIMINADA = 14
        }

        #endregion

        #region "ESTADO PILOTO"
        public static String ESTADO_PILOTO_GENERADO = "GENERADO";
        public static String ESTADO_PILOTO_EJECUTADO = "EJECUTADO";
        public static String ESTADO_PILOTO_EXITOSO = "EXITOSO";
        public static String ESTADO_PILOTO_OBSERVADO = "OBSERVADO";
        public static String ESTADO_PILOTO_ELIMINADO = "ELIMINADO";

        public enum ESTADO_PILOTO
        {
            GENERADO = 15,
            EJECUTADO = 16,
            EXITOSO = 17,
            OBSERVADO = 18,
            ELIMINADO = 19
        }

        #endregion

        #region "ESTADO INDICADOR"
        public static String ESTADO_INDICADOR_ACTIVO    = "ACTIVO";
        public static String ESTADO_INDICADOR_INACTIVO = "INACTIVO";
        public static String ESTADO_INDICADOR_ELIMINADO = "ELIMINADO";
        
        public enum ESTADO_INDICADOR
        {
            ACTIVO = 20,
            INACTIVO = 21,
            ELIMINADO = 22
        }

        #endregion

        #region "NOMBRE TABLAS"

        public static String TABLA_ACCIONES_SOLUCION = "ACCIONES_SOLUCION";
        public static String TABLA_ARTEFACTO_PROCESO = "ARTEFACTO_PROCESO";
        public static String TABLA_ESCALA_CUALITATIVO = "ESCALA_CUALITATIVO";
        public static String TABLA_ESCALA_CUANTITATIVO = "ESCALA_CUANTITATIVO";
        public static String TABLA_ESTADO = "ESTADO";
        public static String TABLA_ESTADO_PILOTO = "ESTADO_PILOTO";
        public static String TABLA_ESTADO_SOLUCION = "ESTADO_SOLUCION";
        public static String TABLA_INDICADOR = "INDICADOR";
        public static String TABLA_INDICADOR_VALOR = "INDICADOR_VALOR";
        public static String TABLA_LECCION_APRENDIDA_PROCESO = "LECCION_APRENDIDA_PROCESO";
        public static String TABLA_LECCIONES_APRENDIDAS = "LECCIONES_APRENDIDAS";
        public static String TABLA_OBSERVACIONES_PILOTO = "OBSERVACIONES_PILOTO";
        public static String TABLA_PILOTO = "PILOTO";
        public static String TABLA_PILOTO_ESTADO = "ESTADO_PILOTO";
        public static String TABLA_PLAN_DESPLIEGUE = "PLAN_DESPLIEGUE";
        public static String TABLA_PROCESO = "PROCESO";
        public static String TABLA_PROPUESTA_ESTADO = "PROPUESTA_ESTADO";
        public static String TABLA_PROPUESTA_INDICADOR = "PROPUESTA_INDICADOR";
        public static String TABLA_PROPUESTAMEJORA = "PROPUESTAMEJORA";
        public static String TABLA_SOLUCION_MEJORA = "SOLUCION_MEJORA";
        public static String TABLA_SOLUCION_ESTADO = "ESTADO_SOLUCION";
        public static String TABLA_UNIDAD = "UNIDAD";

        #endregion

        #region "TIPO INDICADOR"
        public static int TIPO_INDICADOR_CUALITATIVO = 0;
        public static int TIPO_INDICADOR_CUANTITATIVO = 1;
        #endregion  
    }
}
