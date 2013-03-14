using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using TMD.GM.Entidades;
using TMD.GM.Util;

namespace TMD.GM.AccesoDatos
{
    public class ComunDA 
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
                        result.Add( new SelectListItemBE()
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
        public List<SelectListItemBE> ListarPlanMante()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SelectListItemBE> result = new List<SelectListItemBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_PLAN_MANTENIMIENTO"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new SelectListItemBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["CODIGO_PLAN"]),
                            DESCRIPCION = DataUT.ObjectToString(oReader["NOMBRE_PLAN"]),
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

        public PlanBE ObtenerPlanNuevo()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                PlanBE result = new PlanBE();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_PLAN_NUEVO"))
                {
                    if (oReader.Read())
                    {
                        result = new PlanBE()
                        {
                            CODIGO = DataUT.ObjectToString(oReader["NUMERO_PLAN"]),
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
    }
}
