﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;

namespace TMD.GM.AccesoDatos.Contrato
{
    public interface IEspecialidadDA
    {
        List<EspecialidadBE> ObtenerEspecialidades();
        List<EspecialidadBE> ObtenerEspecialidadesxEmp(int codEmpleado);
    }
}
