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
    public class OrdenTrabajoDA : IOrdenTrabajoDA
    {

        public List<OrdenTrabajoBE> ListarOrdenTrabajo(DateTime? pd_Fini, DateTime? pd_Ffin)
        {
            try
            {
                List<OrdenTrabajoBE> result = new List<OrdenTrabajoBE>();
                List<ORDEN_TRABAJO_CONSULTA> lst = BaseDA.GetEntityDatabase.GET_ORDEN_TRABAJO(pd_Fini, pd_Ffin).ToList();
                foreach (ORDEN_TRABAJO_CONSULTA item in lst)
                {
                     result.Add(new OrdenTrabajoBE()
                        {
                            NUMERO_SOLICITUD = DataUT.ObjectToString(item.NUMERO_SOLICITUD),
                            NOMBRE_EQUIPO = DataUT.ObjectToString(item.NOMBRE_EQUIPO),
                            MARCA_EQUIPO = DataUT.ObjectToString(item.MARCA_EQUIPO),
                            DESC_AREA = DataUT.ObjectToString(item.DESC_AREA),
                            FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(item.FECHA_INICIO_SOLICITUD),
                            FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(item.FECHA_FIN_SOLICITUD),
                            ESTADO_SOLICITUD = DataUT.ObjectToInt(item.ESTADO_SOLICITUD),
                        });
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
