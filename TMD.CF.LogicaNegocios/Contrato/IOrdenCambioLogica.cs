using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    public interface IOrdenCambioLogica
    {
        List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase);
    }
}
