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
        private readonly IUsuarioLogica usuarioLogica;

        public OrdenCambioControladora()
        {
            string baseDatos = ConfigurationManager.AppSettings["BaseDatos"];

            ordenCambioLogica = new OrdenCambioLogica(new OrdenCambioData(baseDatos));
            usuarioLogica = new UsuarioLogica(new UsuarioData(baseDatos));
        }

        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return ordenCambioLogica.ListarPorProyectoLBase(codigoProyecto, codigoLineaBase);
        }

        public void Agregar(OrdenCambio ordenCambio)
        {
            ordenCambioLogica.Agregar(ordenCambio);
        }

        public List<Usuario> ListaPorRol(String rol)
        {
            List<Usuario> lista = usuarioLogica.ListaPorRol(rol);
            lista.Insert(0, new Usuario { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }
    }
}