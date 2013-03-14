using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.GM.LogicaNegocios;
using TMD.GM.Site.Models;
using System.Web.Helpers;
using TMD.GM.Entidades;

namespace TMD.GM.Site.Controllers
{
    public class PlanController : Controller
    {
        //
        // GET: /Plan/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Plan()
        {
            ComunBL ComunBL = new ComunBL();
            PlanModel model = new PlanModel();
            PlanBE oPlanBE = ComunBL.ObtenerObtenerPlanNuevo();
            model.codigoPlan = oPlanBE.CODIGO;

            model.listaDetalle = new List<PlanDetalleBE>();
            model.listaDetalle.Add(new PlanDetalleBE());
            return View(model);
        }
        public ActionResult PlanDetalle()
        {
            ComunBL ComunBL = new ComunBL();
            PlanDetalleModel model = new PlanDetalleModel();

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();

            listaDataTA = ComunBL.ListarTipoActividad();
            listaDataTU = ComunBL.ListarTiempoUniMed();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }

            return View(model);
        }

        public ActionResult PlanDetallePV()
        {
            ComunBL ComunBL = new ComunBL();
            PlanDetalleModel model = new PlanDetalleModel();

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();

            listaDataTA = ComunBL.ListarTipoActividad();
            listaDataTU = ComunBL.ListarTiempoUniMed();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }

            return PartialView(model);
        }
    }
}
