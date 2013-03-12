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
    public class NormaLogica : INormaLogica
    {
        private readonly INormaData _objData;

        public NormaLogica()
        {
            _objData = new NormaData("TMD");
        }

        public List<Norma> Obtener(int? idNorma)
        {
            return _objData.Obtener(idNorma);
        }
    }
}
