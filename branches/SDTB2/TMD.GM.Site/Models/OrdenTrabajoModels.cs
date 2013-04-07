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
    public class OrdenTrabajoModel
    {
        public List<SelectListItem> listaES { get; set; }
        public int opcion { get; set; }
        public OrdenTrabajoBE entity { get; set; }


        
    }

    public class OrdenTrabajoConsultaModel
    {
        public List<OrdenTrabajoBE> listaData { get; set; }
        public List<SelectListItem> listaES { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }


    }

    public class OrdenTrabajoGeneraModel
    {
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }

        public List<OrdenTrabajoEquipoBE> listaEquiposPendientes { get; set; }
        public List<OrdenTrabajoDetalleBE> listaActividadesPendientes { get; set; }
    }

    public class OrdenTrabajoEquipoModel
    {
        public OrdenTrabajoEquipoBE entity { get; set; }
        public List<EspecialidadBE> listaEspecialidadEquipo { get; set; }
        public List<EspecialidadBE> listaEspecialidadResponsable { get; set; }
    }
}
