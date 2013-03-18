using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMD.GM.Entidades;
using TMD.GM.LogicaNegocios.Contrato;
using TMD.GM.LogicaNegocios.Implementacion;
using TMD.GM.Site.Models;
using TMD.GM.Util;

namespace TMD.GM.Site.Controllers
{
    public class SolicitudController : Controller
    {
        //
        // GET: /Manten/
        private readonly IComunBL comunBL = new ComunBL();
        private readonly IPlanBL planBL = new PlanBL();
        private readonly ISolicitudBL solicitudBL = new SolicitudBL();
        public ActionResult SolicitudConsulta()
        {
            SolicitudModel model = new SolicitudModel();

            List<SelectListItemBE> listaDataTS = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();

            listaDataTS = comunBL.ListarTipoMante();
            listaDataTS.Insert(0, new SelectListItemBE() { CODIGO = "0", DESCRIPCION = "[Todos]" });
            listaDataES = comunBL.ListarEstadoSolicitud();
            listaDataES.Insert(0, new SelectListItemBE() { CODIGO = "0", DESCRIPCION = "[Todos]" });
            listaDataPM = planBL.ListarPlanMante();
            listaDataPM.Insert(0, new SelectListItemBE() { CODIGO = "", DESCRIPCION = "[Todos]" });

            model.listaTS = new List<SelectListItem>();
            model.listaES = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();

            foreach (var item in listaDataTS)
            {
                model.listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = new List<SelectListItem>();
            return View(model);
        }
        public ActionResult Solicitudes(string pNumSoli, string pFechaIni, string pFechaFin, string pTipoSoli, string pDocuRefe, string pEstaSoli, string pCodiEqui, string pPlanMant)
        {
            SolicitudConsultaModel model = new SolicitudConsultaModel();
            DateTime fechaIni, fechaFin;
            SolicitudFiltroBE filtro = new SolicitudFiltroBE();
            filtro.NUMERO_SOLICITUD = pNumSoli;
            if(DateTime.TryParse(pFechaIni,out fechaIni))
                filtro.FECHA_INICIO_SOLICITUD = fechaIni;
            if(DateTime.TryParse(pFechaFin,out fechaFin))
                filtro.FECHA_FIN_SOLICITUD = fechaFin;
            filtro.TIPO_SOLICITUD = DataUT.ObjectToInt32(pTipoSoli);
            filtro.DOCUMENTO_REFERENCIA = pDocuRefe;
            filtro.ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstaSoli);
            filtro.CODIGO_EQUIPO = DataUT.ObjectToInt32(pCodiEqui);
            filtro.CODIGO_PLAN = pPlanMant;


            model.listaData = solicitudBL.ObtenerSolicitudes(filtro);

            return PartialView("Solicitudes", model);
        }
        public ActionResult SolicitudEditar(string pNumSoli, string pFechaSoli, string pTipoSoli, string pDocuRefe, string pFechaIni, string pFechaFin, string pEstado, string pCodiEqui, string pCodiPlan)
        {
            SolicitudModel model = new SolicitudModel();

            model.solicitudBE = new SolicitudBE()
            {
                NUMERO_SOLICITUD = pNumSoli,
                FECHA_SOLICITUD = DataUT.ObjectToDateTime(pFechaSoli),
                TIPO_SOLICITUD = DataUT.ObjectToInt32( pTipoSoli),
                DOCUMENTO_REFERENCIA = pDocuRefe,
                FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(pFechaIni),
                FECHA_FIN_SOLICITUD =DataUT.ObjectToDateTime( pFechaFin),
                ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstado),
                CODIGO_EQUIPO = DataUT.ObjectToInt32(pCodiEqui),
                CODIGO_PLAN = pCodiPlan
            };

            List<SelectListItemBE> listaDataTS = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();

            listaDataTS = comunBL.ListarTipoMante();
            listaDataES = comunBL.ListarEstadoSolicitud();
            listaDataPM = planBL.ListarPlanMante();
            //model.solicitudBE = solicitudBL.ObtenerSolicitudNueva();

            model.listaTS = new List<SelectListItem>();
            model.listaES = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();


            foreach (var item in listaDataTS)
            {
                model.listaTS.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudBE.TIPO_SOLICITUD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudBE.ESTADO_SOLICITUD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudBE.CODIGO_PLAN), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = listaPM;

            return PartialView("Solicitud",model);
        }
        public ActionResult SolicitudNueva()
        {
            SolicitudModel model = new SolicitudModel();

            List<SelectListItemBE> listaDataTS = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();

            listaDataTS = comunBL.ListarTipoMante();
            listaDataES = comunBL.ListarEstadoSolicitud();
            listaDataPM = planBL.ListarPlanMante();
            model.solicitudBE = solicitudBL.ObtenerSolicitudNueva();

            model.solicitudBE.FECHA_SOLICITUD = DateTime.Now.Date;
            model.solicitudBE.FECHA_INICIO_SOLICITUD = DateTime.Now.Date;
            model.solicitudBE.FECHA_FIN_SOLICITUD = DateTime.Now.Date;

            model.listaTS = new List<SelectListItem>();
            model.listaES = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();


            foreach (var item in listaDataTS)
            {
                model.listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = item.CODIGO == ConstantesUT.ESTADO_SOLICITUD.Aperturado.ToString(), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = listaPM;

            return PartialView("SolicitudNueva", model);
        }
        public ActionResult SolicitudActividades(string pNumSoli)
        {
            SolicitudModel model = new SolicitudModel();

            SolicitudBE entity = new SolicitudBE() { NUMERO_SOLICITUD = pNumSoli };
            entity = solicitudBL.VisualizarSolicitud(entity);
            model.solicitudBE = entity;

            model.solicitudBE.listaActividades = entity.listaActividades;

            Session["SolicitudActividadesKey"] = entity.listaActividades;

            return PartialView(model);

        }

        public ActionResult SolicitudActividades_Actualiza(string pNumSoli)
        {
            SolicitudModel model = new SolicitudModel();

            if (Session["SolicitudActividadesKey"] == null)
                Session["SolicitudActividadesKey"] = new List<SolicitudDetalleBE>();
            model.solicitudBE = new SolicitudBE() { NUMERO_SOLICITUD = pNumSoli };
            model.solicitudBE.listaActividades = (List<SolicitudDetalleBE>)Session["SolicitudActividadesKey"];


            return PartialView("SolicitudActividades", model);

        }

        public ActionResult SolicitudActividadEditar(string pIdActividad, string pNumSoli, string pItemSoli, string pDescActi, string pCodiTipo, string pCodiPrio, string pCodiFrec, string pPersRequ, string pCodiTiem, string pTiemActi, string pFechaProg, string pOrdeTrab)
        {
            SolicitudActividadModel model = new SolicitudActividadModel();

            model.solicitudDetalleBE = new SolicitudDetalleBE() 
            { 
                ID_ACTIVIDAD = DataUT.ObjectToInt32(pIdActividad),
                NUMERO_SOLICITUD = pNumSoli,
                ITEM_SOLICITUD = DataUT.ObjectToInt32(pItemSoli),
                DESCRIPCION_ACTIVIDAD = pDescActi,
                CODIGO_TIPO_ACTIVIDAD = DataUT.ObjectToInt32(pCodiTipo),
                PRIORIDAD_ACTIVIDAD = DataUT.ObjectToInt32(pCodiPrio),
                CODIGO_FRECUENCIA = DataUT.ObjectToInt32(pCodiFrec),
                PERSONAL_REQUERIDO = DataUT.ObjectToInt32(pCodiFrec),
                CODIGO_TIEMPO = DataUT.ObjectToInt32(pCodiFrec),
                TIEMPO_ACTIVIDAD = DataUT.ObjectToInt32(pTiemActi),
                FECHA_PROGRAMACION = DataUT.ObjectToDateTime(pFechaProg),
                ORDEN_TRABAJO = pOrdeTrab,

            };

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataFR = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();
            listaDataPR = comunBL.ListarPrioridad();
            listaDataFR = comunBL.ListarFrecuencia();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();
            model.listaFR = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.CODIGO_TIPO_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.CODIGO_TIEMPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.PRIORIDAD_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataFR)
            {
                model.listaFR.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.CODIGO_FRECUENCIA.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }


            return PartialView("SolicitudActividad",model);

        }

        public ActionResult SolicitudActividadNueva(string pNumSoli)
        {
            SolicitudActividadModel model = new SolicitudActividadModel();

            model.solicitudDetalleBE = new SolicitudDetalleBE()
            {
                ID_ACTIVIDAD = DataUT.ObjectToInt32(0),
                NUMERO_SOLICITUD = pNumSoli,
                ITEM_SOLICITUD = 0,
                DESCRIPCION_ACTIVIDAD = string.Empty,
                CODIGO_TIPO_ACTIVIDAD = 0,
                PRIORIDAD_ACTIVIDAD = 0,
                CODIGO_FRECUENCIA = 0,
                PERSONAL_REQUERIDO = 0,
                CODIGO_TIEMPO = 0,
                TIEMPO_ACTIVIDAD = 0,
                FECHA_PROGRAMACION = DateTime.Now.Date,
                ORDEN_TRABAJO = string.Empty,

            };

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataFR = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();
            listaDataPR = comunBL.ListarPrioridad();
            listaDataFR = comunBL.ListarFrecuencia();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();
            model.listaFR = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.CODIGO_TIPO_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.CODIGO_TIEMPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.PRIORIDAD_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataFR)
            {
                model.listaFR.Add(new SelectListItem() { Selected = (item.CODIGO == model.solicitudDetalleBE.CODIGO_FRECUENCIA.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }


            return PartialView("SolicitudActividad", model);

        }

        public EmptyResult SolicitudActividadAceptar(string pIdActividad, string pNumeSoli, int pItem, int pTipoActi, string pDesc, int pPrio, int pCodiFrec, int pPersRequ, int pCodiTiem, int pTiemActi, string pFechaProg, string pOrdeTrab)
        {
            SolicitudDetalleBE entity = new SolicitudDetalleBE()
            {
                ID_ACTIVIDAD = DataUT.ObjectToInt32(pIdActividad),
                NUMERO_SOLICITUD = pNumeSoli,
                ITEM_SOLICITUD = pItem,
                CODIGO_TIPO_ACTIVIDAD = pTipoActi,
                DESCRIPCION_ACTIVIDAD = pDesc,
                PRIORIDAD_ACTIVIDAD = pPrio,
                CODIGO_FRECUENCIA = pCodiFrec,
                PERSONAL_REQUERIDO = pPersRequ,
                CODIGO_TIEMPO = pCodiTiem,
                TIEMPO_ACTIVIDAD = pTiemActi,
                FECHA_PROGRAMACION = DataUT.ObjectToDateTime(pFechaProg),
                ORDEN_TRABAJO = pOrdeTrab
            };

            if (Session["SolicitudActividadesKey"] == null)
                Session["SolicitudActividadesKey"] = new List<SolicitudDetalleBE>();

            List<SolicitudDetalleBE> lista = new List<SolicitudDetalleBE>();
            lista = (List<SolicitudDetalleBE>)Session["SolicitudActividadesKey"];

            //Verificamos la existencia del registro

            SolicitudDetalleBE item = lista.Find(x => x.ID_ACTIVIDAD == entity.ID_ACTIVIDAD);
            if (item != null)
            {
                item.ID_ACTIVIDAD = entity.ID_ACTIVIDAD;
                item.NUMERO_SOLICITUD = entity.NUMERO_SOLICITUD;
                item.ITEM_SOLICITUD = entity.ITEM_SOLICITUD;
                item.CODIGO_TIPO_ACTIVIDAD = entity.CODIGO_TIPO_ACTIVIDAD;
                item.DESCRIPCION_ACTIVIDAD = entity.DESCRIPCION_ACTIVIDAD;
                item.PRIORIDAD_ACTIVIDAD = entity.PRIORIDAD_ACTIVIDAD;
                item.CODIGO_FRECUENCIA = entity.CODIGO_FRECUENCIA;
                item.PERSONAL_REQUERIDO = entity.PERSONAL_REQUERIDO;
                item.CODIGO_TIEMPO = entity.CODIGO_TIEMPO;
                item.TIEMPO_ACTIVIDAD = entity.TIEMPO_ACTIVIDAD;
                item.FECHA_PROGRAMACION = entity.FECHA_PROGRAMACION;
                item.ORDEN_TRABAJO = entity.ORDEN_TRABAJO;
            }
            else
            {
                lista.Add(entity);
            }
            Session["SolicitudActividadesKey"] = lista;

            return new EmptyResult();

        }

        public EmptyResult SolicitudRegistrar(string pNumSoli, string pFechaSoli, string pTipoSoli, string pDocuRefe, string pFechaIni, string pFechaFin, string pEstado, string pCodiEqui, string pCodiPlan)
        {
            SolicitudBE entity = new SolicitudBE();
            entity.NUMERO_SOLICITUD = pNumSoli;
            entity.FECHA_SOLICITUD = DataUT.ObjectToDateTime(pFechaSoli);
            entity.TIPO_SOLICITUD = DataUT.ObjectToInt32(pTipoSoli);
            entity.DOCUMENTO_REFERENCIA = pDocuRefe;
            entity.FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(pFechaIni);
            entity.FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(pFechaFin) ;
            entity.ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstado) ;
            entity.CODIGO_EQUIPO = DataUT.ObjectToInt32(pCodiEqui);
            entity.CODIGO_PLAN = pCodiPlan;
            entity.listaActividades = new List<SolicitudDetalleBE>();

            solicitudBL.RegistrarSolicitud(entity);

            return new EmptyResult();
        }
        public EmptyResult SolicitudActualizar(string pNumSoli, string pFechaSoli, string pTipoSoli, string pDocuRefe, string pFechaIni, string pFechaFin, string pEstado, string pCodiEqui, string pCodiPlan)
        {
            SolicitudBE entity = new SolicitudBE();
            entity.NUMERO_SOLICITUD = pNumSoli;
            entity.FECHA_SOLICITUD = DataUT.ObjectToDateTime(pFechaSoli);
            entity.TIPO_SOLICITUD = DataUT.ObjectToInt32(pTipoSoli);
            entity.DOCUMENTO_REFERENCIA = pDocuRefe;
            entity.FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(pFechaIni);
            entity.FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(pFechaFin);
            entity.ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstado);
            entity.CODIGO_EQUIPO = DataUT.ObjectToInt32(pCodiEqui);
            entity.CODIGO_PLAN = pCodiPlan;
            entity.listaActividades = new List<SolicitudDetalleBE>();

            if (Session["SolicitudActividadesKey"] == null)
                Session["SolicitudActividadesKey"] = new List<SolicitudDetalleBE>();
            entity.listaActividades = (List<SolicitudDetalleBE>)Session["SolicitudActividadesKey"];

            solicitudBL.ActualizarSolicitud(entity);

            return new EmptyResult() ;
        }

        public ActionResult CalendarioActividades()
        {
            SolicitudModel model = new SolicitudModel();

            List<SelectListItemBE> listaDataTS = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();

            listaDataTS = comunBL.ListarTipoMante();
            listaDataES = comunBL.ListarEstadoSolicitud();
            listaDataPM = planBL.ListarPlanMante();
            model.solicitudBE = solicitudBL.ObtenerSolicitudNueva();

            model.listaTS = new List<SelectListItem>();
            model.listaES = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();

            foreach (var item in listaDataTS)
            {
                model.listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = item.CODIGO == ConstantesUT.ESTADO_SOLICITUD.Aperturado.ToString(), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = listaPM;

            return PartialView(model);
        }
        public ActionResult NuevaActividad()
        {
            SolicitudActividadModel model = new SolicitudActividadModel();

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataFR = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();
            listaDataPR = comunBL.ListarPrioridad();
            listaDataFR = comunBL.ListarFrecuencia();

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

        public ActionResult GenerarCronograma()
        {
            SolicitudModel model = new SolicitudModel();

            List<SelectListItemBE> listaDataTS = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();

            listaDataTS = comunBL.ListarTipoMante();
            listaDataES = comunBL.ListarEstadoSolicitud();
            listaDataPM = planBL.ListarPlanMante();
            model.solicitudBE = solicitudBL.ObtenerSolicitudNueva();

            model.listaTS = new List<SelectListItem>();
            model.listaES = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();

            foreach (var item in listaDataTS)
            {
                model.listaTS.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = item.CODIGO == ConstantesUT.ESTADO_SOLICITUD.Aperturado.ToString(), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            //ViewBag.ddlTipoSolicitud = listaTS;
            //ViewBag.ddlEstadoSolicitud = listaES;
            //ViewBag.ddlPlanMante = listaPM;

            return PartialView(model);
        }
    }
}
