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
        public EquipoBE entity { get; set; }
    }

    public class EquipoBusquedaModel
    {
        public List<EquipoBE> listaEquipos { get; set; }
    }
}
