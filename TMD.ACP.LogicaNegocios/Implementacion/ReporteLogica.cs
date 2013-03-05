using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.ACP.AccesoDatos.Implementacion;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class ReporteLogica
    {
        public DataSet ObtenerRepPlanAuditoria(int idAuditoria)
        {
            return (new ReporteData("TMD")).ObtenerRepPlanAuditoria(idAuditoria);
        }
    }
}
