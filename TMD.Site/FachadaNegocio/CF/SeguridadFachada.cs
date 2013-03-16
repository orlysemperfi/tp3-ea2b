using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using System.Configuration;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    class SeguridadFachada
    {
        private readonly IUsuarioLogica UsuarioLogica;

        public SeguridadFachada()
        {
            string baseDatos = ConfigurationManager.AppSettings["BaseDatos"];
            UsuarioLogica = new UsuarioLogica(new UsuarioData(baseDatos));
        }

        public Usuario ObtenerUsuario(string login)
        {
            return UsuarioLogica.ObtenerUsuario(login);
        }

    }
}