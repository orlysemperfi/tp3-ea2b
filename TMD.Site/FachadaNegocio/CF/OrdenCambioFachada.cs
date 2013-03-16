using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;
using System.Configuration;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    class OrdenCambioControladora
    {
        private readonly IOrdenCambioLogica ordenCambioLogica;

        public OrdenCambioControladora()
        {
            string baseDatos = ConfigurationManager.AppSettings["BaseDatos"];

            ordenCambioLogica = new OrdenCambioLogica(new OrdenCambioData(baseDatos));
        }

        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return ordenCambioLogica.ListarPorProyectoLBase(codigoProyecto, codigoLineaBase);
        }
    }
}