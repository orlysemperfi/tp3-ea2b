using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IAuditorLogica
    {
        List<Auditor> ListarAuditoresPorAuditoria(int idAuditoria);
        void GrabarAuditor(Auditor auditor);
        void EliminarAuditoresPorAuditoria(int idAuditoria);
    }
}
