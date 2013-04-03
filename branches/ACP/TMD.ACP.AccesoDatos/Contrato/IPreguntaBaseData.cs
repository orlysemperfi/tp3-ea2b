using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IPreguntaBaseData
    {
        List<DetallePreguntaBase> ListarDetallePreguntasBase();
    }
}
