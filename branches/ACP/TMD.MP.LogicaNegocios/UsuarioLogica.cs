using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Interfaces;
using TMD.MP.AccesoDatos.Metodos;
using TMD.Entidades;

namespace TMD.MP.LogicaNegocios
{
    public class UsuarioLogica
    {
        public IUsuarioData iUsuario;
        
        #region "Select"

        public UsuarioEntidad ObtenerUsuario(String nombreUsuario, String contraseniaUsuario)
        {
            iUsuario = new UsuarioDataSql();
            UsuarioEntidad oUsuario = new UsuarioEntidad();
            oUsuario = iUsuario.ObtenerUsuario(nombreUsuario, contraseniaUsuario);
            return oUsuario;
        }
        public List<UsuarioEntidad> ObtenerListaEmpleadosTodas()
        {
            iUsuario = new UsuarioDataSql();
            List<UsuarioEntidad> oUsuarioColeccion = iUsuario.ObtenerListaEmpleadosTodas();
            return oUsuarioColeccion;
        }
        #endregion

    }
}
