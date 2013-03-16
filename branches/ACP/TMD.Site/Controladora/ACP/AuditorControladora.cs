using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.ACP.AccesoDatos.Implementacion;
using TMD.Entidades;

namespace TMD.Site.Controladora.ACP
{
    class AuditorControladora : Base
    {
        private static readonly IAuditorLogica _auditorLogica = new AuditorLogica();

        public static List<Auditor> ListarAuditoresPorAuditoria(int idAuditoria)
        {
            return _auditorLogica.ListarAuditoresPorAuditoria(idAuditoria);
        }

        public static void EliminarAuditoresPorAuditoria(int idAuditoria)
        {
            _auditorLogica.EliminarAuditoresPorAuditoria(idAuditoria);
        }

        public static void GrabarAuditor(Auditor auditor)
        {
            _auditorLogica.GrabarAuditor(auditor);
        }
    }
}