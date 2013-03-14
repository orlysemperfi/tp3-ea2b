using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IEmpleadoLogica
    {
        List<EmpleadoEntidad> ListarEmpleados();
        EmpleadoEntidad ObtenerEmpleado(int idEmpleado);
        List<EmpleadoEntidad> ListarEmpleadosPorArea(int idArea);
        List<EmpleadoEntidad> ListarEmpleadosAuditores();
    }
}
