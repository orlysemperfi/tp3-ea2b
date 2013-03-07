using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;
namespace TMD.MP.LogicaNegocios.Contrato
{
    public interface IUsuarioLogica
    {
        #region "Select"

        UsuarioEntidad ObtenerUsuario(String nombreUsuario, String contraseniaUsuario);
        List<UsuarioEntidad> ObtenerListaEmpleadosTodas();

        #endregion
    }
}
