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
        public ActionResult EquipoConsulta(string pFormProc)
        {
            EquipoBusquedaModel model = new EquipoBusquedaModel();
            model.formProcedencia = pFormProc;
            return PartialView(model);
        }

        public ActionResult Equipos(string pCodiEqui, string pNombEqui, string pSeriEqui,string pFormProc)
        {
            EquipoBusquedaModel model = new EquipoBusquedaModel();
            EquipoBE equipoBE = new EquipoBE()
            {
                CODIGO_EQUIPO = pCodiEqui,
                NOMBRE_EQUIPO = pNombEqui,
                SERIE_EQUIPO = pSeriEqui
            };
            model.listaEquipos = equipoBL.BuscarEquipos(equipoBE);
            model.formProcedencia = pFormProc;
            return PartialView( model);
        }
        public ActionResult EquiposTodos(string pCodiEqui, string pNombEqui, string pSeriEqui)
        {
            EquipoBusquedaModel model = new EquipoBusquedaModel();
            EquipoBE equipoBE = new EquipoBE()
            {
                CODIGO_EQUIPO = pCodiEqui,
                NOMBRE_EQUIPO = pNombEqui,
                SERIE_EQUIPO = pSeriEqui
            };
            model.listaEquipos = equipoBL.ListarEquiposTodos(equipoBE);

            return PartialView(model);
        }
        public ActionResult Nuevo()
        {
            EquipoModel model = new EquipoModel();
            model.nuevo = true;
            model.entity = new EquipoBE()
            {
                CODIGO_EQUIPO = "",
                NOMBRE_EQUIPO = "",
                SERIE_EQUIPO = "",
                MARCA_EQUIPO = "",
                MODELO_EQUIPO = "",
                CARACTERISTICAS_EQUIPO = "",
                FECHA_COMPRA = DateTime.Now.Date,
                FECHA_EXPIRACION_GARANTIA = null,
                FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = null,
                CODIGO_AREA = 0,
                CODIGO_TIPO_EQUIPO = 0,
                CODIGO_PLAN = "",
                PROCEDENCIA_EQUIPO = ConstantesUT.PROCEDENCIA.Propio,
                ESTADO_EQUIPO = true
            };

            List<SelectListItemBE> listaDataTE = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataAR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();

            listaDataTE = comunBL.ListarTipoEquipo();
            listaDataAR = comunBL.ListarAreas();
            listaDataPM = planBL.ListarPlanMante();
            listaDataPR = comunBL.ListarProcedencia();

            model.listaTE = new List<SelectListItem>();
            model.listaAR = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();


            foreach (var item in listaDataTE)
            {
                model.listaTE.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_TIPO_EQUIPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataAR)
            {
                model.listaAR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_AREA.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_PLAN), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.PROCEDENCIA_EQUIPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }

            return PartialView("Equipo",model);
        }
        public ActionResult Editar(string pCodiEqui)
        {
            EquipoModel model = new EquipoModel();
            model.nuevo = false;
            model.entity = equipoBL.Visualizar(new EquipoBE() { CODIGO_EQUIPO = pCodiEqui });

            List<SelectListItemBE> listaDataTE = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataAR = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPM = new List<SelectListItemBE>();
            List<SelectListItemBE> listaDataPR = new List<SelectListItemBE>();

            listaDataTE = comunBL.ListarTipoEquipo();
            listaDataAR = comunBL.ListarAreas();
            listaDataPM = planBL.ListarPlanMante();
            listaDataPR = comunBL.ListarProcedencia();

            model.listaTE = new List<SelectListItem>();
            model.listaAR = new List<SelectListItem>();
            model.listaPM = new List<SelectListItem>();
            model.listaPR = new List<SelectListItem>();


            foreach (var item in listaDataTE)
            {
                model.listaTE.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_TIPO_EQUIPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataAR)
            {
                model.listaAR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_AREA.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPM)
            {
                model.listaPM.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.CODIGO_PLAN), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            foreach (var item in listaDataPR)
            {
                model.listaPR.Add(new SelectListItem() { Selected = (item.CODIGO == model.entity.PROCEDENCIA_EQUIPO.ToString()), Value = item.CODIGO.ToString(), Text = item.DESCRIPCION });
            }
            return PartialView("Equipo", model);
        }

        [HttpPost]
        [AllowAnonymous]
        public EmptyResult Registrar(string pCodiEqui, string pNombEqui,string pSerie,string pMarca, string pModel, string pCarac, string pFechaComp, string pFechaExpi, string pFechaUltiMant,
            string pCodiArea, string pCodiTipo, string pCodiPlan, string pProced, string pEstaEqui)
        {
            if (ModelState.IsValid)
            {
                EquipoBE entity = new EquipoBE()
                {
                    CODIGO_EQUIPO = pCodiEqui,
                    NOMBRE_EQUIPO = pNombEqui,
                    SERIE_EQUIPO = pSerie,
                    MARCA_EQUIPO = pMarca,
                    MODELO_EQUIPO = pModel,
                    CARACTERISTICAS_EQUIPO = pCarac,
                    FECHA_COMPRA = DataUT.ObjectToDateNullTimeTryParse(pFechaComp),
                    FECHA_EXPIRACION_GARANTIA = DataUT.ObjectToDateNullTimeTryParse(pFechaExpi),
                    FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = DataUT.ObjectToDateNullTimeTryParse(pFechaUltiMant),
                    CODIGO_AREA = DataUT.ObjectToInt32(pCodiArea),
                    CODIGO_TIPO_EQUIPO = DataUT.ObjectToInt32(pCodiTipo),
                    CODIGO_PLAN = pCodiPlan,
                    PROCEDENCIA_EQUIPO = DataUT.ObjectToInt32(pProced),
                    ESTADO_EQUIPO = (pEstaEqui == "true")
                };
                equipoBL.Registrar(entity);
            }
            return new EmptyResult();
        }

        public EmptyResult Actualizar(string pCodiEqui, string pNombEqui, string pSerie, string pMarca, string pModel, string pCarac, string pFechaComp, string pFechaExpi, string pFechaUltiMant,
            string pCodiArea, string pCodiTipo, string pCodiPlan, string pProced, string pEstaEqui)
        {
            EquipoBE entity = new EquipoBE()
            {
                CODIGO_EQUIPO = pCodiEqui,
                NOMBRE_EQUIPO = pNombEqui,
                SERIE_EQUIPO = pSerie,
                MARCA_EQUIPO = pMarca,
                MODELO_EQUIPO = pModel,
                CARACTERISTICAS_EQUIPO = pCarac,
                FECHA_COMPRA = DataUT.ObjectToDateNullTimeTryParse(pFechaComp),
                FECHA_EXPIRACION_GARANTIA = DataUT.ObjectToDateNullTimeTryParse(pFechaExpi),
                FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = DataUT.ObjectToDateNullTimeTryParse(pFechaUltiMant),
                CODIGO_AREA = DataUT.ObjectToInt32(pCodiArea),
                CODIGO_TIPO_EQUIPO = DataUT.ObjectToInt32(pCodiTipo),
                CODIGO_PLAN = pCodiPlan,
                PROCEDENCIA_EQUIPO = DataUT.ObjectToInt32(pProced),
                ESTADO_EQUIPO = (pEstaEqui == "true")
            };
            equipoBL.Actualizar(entity);

            return new EmptyResult();
        }

        public EmptyResult Eliminar(string pCodigo)
        {

            equipoBL.Eliminar(new EquipoBE() { CODIGO_EQUIPO = pCodigo });

            return new EmptyResult();
        }
    }
}
