﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.AccesoDatos.Contrato
{
    public interface IActividadData
    {
        List<Actividad> ListarActividadesPorAuditoria(int idAuditoria);
        void GrabarActividad(Actividad actividad);
        void EliminarActividadesPorAuditoria(int idAuditoria);
    }
}
