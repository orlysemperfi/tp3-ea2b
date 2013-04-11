using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.SD.AccesoDatos_Atencion.Util;
using TMD.Entidades;


namespace TMD.SD.AccesoDatos_Atencion.Map
{

    static class ProyectoServicioSedeDataMap
    {
        public static ProyectoServicioSede Select(IDataReader reader)
        {
            return new ProyectoServicioSede
            {
                Codigo_Servicio = reader.GetInt("CODIGO_SERVICIO"),
                Nombre_Servicio = reader.GetString("NOMBRE_SERVICIO"),
                Descripcion_Servicio = reader.GetString("DESCRIPCION_SERVICIO"),

                Codigo_Proyecto = reader.GetInt("CODIGO_PROYECTO"),
                //Nombre_Proyecto = reader.GetString("NOMBRE_PROYECTO"),
                Codigo_Sede = reader.GetInt("CODIGO_SEDE"),
                //Nombre_Sede = reader.GetString("NOMBRE_SEDE"),
                Codigo_SLA = reader.GetInt("CODIGO_SLA"),
                Nombre_SLA = reader.GetString("NOMBRE_SLA"),
                Codigo_Detalle_SLA = reader.GetInt("CODIGO_DETALLE_SLA"),
                Urgencia = reader.GetSmallInt("URGENCIA_DETALLE_SLA"),
                Impacto = reader.GetSmallInt("IMPACTO_DETALLE_SLA"),
                Prioridad = reader.GetSmallInt("URGENCIA_DETALLE_SLA") * reader.GetSmallInt("IMPACTO_DETALLE_SLA"),
                Complejidad = reader.GetSmallInt("COMPLEJIDAD_DETALLE_SLA"),
                Tiempo_Respuesta = Convert.ToInt32(reader.GetBigInt("TIEMPO_RESPUESTA_DETALLE_SLA")),
                Tiempo_Cierre = Convert.ToInt32(reader.GetBigInt("TIEMPO_CIERRE_DETALLE_SLA"))


            };
        }
    }
}