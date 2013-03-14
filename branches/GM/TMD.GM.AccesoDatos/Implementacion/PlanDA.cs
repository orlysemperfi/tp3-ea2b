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
    public class PlanDA : IPlanDA
    {
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
                            CODIGO_PLAN = DataUT.ObjectToString(oReader["NUMERO_PLAN"]),
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
        public List<PlanBE> ListarPlanManteTodos()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<PlanBE> result = new List<PlanBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_PLAN_MANTENIMIENTO_TODOS"))
                {
                    while (oReader.Read())
                    {
                        result.Add(new PlanBE()
                        {
                            CODIGO_PLAN = DataUT.ObjectToString(oReader["CODIGO_PLAN"]),
                            NOMBRE_PLAN = DataUT.ObjectToString(oReader["NOMBRE_PLAN"]),
                            ESTADO_PLAN = DataUT.ObjectToBoolean(oReader["ESTADO_PLAN"]),
                            
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
