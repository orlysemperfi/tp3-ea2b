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
    public class PlanModel
    {
        public List<PlanDetalleBE> listaDetalle { get; set; }
        public string codigoPlan { get; set; }
        public bool activo { get; set; }
       
    }
}
