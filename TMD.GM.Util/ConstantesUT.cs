using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace TMD.GM.Util
{
    public static class ConstantesUT
    {
        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ESTADO_SOLICITUD
        {
            public const int Aperturado = 1;
            public const int Programado = 2;
            public const int Completado = 3;
            public const int Anulado = 4;
        }
        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ESTADO_ORDEN
        {
            public const int Abierta = 1;
            public const int Cerrada = 2;
            public const int Anulada = 3;
        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ESTADO_GENERICO
        {
            public const int Activo = 1;
            public const int Inactivo = 0;
        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct UNIDAD_TIEMPO
        {
            public const int D = 1;
            public const int H = 2;
            public const int M = 3;
            public const string desTiempoDefault = "minuto(s)";


        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct FRECUENCIA
        {
            public const int Diario = 1;
            public const int Semanal = 2;
            public const int Quincenal = 3;
            public const int Mensual = 4;
            public const int Trimestral = 5;
            public const int Semestral = 6;
            public const int Anual = 7;
        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct MENSAJES_ERROR
        {
            public const string NoExiste = "No existe el registro";
            public const string YaExisteCodigo = "Código ya existente";
            public const string YaExisteNombre = "Nombre ya existente";
            public const string YaExisteNumSerie = "N° de Serie ya existente";

            public const string Solicitud_EquiPlanProg = "El equipo y el plan estan asociados a otra solicitud programada";

        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct SESSION
        {
            public const string PlanActividadActual = "PlanActividadKey";
            public const string PlanActividades = "PlanActividadesKey";

            public const string SolicitudActividadActual = "SolicitudActividadKey";
            public const string SolicitudActividades = "SolicitudActividadesKey";

            public const string OTActividadActual = "OTActividadKey";
            public const string OTActividades = "OTActividadesKey";
            public const string OTActual = "OTActualKey";

            public const string OTEquiposPendientes = "OTEquiposPendientesKey";
            public const string OTActividadesPendientes = "OTActividadesPendientesKey";
            public const string OTEquiposCheck = "OTEquiposCheckKey";
            public const string OTActividadesCheck = "OTActividadesCheckKey";


        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct OPCION
        {
            public const int Editar = 1;
            public const int Nuevo = 2;
            public const int Visualizar = 3;
            public const int Eliminar = 4;
        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct PROCEDENCIA
        {
            public const int Propio = 1;
            public const int Externo = 2;
        }


        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct PARAMETROS
        {
            public const int HorasLaborables = 8;
        }
    }
}
