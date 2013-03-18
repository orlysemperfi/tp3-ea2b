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
    public class EquipoDA : IEquipoDA
    {
        public List<EquipoBE> BuscarEquipos()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            List<EquipoBE> listaResult = new List<EquipoBE>();
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();

                        var listaDatos = (from u in db.EQUIPO_COMPUTO where u.ESTADO_EQUIPO == ConstantesUT.ESTADO_GENERICO.Activo select u);

                        foreach (var itemEntidad in listaDatos)
                        {
                            listaResult.Add(new EquipoBE()
                            {
                                CODIGO_EQUIPO = itemEntidad.CODIGO_EQUIPO,
                                NOMBRE_EQUIPO = itemEntidad.NOMBRE_EQUIPO,
                                SERIE_EQUIPO = itemEntidad.SERIE_EQUIPO,
                                MARCA_EQUIPO = itemEntidad.MARCA_EQUIPO,
                                MODELO_EQUIPO = itemEntidad.MODELO_EQUIPO,
                                CARACTERISTICAS_EQUIPO = itemEntidad.CARACTERISTICAS_EQUIPO,
                                FECHA_COMPRA = itemEntidad.FECHA_COMPRA,
                                FECHA_EXPIRACION_GARANTIA = itemEntidad.FECHA_EXPIRACION_GARANTIA,
                                FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = itemEntidad.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO,
                                CODIGO_AREA = DataUT.ObjectToInt32(itemEntidad.CODIGO_AREA),
                                DESCRIPCION_AREA = (itemEntidad.AREA != null) ? itemEntidad.AREA.DESCRIPCION : string.Empty,
                                CODIGO_TIPO_EQUIPO = DataUT.ObjectToInt32(itemEntidad.CODIGO_TIPO_EQUIPO),
                                CODIGO_PLAN = itemEntidad.CODIGO_PLAN,
                                PROCEDENCIA_EQUIPO = itemEntidad.PROCEDENCIA_EQUIPO,
                                ESTADO_EQUIPO = (itemEntidad.ESTADO_EQUIPO == ConstantesUT.ESTADO_GENERICO.Activo),

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
