using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using TMD.GM.Entidades;

namespace TMD.GM.Site.Models
{
    public class SolicitudActividadModel
    {
        public int item { get; set; }
        public SolicitudDetalleBE solicitudDetalleBE { get; set; }
        public List<SelectListItem> listaTA { get; set; }
        public List<SelectListItem> listaTU { get; set; }
        public List<SelectListItem> listaPR { get; set; }
        public List<SelectListItem> listaFR { get; set; }
    }

    public class SolicitudModel
    {
        public List<SelectListItem> listaTS { get; set; }
        public List<SelectListItem> listaES { get; set; }
        public List<SelectListItem> listaPM { get; set; }
        public SolicitudBE solicitudBE { get; set; }
        public int opcion { get; set; }
        public bool cronogramGenerado { get; set; }
    }

    public class SolicitudConsultaModel
    {
        public List<SolicitudBE> listaData { get; set; }

    }

}
