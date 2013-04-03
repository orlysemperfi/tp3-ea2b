using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.DBO.AccesoDatos_Atencion.Contrato
{

    public interface IProyectoData
    {

        List<Proyecto> listaProyectosUsuarioCliente(int codigoUsuarioCliente);
        List<Proyecto> listaProyectosUsuarioClienteServicio(int codigoCliente, int codigoUsuarioCliente, int codigoServicio);

    }
}
