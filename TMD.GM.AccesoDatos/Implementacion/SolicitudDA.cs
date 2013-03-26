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
        public List<SolicitudBE> ObtenerSolicitudes(SolicitudFiltroBE filtro)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<SolicitudBE> result = new List<SolicitudBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_SOLICITUDES", filtro.NUMERO_SOLICITUD, filtro.FECHA_INICIO_SOLICITUD, filtro.FECHA_FIN_SOLICITUD,
                    filtro.ESTADO_SOLICITUD, filtro.TIPO_SOLICITUD, filtro.DOCUMENTO_REFERENCIA, filtro.CODIGO_EQUIPO, filtro.CODIGO_PLAN))
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


        public void RegistrarSolicitud(SolicitudBE solicitudBE)
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

                        SOLICITUD_CABECERA entidad = new SOLICITUD_CABECERA();

                        entidad.NUMERO_SOLICITUD = solicitudBE.NUMERO_SOLICITUD;
                        entidad.FECHA_SOLICITUD = solicitudBE.FECHA_SOLICITUD;
                        entidad.TIPO_SOLICITUD = solicitudBE.TIPO_SOLICITUD;
                        entidad.DOCUMENTO_REFERENCIA = solicitudBE.DOCUMENTO_REFERENCIA;
                        entidad.FECHA_INICIO_SOLICITUD = solicitudBE.FECHA_INICIO_SOLICITUD;
                        entidad.FECHA_FIN_SOLICITUD = solicitudBE.FECHA_FIN_SOLICITUD;
                        entidad.ESTADO_SOLICITUD = solicitudBE.ESTADO_SOLICITUD;
                        entidad.CODIGO_EQUIPO = solicitudBE.CODIGO_EQUIPO;
                        entidad.CODIGO_PLAN = solicitudBE.CODIGO_PLAN;

                        

                        db.SOLICITUD_CABECERA.AddObject(entidad);

                        //foreach (var item in solicitudBE.listaActividades)
                        //{
                        //    SOLICITUD_DETALLE itemEntidad = new SOLICITUD_DETALLE();
                        //    itemEntidad.NUMERO_SOLICITUD = entidad.NUMERO_SOLICITUD;
                        //    itemEntidad.ITEM_SOLICITUD = item.ITEM_SOLICITUD;
                        //    itemEntidad.CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD;
                        //    itemEntidad.DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD;
                        //    itemEntidad.PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD;
                        //    itemEntidad.CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA;
                        //    itemEntidad.PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO;
                        //    itemEntidad.CODIGO_TIEMPO = item.CODIGO_TIEMPO;
                        //    itemEntidad.TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD;
                        //    itemEntidad.FECHA_PROGRAMACION = item.FECHA_PROGRAMACION;
                        //    itemEntidad.ORDEN_TRABAJO = item.ORDEN_TRABAJO;

                        //    db.SOLICITUD_DETALLE.AddObject(itemEntidad);
                        //}

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

        public void ActualizarSolicitud(SolicitudBE solicitudBE)
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

                        SOLICITUD_CABECERA entidad = (from u in db.SOLICITUD_CABECERA where u.NUMERO_SOLICITUD == solicitudBE.NUMERO_SOLICITUD select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        entidad.FECHA_SOLICITUD = solicitudBE.FECHA_SOLICITUD;
                        entidad.TIPO_SOLICITUD = solicitudBE.TIPO_SOLICITUD;
                        entidad.DOCUMENTO_REFERENCIA = solicitudBE.DOCUMENTO_REFERENCIA;
                        entidad.FECHA_INICIO_SOLICITUD = solicitudBE.FECHA_INICIO_SOLICITUD;
                        entidad.FECHA_FIN_SOLICITUD = solicitudBE.FECHA_FIN_SOLICITUD;
                        entidad.ESTADO_SOLICITUD = solicitudBE.ESTADO_SOLICITUD;
                        entidad.CODIGO_EQUIPO = solicitudBE.CODIGO_EQUIPO;
                        entidad.CODIGO_PLAN = solicitudBE.CODIGO_PLAN;

                        db.SOLICITUD_CABECERA.ApplyCurrentValues(entidad);

                        #region
                        //Listamos las todas las actividades determinadas del cliente
                        List<SOLICITUD_DETALLE> listActCliente = new List<SOLICITUD_DETALLE>(); ;
                        foreach (var item in solicitudBE.listaActividades)
                        {
                            listActCliente.Add(new SOLICITUD_DETALLE()
                            {
                                ID_ACTIVIDAD = item.ID_ACTIVIDAD,
                                NUMERO_SOLICITUD = item.NUMERO_SOLICITUD,
                                ITEM_SOLICITUD = item.ITEM_SOLICITUD,
                                CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD,
                                DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD,
                                PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD,
                                CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA,
                                PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO,
                                CODIGO_TIEMPO = item.CODIGO_TIEMPO,
                                TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD,
                                FECHA_PROGRAMACION = item.FECHA_PROGRAMACION,
                                ORDEN_TRABAJO = item.ORDEN_TRABAJO
                            });
                        }

                        //Listamos las pruebas asociadas a la clasificacion actalmente
                        List<SOLICITUD_DETALLE> listActServer = (from actividadesServer in db.SOLICITUD_DETALLE
                                                                 where actividadesServer.NUMERO_SOLICITUD == solicitudBE.NUMERO_SOLICITUD
                                                                          select actividadesServer).ToList();

                        //Listamos las todas las actividades modificadas por el cliente
                        List<SOLICITUD_DETALLE> listActModifica = (from actividadesServer in listActServer
                                                                            join actividadesClient in listActCliente on actividadesServer.ID_ACTIVIDAD equals actividadesClient.ID_ACTIVIDAD
                                                                   where actividadesServer.NUMERO_SOLICITUD == solicitudBE.NUMERO_SOLICITUD
                                                                            select actividadesServer).ToList();



                        var cComparerExcept = new ComparerExcept<SOLICITUD_DETALLE>();

                        //Determinamos las nuevas actividades
                        List<SOLICITUD_DETALLE> listActNuevas = listActCliente.Except(listActServer, cComparerExcept).ToList();

                        //Determinamos las pruebas a desasociar
                        List<SOLICITUD_DETALLE> listActElimina = listActServer.Except(listActCliente, cComparerExcept).ToList();


                        //Actualizamos el detalle
                        foreach (var item in listActNuevas)
                        {
                            SOLICITUD_DETALLE itemDetalle = new SOLICITUD_DETALLE()
                            {
                                #region Datos
                                NUMERO_SOLICITUD = item.NUMERO_SOLICITUD,
                                ITEM_SOLICITUD = item.ITEM_SOLICITUD,
                                CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD,
                                DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD,
                                PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD,
                                CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA,
                                PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO,
                                CODIGO_TIEMPO = item.CODIGO_TIEMPO,
                                TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD,
                                FECHA_PROGRAMACION = item.FECHA_PROGRAMACION,
                                ORDEN_TRABAJO = item.ORDEN_TRABAJO,
                                #endregion
                            };
                            db.SOLICITUD_DETALLE.AddObject(itemDetalle);
                        }
                        foreach (var item in listActModifica)
                        {
                            SOLICITUD_DETALLE itemDetalle = (from u in db.SOLICITUD_DETALLE
                                                                      where (u.ID_ACTIVIDAD == item.ID_ACTIVIDAD)
                                                                      select u).FirstOrDefault();
                            #region Datos
                            itemDetalle.ITEM_SOLICITUD = item.ITEM_SOLICITUD;
                            itemDetalle.CODIGO_TIPO_ACTIVIDAD = item.CODIGO_TIPO_ACTIVIDAD;
                            itemDetalle.DESCRIPCION_ACTIVIDAD = item.DESCRIPCION_ACTIVIDAD;
                            itemDetalle.PRIORIDAD_ACTIVIDAD = item.PRIORIDAD_ACTIVIDAD;
                            itemDetalle.CODIGO_FRECUENCIA = item.CODIGO_FRECUENCIA;
                            itemDetalle.PERSONAL_REQUERIDO = item.PERSONAL_REQUERIDO;
                            itemDetalle.CODIGO_TIEMPO = item.CODIGO_TIEMPO;
                            itemDetalle.TIEMPO_ACTIVIDAD = item.TIEMPO_ACTIVIDAD;
                            itemDetalle.FECHA_PROGRAMACION = item.FECHA_PROGRAMACION;
                            itemDetalle.ORDEN_TRABAJO = item.ORDEN_TRABAJO;
                            #endregion
                            db.SOLICITUD_DETALLE.ApplyCurrentValues(itemDetalle);
                        }
                        foreach (var item in listActElimina)
                        {
                            SOLICITUD_DETALLE itemDetalle = (from u in db.SOLICITUD_DETALLE
                                                                      where (u.ID_ACTIVIDAD == item.ID_ACTIVIDAD)
                                                                      select u).FirstOrDefault();
                            db.SOLICITUD_DETALLE.DeleteObject(itemDetalle);
                        }
                        #endregion

                       
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

        public void EliminarSolicitud(SolicitudBE solicitudBE)
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

                        SOLICITUD_CABECERA entidad = (from u in db.SOLICITUD_CABECERA where u.NUMERO_SOLICITUD == solicitudBE.NUMERO_SOLICITUD select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);
                        
                        #region Validacion

                        #endregion

                        //db.SOLICITUD_CABECERA.DeleteObject(entidad);
                        entidad.ESTADO_SOLICITUD = ConstantesUT.ESTADO_SOLICITUD.Anulado;
                        db.SOLICITUD_CABECERA.ApplyCurrentValues(entidad);

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

        public SolicitudBE VisualizarSolicitud(SolicitudBE SolicitudBE)
        {
            //Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    SOLICITUD_CABECERA entidad = (from u in db.SOLICITUD_CABECERA where u.NUMERO_SOLICITUD == SolicitudBE.NUMERO_SOLICITUD select u).FirstOrDefault(); ;

                    if (entidad == null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                    SolicitudBE.FECHA_SOLICITUD = DataUT.ObjectToDateTime( entidad.FECHA_SOLICITUD);
                    SolicitudBE.TIPO_SOLICITUD = DataUT.ObjectToInt32(entidad.TIPO_SOLICITUD);
                    SolicitudBE.DOCUMENTO_REFERENCIA = entidad.DOCUMENTO_REFERENCIA;
                    SolicitudBE.FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(entidad.FECHA_INICIO_SOLICITUD);
                    SolicitudBE.FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(entidad.FECHA_FIN_SOLICITUD);
                    SolicitudBE.ESTADO_SOLICITUD = DataUT.ObjectToInt32(entidad.ESTADO_SOLICITUD);
                    SolicitudBE.CODIGO_EQUIPO = DataUT.ObjectToInt32(entidad.CODIGO_EQUIPO);
                    SolicitudBE.CODIGO_PLAN = entidad.CODIGO_PLAN;

                    SolicitudBE.listaActividades = new List<SolicitudDetalleBE>();
                    foreach (var itemEntidad in entidad.SOLICITUD_DETALLE)
                    {
                        SolicitudDetalleBE item = new SolicitudDetalleBE();
                        item.GUID_ROW = Guid.NewGuid();
                        item.ID_ACTIVIDAD = itemEntidad.ID_ACTIVIDAD;
                        item.NUMERO_SOLICITUD = itemEntidad.NUMERO_SOLICITUD;
                        item.ITEM_SOLICITUD = itemEntidad.ITEM_SOLICITUD;
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
                        item.FECHA_PROGRAMACION = DataUT.ObjectToDateTime( itemEntidad.FECHA_PROGRAMACION);
                        item.ORDEN_TRABAJO = itemEntidad.ORDEN_TRABAJO;

                        SolicitudBE.listaActividades.Add(item);
                    }

                }
                return SolicitudBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SolicitudDetalleBE> GenerarCronograma(SolicitudBE solicitudBE)
        {
            try
            {
                List<SolicitudDetalleBE> listaResult = new List<SolicitudDetalleBE>();

                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    SOLICITUD_CABECERA entidad = (from u in db.SOLICITUD_CABECERA where u.NUMERO_SOLICITUD == solicitudBE.NUMERO_SOLICITUD select u).FirstOrDefault();

                    #region Validaciones

                    if (entidad == null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                    //Verificamos que el equipo y su plan no existan en otra solicitud

                    SOLICITUD_CABECERA entidadValida = (from u in db.SOLICITUD_CABECERA
                                                       where u.NUMERO_SOLICITUD != solicitudBE.NUMERO_SOLICITUD 
                               && u.CODIGO_EQUIPO == solicitudBE.CODIGO_EQUIPO && u.CODIGO_PLAN == solicitudBE.CODIGO_PLAN
                               && u.FECHA_INICIO_SOLICITUD <= solicitudBE.FECHA_INICIO_SOLICITUD && u.FECHA_FIN_SOLICITUD >= solicitudBE.FECHA_FIN_SOLICITUD
                               select u).FirstOrDefault();

                    if (entidadValida != null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.Solicitud_EquiPlanProg);

                    #endregion

                    var detallePlan = (from u in db.PLAN_MANTENIMIENTO_DETALLE where u.CODIGO_PLAN == entidad.CODIGO_PLAN select u);

                    foreach (var itemEntidad in detallePlan)
                    {
                        DateTime fecha = solicitudBE.FECHA_INICIO_SOLICITUD;
                        
                        while (fecha <= solicitudBE.FECHA_FIN_SOLICITUD)
                        {
                            #region Datos
                            SolicitudDetalleBE item = new SolicitudDetalleBE();
                            item.ID_ACTIVIDAD = 0;
                            item.NUMERO_SOLICITUD = solicitudBE.NUMERO_SOLICITUD;
                            item.ITEM_SOLICITUD = itemEntidad.ITEM_ACTIVIDAD;
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
                            item.FECHA_PROGRAMACION = fecha;
                            item.ORDEN_TRABAJO = "";
                            #endregion
                            listaResult.Add(item);

                            switch (itemEntidad.FRECUENCIA.CODIGO_FRECUENCIA)
                            {
                                #region Incrementamos los dias segun la frecuencia
                                case ConstantesUT.FRECUENCIA.Diario:
                                    fecha = fecha.AddDays(1);
                                    break;
                                case ConstantesUT.FRECUENCIA.Semanal:
                                    fecha = fecha.AddDays(7);
                                    break;
                                case ConstantesUT.FRECUENCIA.Quincenal:
                                    fecha = fecha.AddDays(14);
                                    break;
                                case ConstantesUT.FRECUENCIA.Mensual:
                                    fecha = fecha.AddMonths(1);
                                    break;
                                case ConstantesUT.FRECUENCIA.Trimestral:
                                    fecha = fecha.AddMonths(3);
                                    break;
                                case ConstantesUT.FRECUENCIA.Semestral:
                                    fecha = fecha.AddMonths(6);
                                    break;
                                case ConstantesUT.FRECUENCIA.Anual:
                                    fecha = fecha.AddYears(1);
                                    break;
                                default:
                                    break;
                                #endregion
                            }
                           
                        }
                        
                    }

                }
                return listaResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CronogramaBE ActividadesCronograma(DateTime fecha)
        {
            try
            {
                CronogramaBE result = new CronogramaBE();
                result.listaActividades = new List<SolicitudDetalleBE>();
                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    #region Actividades
                    var listaActividadData =  (from u in db.SOLICITUD_DETALLE where u.FECHA_PROGRAMACION == fecha select u).ToList() ;

                    foreach (var itemEntidad in listaActividadData)
                    {
                        SolicitudDetalleBE item = new SolicitudDetalleBE();
                        item.ID_ACTIVIDAD = itemEntidad.ID_ACTIVIDAD;
                        item.NUMERO_SOLICITUD = itemEntidad.NUMERO_SOLICITUD;
                        item.ITEM_SOLICITUD = itemEntidad.ITEM_SOLICITUD;
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
                        item.FECHA_PROGRAMACION = DataUT.ObjectToDateTime(itemEntidad.FECHA_PROGRAMACION);
                        item.ORDEN_TRABAJO = itemEntidad.ORDEN_TRABAJO;

                        result.listaActividades.Add(item);
                    }
                    #endregion

                    #region PERSONAL_DISPONIBLE

                    List<ACTIVIDAD_TIPO> listaActividades = (from actividades in result.listaActividades
                                                  select  new ACTIVIDAD_TIPO { CODIGO_TIPO_ACTIVIDAD = actividades.CODIGO_TIPO_ACTIVIDAD }).Distinct().ToList();

                    int numPersonalDisp = (from emplActi in db.EMPLEADO_ACTIVIDAD
                                          join tipoActi in db.ACTIVIDAD_TIPO on emplActi.CODIGO_TIPO_ACTIVIDAD equals tipoActi.CODIGO_TIPO_ACTIVIDAD
                                          join emp in db.EMPLEADO on emplActi.CODIGO_EMPLEADO equals emp.CODIGO_EMPLEADO
                                          select emp).Count();

                    result.PERSONAL_DISPONIBLE = numPersonalDisp;
                    #endregion

                    #region HORAS_LABORABLES
                    CALENDARIO_LABORABLE calendario = (from cal in db.CALENDARIO_LABORABLE
                                                      where cal.FECHA_LABORABLE == fecha
                                                      select cal).FirstOrDefault();

                    if (calendario != null)
                    {
                        result.HORAS_LABORABLES = calendario.HORAS_LABORABLES;
                    }

                    #endregion

                    result.HORAS_DISPONIBLE = result.PERSONAL_DISPONIBLE * result.HORAS_LABORABLES;
                    result.HORAS_EMPLEADAS = (from actividades in result.listaActividades
                                              select actividades.TIEMPO_ACTIVIDAD).Sum() ;
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
