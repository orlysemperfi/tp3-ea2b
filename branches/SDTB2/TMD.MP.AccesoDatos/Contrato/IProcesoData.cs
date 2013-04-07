﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.AccesoDatos.Interfaces
{
    public interface IProcesoData
    {
        #region "Select"

        List<ProcesoEntidad> ObtenerListaProcesoTodas();

        List<ProcesoEntidad> ObtenerProcesoPorArea1(int codigoArea);

        #endregion
    }
}
