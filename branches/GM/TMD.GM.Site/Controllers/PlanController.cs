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
            model.opcion = ConstantesUT.OPCION.Nuevo;
            //PlanBE oPlanBE = planBL.ObtenerObtenerPlanNuevo();
            //model.codigoPlan = oPlanBE.CODIGO_PLAN;

            model.activo = true;
            model.listaDetalle = new List<PlanDetalleBE>();
            //model.listaDetalle.Add(new PlanDetalleBE());

            Session[ConstantesUT.SESSION.PlanActividades] = null;
            return PartialView("Plan",model);
        }
        public ActionResult PlanEdit(string pCodigo, string pNombre, int pEstado)
        {
            PlanModel model = new PlanModel();
            model.opcion = ConstantesUT.OPCION.Editar;
            model.codigoPlan = pCodigo;
            model.nombrePlan = pNombre;
            model.activo = (pEstado == ConstantesUT.ESTADO_GENERICO.Activo);

            model.listaDetalle = new List<PlanDetalleBE>();

            Session[ConstantesUT.SESSION.PlanActividades] = null;

            return PartialView("Plan",model);
        }

        public ActionResult PlanRegistrar(string pCodigo, string pNombre, string pEstado)
        {
            try
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
                if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                    Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();
                entity.listaActividades = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades];
                if (entity.listaActividades.Count == 0)
                    throw new Exception("Debe agregar como mínimo una actividad");

                planBL.RegistrarPlan(entity);

                //return PartialView("PlanNuevo", model);
                return new EmptyResult();
            }
            catch(Exception ex)
            {
                Response.StatusCode = 500;
                return PartialView("../Error/MensajeError", new ErrorModel()
                {
                    Titulo = "Error",
                    Mensaje = ex.Message,
                });
            }
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

            if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();
            entity.listaActividades = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades]; 

            planBL.ActualizarPlan(entity);

            //return PartialView("PlanEdit", model);
            return new EmptyResult();
        }
        public ActionResult PlanActividad_Editar(string pGuidActividad)
        {
            if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();

            List<PlanDetalleBE> lista = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades];
            PlanActividadModel model = new PlanActividadModel();

            model.entity =  lista.Find(x => x.GUID_ROW.ToString() == pGuidActividad);

            Session[ConstantesUT.SESSION.PlanActividadActual] = model.entity;

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

            return PartialView("PlanActividad", model);
        }

        public EmptyResult PlanActividadAceptar(int pItem, int pTipoActi, string pTipoActiDes, string pDesc, int pPrio, int pCodiFrec, string pCodiFrecDes, int pPersRequ, int pCodiTiem, string pCodiTiemDes, int pTiemActi, string pProc, string pObse)
        {
            PlanDetalleBE entity = (PlanDetalleBE )Session[ConstantesUT.SESSION.PlanActividadActual] ;

            entity.ITEM_ACTIVIDAD = pItem;
            entity.CODIGO_TIPO_ACTIVIDAD = pTipoActi;
            entity.DESCRIPCION_TIPO_ACTIVIDAD = pTipoActiDes;
            entity.DESCRIPCION_ACTIVIDAD = pDesc;
            entity.PRIORIDAD_ACTIVIDAD = pPrio;
            entity.CODIGO_FRECUENCIA = pCodiFrec;
            entity.DESCRIPCION_FRECUENCIA = pCodiFrecDes;
            entity.PERSONAL_REQUERIDO = 1;//pPersRequ
            entity.CODIGO_TIEMPO = pCodiTiem;
            entity.DESCRIPCION_TIEMPO = pCodiTiemDes;
            entity.TIEMPO_ACTIVIDAD = pTiemActi;
            entity.PROCEDIMIENTOS_PLAN = pProc;
            entity.OBSERVACIONES_PLAN = pObse;

            if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();

            List<PlanDetalleBE> lista = new List<PlanDetalleBE>();
            lista = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades];

            //Verificamos la existencia del registro

            PlanDetalleBE item = lista.Find(x => x.GUID_ROW == entity.GUID_ROW);
            if (item != null)
            {
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
            Session[ConstantesUT.SESSION.PlanActividades] = lista;

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

            Session[ConstantesUT.SESSION.PlanActividades] = entity.listaActividades;

            return PartialView(model);
        }

        public ActionResult PlanActividades_Actualizar(string pCodigo)
        {
            PlanModel model = new PlanModel();
            
            model.codigoPlan = pCodigo;

            if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();

            model.listaDetalle = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades];

            return PartialView("PlanActividades", model);
        }

        public ActionResult PlanActividades_Eliminar(string pGuidActividad)
        {
            PlanModel model = new PlanModel();

            if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();

            List<PlanDetalleBE> listaTmp = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades];
            listaTmp.Remove(listaTmp.Find(x => x.GUID_ROW.ToString() == pGuidActividad));
            model.listaDetalle = new List<PlanDetalleBE>();
            int index = 0;
            foreach (var item in listaTmp)
            {
                index++;
                item.ITEM_ACTIVIDAD = index;
                model.listaDetalle.Add(item);
            }
            Session[ConstantesUT.SESSION.PlanActividades] = model.listaDetalle ;

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
            if (Session[ConstantesUT.SESSION.PlanActividades] == null)
                Session[ConstantesUT.SESSION.PlanActividades] = new List<PlanDetalleBE>();
            List<PlanDetalleBE> lista = (List<PlanDetalleBE>)Session[ConstantesUT.SESSION.PlanActividades];

            PlanActividadModel model = new PlanActividadModel();
            model.entity = new PlanDetalleBE()
            {
                GUID_ROW = Guid.NewGuid(),
                CODIGO_PLAN = pCodigo,
                ITEM_ACTIVIDAD = lista.Count + 1,
                CODIGO_TIPO_ACTIVIDAD = 0,
                DESCRIPCION_ACTIVIDAD = "", PRIORIDAD_ACTIVIDAD = 0, CODIGO_FRECUENCIA = 0, PERSONAL_REQUERIDO = 0,
                CODIGO_TIEMPO = 0, TIEMPO_ACTIVIDAD = 0, PROCEDIMIENTOS_PLAN = "", OBSERVACIONES_PLAN = "", ID_ACTIVIDAD = 0
            };

            Session[ConstantesUT.SESSION.PlanActividadActual] = model.entity;

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

        public ActionResult Planes(string pCodigo, string pNombre)
        {
            PlanConsultaModel model = new PlanConsultaModel();
            PlanBE planBE = new PlanBE() { CODIGO_PLAN = pCodigo, NOMBRE_PLAN = pNombre };

            model.listaData = planBL.ListarPlanManteTodos(planBE);

            

            return PartialView( model);
        }
    }
}
