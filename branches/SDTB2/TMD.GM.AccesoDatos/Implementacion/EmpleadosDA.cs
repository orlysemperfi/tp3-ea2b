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
using System.Data.Common;

namespace TMD.GM.AccesoDatos.Implementacion
{
    public class EmpleadosDA : IEmpleadosDA
    {
        public List<EmpleadosBE> ObtenerEmpleados(string nombres)
        {
            try
            {
                List<EmpleadosBE> result = new List<EmpleadosBE>();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@NOMBRES", SqlDbType.VarChar);
                param[0].Value = nombres;

                using (IDataReader oReader = SQLHelper.ExecuteReader(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "GET_EMPLEADOS", param))
                {
                    while (oReader.Read())
                    {
                        result.Add(new EmpleadosBE()
                        {
                            NOMBRES = DataUT.ObjectToString(oReader["NOMBRES"]),
                            APELLIDO_PATERNO = DataUT.ObjectToString(oReader["APELLIDO_PATERNO"]),
                            APELLIDO_MATERNO = DataUT.ObjectToString(oReader["APELLIDO_MATERNO"]),
                            DNI_PERSONA = DataUT.ObjectToString(oReader["DNI_PERSONA"]),
                            CODIGO_EMPLEADO = DataUT.ObjectToInt32(oReader["CODIGO_EMPLEADO"]),
                            CODIGO_AREA = DataUT.ObjectToInt32(oReader["CODIGO_AREA"]),
                            CODIGO_PUESTO = DataUT.ObjectToInt32(oReader["CODIGO_PUESTO"]),
                            DESCRIPCION_AREA = DataUT.ObjectToString(oReader["DESCRIPCION_AREA"]),
                            DESCRIPCION_PUESTO = DataUT.ObjectToString(oReader["DESCRIPCION_PUESTO"]),
                            NOMBRE_COMPLETO = DataUT.ObjectToString(oReader["NOMBRE_COMPLETO"]),
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

        public List<EmpleadosBE> BuscarEmpleados(EmpleadosBE empleadosBE)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            List<EmpleadosBE> listaResult = new List<EmpleadosBE>();
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();

                        var listaDatos = (from e in db.EMPLEADO
                                          join p in db.PERSONA on e.CODIGO_EMPLEADO equals p.CODIGO_PERSONA
                                          join pu in db.PUESTO on e.CODIGO_PUESTO equals pu.CODIGO_PUESTO
                                          where (p.NRO_DOCUMENTO.Contains(empleadosBE.DNI_PERSONA) || empleadosBE.DNI_PERSONA == "")
                                              &&
                                              ((p.NOMBRE_PERSONA + p.APELLIDO_MATERNO + p.APELLIDO_PATERNO).Contains(empleadosBE.NOMBRE_COMPLETO) || empleadosBE.NOMBRE_COMPLETO == "")
                                          select new { CODIGO_EMPLEADO = e.CODIGO_EMPLEADO,
                                                       DNI_PERSONA = p.NRO_DOCUMENTO, 
                                              NOMBRE_COMPLETO = p.NOMBRE_PERSONA + " " + p.APELLIDO_PATERNO + " " + p.APELLIDO_MATERNO,
                                              DESCRIPCION_PUESTO = pu.DESCRIPCION
                                          });

                        foreach (var itemEntidad in listaDatos)
                        {
                            listaResult.Add(new EmpleadosBE()
                            {
                                CODIGO_EMPLEADO = itemEntidad.CODIGO_EMPLEADO,
                                DNI_PERSONA = itemEntidad.DNI_PERSONA,
                                NOMBRE_COMPLETO = itemEntidad.NOMBRE_COMPLETO,
                                DESCRIPCION_PUESTO = itemEntidad.DESCRIPCION_PUESTO,
                            });
                        }
                        return listaResult;

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Registrar_Actividad(int empleado, int actividad)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[0].Value = empleado;
                param[1] = new SqlParameter("@CODIGO_TIPO_ACTIVIDAD", SqlDbType.Int);
                param[1].Value = actividad;
                param[2] = new SqlParameter("@EXISTE", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;

                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_EMPLEADO_ACTIVIDAD", param);

                return Convert.ToInt32(param[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar_Actividad_Empleado(int empleado, int actividad)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[0].Value = empleado;
                param[1] = new SqlParameter("@CODIGO_TIPO_ACTIVIDAD", SqlDbType.Int);
                param[1].Value = actividad;

                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_EMPLEADO_ACTIVIDAD_ELIMINAR", param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Especialidad_Actividad_Empleado(int empleado, int actividad, bool especialidad)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@CODIGO_EMPLEADO", SqlDbType.Int);
                param[0].Value = empleado;
                param[1] = new SqlParameter("@CODIGO_TIPO_ACTIVIDAD", SqlDbType.Int);
                param[1].Value = actividad;
                param[2] = new SqlParameter("@ESPECIALIDAD", SqlDbType.Int);
                param[2].Value = especialidad ? 1 : 0;

                SQLHelper.ExecuteNonQuery(BaseDA.GetSQLConnectionString(), CommandType.StoredProcedure, "SET_EMPLEADO_ACTIVIDAD_ESPECIALIDAD", param);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
