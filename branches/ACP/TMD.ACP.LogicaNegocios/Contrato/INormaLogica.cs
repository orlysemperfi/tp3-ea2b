using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;


namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface INormaLogica
    {
        List<Norma> Obtener(int? idNorma);
    }
}
