using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using System.Configuration;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.Entidades;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    public class SeguridadFachada
    {
        public IUsuarioLogica UsuarioLogica { get; set; }

        public SeguridadFachada()
        {
        }

        public Usuario ObtenerUsuario(string login)
        {
            return UsuarioLogica.ObtenerUsuario(login);
        }

    }
}