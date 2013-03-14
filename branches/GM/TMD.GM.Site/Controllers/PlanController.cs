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

namespace TMD.GM.Site.Controllers
{
    public class PlanController : Controller
    {
        //
        // GET: /Plan/
        private readonly IComunBL comunBL = new ComunBL();
        private readonly IPlanBL planBL = new PlanBL();
        private readonly ISolicitudBL solicitudBL = new SolicitudBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlanConsulta()
        {
            return View();
        }
        public ActionResult PlanNuevo()
        {
            PlanModel model = new PlanModel();
            PlanBE oPlanBE = planBL.ObtenerObtenerPlanNuevo();
            model.codigoPlan = oPlanBE.CODIGO_PLAN;

            model.listaDetalle = new List<PlanDetalleBE>();
            //model.listaDetalle.Add(new PlanDetalleBE());
            return PartialView(model);
        }
        public ActionResult PlanDetalle()
        {
            PlanDetalleModel model = new PlanDetalleModel();

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();

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
            PlanDetalleModel model = new PlanDetalleModel();

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();

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

        public ActionResult ListarTodosPV()
        {
            PlanConsultaModel model = new PlanConsultaModel();


            model.listaData = planBL.ListarPlanManteTodos();

            return PartialView("PlanConsultaResultPV", model);
        }
    }
}
