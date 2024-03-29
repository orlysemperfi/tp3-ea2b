﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class PreguntaVerificacionLogica : IPreguntaVerificacionLogica
    {
        private readonly IPreguntaVerificacionData _objData;

        public PreguntaVerificacionLogica()
        {
            _objData = new PreguntaVerificacionData("TMD");
        }


        public List<PreguntaVerificacion> Obtener(int idAuditoria, int idNorma, int idCapitulo)
        {
            return _objData.Obtener(idAuditoria, idNorma, idCapitulo);
        }


        public void Modificar(PreguntaVerificacion item)
        {
            _objData.Modificar(item);
        }

        public void GrabarPreguntaVerificacion(int idAuditoria,List<DetallePreguntaBase> oListaPreguntaBase)
        {
            foreach (DetallePreguntaBase ePreguntaBase in oListaPreguntaBase)
            {
                PreguntaVerificacion ePreguntaVerificacion = new PreguntaVerificacion();
                ePreguntaVerificacion.ObjAuditoria.IdAuditoria = idAuditoria;
                ePreguntaVerificacion.idPreguntaVerificacion = ePreguntaBase.IdPreguntaBase;
                ePreguntaVerificacion.DescripcionPregunta = ePreguntaBase.DescripcionPregunta;
                ePreguntaVerificacion.IdNorma = ePreguntaBase.IdNorma;
                ePreguntaVerificacion.IdCapitulo = ePreguntaBase.IdCapitulo;
                _objData.GrabarPreguntaVerificacion(ePreguntaVerificacion);
            }
        }

        public List<PreguntaVerificacion> ObtenerListaPreguntaVerificacionPorAuditoria(int idAuditoria)
        {
            return _objData.ObtenerListaPreguntaVerificacionPorAuditoria(idAuditoria);
        }        
    }
}
