using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;
using TMD.Core;
namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class ActividadLogica : IActividadLogica
    {
        private readonly IActividadData _objData;

        public ActividadLogica()
        {
            _objData = new ActividadData("TMD");
        }

        public List<Actividad> ListarActividadesPorAuditoria(int idAuditoria)
        {
            return _objData.ListarActividadesPorAuditoria(idAuditoria);
        }

        public void GrabarActividad(Actividad actividad)
        {
            actividad.Estado = EstadoActividad.Creado;
            _objData.GrabarActividad(actividad);
        }

        public void EliminarActividadesPorAuditoria(int idAuditoria)
        {
            _objData.EliminarActividadesPorAuditoria(idAuditoria);
        }
    }
}
