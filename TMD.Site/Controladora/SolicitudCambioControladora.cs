﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;


namespace TMD.CF.Site.Controladora
{
    class SolicitudCambioControladora : Base
    {
        private static readonly ISolicitudCambioLogica _solicitudCambioLogica = new SolicitudCambioLogica(new SolicitudCambioData(BaseDatos));

        public void Agregar(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioLogica.Agregar(solicitudCambio);
        }

        public void Aprobar(SolicitudCambio solicitudCambio)
        {
            _solicitudCambioLogica.Aprobar(solicitudCambio);
        }

        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            return _solicitudCambioLogica.ListarPorProyectoLineaBase(solicitudCambio);
        }

        public SolicitudCambio ObtenerPorId(int id)
        {
            return _solicitudCambioLogica.ObtenerPorId(id);
        }
    }
}