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
    public class OrdenTrabajoController : Controller
    {
        //
        // GET: /OrdenTrabajo/
        private readonly IOrdenTrabajoBL ordenTrabajoBL = new OrdenTrabajoBL();
        private readonly IEspecialidadBL especialidadBL = new EspecialidadBL();
        private readonly IComunBL comunBL = new ComunBL();

        public ActionResult OrdenTrabajoConsulta()
        {
            OrdenTrabajoConsultaModel model = new OrdenTrabajoConsultaModel();

            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();
            listaDataES = comunBL.ListarEstadoOT();
            listaDataES.Insert(0, new SelectListItemBE() { CODIGO = "0", DESCRIPCION = "[Todos]" });

            model.listaES = new List<SelectListItem>();
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            model.fechaFin = DateTime.Now.Date;
            model.fechaIni = model.fechaFin.AddMonths(-1);

            return View("Consulta",model);
        }

        public ActionResult OrdenesTrabajo(string pNumOT, string pFechaIni, string pFechaFin, string pNumSoli, string pEstadoCodi, string pCodiResp)
        {
            OrdenTrabajoConsultaModel model = new OrdenTrabajoConsultaModel();

            DateTime fechaIni, fechaFin;
            OrdenTrabajoFiltroBE filtro = new OrdenTrabajoFiltroBE();
            filtro.NUMERO_ORDEN = pNumOT;
            filtro.NUMERO_SOLICITUD = pNumSoli;
            filtro.ESTADO_ORDEN = DataUT.ObjectToInt32(pEstadoCodi) ;
            filtro.CODIGO_EMPLEADO = DataUT.ObjectToIntTryParse(pCodiResp);
            if(DateTime.TryParse(pFechaIni,out fechaIni))
                filtro.FECHA_INICIO_ORDEN = fechaIni;
            if(DateTime.TryParse(pFechaFin,out fechaFin))
                filtro.FECHA_FIN_ORDEN = fechaFin;

            model.listaData = ordenTrabajoBL.ListarOrdenTrabajo(filtro);
            return PartialView(model);
        }



        //public ActionResult Solicitudes(string pNumSoli, string pFechaIni, string pFechaFin, string pTipoSoli, string pDocuRefe, string pEstaSoli, string pCodiEqui, string pPlanMant)
        //{
        //    SolicitudConsultaModel model = new SolicitudConsultaModel();
        //    DateTime fechaIni, fechaFin;
        //    SolicitudFiltroBE filtro = new SolicitudFiltroBE();
        //    filtro.NUMERO_SOLICITUD = pNumSoli;
        //    if (DateTime.TryParse(pFechaIni, out fechaIni))
        //        filtro.FECHA_INICIO_SOLICITUD = fechaIni;
        //    if (DateTime.TryParse(pFechaFin, out fechaFin))
        //        filtro.FECHA_FIN_SOLICITUD = fechaFin;
        //    filtro.TIPO_SOLICITUD = DataUT.ObjectToInt32(pTipoSoli);
        //    filtro.DOCUMENTO_REFERENCIA = pDocuRefe;
        //    filtro.ESTADO_SOLICITUD = DataUT.ObjectToInt32(pEstaSoli);
        //    filtro.CODIGO_EQUIPO = DataUT.ObjectToInt32(pCodiEqui);
        //    filtro.CODIGO_PLAN = pPlanMant;


        //    model.listaData = solicitudBL.ObtenerSolicitudes(filtro);

        //    return PartialView("Solicitudes", model);
        //}
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


        public EmptyResult Eliminar(string pCodigo)
        {

            ordenTrabajoBL.Eliminar(new OrdenTrabajoBE() { NUMERO_ORDEN = pCodigo });

            return new EmptyResult();
        }

        public ActionResult Editar(string pNumOrden)
        {
            OrdenTrabajoModel model = new OrdenTrabajoModel();
            model.opcion = ConstantesUT.OPCION.Editar;

            model.entity = ordenTrabajoBL.Visualizar(new OrdenTrabajoBE(){ NUMERO_ORDEN = pNumOrden});

            List<SelectListItemBE> listaDataES = new List<SelectListItemBE>();

            listaDataES = comunBL.ListarEstadoSolicitud();

            model.listaES = new List<SelectListItem>();
            
            foreach (var item in listaDataES)
            {
                model.listaES.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.ESTADO_ORDEN.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            
            Session[ConstantesUT.SESSION.OTActividades] = null;

            return PartialView("OrdenTrabajo", model);
        }

        public ActionResult Actividades(string pNumOrden)
        {
            OrdenTrabajoModel model = new OrdenTrabajoModel();
            OrdenTrabajoBE entity = new OrdenTrabajoBE() { NUMERO_ORDEN = pNumOrden };
            entity.listaActividades = ordenTrabajoBL.VisualizarDetalle(entity);
            model.entity = entity;

            Session[ConstantesUT.SESSION.OTActividades] = entity.listaActividades;

            return PartialView(model);
        }

        public ActionResult Generar()
        {
            OrdenTrabajoGeneraModel model = new OrdenTrabajoGeneraModel();
            model.fechaIni = DateTime.Now.Date;
            model.fechaFin = model.fechaIni.AddDays(6);

            Session[ConstantesUT.SESSION.OTEquiposCheck] = null;
            Session[ConstantesUT.SESSION.OTActividadesCheck] = null;

            return PartialView(model);
        }

        public ActionResult EquiposPendientes(string pFechaIni, string pFechaFin)
        {
            OrdenTrabajoGeneraModel model = new OrdenTrabajoGeneraModel();

            DateTime fechaIni, fechaFin;
            model.listaEquiposPendientes = new List<OrdenTrabajoEquipoBE>();
            if (DateTime.TryParse(pFechaIni, out  fechaIni) && DateTime.TryParse(pFechaFin, out  fechaFin))
                model.listaEquiposPendientes = ordenTrabajoBL.ListarEquiposPendientes(new OrdenTrabajoFiltroBE() { FECHA_INICIO_ORDEN = fechaIni, FECHA_FIN_ORDEN = fechaFin });

            Session[ConstantesUT.SESSION.OTEquiposPendientes] = model.listaEquiposPendientes;
            

            #region Actualizamos lo seleccionado
            if (Session[ConstantesUT.SESSION.OTEquiposCheck] == null)
                Session[ConstantesUT.SESSION.OTEquiposCheck] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposCheck = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposCheck];
            foreach (var item in listaEquiposCheck)
            {
                OrdenTrabajoEquipoBE itemLista = model.listaEquiposPendientes.Find(x => x.CODIGO_EQUIPO == item.CODIGO_EQUIPO);
                if (itemLista != null)
                    itemLista.CHECKED = true;
                
            }
            #endregion


            return PartialView(model);
        }
        public ActionResult ActividadesPendientes(string pCodiEqui)
        {
            OrdenTrabajoGeneraModel model = new OrdenTrabajoGeneraModel();

            model.listaEquiposPendientes = new List<OrdenTrabajoEquipoBE>();

            model.listaActividadesPendientes = ordenTrabajoBL.ListarActividadesEquiposPendientes(new OrdenTrabajoFiltroBE() { CODIGO_EQUIPO = pCodiEqui });

            #region Actualizamos lo seleccionado

            Session[ConstantesUT.SESSION.OTActividadesPendientes] = model.listaActividadesPendientes;

            if (Session[ConstantesUT.SESSION.OTActividadesCheck] == null)
                Session[ConstantesUT.SESSION.OTActividadesCheck] = new List<OrdenTrabajoDetalleBE>();
            List<OrdenTrabajoDetalleBE> listaActividadesCheck = (List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesCheck];
            foreach (var item in listaActividadesCheck)
            {
                OrdenTrabajoDetalleBE itemLista = model.listaActividadesPendientes.Find(x => x.ID_ACTIVIDAD == item.ID_ACTIVIDAD);
                if (itemLista!= null)
                    itemLista.CHECKED = true;
                
            }
            #endregion

            return PartialView(model);
        }

        public EmptyResult ChangeEquipoPendiente(string pCodiEqui, string pNumSoli, string pCheck)
        {
            if (Session[ConstantesUT.SESSION.OTEquiposPendientes] == null)
                Session[ConstantesUT.SESSION.OTEquiposPendientes] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposPedientes = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposPendientes];

            if (Session[ConstantesUT.SESSION.OTEquiposCheck] == null)
                Session[ConstantesUT.SESSION.OTEquiposCheck] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposCheck = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposCheck];

            if (pCheck == "false")
            {
                OrdenTrabajoEquipoBE itemRemove = listaEquiposCheck.Find(x => x.CODIGO_EQUIPO == pCodiEqui);
                if (itemRemove != null)
                    listaEquiposCheck.Remove(itemRemove);
            }
            else if (pCheck == "true")
            {
                OrdenTrabajoEquipoBE actual = listaEquiposPedientes.Find(x => x.CODIGO_EQUIPO == pCodiEqui);
                OrdenTrabajoEquipoBE itemAdd = listaEquiposCheck.Find(x => x.CODIGO_EQUIPO == pCodiEqui);
                if (itemAdd == null)
                    listaEquiposCheck.Add(new OrdenTrabajoEquipoBE() { CODIGO_EQUIPO = pCodiEqui, NUMERO_SOLICITUD = pNumSoli, NOMBRE_EQUIPO = actual.NOMBRE_EQUIPO });
            }

            Session[ConstantesUT.SESSION.OTEquiposCheck] = listaEquiposCheck;

            return new EmptyResult();
        }
        public EmptyResult ChangeActividadPendiente(string pIdActi,string pCodiEqui, string pCheck)
        {
            if (Session[ConstantesUT.SESSION.OTActividadesPendientes] == null)
                Session[ConstantesUT.SESSION.OTActividadesPendientes] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoDetalleBE> listaActividadesPedientes = (List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesPendientes];

            if (Session[ConstantesUT.SESSION.OTActividadesCheck] == null)
                Session[ConstantesUT.SESSION.OTActividadesCheck] = new List<OrdenTrabajoDetalleBE>();

            List<OrdenTrabajoDetalleBE> listaActividadesCheck = (List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesCheck];

            if (pCheck == "false")
            {
                OrdenTrabajoDetalleBE itemRemove = listaActividadesCheck.Find(x => x.ID_ACTIVIDAD == DataUT.ObjectToIntTryParse(pIdActi));
                if (itemRemove != null)
                    listaActividadesCheck.Remove(itemRemove);
            }
            else if (pCheck == "true")
            {
                OrdenTrabajoDetalleBE actual = listaActividadesPedientes.Find(x => x.ID_ACTIVIDAD == DataUT.ObjectToIntTryParse(pIdActi));

                OrdenTrabajoDetalleBE itemAdd = listaActividadesCheck.Find(x => x.ID_ACTIVIDAD == DataUT.ObjectToIntTryParse(pIdActi));
                if (itemAdd == null)
                    listaActividadesCheck.Add(new OrdenTrabajoDetalleBE() { 
                        ID_ACTIVIDAD = DataUT.ObjectToIntTryParse(pIdActi), 
                        CODIGO_EQUIPO = pCodiEqui,
                        ITEM_ORDEN = actual.ITEM_ORDEN,
                        TIEMPO_ACTIVIDAD_TEXTO = actual.TIEMPO_ACTIVIDAD_TEXTO,
                        DESCRIPCION_ACTIVIDAD = actual.DESCRIPCION_ACTIVIDAD,
                        DESCRIPCION_TIPO_ACTIVIDAD = actual.DESCRIPCION_TIPO_ACTIVIDAD,
                        FECHA_PROGRAMADA = actual.FECHA_PROGRAMADA
                    });
            }

            Session[ConstantesUT.SESSION.OTActividadesCheck] = listaActividadesCheck;

            return new EmptyResult();
        }




        public ActionResult AsignacionResponsable()
        {
            OrdenTrabajoGeneraModel model = new OrdenTrabajoGeneraModel();

            model.listaEquiposPendientes = new List<OrdenTrabajoEquipoBE>();

            if (Session[ConstantesUT.SESSION.OTEquiposCheck] == null)
                Session[ConstantesUT.SESSION.OTEquiposCheck] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposCheck = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposCheck];

            if (Session[ConstantesUT.SESSION.OTActividadesCheck] == null)
                Session[ConstantesUT.SESSION.OTActividadesCheck] = new List<OrdenTrabajoDetalleBE>();
            List<OrdenTrabajoDetalleBE> listaActividadesCheck = (List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesCheck];

            foreach (var item in listaEquiposCheck)
            {
                OrdenTrabajoEquipoBE itemLista = new OrdenTrabajoEquipoBE();
                List<OrdenTrabajoDetalleBE> listaDetalle = listaActividadesCheck.FindAll(x => x.CODIGO_EQUIPO == item.CODIGO_EQUIPO);

                itemLista.CODIGO_EQUIPO = item.CODIGO_EQUIPO;
                itemLista.NOMBRE_EQUIPO = item.NOMBRE_EQUIPO;
                itemLista.CANTIDAD_ACTIVIDADES = listaDetalle.Count;
                itemLista.TIEMPO_ESTIMADO = DataUT.ObjectToString( listaDetalle.Sum(x=>x.TIEMPO_ACTIVIDAD)) ;
                itemLista.CODIGO_RESPONSABLE = item.CODIGO_RESPONSABLE;
                itemLista.NOMBRE_RESPONSABLE = item.NOMBRE_RESPONSABLE;
                itemLista.CANTIDAD_OT_ASIGNADAS = 0;
                itemLista.HORAS_OT_ASIGNADAS = 0;

                if (itemLista != null)
                {
                    model.listaEquiposPendientes.Add(itemLista);
                }
                
            }

            return PartialView(model);
        }

        public ActionResult ActividadesPendientesResumen(string pCodiEqui)
        {
            OrdenTrabajoGeneraModel model = new OrdenTrabajoGeneraModel();

            model.listaEquiposPendientes = new List<OrdenTrabajoEquipoBE>();

            if (Session[ConstantesUT.SESSION.OTActividadesCheck] == null)
                Session[ConstantesUT.SESSION.OTActividadesCheck] = new List<OrdenTrabajoDetalleBE>();
            List<OrdenTrabajoDetalleBE> listaActividadesCheck = (List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesCheck];
            model.listaActividadesPendientes = listaActividadesCheck.FindAll(x => x.CODIGO_EQUIPO == pCodiEqui);

            return PartialView(model);
        }

        public ActionResult ListarActividadResponsables(string pCodiEqui)
        {
            OrdenTrabajoEquipoModel model = new OrdenTrabajoEquipoModel();

            if (Session[ConstantesUT.SESSION.OTEquiposCheck] == null)
                Session[ConstantesUT.SESSION.OTEquiposCheck] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposCheck = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposCheck];

            model.entity = listaEquiposCheck.Find(x=>x.CODIGO_EQUIPO == pCodiEqui);

            return PartialView(model);
        }

        public ActionResult ActividadesEquipo(string pCodiEqui)
        {
            OrdenTrabajoEquipoModel model = new OrdenTrabajoEquipoModel();

            if (Session[ConstantesUT.SESSION.OTActividadesCheck] == null)
                Session[ConstantesUT.SESSION.OTActividadesCheck] = new List<OrdenTrabajoDetalleBE>();
            List<OrdenTrabajoDetalleBE> listaActividadesPendientes = ((List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesCheck]).FindAll(x => x.CODIGO_EQUIPO == pCodiEqui);

            List<string> listaTipoActividad = listaActividadesPendientes.Select(x => x.DESCRIPCION_TIPO_ACTIVIDAD).Distinct().ToList();

            model.listaEspecialidadEquipo = new List<EspecialidadBE>();
            foreach (var item in listaTipoActividad)
            {
                model.listaEspecialidadEquipo.Add(new EspecialidadBE() { DESCRIPCION_TIPO_ACTIVIDAD = item });
            }
            return PartialView(model);
        }

        public ActionResult EspecialidadesResponsable(string pCodiPers)
        {
            OrdenTrabajoEquipoModel model = new OrdenTrabajoEquipoModel();

            model.listaEspecialidadResponsable = especialidadBL.ObtenerEspecialidadesxEmp(DataUT.ObjectToIntTryParse(pCodiPers));

            return PartialView(model);
        }


        public EmptyResult AsignaResponsableEquipoCheck(string pCodiEqui, string pCodiPers, string pNombPers)
        {
            if (Session[ConstantesUT.SESSION.OTEquiposCheck] == null)
                Session[ConstantesUT.SESSION.OTEquiposCheck] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposCheck = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposCheck];

            OrdenTrabajoEquipoBE item = listaEquiposCheck.Find(x => x.CODIGO_EQUIPO == pCodiEqui);
            if(item != null)
            {
                item.CODIGO_RESPONSABLE = DataUT.ObjectToIntTryParse(pCodiPers);
                item.NOMBRE_RESPONSABLE = pNombPers;

                Session[ConstantesUT.SESSION.OTEquiposCheck] = listaEquiposCheck;
            }

            return new EmptyResult() ;
        }

        public EmptyResult GenerarConfirma()
        {

            List<OrdenTrabajoEquipoBE> listaEquiposPendientes = new List<OrdenTrabajoEquipoBE>();

            if (Session[ConstantesUT.SESSION.OTEquiposCheck] == null)
                Session[ConstantesUT.SESSION.OTEquiposCheck] = new List<OrdenTrabajoEquipoBE>();
            List<OrdenTrabajoEquipoBE> listaEquiposCheck = (List<OrdenTrabajoEquipoBE>)Session[ConstantesUT.SESSION.OTEquiposCheck];

            if (Session[ConstantesUT.SESSION.OTActividadesCheck] == null)
                Session[ConstantesUT.SESSION.OTActividadesCheck] = new List<OrdenTrabajoDetalleBE>();
            List<OrdenTrabajoDetalleBE> listaActividadesCheck = (List<OrdenTrabajoDetalleBE>)Session[ConstantesUT.SESSION.OTActividadesCheck];

            List<OrdenTrabajoBE> listaRegistrar = new List<OrdenTrabajoBE>();
            foreach (var item in listaEquiposCheck)
            {
                List<OrdenTrabajoDetalleBE> listaDetalle = listaActividadesCheck.FindAll(x => x.CODIGO_EQUIPO == item.CODIGO_EQUIPO);

                OrdenTrabajoBE nuevaOrden = new OrdenTrabajoBE();
                nuevaOrden.NUMERO_ORDEN = "";
                nuevaOrden.FECHA_EMISION_ORDEN = DateTime.Now.Date;
                nuevaOrden.FECHA_INICIO_ORDEN = null;
                nuevaOrden.FECHA_FIN_ORDEN = null;
                nuevaOrden.HORAS_TRABAJO_ORDEN = listaDetalle.Sum(x => x.TIEMPO_ACTIVIDAD)/60;
                nuevaOrden.OBSERVACIONES_ORDEN = "";
                nuevaOrden.CODIGO_EMPLEADO = item.CODIGO_RESPONSABLE;
                nuevaOrden.NUMERO_SOLICITUD = item.NUMERO_SOLICITUD;
                nuevaOrden.ESTADO_ORDEN = ConstantesUT.ESTADO_ORDEN.Abierta;

                nuevaOrden.listaActividades = new List<OrdenTrabajoDetalleBE>();

                foreach (var itemDetalle in listaDetalle)
                {
                    nuevaOrden.listaActividades.Add(itemDetalle);
                }

                listaRegistrar.Add(nuevaOrden);
            }
            ordenTrabajoBL.Registrar(listaRegistrar);

            return new EmptyResult();

        }
    }
}
