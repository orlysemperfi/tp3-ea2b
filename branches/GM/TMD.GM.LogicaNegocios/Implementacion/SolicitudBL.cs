﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.AccesoDatos.Implementacion;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.AccesoDatos.Contrato;

namespace TMD.GM.LogicaNegocios.Implementacion
{
    public class SolicitudBL:ISolicitudBL
    {
        #region Constructor
        private readonly ISolicitudDA instanciaDA;
        public SolicitudBL()
        {
            instanciaDA = new SolicitudDA();
        }
        #endregion

        public SolicitudBE ObtenerSolicitudNueva()
        {
            return instanciaDA.ObtenerSolicitudNueva();
        }

        public List<SolicitudBE> ObtenerSolicitudes()
        {
            return instanciaDA.ObtenerSolicitudes();
        }
    }
}