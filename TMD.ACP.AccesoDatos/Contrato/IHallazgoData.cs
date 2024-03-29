﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IHallazgoData
    {
        int Agregar(Hallazgo hallazgo);
        void Modificar(Hallazgo hallazgo);
        void Eliminar(int idHallazgo);
        List<Hallazgo> Obtener(Hallazgo filtro);
        List<Auditoria> ObtenerAuditoriasSeguimiento(int anhoAuditoria);
        List<Hallazgo> ObtenerHallazgosSeguimiento(int idAuditoria, int idHallazgo);
        void GrabarHallazgoSeguimiento(Hallazgo hallazgo);
        List<Hallazgo> Obtener_Anio(int AnhoAuditoria);
        List<Hallazgo> ObtenerHallazgosSeguimientoPorPeriodo(int anhoAuditoria, int idHallazgo);

        List<Hallazgo> ObtenerHallazgosSeguimiento_PlanAccion(int idHallazgo);
        void ModificarHallazgoSeguimiento(Hallazgo eHallazgo);
        bool ValidarUpdate(Int32 IdHallazgo, DateTime dFecCompromiso);
        List<Hallazgo> ObtenerHallazgosPorPreguntaVerificacion(int idAuditoria, int idPreguntaVerificacion);
    }
}
