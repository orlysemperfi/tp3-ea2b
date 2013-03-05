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
    }
}
