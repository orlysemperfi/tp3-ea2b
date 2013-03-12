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
    public class CapituloLogica : ICapituloLogica
    {
        private readonly ICapituloData _objData;

        public CapituloLogica()
        {
            _objData = new CapituloData("TMD");
        }

        public List<Capitulo> Obtener(int idNorma, int? idCapitulo)
        {
            return _objData.Obtener(idNorma, idCapitulo);
        }
    }
}
