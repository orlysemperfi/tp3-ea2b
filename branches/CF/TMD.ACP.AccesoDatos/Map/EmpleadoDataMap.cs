﻿using System;
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
            //PENDIENTE DE REVISION
            objEmpleado.codigo = reader.GetInt("idEmpleado");            
            objEmpleado.nombre = reader.GetString("nombres");
            objEmpleado.apellidopaterno = reader.GetString("apepat");
            objEmpleado.apellidomaterno = reader.GetString("apemat");
            //objEmpleado.ObjArea.IdArea = reader.GetInt("idArea");
            //objEmpleado.ObjArea.NombreArea = reader.GetString("nombreArea");
            return objEmpleado;
        }
    }
}