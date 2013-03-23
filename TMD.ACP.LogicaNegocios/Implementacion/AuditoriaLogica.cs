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
    public class AuditoriaLogica : IAuditoriaLogica
    {
        private readonly IAuditoriaData _objData;

        public AuditoriaLogica()
        {
            _objData = new AuditoriaData("TMD");
        }

        public List<Auditoria> Obtener(Auditoria filtro)
        {
            if (String.IsNullOrEmpty(filtro.Estado)) filtro.Estado = null;

            return _objData.Obtener(filtro);
        }

        public List<Auditoria> ListarPlanAuditorias(int anhoAuditoria, string estAutorizado, string estPlanificado)
        {
            return _objData.ListarPlanAuditorias(anhoAuditoria, estAutorizado, estPlanificado);
        }

        public Auditoria ObtenerPlanAuditoriaPorID(int idAuditoria)
        {
            return _objData.ObtenerPlanAuditoriaPorID(idAuditoria);
        }

        public void GrabarPlanAuditoria(Auditoria eAuditoria)
        {
            eAuditoria.Estado = EstadoAuditoria.Planificado;
            _objData.GrabarPlanAuditoria(eAuditoria);
        }

        public ProgramaAnualAuditoria ObtenerProgramaAnualAuditorias()
        {
            return _objData.ObtenerProgramaAnualAuditorias();
        }

        public List<Auditoria> ListarAuditoriasPorAnio(int anhoAuditoria)
        {
            return _objData.ListarAuditoriasPorAnio(anhoAuditoria);
        }

        public int GrabarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual)
        {
            eProgramaAnual.Estado = EstadoProgramaAnual.Creado;
            int idPrograma = _objData.GrabarProgramaAnualAuditoria(eProgramaAnual);

            foreach (Auditoria eAuditoria in eProgramaAnual.ObjAuditorias)
            {
                eAuditoria.idPrograma = idPrograma;
                eAuditoria.Estado = EstadoAuditoria.Creado;
                _objData.GrabarAuditoria(eAuditoria);
            }

            return idPrograma;
        }

        public bool ValidarAuditoria(int idEntidadAuditada)
        {
            return _objData.ValidarAuditoria(idEntidadAuditada);
        }
    }
}
