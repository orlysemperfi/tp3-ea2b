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
    }
}
