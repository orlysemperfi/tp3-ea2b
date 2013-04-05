using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    public interface IUsuarioProyectoLogica
    {
        List<UsuarioProyecto> ListaUsuarioProyecto(int idUsuario);
    }
}
