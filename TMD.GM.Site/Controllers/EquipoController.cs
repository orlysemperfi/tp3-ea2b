using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.GM.LogicaNegocios;
using TMD.GM.Site.Models;
using System.Web.Helpers;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Implementacion;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.Util;

namespace TMD.GM.Site.Controllers
{
    public class EquipoController : Controller
    {
        //
        // GET: /Plan/
        private readonly IComunBL comunBL = new ComunBL();
        private readonly IPlanBL planBL = new PlanBL();
        private readonly ISolicitudBL solicitudBL = new SolicitudBL();
        private readonly IEquipoBL equipoBL = new EquipoBL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EquipoSeleccionar()
        {
            return View();
        }
        public ActionResult EquipoConsulta()
        {
            return PartialView();
        }

        public ActionResult Equipos()
        {
            EquipoBusquedaModel model = new EquipoBusquedaModel();
            model.listaEquipos = equipoBL.BuscarEquipos();

            return PartialView( model);
        }
      
    }
}
