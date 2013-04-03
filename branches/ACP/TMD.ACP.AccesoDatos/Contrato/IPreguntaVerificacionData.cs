using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IPreguntaVerificacionData
    {
        List<PreguntaVerificacion> Obtener(int idAuditoria, int idNorma, int idCapitulo);
        void Modificar(PreguntaVerificacion item);
        void GrabarPreguntaVerificacion(PreguntaVerificacion ePreguntaVerificacion);
        List<PreguntaVerificacion> ObtenerListaPreguntaVerificacionPorAuditoria(int idAuditoria);
    }
}
