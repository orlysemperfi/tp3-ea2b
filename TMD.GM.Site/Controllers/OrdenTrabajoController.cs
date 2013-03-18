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
    public class OrdenTrabajoController : Controller
    {
        //
        // GET: /OrdenTrabajo/
        private readonly IOrdenTrabajoBL planBL = new OrdenTrabajoBL();

        public ActionResult OrdenTrabajoConsulta()
        {
            return View();
        }

        public ActionResult OrdenTrabajoConsultaResult(DateTime? pd_Fini, DateTime? pd_Ffin)
        {
            OrdenTrabajoConsultaModels model = new OrdenTrabajoConsultaModels();
            model.listaData = planBL.ListarOrdenTrabajo(pd_Fini, pd_Ffin);
            return PartialView(model);
        }
        public ActionResult OrdenTrabajoCrear()
        {
            //SolicitudModel model = new SolicitudModel();

            //List<SelectListItem> listaTS = new List<SelectListItem>();
            //List<SelectListItem> listaES = new List<SelectListItem>();
            //List<SelectListItem> listaPM = new List<SelectListItem>();

            //model.listaDataTS = comunBL.ListarTipoMante();
            //model.listaDataES = comunBL.ListarEstadoSolicitud();
            //model.listaDataPM = planBL.ListarPlanMante();
            //model.solicitudBE = solicitudBL.ObtenerSolicitudNueva();

            //foreach (var item in model.listaDataTS)
            //{
            //    listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            //}
            //foreach (var item in model.listaDataES)
            //{
            //    listaES.Add(new SelectListItem() { Selected = item.CODIGO == ConstantesUT.ESTADO_SOLICITUD.Aperturado.ToString(), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            //}
            //foreach (var item in model.listaDataPM)
            //{
            //    listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            //}
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = listaPM;
            OrdenTrabajoBE be = new OrdenTrabajoBE();
            return PartialView(be);
        }

    }
}
