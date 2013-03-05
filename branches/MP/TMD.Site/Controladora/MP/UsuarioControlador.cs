using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.LogicaNegocios;
using TMD.Entidades;

namespace TMD.MP.Controlador
{
    public class UsuarioControlador
    {
        public UsuarioLogica usuarioLogica = new UsuarioLogica();

        public UsuarioEntidad ObtenerUsuario(String nombreUsuario, String contraseniaUsuario)
        {
            return usuarioLogica.ObtenerUsuario(nombreUsuario, contraseniaUsuario);
        }

        public List<UsuarioEntidad> ObtenerListaEmpleadosTodas()
        {
            return usuarioLogica.ObtenerListaEmpleadosTodas();
        }
    }
}
