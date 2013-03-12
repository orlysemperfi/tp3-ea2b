using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface INormaData
    {
        List<Norma> Obtener(int? idNorma);
    }
}
