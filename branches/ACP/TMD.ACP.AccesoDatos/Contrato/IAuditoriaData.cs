using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IAuditoriaData
    {
        List<Auditoria> Obtener(Auditoria filtro);
        List<Auditoria> ListarPlanAuditorias(int anhoAuditoria, string estAutorizado, string estPlanificado);
        Auditoria ObtenerPlanAuditoriaPorID(int idAuditoria);
        void GrabarPlanAuditoria(Auditoria eAuditoria);
        ProgramaAnualAuditoria ObtenerProgramaAnualAuditorias();
        List<Auditoria> ListarAuditoriasPorAnio(int anhoAuditoria);
        int GrabarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual);
        void GrabarAuditoria(Auditoria eAuditoria);
        bool ValidarAuditoria(int idEntidadAuditada);
        void AprobarAuditoria(Auditoria eAuditoria);
        void AprobarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual);
        void RechazarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual);
        void RechazarAuditoria(Auditoria eAuditoria);
        void GrabarInformeFinalAuditoria(Auditoria eAuditoria);
        Auditoria ObtenerInformeFinalPorAuditoria(int idAuditoria);
    }
}
