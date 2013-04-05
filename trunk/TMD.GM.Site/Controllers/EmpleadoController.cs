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
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        private readonly IEmpleadosBL empleadoBL = new EmpleadosBL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buscar(string pFormProc)
        {
            EmpleadoBusquedaModel model = new EmpleadoBusquedaModel();
            model.formProcedencia = pFormProc;
            return PartialView(model);
        }

        public ActionResult BuscarEmpleados(string pDNI, string pNombre)
        {
            EmpleadoBusquedaModel model = new EmpleadoBusquedaModel();
            model.listaEmpleados = empleadoBL.BuscarEmpleados(new EmpleadosBE() { DNI_PERSONA = pDNI, NOMBRE_COMPLETO = pNombre });

            return PartialView("../Empleado/BuscarResultado", model);
        }

    }
}
