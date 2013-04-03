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
        private readonly IPreguntaVerificacionData _objPreguntaVerificacionData;
        private readonly IHallazgoData _objHallazgoData;

        public AuditoriaLogica()
        {
            _objData = new AuditoriaData("TMD");
            _objPreguntaVerificacionData = new PreguntaVerificacionData("TMD");
            _objHallazgoData = new HallazgoData("TMD");
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

        public string GrabarInformeFinalAuditoria(Auditoria eAuditoria)
        {
            bool blnExisteRespuesta=true;
            string msjError = "";
            List<PreguntaVerificacion> listPreguntaVerificacion = _objPreguntaVerificacionData.ObtenerListaPreguntaVerificacionPorAuditoria(eAuditoria.IdAuditoria.Value);
            foreach(PreguntaVerificacion ePreguntaVerificacion in listPreguntaVerificacion)
            {                
                if (ePreguntaVerificacion.Respuesta.HasValue){
                    if (ePreguntaVerificacion.Respuesta.Value == false){
                        List<Hallazgo> lstHallazgos = _objHallazgoData.ObtenerHallazgosPorPreguntaVerificacion(eAuditoria.IdAuditoria.Value, ePreguntaVerificacion.idPreguntaVerificacion);
                        if (lstHallazgos.Count == 0){
                            blnExisteRespuesta = false;
                            msjError = "No existen hallazgos para las preguntas de verificación que no cumplen.";
                            break;
                        }                    
                    }
                }else{
                    blnExisteRespuesta = false;
                    msjError = "Existen preguntas de verificación que no han sido respondidas.";
                    break;
                }
            }

            if (blnExisteRespuesta)
            {
                eAuditoria.Estado = EstadoAuditoria.Realizado;
                _objData.GrabarInformeFinalAuditoria(eAuditoria);
            }

            return msjError;            
        }


        public Auditoria ObtenerInformeFinalPorAuditoria(int idAuditoria)
        {
            return _objData.ObtenerInformeFinalPorAuditoria(idAuditoria);
        }


       
    }
}
