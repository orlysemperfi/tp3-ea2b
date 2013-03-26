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
            public const int Anulado = 4;

        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct ESTADO_GENERICO
        {
            public const int Activo = 1;
            public const int Inactivo = 0;
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

            public const string Solicitud_EquiPlanProg = "El equipo y el plan estan asociados a otra solicitud programada";

        }

        [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes")]
        public struct SESSION
        {
            public const string PlanActividadActual = "PlanActividadKey";
            public const string PlanActividades = "PlanActividadesKey";

            public const string SolicitudActividadActual = "SolicitudActividadKey";
            public const string SolicitudActividades = "SolicitudActividadesKey";


        }
    }
}
