using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.GM.Entidades;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using TMD.GM.Util;
using TMD.GM.AccesoDatos.Contrato;
using System.Data.Common;

namespace TMD.GM.AccesoDatos.Implementacion
{
    public class ComunDA : IComunDA
    {
        public List<SelectListItemBE> ListarTipoMante()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_SOLICITUD_TIPO"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO_TIPO_SOLICITUD"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_SOLICITUD"]),
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

        public List<SelectListItemBE> ListarEstadoSolicitud()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_SOLICITUD_ESTADO"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO_ESTADO_SOLICITUD"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["DESCRIPCION_ESTADO_SOLICITUD"]),
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
        public List<SelectListItemBE> ListarEstadoOT()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            List<SelectListItemBE> listaResult = new List<SelectListItemBE>();
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();

                        var listaDatos = (from u in db.ORDEN_TRABAJO_ESTADO select u);

                        foreach (var itemEntidad in listaDatos)
                        {
                            listaResult.Add(new SelectListItemBE()
                            {
                                CODIGO = itemEntidad.CODIGO_ESTADO_OT.ToString(),
                                DESCRIPCION = itemEntidad.DESCRIPCION_ESTADO_OT,
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
        public List<SelectListItemBE> ListarTipoEquipo()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            List<SelectListItemBE> listaResult = new List<SelectListItemBE>();
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();

                        var listaDatos = (from u in db.EQUIPO_TIPO select u);

                        foreach (var itemEntidad in listaDatos)
                        {
                            listaResult.Add(new SelectListItemBE()
                            {
                                CODIGO = itemEntidad.CODIGO_TIPO_EQUIPO.ToString(),
                                DESCRIPCION = itemEntidad.DESCRIPCION_TIPO_EQUIPO,
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
        public List<SelectListItemBE> ListarAreas()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            List<SelectListItemBE> listaResult = new List<SelectListItemBE>();
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();

                        var listaDatos = (from u in db.AREA select u);

                        foreach (var itemEntidad in listaDatos)
                        {
                            listaResult.Add(new SelectListItemBE()
                            {
                                CODIGO = itemEntidad.CODIGO_AREA.ToString(),
                                DESCRIPCION = itemEntidad.DESCRIPCION,
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
        public List<SelectListItemBE> ListarTipoActividad()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_ACTIVIDAD_TIPO"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["DESCRIPCION"]),
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
        public List<SelectListItemBE> ListarTiempoUniMed()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_TIEMPO_UNIDAD"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["DESCRIPCION"]),
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

        public List<SelectListItemBE> ListarPrioridad()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_PRIORIDAD"))
                {
                    //result.Add(new SelectListItemBE()
                    //{
                    //    CODIGO = "0",
                    //    DESCRIPCION = "[Todos]",
                    //});
                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["DESCRIPCION"]),
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
        public List<SelectListItemBE> ListarFrecuencia()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_FRECUENCIA"))
                {
                    //result.Add(new SelectListItemBE()
                    //{
                    //    CODIGO = "0",
                    //    DESCRIPCION = "[Todos]",
                    //});

                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["DESCRIPCION"]),
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

        public List<SelectListItemBE> ListarProcedencia()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            List<SelectListItemBE> listaResult = new List<SelectListItemBE>();
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();

                        var listaDatos = (from u in db.PROCEDENCIA select u);

                        foreach (var itemEntidad in listaDatos)
                        {
                            listaResult.Add(new SelectListItemBE()
                            {
                                CODIGO = itemEntidad.CODIGO_PROCEDENCIA.ToString(),
                                DESCRIPCION = itemEntidad.DESCRIPCION_PROCEDENCIA,
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
    }
}
