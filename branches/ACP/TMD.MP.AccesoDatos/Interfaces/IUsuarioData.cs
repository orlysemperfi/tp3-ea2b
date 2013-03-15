using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
using System.Data.SqlClient;

namespace TMD.MP.AccesoDatos.Interfaces
{
    public interface IUsuarioData
    {
        #region "Select"

        UsuarioEntidad ObtenerUsuario(String nombreUsuario, String contraseniaUsuario);
        List<UsuarioEntidad> ObtenerListaEmpleadosTodas();
        #endregion
    }
}
