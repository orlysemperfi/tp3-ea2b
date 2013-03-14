using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using TMD.GM.Util;
using TMD.GM.AccesoDatos.Contrato;


namespace TMD.GM.AccesoDatos.Implementacion
{
    public class SolicitudDA: ISolicitudDA
    {
        public SolicitudBE ObtenerSolicitudNueva()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                SolicitudBE result = new SolicitudBE();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_SOLICITUD_NUEVA"))
                {
                    if (oReader.Read())
                    {
                        result = new SolicitudBE()
                        {
                            NUMERO_SOLICITUD = DataUT.ObjectToString(oReader["NUMERO_SOLICITUD"]),
                        };
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SolicitudBE> ObtenerSolicitudes()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SolicitudBE> result = new List<SolicitudBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_SOLICITUDES"))
                {
                    while (oReader.Read())
                    {
                        result.Add( new SolicitudBE()
                        {
                            NUMERO_SOLICITUD = DataUT.ObjectToString(oReader["NUMERO_SOLICITUD"]),
                            FECHA_SOLICITUD = DataUT.ObjectToDateTime(oReader["FECHA_SOLICITUD"]),
                            TIPO_SOLICITUD = DataUT.ObjectToInt32(oReader["TIPO_SOLICITUD"]),
                            DESCRIPCION_TIPO_SOLICITUD = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_SOLICITUD"]),
                            DOCUMENTO_REFERENCIA = DataUT.ObjectToString(oReader["DOCUMENTO_REFERENCIA"]),
                            FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(oReader["FECHA_INICIO_SOLICITUD"]),
                            FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(oReader["FECHA_FIN_SOLICITUD"]),
                            ESTADO_SOLICITUD = DataUT.ObjectToInt32(oReader["ESTADO_SOLICITUD"]),
                            DESCRIPCION_ESTADO_SOLICITUD = DataUT.ObjectToString(oReader["DESCRIPCION_ESTADO_SOLICITUD"]),
                            CODIGO_EQUIPO = DataUT.ObjectToInt32(oReader["CODIGO_EQUIPO"]),
                            NOMBRE_EQUIPO = DataUT.ObjectToString(oReader["NOMBRE_EQUIPO"]),
                            CODIGO_PLAN = DataUT.ObjectToString(oReader["CODIGO_PLAN"]),
                            NOMBRE_PLAN = DataUT.ObjectToString(oReader["NOMBRE_PLAN"]),
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
