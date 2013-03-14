using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios;
using TMD.GM.Site.Models;
using TMD.GM.Util;

namespace TMD.GM.Site.Controllers
{
    public class SolicitudController : Controller
    {
        //
        // GET: /Manten/

        public ActionResult Solicitud()
        {
            ComunBL  ComunBL = new ComunBL();
            SolicitudModel model = new SolicitudModel();

            List<SelectListItem> listaTS = new List<SelectListItem>();
            List<SelectListItem> listaES = new List<SelectListItem>();

            model.listaDataTS = ComunBL.ListarTipoMante();
            model.listaDataES = ComunBL.ListarEstadoSolicitud();

            foreach (var item in model.listaDataTS)
            {
                listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in model.listaDataES)
            {
                listaES.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            ViewBag.ddlTipoSolicitud = listaTS;
            ViewBag.ddlEstadoSolicitud = listaES;
            ViewBag.ddlPlanMante = new List<SelectListItem>();
            return View();
        }

        public ActionResult SolicitudEdit()
        {
            ComunBL ComunBL = new ComunBL();
            SolicitudModel model = new SolicitudModel();

            List<SelectListItem> listaTS = new List<SelectListItem>();
            List<SelectListItem> listaES = new List<SelectListItem>();
            List<SelectListItem> listaPM = new List<SelectListItem>();

            model.listaDataTS = ComunBL.ListarTipoMante();
            model.listaDataES = ComunBL.ListarEstadoSolicitud();
            model.listaDataPM = ComunBL.ListarPlanMante();
            model.solicitudBE = ComunBL.ObtenerSolicitudNueva();

            foreach (var item in model.listaDataTS)
            {
                listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in model.listaDataES)
            {
                listaES.Add(new SelectListItem() { Selected = item.CODIGO == ConstantesUT.ESTADO_SOLICITUD.Aperturado.ToString(), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in model.listaDataPM)
            {
                listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            ViewBag.ddlTipoSolicitud = listaTS;
            ViewBag.ddlEstadoSolicitud = listaES;
            ViewBag.ddlPlanMante = listaPM;

            return View(model);
        }
        public ActionResult CalendarioActividades()
        {
            ComunBL ComunBL = new ComunBL();
            SolicitudModel model = new SolicitudModel();

            List<SelectListItem> listaTS = new List<SelectListItem>();
            List<SelectListItem> listaES = new List<SelectListItem>();
            List<SelectListItem> listaPM = new List<SelectListItem>();

            model.listaDataTS = ComunBL.ListarTipoMante();
            model.listaDataES = ComunBL.ListarEstadoSolicitud();
            model.listaDataPM = ComunBL.ListarPlanMante();
            model.solicitudBE = ComunBL.ObtenerSolicitudNueva();

            foreach (var item in model.listaDataTS)
            {
                listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in model.listaDataES)
            {
                listaES.Add(new SelectListItem() { Selected = item.CODIGO == ConstantesUT.ESTADO_SOLICITUD.Aperturado.ToString(), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in model.listaDataPM)
            {
                listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            ViewBag.ddlTipoSolicitud = listaTS;
            ViewBag.ddlEstadoSolicitud = listaES;
            ViewBag.ddlPlanMante = listaPM;

            return View(model);
        }
        public ActionResult NuevaActividad()
        {
            ComunBL ComunBL = new ComunBL();
            ActividadModel model = new ActividadModel();

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataFR = new List<SelectListItemBE>();

            listaDataTA = ComunBL.ListarTipoActividad();
            listaDataTU = ComunBL.ListarTiempoUniMed();
            listaDataPR = ComunBL.ListarPrioridad();
            listaDataFR = ComunBL.ListarFrecuencia();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();
            model.listaFR = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataFR)
            {
                model.listaFR.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = listaPM;

            return View(model);
        }
    }
}
