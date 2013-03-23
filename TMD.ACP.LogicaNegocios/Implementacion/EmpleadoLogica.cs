using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class EmpleadoLogica : IEmpleadoLogica
    {
        private readonly IEmpleadoData _objData;

        public EmpleadoLogica()
        {
            _objData = new EmpleadoData("TMD");
        }

        public List<EmpleadoEntidad> ListarEmpleados()
        {
            return _objData.ListarEmpleados();
        }

        public EmpleadoEntidad ObtenerEmpleado(int idEmpleado)
        {
            return _objData.ObtenerEmpleado(idEmpleado);
        }

        public List<EmpleadoEntidad> ListarEmpleadosPorArea(int idArea)
        {
            return _objData.ListarEmpleadosPorArea(idArea);
        }

        public List<EmpleadoEntidad> ListarEmpleadosAuditores()
        {
            List<EmpleadoEntidad> lstBusqueda = _objData.ListarEmpleados();
            List<EmpleadoEntidad> lstEmpleados = new List<EmpleadoEntidad>();

            foreach (EmpleadoEntidad eEmpleado in lstBusqueda)
            {
                if (eEmpleado.ObjArea.codigo == 4)
                {
                    lstEmpleados.Add(eEmpleado);
                }
            }
            return lstEmpleados;
        }
    }
}
