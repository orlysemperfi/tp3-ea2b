using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IPreguntaVerificacionLogica
    {
        List<PreguntaVerificacion> Obtener(int idAuditoria, int idNorma, int idCapitulo);
        void Modificar(PreguntaVerificacion item);
    }
}
