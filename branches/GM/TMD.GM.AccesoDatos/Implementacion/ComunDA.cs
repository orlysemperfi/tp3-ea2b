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
    }
}
