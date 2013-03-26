using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;
using System.Data;
using System.Data.SqlClient;
using TMD.GM.Util;
using TMD.GM.AccesoDatos.Contrato;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TMD.GM.AccesoDatos.Implementacion
{
    public class InformesDA : IInformesDA
    {
        public List<InformesBE> ObtenerInformes(int numero, int codigo_empleado, string observacion, DateTime fecha)
        {
            try
            {
                List<InformesBE> result = new List<InformesBE>();

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@NUMERO", SqlDbType.Int);
                param[0].Value = numero;
                param[1] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[1].Value = codigo_empleado;
                param[2] = new SqlParameter("@OBSERVACION", SqlDbType.VarChar);
                param[2].Value = observacion;
                param[3] = new SqlParameter("@FECHA", SqlDbType.Date);
                param[3].Value = fecha;

                using (IDataReader oReader = SQLHelper.ExecuteReader(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "GET_INFORMES", param))
                {
                    while (oReader.Read())
                    {
                        result.Add(new InformesBE()
                        {
                            NUMERO_INFORME = DataUT.ObjectToInt32(oReader["NUMERO_INFORME"]),
                            FECHA_INFORME = DataUT.ObjectToDateTime(oReader["FECHA_INFORME"]),
                            CODIGO_EMPLEADO = DataUT.ObjectToInt32(oReader["CODIGO_EMPLEADO"]),
                            OBSERVACION_EMPLEADO = DataUT.ObjectToString(oReader["OBSERVACION_EMPLEADO"]),
                            NOMBRES = DataUT.ObjectToString(oReader["NOMBRES"]),
                            FECHA = DataUT.ObjectToString(oReader["FECHA"]),
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


        public DataTable ObtenerInformes_Orden(int codigo_empleado)
        {
            try
            {
                List<InformesBE> result = new List<InformesBE>();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[0].Value = codigo_empleado;

                DataTable oDT = SQLHelper.ExecuteDataset(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "GET_ORDEN_TRABAJO_INFORME", param).Tables[0];

                return oDT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_OrdenDetalle(string numero_orden)
        {
            try
            {
                List<InformesBE> result = new List<InformesBE>();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@NUMERO_ORDEN", SqlDbType.VarChar);
                param[0].Value = numero_orden;

                DataTable oDT = SQLHelper.ExecuteDataset(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "GET_ORDEN_TRABAJO_DETALLE", param).Tables[0];

                return oDT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerInformes_OrdenDetalle(string numero_orden, int numero_informe)
        {
            try
            {
                List<InformesBE> result = new List<InformesBE>();

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@NUMERO_ORDEN", SqlDbType.VarChar);
                param[0].Value = numero_orden;
                param[1] = new SqlParameter("@NUMERO_INFORME", SqlDbType.Int);
                param[1].Value = numero_informe;

                DataTable oDT = SQLHelper.ExecuteDataset(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "GET_ORDEN_TRABAJO_INFORME_DETALLE", param).Tables[0];

                return oDT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 Informes_Orden_Insertar(DateTime fecha, int empleado, string observacion)
        {
            int numero = 0;
            try
            {
                List<InformesBE> result = new List<InformesBE>();

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@FECHA_INFORME", SqlDbType.Date);
                param[0].Value = fecha;
                param[1] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[1].Value = empleado;
                param[2] = new SqlParameter("@OBSERVACION_EMPLEADO", SqlDbType.VarChar);
                param[2].Value = observacion;
                param[3] = new SqlParameter("@NUMERO", SqlDbType.Int);
                param[3].Direction= ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_INFORME_NUEVO", param);

                numero = Convert.ToInt32(param[3].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return numero;
        }

        public void Informes_Orden_Actualizar(int numero, DateTime fecha, int empleado, string observacion)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@NUMERO_INFORME", SqlDbType.Int);
                param[0].Value = numero;
                param[1] = new SqlParameter("@FECHA_INFORME", SqlDbType.Date);
                param[1].Value = fecha;
                param[2] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[2].Value = empleado;
                param[3] = new SqlParameter("@OBSERVACION_EMPLEADO", SqlDbType.VarChar);
                param[3].Value = observacion;


                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_INFORME_ACTUALIZAR", param);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Informes_Orden_Insertar_Detalle(int NUMERO_INFORME, int ITEM_INFORME, string NUMERO_ORDEN, int ITEM_ORDEN, string RESULTADO_ATENCION)
        {
            try
            {
                List<InformesBE> result = new List<InformesBE>();

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@NUMERO_INFORME", SqlDbType.Int);
                param[0].Value = NUMERO_INFORME;
                param[1] = new SqlParameter("@ITEM_INFORME", SqlDbType.Int);
                param[1].Value = ITEM_INFORME;
                param[2] = new SqlParameter("@NUMERO_ORDEN", SqlDbType.VarChar);
                param[2].Value = NUMERO_ORDEN;
                param[3] = new SqlParameter("@ITEM_ORDEN", SqlDbType.Int);
                param[3].Value = ITEM_ORDEN;
                param[4] = new SqlParameter("@RESULTADO_ATENCION", SqlDbType.VarChar);
                param[4].Value = RESULTADO_ATENCION;

                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_INFORME_DETALLE", param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Informes_Orden_Eliminar_Detalle(int NUMERO_INFORME)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@NUMERO_INFORME", SqlDbType.Int);
                param[0].Value = NUMERO_INFORME;

                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_INFORME_DETALLE_ELIMINAR", param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
