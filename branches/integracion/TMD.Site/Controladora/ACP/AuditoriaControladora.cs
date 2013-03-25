using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Entidades;

namespace TMD.Site.Controladora.ACP
{
    class AuditoriaControladora : Base
    {
        private static readonly IAuditoriaLogica _auditoriaLogica = new AuditoriaLogica();
        private static readonly IActividadLogica _actividadLogica = new ActividadLogica();
        private static readonly IEmpleadoLogica _empleadoLogica = new EmpleadoLogica();
        private static readonly IEntidadAuditadaLogica _entidadAuditadaLogica = new EntidadAuditadaLogica();

        public static Auditoria ObtenerPlanAuditoriaPorID(int idAuditoria)
        {
            return _auditoriaLogica.ObtenerPlanAuditoriaPorID(idAuditoria);
        }

        public static List<Auditoria> ObtenerPlanAuditoriaPorID(Auditoria filtro)
        {
            return _auditoriaLogica.Obtener(filtro);
        }

        public static List<Auditoria> ListarPlanAuditorias(int anhoAuditoria, string estAutorizado, string estPlanificado)
        {
            return _auditoriaLogica.ListarPlanAuditorias(anhoAuditoria, estAutorizado, estPlanificado);
        }

        public static void GrabarPlanAuditoria(Auditoria auditoria)
        {
            _auditoriaLogica.GrabarPlanAuditoria(auditoria);
        }

        public static List<Actividad> ListarActividadesPorAuditoria(int idAuditoria)
        {
            return _actividadLogica.ListarActividadesPorAuditoria(idAuditoria);
        }

        public static void GrabarActividad(Actividad actividad)
        {
            _actividadLogica.GrabarActividad(actividad);
        }

        public static void EliminarActividadesPorAuditoria(int idAuditoria)
        {
            _actividadLogica.EliminarActividadesPorAuditoria(idAuditoria);
        }

        #region "Programa Anual de Auditoria"

        public static ProgramaAnualAuditoria ObtenerProgramaAnualAuditorias()
        {
            return _auditoriaLogica.ObtenerProgramaAnualAuditorias();
        }

        public static List<Auditoria> ListarAuditoriasPorAnio(int anhoAuditoria)
        {
            return _auditoriaLogica.ListarAuditoriasPorAnio(anhoAuditoria);
        }

        public static List<EntidadAuditada> ListarEntidadesAuditadas()
        {
            return _entidadAuditadaLogica.ListarEntidadesAuditadas();
        }

        public static List<EmpleadoEntidad> ListarEmpleadosPorArea(int idArea)
        {
            return _empleadoLogica.ListarEmpleadosPorArea(idArea);
        }

        public static EntidadAuditada ObtenerEntidadAuditada(int idEntidadAuditada)
        {
            return _entidadAuditadaLogica.ObtenerEntidadAuditada(idEntidadAuditada);
        }

        public static int GrabarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual)
        {
            return _auditoriaLogica.GrabarProgramaAnualAuditoria(eProgramaAnual);
        }

        public static bool ValidarAuditoria(int idEntidadAuditada)
        {
            return _auditoriaLogica.ValidarAuditoria(idEntidadAuditada);
        }

        #endregion
    }
}