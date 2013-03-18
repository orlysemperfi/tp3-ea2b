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
            Session["PlanActividadesKey"] = new List<PlanDetalleBE>();
            return PartialView(model);
        }
        public ActionResult PlanEdit(string pCodigo, string pNombre, int pEstado)
        {
            PlanModel model = new PlanModel();
            model.codigoPlan = pCodigo;
            model.nombrePlan = pNombre;
            model.activo = (pEstado == ConstantesUT.ESTADO_GENERICO.Activo);

            model.listaDetalle = new List<PlanDetalleBE>();
            return PartialView(model);
        }

        public ActionResult PlanRegistrar(string pCodigo, string pNombre, string pEstado)
        {
            PlanModel model = new PlanModel();
            model.codigoPlan = pCodigo;
            model.nombrePlan = pNombre;
            //model.activo = (pEstado == ConstantesUT.ESTADO_GENERICO.Activo);
            PlanBE entity = new PlanBE();
            entity.CODIGO_PLAN = pCodigo;
            entity.NOMBRE_PLAN = pNombre;
            entity.ESTADO_PLAN = (pEstado == "true");
            entity.listaActividades = new List<PlanDetalleBE>();

            if (Session["PlanActividadesKey"] == null)
                Session["PlanActividadesKey"] = new List<PlanDetalleBE>();
            entity.listaActividades = (List<PlanDetalleBE>)Session["PlanActividadesKey"]; 

            planBL.RegistrarPlan(entity);

            return PartialView("PlanNuevo", model);
        }
        public ActionResult PlanActualizar(string pCodigo, string pNombre, string pEstado)
        {
            PlanModel model = new PlanModel();
            model.codigoPlan = pCodigo;
            model.nombrePlan = pNombre;
            //model.activo = (pEstado == ConstantesUT.ESTADO_GENERICO.Activo);
            PlanBE entity = new PlanBE();
            entity.CODIGO_PLAN = pCodigo;
            entity.NOMBRE_PLAN = pNombre;
            entity.ESTADO_PLAN = (pEstado == "true");

            if (Session["PlanActividadesKey"] == null)
                Session["PlanActividadesKey"] = new List<PlanDetalleBE>();
            entity.listaActividades = (List<PlanDetalleBE>)Session["PlanActividadesKey"]; 

            planBL.ActualizarPlan(entity);

            return PartialView("PlanEdit", model);
        }
        public ActionResult PlanActividad(string pIdActividad, string pCodigo, int pItem, int pTipoActi, string pDesc, int pPrio, int pCodiFrec, int pPersRequ, int pCodiTiem, int pTiemActi, string pProc, string pObse)
        {
            PlanActividadModel model = new PlanActividadModel();
            model.entity = new PlanDetalleBE() {ID_ACTIVIDAD = DataUT.ObjectToInt32(pIdActividad), CODIGO_PLAN = pCodigo, ITEM_ACTIVIDAD = pItem, CODIGO_TIPO_ACTIVIDAD = pTipoActi,
            DESCRIPCION_ACTIVIDAD = pDesc, PRIORIDAD_ACTIVIDAD = pPrio, CODIGO_FRECUENCIA = pCodiFrec, PERSONAL_REQUERIDO = pPersRequ,
            CODIGO_TIEMPO = pCodiTiem, TIEMPO_ACTIVIDAD = pTiemActi, PROCEDIMIENTOS_PLAN = pProc, OBSERVACIONES_PLAN = pObse};

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataCF = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();
            listaDataPR = comunBL.ListarPrioridad();
            listaDataCF = comunBL.ListarFrecuencia();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();
            model.listaFR = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_TIPO_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_TIEMPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.PRIORIDAD_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataCF)
            {
                model.listaFR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_FRECUENCIA.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }

            return PartialView(model);
        }

        public EmptyResult PlanActividadAceptar(string pIdActividad, string pCodigo, int pItem, int pTipoActi, string pDesc, int pPrio, int pCodiFrec, int pPersRequ, int pCodiTiem, int pTiemActi, string pProc, string pObse)
        {
            PlanDetalleBE entity = new PlanDetalleBE()
            {
                ID_ACTIVIDAD = DataUT.ObjectToInt32(pIdActividad),
                CODIGO_PLAN = pCodigo,
                ITEM_ACTIVIDAD = pItem,
                CODIGO_TIPO_ACTIVIDAD = pTipoActi,
                DESCRIPCION_ACTIVIDAD = pDesc,
                PRIORIDAD_ACTIVIDAD = pPrio,
                CODIGO_FRECUENCIA = pCodiFrec,
                PERSONAL_REQUERIDO = pPersRequ,
                CODIGO_TIEMPO = pCodiTiem,
                TIEMPO_ACTIVIDAD = pTiemActi,
                PROCEDIMIENTOS_PLAN = pProc,
                OBSERVACIONES_PLAN = pObse
            };

            if (Session["PlanActividadesKey"] == null)
                Session["PlanActividadesKey"] = new List<PlanDetalleBE>();

            List<PlanDetalleBE> lista = new List<PlanDetalleBE>();
            lista = (List<PlanDetalleBE>)Session["PlanActividadesKey"];

            //Verificamos la existencia del registro

            PlanDetalleBE item = lista.Find(x=>x.ID_ACTIVIDAD == entity.ID_ACTIVIDAD);
            if (item != null)
            {
                item.ID_ACTIVIDAD = entity.ID_ACTIVIDAD;
                item.CODIGO_PLAN = entity.CODIGO_PLAN;
                item.ITEM_ACTIVIDAD = entity.ITEM_ACTIVIDAD;
                item.CODIGO_TIPO_ACTIVIDAD = entity.CODIGO_TIPO_ACTIVIDAD;
                item.DESCRIPCION_ACTIVIDAD = entity.DESCRIPCION_ACTIVIDAD;
                item.PRIORIDAD_ACTIVIDAD = entity.PRIORIDAD_ACTIVIDAD;
                item.CODIGO_FRECUENCIA = entity.CODIGO_FRECUENCIA;
                item.PERSONAL_REQUERIDO = entity.PERSONAL_REQUERIDO;
                item.CODIGO_TIEMPO = entity.CODIGO_TIEMPO;
                item.TIEMPO_ACTIVIDAD = entity.TIEMPO_ACTIVIDAD;
                item.PROCEDIMIENTOS_PLAN = entity.PROCEDIMIENTOS_PLAN;
                item.OBSERVACIONES_PLAN = entity.OBSERVACIONES_PLAN;
            }
            else
            {
                lista.Add(entity);
            }
            Session["PlanActividadesKey"] = lista;

            return new EmptyResult();  

        }
        public EmptyResult PlanEliminar(string pCodigo)
        {
            try
            {
                planBL.EliminarPlan(new PlanBE() { CODIGO_PLAN = pCodigo });
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro");
            }

            return new EmptyResult();

        }
        public ActionResult PlanActividades(string pCodigo)
        {
            PlanModel model = new PlanModel();
            PlanBE entity = new PlanBE() { CODIGO_PLAN = pCodigo };
            entity = planBL.VisualizarPlan(entity);
            model.codigoPlan = pCodigo;

            model.listaDetalle = entity.listaActividades;

            Session["PlanActividadesKey"] = entity.listaActividades;

            return PartialView(model);
        }

        public ActionResult PlanActividades_Actualizar(string pCodigo)
        {
            PlanModel model = new PlanModel();
            
            model.codigoPlan = pCodigo;

            if (Session["PlanActividadesKey"] == null)
                Session["PlanActividadesKey"] = new List<PlanDetalleBE>();

            model.listaDetalle = (List<PlanDetalleBE>)Session["PlanActividadesKey"];

            return PartialView("PlanActividades", model);
        }
        //public ActionResult PlanDetalle()
        //{
        //    PlanActividadModel model = new PlanActividadModel();

        //    List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
        //    List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();

        //    listaDataTA = comunBL.ListarTipoActividad();
        //    listaDataTU = comunBL.ListarTiempoUniMed();

        //    model.listaTA = new List<SelectListItem>();
        //    model.listaTU = new List<SelectListItem>();

        //    foreach (var item in listaDataTA)
        //    {
        //        model.listaTA.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
        //    }
        //    foreach (var item in listaDataTU)
        //    {
        //        model.listaTU.Add(new SelectListItem() { Selected = false, Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
        //    }

        //    return View(model);
        //}

        public ActionResult PlanActividadNuevo(string pCodigo)
        {
             PlanActividadModel model = new PlanActividadModel();
            model.entity = new PlanDetalleBE() { CODIGO_PLAN = pCodigo, ITEM_ACTIVIDAD = 0, CODIGO_TIPO_ACTIVIDAD = 0,
            DESCRIPCION_ACTIVIDAD = "", PRIORIDAD_ACTIVIDAD = 0, CODIGO_FRECUENCIA = 0, PERSONAL_REQUERIDO = 0,
            CODIGO_TIEMPO = 0, TIEMPO_ACTIVIDAD = 0, PROCEDIMIENTOS_PLAN = "", OBSERVACIONES_PLAN = "", ID_ACTIVIDAD = 0};

            List<SelectListItemBE> listaDataTA = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataTU = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataCF = new List<SelectListItemBE>();

            listaDataTA = comunBL.ListarTipoActividad();
            listaDataTU = comunBL.ListarTiempoUniMed();
            listaDataPR = comunBL.ListarPrioridad();
            listaDataCF = comunBL.ListarFrecuencia();

            model.listaTA = new List<SelectListItem>();
            model.listaTU = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();
            model.listaFR = new List<SelectListItem>();

            foreach (var item in listaDataTA)
            {
                model.listaTA.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_TIPO_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataTU)
            {
                model.listaTU.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_TIEMPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.PRIORIDAD_ACTIVIDAD.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataCF)
            {
                model.listaFR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_FRECUENCIA.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }

            return PartialView("PlanActividad" , model);
        }

        public ActionResult Planes()
        {
            PlanConsultaModel model = new PlanConsultaModel();


            model.listaData = planBL.ListarPlanManteTodos();

            return PartialView( model);
        }
    }
}
