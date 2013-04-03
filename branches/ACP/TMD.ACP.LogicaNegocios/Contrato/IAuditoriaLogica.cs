using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IAuditoriaLogica
    {
        List<Auditoria> Obtener(Auditoria filtro);
        List<Auditoria> ListarPlanAuditorias(int anhoAuditoria, string estAutorizado, string estPlanificado);
        Auditoria ObtenerPlanAuditoriaPorID(int idAuditoria);
        void GrabarPlanAuditoria(Auditoria eAuditoria);
        ProgramaAnualAuditoria ObtenerProgramaAnualAuditorias();
        List<Auditoria> ListarAuditoriasPorAnio(int anhoAuditoria);
        int GrabarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual);
        bool ValidarAuditoria(int idEntidadAuditada);
        string GrabarInformeFinalAuditoria(Auditoria eAuditoria);
        Auditoria ObtenerInformeFinalPorAuditoria(int idAuditoria);
    }
}
