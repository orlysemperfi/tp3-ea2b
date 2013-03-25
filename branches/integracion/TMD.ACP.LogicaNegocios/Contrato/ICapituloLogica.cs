using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;


namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface ICapituloLogica
    {
        List<Capitulo> Obtener(int idNorma, int? idCapitulo);
    }
}
