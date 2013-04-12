using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using TMD.GM.Entidades;
using TMD.GM.Util;

namespace TMD.GM.Site.Models
{
    public class PlanActividadModel
    {
        public PlanDetalleBE entity { get; set; }
        public List<SelectListItem> listaTA { get; set; }
        public List<SelectListItem> listaTU { get; set; }
        public List<SelectListItem> listaPR { get; set; }
        public List<SelectListItem> listaFR { get; set; }
    }
    public class PlanConsultaModel
    {
        public List<PlanBE> listaData { get; set; }

    }

    public class PlanModel
    {
        public List<PlanDetalleBE> listaDetalle { get; set; }
        public string TITULO { get; set; }
        public string codigoPlan { get; set; }
        public string nombrePlan { get; set; }
        public bool activo { get; set; }
        public int opcion { get; set; }

        

    }
}
