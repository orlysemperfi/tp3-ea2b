﻿using System;
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
    public class OrdenTrabajoConsultaModels
    {
        public List<OrdenTrabajoBE> listaData { get; set; }
       
    }
}
