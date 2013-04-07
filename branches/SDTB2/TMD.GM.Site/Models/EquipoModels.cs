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
    public class EquipoModel
    {

        public bool nuevo { get; set; }
        public EquipoBE entity { get; set; }
        public List<SelectListItem> listaTE { get; set; }
        public List<SelectListItem> listaAR { get; set; }
        public List<SelectListItem> listaPM { get; set; }
        public List<SelectListItem> listaPR { get; set; }
    }

    public class EquipoBusquedaModel
    {
        public string formProcedencia { get; set; }
        public List<EquipoBE> listaEquipos { get; set; }
    }
}
