using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.MP.AccesoDatos.Contrato;
using TMD.MP.AccesoDatos.Implementacion;
using TMD.Entidades;
using TMD.MP.LogicaNegocios.Contrato;

namespace TMD.MP.LogicaNegocios.Implementacion
{
    public class UsuarioLogica : IUsuarioLogica
    {
        public IUsuarioData iUsuario;
        private static IUsuarioLogica instance;
        private UsuarioLogica() { }
        public static IUsuarioLogica getInstance()
        {
            if (instance == null) {
                instance = new UsuarioLogica();
            }
            return instance;
        }        
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
