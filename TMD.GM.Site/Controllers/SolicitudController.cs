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

        public EmptyResult RedirectEspecialidad()
        {
            Response.Redirect("http://localhost:1051/MantEmpleado/frmMantEmpleado.aspx");
            return new EmptyResult();
        }
        public EmptyResult RedirectInforme()
        {
            Response.Redirect("http://localhost:1051/MantInforme/frmMantInforme.aspx");
            return new EmptyResult();
        }
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
        public ActionResult SolicitudEditar(string pNumSoli, string pFechaSoli, string pTipoSoli, string pDocuRefe, string pFechaIni, string pFechaFin, string pEstado, string pCodiEqui, string pCodiPlan, string pNombEqui, string pDescArea)
        {
            SolicitudModel model = new SolicitudModel();
            model.opcion = ConstantesUT.OPCION.Editar;

            model.solicitudBE = new SolicitudBE()
            {
                NUMERO_SOLICITUD = pNumSoli,
                FECHA_SOLICITUD = DataUT.ObjectToDateTime(pFechaSoli),
                TIPO_SOLICITUD = DataUT.ObjectToInt32( pTipoSoli),
                DOCUMENTO_REFERENCIA = pDocuRefe,
                FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(pFechaIni),
                FECHA_FIN_SOLICITUD =DataUT.ObjectToDateTime( pFechaFin),
                ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstado),
                CODIGO_EQUIPO = DataUT.ObjectToString(pCodiEqui),
                NOMBRE_EQUIPO = pNombEqui,
                DESCRIPCION_AREA = pDescArea,
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

            Session[ConstantesUT.SESSION.SolicitudActividades] = null;

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
            //model.solicitudBE = solicitudBL.ObtenerSolicitudNueva();
            model.solicitudBE = new SolicitudBE();
            model.opcion = ConstantesUT.OPCION.Nuevo;

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

            Session[ConstantesUT.SESSION.SolicitudActividades] = null;

            return PartialView("Solicitud", model);
        }
        public ActionResult SolicitudActividades(string pNumSoli)
        {
            SolicitudModel model = new SolicitudModel();
            SolicitudBE entity = new SolicitudBE() { NUMERO_SOLICITUD = pNumSoli };
            entity = solicitudBL.VisualizarSolicitud(entity);
            model.solicitudBE = entity;

            model.solicitudBE.listaActividades = entity.listaActividades;

            Session[ConstantesUT.SESSION.SolicitudActividades] = entity.listaActividades;

            return PartialView(model);
        }

        public ActionResult SolicitudActividades_Actualiza(string pNumSoli)
        {
            SolicitudModel model = new SolicitudModel();

            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<SolicitudDetalleBE>();
            model.solicitudBE = new SolicitudBE() { NUMERO_SOLICITUD = pNumSoli };
            model.solicitudBE.listaActividades = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];


            return PartialView("SolicitudActividades", model);

        }

        public ActionResult SolicitudActividadEliminar(string pGuidActividad)
        {
            SolicitudModel model = new SolicitudModel();

            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<SolicitudDetalleBE>();

            List<SolicitudDetalleBE> listaTmp = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];
            model.solicitudBE = new SolicitudBE();

            //model.solicitudBE.listaActividades = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];
            //model.solicitudBE.listaActividades.Remove(model.solicitudBE.listaActividades.Find(x => x.GUID_ROW.ToString() == pGuidActividad));

            listaTmp.Remove(listaTmp.Find(x => x.GUID_ROW.ToString() == pGuidActividad));
            model.solicitudBE.listaActividades = new List<SolicitudDetalleBE>();
            int index = 0;
            foreach (var item in listaTmp)
            {
                index++;
                item.ITEM_SOLICITUD = index;
                model.solicitudBE.listaActividades.Add(item);
            }
            model.cronogramGenerado = (model.solicitudBE.listaActividades.Count>0);
            Session[ConstantesUT.SESSION.SolicitudActividades] = model.solicitudBE.listaActividades;

            return PartialView("SolicitudActividades", model);
        }
        public ActionResult SolicitudActividadEliminarTodas()
        {
            SolicitudModel model = new SolicitudModel();

            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<SolicitudDetalleBE>();
            model.solicitudBE = new SolicitudBE();
            model.solicitudBE.listaActividades = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];
            model.solicitudBE.listaActividades.Clear();

            Session[ConstantesUT.SESSION.SolicitudActividades] = model.solicitudBE.listaActividades;

            return PartialView("SolicitudActividades", model);
        }

        public ActionResult SolicitudActividadEditar(string pGuidActividad)
        {
            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<PlanDetalleBE>();

            List<SolicitudDetalleBE> lista = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];
            SolicitudActividadModel model = new SolicitudActividadModel();

            model.solicitudDetalleBE = lista.Find(x => x.GUID_ROW.ToString() == pGuidActividad);

            Session[ConstantesUT.SESSION.SolicitudActividadActual] = model.solicitudDetalleBE;

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
            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<PlanDetalleBE>();
            List<SolicitudDetalleBE> lista = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];

            SolicitudActividadModel model = new SolicitudActividadModel();
            model.solicitudDetalleBE = new SolicitudDetalleBE()
            {
                GUID_ROW = Guid.NewGuid(),
                NUMERO_SOLICITUD = pNumSoli,
                ITEM_SOLICITUD = lista.Count + 1,
                DESCRIPCION_ACTIVIDAD = string.Empty,
                CODIGO_TIPO_ACTIVIDAD = 0,PRIORIDAD_ACTIVIDAD = 0,CODIGO_FRECUENCIA = 0,PERSONAL_REQUERIDO = 0,
                CODIGO_TIEMPO = 0,TIEMPO_ACTIVIDAD = 0,FECHA_PROGRAMACION = DateTime.Now.Date,ORDEN_TRABAJO = string.Empty,
            };

            Session[ConstantesUT.SESSION.SolicitudActividadActual] = model.solicitudDetalleBE;

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

        public EmptyResult SolicitudActividadAceptar(int pItem, int pTipoActi, string pDesc, int pPrio, int pCodiFrec, int pPersRequ, int pCodiTiem, int pTiemActi, string pFechaProg, string pOrdeTrab)
        {
            SolicitudDetalleBE entity = (SolicitudDetalleBE)Session[ConstantesUT.SESSION.SolicitudActividadActual];

            entity.ITEM_SOLICITUD = pItem;
            entity.CODIGO_TIPO_ACTIVIDAD = pTipoActi;
            entity.DESCRIPCION_ACTIVIDAD = pDesc;
            entity.PRIORIDAD_ACTIVIDAD = pPrio;
            entity.CODIGO_FRECUENCIA = pCodiFrec;
            entity.PERSONAL_REQUERIDO = pPersRequ;
            entity.CODIGO_TIEMPO = pCodiTiem;
            entity.TIEMPO_ACTIVIDAD = pTiemActi;
            entity.FECHA_PROGRAMACION = DataUT.ObjectToDateNullTimeTryParse(pFechaProg);
            entity.ORDEN_TRABAJO = pOrdeTrab;

            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<SolicitudDetalleBE>();

            List<SolicitudDetalleBE> lista = new List<SolicitudDetalleBE>();
            lista = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];

            //Verificamos la existencia del registro

            SolicitudDetalleBE item = lista.Find(x => x.GUID_ROW == entity.GUID_ROW);
            if (item != null)
            {
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
            Session[ConstantesUT.SESSION.SolicitudActividades] = lista;

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
            entity.CODIGO_EQUIPO = pCodiEqui;
            entity.CODIGO_PLAN = pCodiPlan;
            entity.listaActividades = new List<SolicitudDetalleBE>();

            solicitudBL.RegistrarSolicitud(entity);

            return new EmptyResult();
        }
        public EmptyResult SolicitudActualizar(string pNumSoli, string pFechaSoli, string pTipoSoli, string pDocuRefe, string pFechaIni, string pFechaFin, string pEstado, string pCodiEqui, string pCodiPlan, string pCronGene)
        {
            SolicitudBE entity = new SolicitudBE();
            entity.NUMERO_SOLICITUD = pNumSoli;
            entity.FECHA_SOLICITUD = DataUT.ObjectToDateTime(pFechaSoli);
            entity.TIPO_SOLICITUD = DataUT.ObjectToInt32(pTipoSoli);
            entity.DOCUMENTO_REFERENCIA = pDocuRefe;
            entity.FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(pFechaIni);
            entity.FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(pFechaFin);
            entity.ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstado);
            entity.CODIGO_EQUIPO = DataUT.ObjectToString(pCodiEqui);
            entity.CODIGO_PLAN = pCodiPlan;
            


            entity.ESTADO_SOLICITUD = (entity.ESTADO_SOLICITUD == ConstantesUT.ESTADO_SOLICITUD.Aperturado && pCronGene == "1") ? ConstantesUT.ESTADO_SOLICITUD.Programado : entity.ESTADO_SOLICITUD;

            entity.listaActividades = new List<SolicitudDetalleBE>();

            if (Session[ConstantesUT.SESSION.SolicitudActividades] == null)
                Session[ConstantesUT.SESSION.SolicitudActividades] = new List<SolicitudDetalleBE>();
            entity.listaActividades = (List<SolicitudDetalleBE>)Session[ConstantesUT.SESSION.SolicitudActividades];

            solicitudBL.ActualizarSolicitud(entity);

            return new EmptyResult() ;
        }
        public EmptyResult SolicitudEliminar(string pCodigo)
        {
            SolicitudBE entity = new SolicitudBE();
            entity.NUMERO_SOLICITUD = pCodigo;

            solicitudBL.EliminarSolicitud(entity);

            return new EmptyResult();
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

            return PartialView(model);
        }
        //public ActionResult NuevaActividad()
        //{
        //    SolicitudActividadModel model = new SolicitudActividadModel();

        //    List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
        //    List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
        //    List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
        //    List<SelectListItemBE> listaDataFR = new List<SelectListItemBE>();

        //    listaDataTA = comunBL.ListarTipoActividad();
        //    listaDataTU = comunBL.ListarTiempoUniMed();
        //    listaDataPR = comunBL.ListarPrioridad();
        //    listaDataFR = comunBL.ListarFrecuencia();

        //    model.listaTA = new List<SelectListItem>();
        //    model.listaTU = new List<SelectListItem>();
        //    model.listaPR = new List<SelectListItem>();
        //    model.listaFR = new List<SelectListItem>();

        //    foreach (var item in listaDataTA)
        //    {
        //        model.listaTA.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
        //    }
        //    foreach (var item in listaDataTU)
        //    {
        //        model.listaTU.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
        //    }
        //    foreach (var item in listaDataPR)
        //    {
        //        model.listaPR.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
        //    }
        //    foreach (var item in listaDataFR)
        //    {
        //        model.listaFR.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
        //    }

        //    return View(model);
        //}

        public ActionResult GenerarCronograma(string pNumeSoli, string pFechaInicio, string pFechaFin)
        {
            SolicitudModel model = new SolicitudModel();

            DateTime fechaInicio, fechaFin;

            if (!DateTime.TryParse(pFechaInicio, out fechaInicio))
                throw new Exception("Rango de fecha no válido");

            if (!DateTime.TryParse(pFechaFin, out fechaFin))
                throw new Exception("Rango de fecha no válido");

            model.solicitudBE = new SolicitudBE() { NUMERO_SOLICITUD = pNumeSoli , FECHA_INICIO_SOLICITUD = fechaInicio , FECHA_FIN_SOLICITUD = fechaFin};

            model.solicitudBE.listaActividades = solicitudBL.GenerarCronograma(model.solicitudBE);

            if (model.solicitudBE.listaActividades.Count > 0)
                model.cronogramGenerado = true;
            else
                model.cronogramGenerado = false;

            Session[ConstantesUT.SESSION.SolicitudActividades] = model.solicitudBE.listaActividades;

            return PartialView("SolicitudActividades",model);
        }

        public ActionResult CalendarioDetalle(string pFecha)
        {
            
            DateTime fecha ;
            if (!DateTime.TryParse(pFecha, out fecha))
                return null;

            CronogramaBE entity = solicitudBL.ActividadesCronograma(fecha);
            ViewBag.listaActividades = entity.listaActividades;

            ViewBag.PersonalDisp = entity.PERSONAL_DISPONIBLE;
            ViewBag.HorasLabo = entity.HORAS_LABORABLES;
            ViewBag.HorasDisp = entity.HORAS_DISPONIBLE;
            ViewBag.HorasEmpl = entity.HORAS_EMPLEADAS;

            return PartialView();
        }
    }
}
