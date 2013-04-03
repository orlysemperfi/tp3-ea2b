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
    public class PreguntaBaseLogica : IPreguntaBaseLogica
    {
        private readonly IPreguntaBaseData _objData;

        public PreguntaBaseLogica()
        {
            _objData = new PreguntaBaseData("TMD");
        }
        
        public List<DetallePreguntaBase> ListarDetallePreguntasBase()
        {
            return _objData.ListarDetallePreguntasBase();
        }
    }
}
