﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios.Contrato
{
    public interface IAreaLogica
    {
        #region "Select"

        List<AreaEntidad> ObtenerListaAreaTodas();

        #endregion
    }
}
