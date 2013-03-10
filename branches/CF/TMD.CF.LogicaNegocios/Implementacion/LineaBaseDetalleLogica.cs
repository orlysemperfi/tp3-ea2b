using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    public class LineaBaseDetalleLogica : ILineaBaseDetalleLogica
    {
        private readonly ILineaBaseElementoConfiguracionData _lineaBaseEcsData;

        public LineaBaseDetalleLogica(ILineaBaseElementoConfiguracionData lineaBaseEcsData)
        {
            _lineaBaseEcsData = lineaBaseEcsData;
        }

        public List<Entidades.LineaBaseElementoConfiguracion> ListarPorLineaBase(LineaBase lineaBase)
        {
            return _lineaBaseEcsData.ListaPorLineaBase(lineaBase);
        }
    }
}
