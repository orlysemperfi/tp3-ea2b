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

        public void RegistrarPlan(PlanBE planBE)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();
                        dbTran = db.Connection.BeginTransaction();

                        PLAN_MANTENIMIENTO_CABECERA entidad = new PLAN_MANTENIMIENTO_CABECERA();

                        entidad.CODIGO_PLAN = planBE.CODIGO_PLAN;
                        entidad.NOMBRE_PLAN = planBE.NOMBRE_PLAN;
                        entidad.ESTADO_PLAN = planBE.ESTADO_PLAN ? ConstantesUT.ESTADO_GENERICO.Activo : ConstantesUT.ESTADO_GENERICO.Inactivo;

                        #region Validacion
                        PLAN_MANTENIMIENTO_CABECERA entidadActual = (from u in db.PLAN_MANTENIMIENTO_CABECERA where u.CODIGO_PLAN == planBE.CODIGO_PLAN select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteCodigo);

                        entidadActual = (from u in db.PLAN_MANTENIMIENTO_CABECERA where u.NOMBRE_PLAN == planBE.NOMBRE_PLAN select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteNombre);
                        #endregion



                        db.PLAN_MANTENIMIENTO_CABECERA.AddObject(entidad);

                        foreach (var item in planBE.listaActividades)
                        {
                            PLAN_MANTENIMIENTO_DETALLE itemEntidad = new PLAN_MANTENIMIENTO_DETALLE();
                            itemEntidad.CODIGO_PLAN = entidad.CODIGO_PLAN;
                            itemEntidad.ITEM_ACTIVIDAD = item.ITEM_ACTIVIDAD;
                            itemEntidad.CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD;
                            itemEntidad.DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD;
                            itemEntidad.PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD;
                            itemEntidad.CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA;
                            itemEntidad.PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO;
                            itemEntidad.CODIGO_TIEMPO = item.CODIGO_TIEMPO;
                            itemEntidad.TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD;
                            itemEntidad.PROCEDIMIENTOS_PLAN = item.PROCEDIMIENTOS_PLAN;
                            itemEntidad.OBSERVACIONES_PLAN = item.OBSERVACIONES_PLAN;

                            db.PLAN_MANTENIMIENTO_DETALLE.AddObject(itemEntidad);
                        }

                        if (db.SaveChanges() < 1)
                        {
                            throw new Exception("Error en el proceso");
                        }
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPlan(PlanBE planBE)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();
                        dbTran = db.Connection.BeginTransaction();

                        PLAN_MANTENIMIENTO_CABECERA entidad = (from u in db.PLAN_MANTENIMIENTO_CABECERA where u.CODIGO_PLAN == planBE.CODIGO_PLAN select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        #region Validacion
                        PLAN_MANTENIMIENTO_CABECERA entidadActual = (from u in db.PLAN_MANTENIMIENTO_CABECERA
                                                                     where (u.NOMBRE_PLAN == planBE.NOMBRE_PLAN &&
                                                                         u.CODIGO_PLAN != planBE.CODIGO_PLAN)
                                                                     select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteNombre);
                        #endregion


                        entidad.NOMBRE_PLAN = planBE.NOMBRE_PLAN;
                        entidad.ESTADO_PLAN = planBE.ESTADO_PLAN ? ConstantesUT.ESTADO_GENERICO.Activo : ConstantesUT.ESTADO_GENERICO.Inactivo;

                        db.PLAN_MANTENIMIENTO_CABECERA.ApplyCurrentValues(entidad);

                        //Listamos las todas las actividades determinadas del cliente
                        List<PLAN_MANTENIMIENTO_DETALLE> listActCliente = new List<PLAN_MANTENIMIENTO_DETALLE>(); ;
                        foreach (var item in planBE.listaActividades)
                        {
                            listActCliente.Add(new PLAN_MANTENIMIENTO_DETALLE()
                            {
                                ID_ACTIVIDAD = item.ID_ACTIVIDAD,
                                CODIGO_PLAN = item.CODIGO_PLAN,
                                ITEM_ACTIVIDAD = item.ITEM_ACTIVIDAD,
                                CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD,
                                DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD,
                                PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD,
                                CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA,
                                PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO,
                                CODIGO_TIEMPO = item.CODIGO_TIEMPO,
                                TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD,
                                PROCEDIMIENTOS_PLAN = item.PROCEDIMIENTOS_PLAN,
                                OBSERVACIONES_PLAN = item.OBSERVACIONES_PLAN
                            });
                        }

                        //Listamos las pruebas asociadas a la clasificacion actalmente
                        List<PLAN_MANTENIMIENTO_DETALLE> listActServer = (from actividadesServer in db.PLAN_MANTENIMIENTO_DETALLE
                                                                          where actividadesServer.CODIGO_PLAN == planBE.CODIGO_PLAN
                                                                          select actividadesServer).ToList();

                        //Listamos las todas las actividades modificadas por el cliente
                        List<PLAN_MANTENIMIENTO_DETALLE> listActModifica = (from actividadesServer in listActServer
                                                                            join actividadesClient in listActCliente on actividadesServer.ID_ACTIVIDAD equals actividadesClient.ID_ACTIVIDAD
                                                                           where actividadesServer.CODIGO_PLAN == planBE.CODIGO_PLAN
                                                                           select actividadesServer).ToList();

                      

                        var cComparerExcept = new ComparerExcept<PLAN_MANTENIMIENTO_DETALLE>();

                        //Determinamos las nuevas actividades
                        List<PLAN_MANTENIMIENTO_DETALLE> listActNuevas = listActCliente.Except(listActServer, cComparerExcept).ToList();

                        //Determinamos las pruebas a desasociar
                        List<PLAN_MANTENIMIENTO_DETALLE> listActElimina = listActServer.Except(listActCliente, cComparerExcept).ToList();


                        //Actualizamos el detalle
                        foreach (var item in listActNuevas)
                        {
                            PLAN_MANTENIMIENTO_DETALLE itemDetalle = new PLAN_MANTENIMIENTO_DETALLE()
                            {
                                #region Datos
                                CODIGO_PLAN = item.CODIGO_PLAN,
                                ITEM_ACTIVIDAD = item.ITEM_ACTIVIDAD,
                                CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD,
                                DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD,
                                PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD,
                                CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA,
                                PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO,
                                CODIGO_TIEMPO = item.CODIGO_TIEMPO,
                                TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD,
                                PROCEDIMIENTOS_PLAN = item.PROCEDIMIENTOS_PLAN,
                                OBSERVACIONES_PLAN = item.OBSERVACIONES_PLAN,
                                #endregion
                            };
                            db.PLAN_MANTENIMIENTO_DETALLE.AddObject(itemDetalle);
                        }
                        foreach (var item in listActModifica)
                        {
                            PLAN_MANTENIMIENTO_DETALLE itemDetalle = (from u in db.PLAN_MANTENIMIENTO_DETALLE
                                                                      where (u.ID_ACTIVIDAD == item.ID_ACTIVIDAD)
                                                                      select u).FirstOrDefault();
                            #region Datos
                            itemDetalle.ITEM_ACTIVIDAD = item.ITEM_ACTIVIDAD;
                            itemDetalle.CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD;
                            itemDetalle.DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD;
                            itemDetalle.PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD;
                            itemDetalle.CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA;
                            itemDetalle.PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO;
                            itemDetalle.CODIGO_TIEMPO = item.CODIGO_TIEMPO;
                            itemDetalle.TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD;
                            itemDetalle.PROCEDIMIENTOS_PLAN = item.PROCEDIMIENTOS_PLAN;
                            itemDetalle.OBSERVACIONES_PLAN = item.OBSERVACIONES_PLAN;
                            #endregion
                            db.PLAN_MANTENIMIENTO_DETALLE.ApplyCurrentValues(itemDetalle);
                        }
                        foreach (var item in listActElimina)
                        {
                            PLAN_MANTENIMIENTO_DETALLE itemDetalle = (from u in db.PLAN_MANTENIMIENTO_DETALLE
                                                                      where (u.ID_ACTIVIDAD == item.ID_ACTIVIDAD)
                                                                      select u).FirstOrDefault();
                            db.PLAN_MANTENIMIENTO_DETALLE.DeleteObject(itemDetalle);
                        }

                        if (db.SaveChanges() < 1)
                        {
                            throw new Exception("Error en el proceso");
                        }
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarPlan(PlanBE planBE)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    DbTransaction dbTran = null;
                    try
                    {
                        if (db.Connection.State == System.Data.ConnectionState.Closed)
                            db.Connection.Open();
                        dbTran = db.Connection.BeginTransaction();

                        PLAN_MANTENIMIENTO_CABECERA entidad = (from u in db.PLAN_MANTENIMIENTO_CABECERA where u.CODIGO_PLAN == planBE.CODIGO_PLAN select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        #region Validacion
                     
                        #endregion
                        foreach (var item in entidad.PLAN_MANTENIMIENTO_DETALLE)
                        {
                            db.PLAN_MANTENIMIENTO_DETALLE.DeleteObject(item);

                        }
                        db.PLAN_MANTENIMIENTO_CABECERA.DeleteObject(entidad);

                        if (db.SaveChanges() < 1)
                        {
                            throw new Exception("Error en el proceso");
                        }
                        dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PlanBE VisualizarPlan(PlanBE planBE)
        {
            //Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    PLAN_MANTENIMIENTO_CABECERA entidad = (from u in db.PLAN_MANTENIMIENTO_CABECERA where u.CODIGO_PLAN == planBE.CODIGO_PLAN select u).FirstOrDefault(); ;

                    if (entidad == null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                    planBE.NOMBRE_PLAN = entidad.NOMBRE_PLAN;
                    planBE.ESTADO_PLAN = entidad.ESTADO_PLAN == ConstantesUT.ESTADO_GENERICO.Activo;

                    planBE.listaActividades = new List<PlanDetalleBE>();
                    foreach (var itemEntidad in entidad.PLAN_MANTENIMIENTO_DETALLE)
                    {
                        PlanDetalleBE item = new PlanDetalleBE();
                        item.GUID_ROW     = Guid.NewGuid();
                        item.ID_ACTIVIDAD = itemEntidad.ID_ACTIVIDAD;
                        item.CODIGO_PLAN = itemEntidad.CODIGO_PLAN;
                        item.ITEM_ACTIVIDAD = itemEntidad.ITEM_ACTIVIDAD;
                        item.CODIGO_TIPO_ACTIVIDAD = DataUT.ObjectToInt32(itemEntidad.CODIGO_TIPO_ACTIVIDAD);
                        item.DESCRIPCION_TIPO_ACTIVIDAD = itemEntidad.ACTIVIDAD_TIPO.DESCRIPCION_TIPO_ACTIVIDAD;
                        item.DESCRIPCION_ACTIVIDAD = itemEntidad.DESCRIPCION_ACTIVIDAD;
                        item.PRIORIDAD_ACTIVIDAD = DataUT.ObjectToInt32(itemEntidad.PRIORIDAD_ACTIVIDAD);
                        item.CODIGO_FRECUENCIA = DataUT.ObjectToInt32(itemEntidad.CODIGO_FRECUENCIA);
                        item.DESCRIPCION_FRECUENCIA = itemEntidad.FRECUENCIA.DESCRIPCION_FRECUENCIA;
                        item.PERSONAL_REQUERIDO = DataUT.ObjectToInt32(itemEntidad.PERSONAL_REQUERIDO);
                        item.CODIGO_TIEMPO = DataUT.ObjectToInt32(itemEntidad.CODIGO_TIEMPO);
                        item.DESCRIPCION_TIEMPO = itemEntidad.UNIDAD_TIEMPO.DESCRIPCION_TIEMPO;
                        item.TIEMPO_ACTIVIDAD = DataUT.ObjectToInt32(itemEntidad.TIEMPO_ACTIVIDAD);
                        item.PROCEDIMIENTOS_PLAN = itemEntidad.PROCEDIMIENTOS_PLAN;
                        item.OBSERVACIONES_PLAN = itemEntidad.OBSERVACIONES_PLAN;

                        planBE.listaActividades.Add(item);
                    }

                }
                return planBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
