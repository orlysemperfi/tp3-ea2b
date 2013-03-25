using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using TMD.DBO.AccesoDatos_Atencion.Util;
using TMD.Entidades;

namespace TMD.DBO.AccesoDatos_Atencion.Map
{
    static class TicketDataMap
    {
        public static Ticket Select(IDataReader reader)
        {

            return new Ticket
                {
                    Codigo_Ticket  = reader.GetInt("CODIGO_TICKET"),
                    Codigo_Cliente = reader.GetInt("CODIGO_CLIENTE"),
                    Codigo_Usuario = reader.GetInt("CODIGO_USUARIO_CLIENTE"),
                    Descripcion_Corta = reader.GetString("DESCRIPCION_CORTA_TICKET"),
                    Descripcion_Larga  = reader.GetString("DESCRIPCION_TICKET"),
                    Tipo_Registro_Ticket = reader.GetString("TIPO_REGISTRO_TICKET"),
                    Tipo_Atencion_Ticket=reader.GetString("TIPO_ATENCION_TICKET"),
                    Estado_Ticket  = reader.GetString("ESTADO_TICKET"),
                    Nombre_UsuarioCliente = reader.GetString("NOMBRE_USUARIO_CLIENTE"),
                    Empleado_Propietario = reader.GetString("Empleado_Propietario"),
                    Empleado_Asignado = reader.GetString("Empleado_Asignado"),
                    Empleado_Ult_Modif = reader.GetString("Empleado_Ult_Modif"),
                    Nombre_Servicio = reader.GetString("NOMBRE_SERVICIO"),
                    Prioridad_Ticket = reader.GetInt("PRIORIDAD_TICKET"),
                    Fecha_Registro=reader.GetDateTime ("FECHA_REGISTRO_TICKET"),
                    Fecha_Expiracion = reader.GetDateTime("FECHA_EXPIRACION_TICKET"),
                    Codigo_Equipo=reader.GetInt("CODIGO_EQUIPO"),
                    Solucion_Ticket  = reader.GetString("SOLUCION_TICKET"),
                    Codigo_Proyecto =reader.GetInt("CODIGO_PROYECTO"),
                    Codigo_Servicio = reader.GetInt("CODIGO_SERVICIO"),
                    Codigo_Sede = reader.GetInt("CODIGO_SEDE"),
                    Ultimo_Seguimiento = reader.GetBigInt("ULTIMA_SECUENCIA_SEGUIMIENTO_TICKET"),
                    Ultimo_Adicional = reader.GetBigInt("ULTIMA_SECUENCIA_ADICIONAL_TICKET")
                    
                };
        }
    }
}
