﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;

using TMD.Entidades;

namespace TMD.Site.Controladora.ACP
{
    class PreguntaVerificacionControladora : Base
    {
        private static readonly ICapituloLogica _capituloLogica = new CapituloLogica();
        private static readonly INormaLogica _normaLogica = new NormaLogica();
        private static readonly IPreguntaVerificacionLogica _preguntaVerificacionLogica = new PreguntaVerificacionLogica();
        private static readonly IPreguntaBaseLogica _preguntaBaseLogica = new PreguntaBaseLogica();

        public static List<Capitulo> ObtenerCapitulo(int idNorma, int? idCapitulo)
        {
            return _capituloLogica.Obtener(idNorma, idCapitulo);
        }

        public static List<Norma> ObtenerNorma(int? idNorma)
        {
            return _normaLogica.Obtener(idNorma);
        }

        public static List<PreguntaVerificacion> ObtenerPreguntaVerificacion(int idAuditoria, int idNorma, int idCapitulo)
        {
            return _preguntaVerificacionLogica.Obtener(idAuditoria, idNorma, idCapitulo);
        }

        public static void ModificarPreguntaVerificacion(PreguntaVerificacion oPreguntaVerificacion)
        {
            _preguntaVerificacionLogica.Modificar(oPreguntaVerificacion);
        }

        public static List<DetallePreguntaBase> ListarDetallePreguntasBase()
        {
           return _preguntaBaseLogica.ListarDetallePreguntasBase();
        }

        public static void GrabarPreguntaVerificacion(int idAuditoria, List<DetallePreguntaBase> oListaPreguntaBase)
        {
            _preguntaVerificacionLogica.GrabarPreguntaVerificacion(idAuditoria,oListaPreguntaBase);
        }

        public static List<PreguntaVerificacion> ObtenerListaPreguntaVerificacionPorAuditoria(int idAuditoria)
        {
            return _preguntaVerificacionLogica.ObtenerListaPreguntaVerificacionPorAuditoria(idAuditoria);
        }

    }
}