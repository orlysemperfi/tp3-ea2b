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
    public class EntidadAuditadaLogica : IEntidadAuditadaLogica
    {
        private readonly IEntidadAuditadaData _objData;

        public EntidadAuditadaLogica()
        {
            _objData = new EntidadAuditadaData("TMD");
        }

        public List<EntidadAuditada> ListarEntidadesAuditadas()
        {
            return _objData.ListarEntidadesAuditadas();
        }

        public EntidadAuditada ObtenerEntidadAuditada(int idEntidadAuditada)
        {
            return _objData.ObtenerEntidadAuditada(idEntidadAuditada);
        }
    }
}
