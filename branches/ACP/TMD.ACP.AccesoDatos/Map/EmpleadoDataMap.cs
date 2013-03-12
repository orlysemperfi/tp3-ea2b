using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Util;


namespace TMD.ACP.AccesoDatos.Map
{
    static class EmpleadoDataMap
    {
        public static EmpleadoEntidad SelectEmpleado(IDataReader reader)
        {
            EmpleadoEntidad objEmpleado = new EmpleadoEntidad();
            objEmpleado.codigo = reader.GetInt("CODIGO_EMPLEADO");            
            objEmpleado.nombre = reader.GetString("nombres");
            objEmpleado.apellidopaterno = reader.GetString("apepat");
            objEmpleado.apellidomaterno = reader.GetString("apemat");
            return objEmpleado;
        }
    }
}
