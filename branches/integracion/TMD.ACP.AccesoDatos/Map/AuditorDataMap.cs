using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;

namespace TMD.ACP.AccesoDatos.Map
{
    class AuditorDataMap
    {
        public static Auditor SelectListaAuditores(IDataReader reader)
        {
            Auditor objAuditor = new Auditor();

            objAuditor.IdAuditoria = reader.GetInt("idAuditoria");
            objAuditor.IdAuditor = reader.GetInt("idAuditor");
            
            return objAuditor;
        }
    }
}
