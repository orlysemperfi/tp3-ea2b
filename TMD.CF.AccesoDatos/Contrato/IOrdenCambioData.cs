using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.AccesoDatos.Contrato
{
    public interface IOrdenCambioData
    {
        List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase);
    }
}
