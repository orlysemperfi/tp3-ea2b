using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class AuditorLogica : IAuditorLogica
    {
        private readonly IAuditorData _objData;


        public AuditorLogica()
        {
            _objData = new AuditorData("TMD");
        }


        public List<Auditor> ListarAuditoresPorAuditoria(int idAuditoria)
        {
            return _objData.ListarAuditoresPorAuditoria(idAuditoria);
        }

        public void GrabarAuditor(Auditor auditor)
        {
            _objData.GrabarAuditor(auditor);
        }

        public void EliminarAuditoresPorAuditoria(int idAuditoria)
        {
            _objData.EliminarAuditoresPorAuditoria(idAuditoria);
        }
    }
}
