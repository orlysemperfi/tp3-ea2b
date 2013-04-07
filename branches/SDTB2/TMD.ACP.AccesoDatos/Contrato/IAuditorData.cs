using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IAuditorData
    {
        List<Auditor> ListarAuditoresPorAuditoria(int idAuditoria);
        void GrabarAuditor(Auditor auditor);
        void EliminarAuditoresPorAuditoria(int idAuditoria);
    }
}
