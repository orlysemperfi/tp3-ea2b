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

        //public List<OrdenTrabajoBE> ListarOrdenTrabajo1(DateTime? pd_Fini, DateTime? pd_Ffin)
        //{
        //    try
        //    {
        //        List<OrdenTrabajoBE> result = new List<OrdenTrabajoBE>();
        //        List<ORDEN_TRABAJO_CONSULTA> lst = BaseDA.GetEntityDatabase.GET_ORDEN_TRABAJO(pd_Fini, pd_Ffin).ToList();
        //        foreach (ORDEN_TRABAJO_CONSULTA item in lst)
        //        {
        //             result.Add(new OrdenTrabajoBE()
        //                {
        //                    NUMERO_SOLICITUD = DataUT.ObjectToString(item.NUMERO_SOLICITUD),
        //                    NOMBRE_EQUIPO = DataUT.ObjectToString(item.NOMBRE_EQUIPO),
        //                    MARCA_EQUIPO = DataUT.ObjectToString(item.MARCA_EQUIPO),
        //                    DESC_AREA = DataUT.ObjectToString(item.DESC_AREA),
        //                    FECHA_INICIO_SOLICITUD = DataUT.ObjectToDateTime(item.FECHA_INICIO_SOLICITUD),
        //                    FECHA_FIN_SOLICITUD = DataUT.ObjectToDateTime(item.FECHA_FIN_SOLICITUD),
        //                    ESTADO_SOLICITUD = DataUT.ObjectToInt(item.ESTADO_SOLICITUD),
        //                });
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public List<OrdenTrabajoBE> ListarOrdenTrabajo(OrdenTrabajoFiltroBE filtro)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<OrdenTrabajoBE> result = new List<OrdenTrabajoBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_ORDEN_TRABAJO", filtro.NUMERO_ORDEN, filtro.NUMERO_SOLICITUD, filtro.FECHA_INICIO_ORDEN,
                    filtro.FECHA_FIN_ORDEN, filtro.ESTADO_ORDEN, filtro.CODIGO_EMPLEADO))
                {
                    while (oReader.Read())
                    {
                        result.Add(new OrdenTrabajoBE()
                        {
                            NUMERO_ORDEN = DataUT.ObjectToString(oReader["NUMERO_ORDEN"]),
                            FECHA_EMISION_ORDEN = DataUT.ObjectToDateTime(oReader["FECHA_EMISION_ORDEN"]),
                            NOMBRE_EMPLEADO = DataUT.ObjectToString(oReader["NOMBRE_RESPONSABLE"]),
                            HORAS_TRABAJO_ORDEN = DataUT.ObjectToDecimal(oReader["HORAS_TRABAJO_ORDEN"]),
                            NUMERO_SOLICITUD = DataUT.ObjectToString(oReader["NUMERO_SOLICITUD"]),
                            DESCRIPCION_ESTADO = DataUT.ObjectToString(oReader["DESCRIPCION_ESTADO_OT"]),
                            ESTADO_ORDEN = DataUT.ObjectToInt32(oReader["ESTADO_ORDEN"]),
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

        public OrdenTrabajoBE ObtenerOrdenTrabajoNueva()
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                OrdenTrabajoBE result = new OrdenTrabajoBE();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_ORDENTRABAJO_NUEVA"))
                {
                    if (oReader.Read())
                    {
                        result = new OrdenTrabajoBE()
                        {
                            NUMERO_ORDEN = DataUT.ObjectToString(oReader["NUMERO_ORDEN"]),
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

        public void Registrar(List<OrdenTrabajoBE> entidades)
        {
            foreach (var entidad in entidades)
            {
                OrdenTrabajoBE nueva = ObtenerOrdenTrabajoNueva();
                entidad.NUMERO_ORDEN = nueva.NUMERO_ORDEN;
                Registrar(entidad);
            }
        }

        public void Registrar(OrdenTrabajoBE entidad)
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

                        ORDEN_TRABAJO_CABECERA nuevaEntidad = new ORDEN_TRABAJO_CABECERA();

                        nuevaEntidad.NUMERO_ORDEN = entidad.NUMERO_ORDEN;
                        nuevaEntidad.FECHA_EMISION_ORDEN = entidad.FECHA_EMISION_ORDEN;
                        nuevaEntidad.FECHA_INICIO_ORDEN = entidad.FECHA_INICIO_ORDEN;
                        nuevaEntidad.FECHA_FIN_ORDEN = entidad.FECHA_FIN_ORDEN;
                        nuevaEntidad.HORAS_TRABAJO_ORDEN = entidad.HORAS_TRABAJO_ORDEN;
                        nuevaEntidad.OBSERVACIONES_ORDEN = entidad.OBSERVACIONES_ORDEN;
                        nuevaEntidad.CODIGO_EMPLEADO = entidad.CODIGO_EMPLEADO;
                        nuevaEntidad.NUMERO_SOLICITUD = entidad.NUMERO_SOLICITUD;
                        nuevaEntidad.ESTADO_ORDEN = entidad.ESTADO_ORDEN;

                        db.ORDEN_TRABAJO_CABECERA.AddObject(nuevaEntidad);

                        foreach (var item in entidad.listaActividades)
                        {
                            ORDEN_TRABAJO_DETALLE itemEntidad = new ORDEN_TRABAJO_DETALLE();
                            itemEntidad.NUMERO_ORDEN = entidad.NUMERO_ORDEN;
                            itemEntidad.ITEM_ORDEN = item.ITEM_ORDEN;
                            itemEntidad.NUMERO_SOLICITUD = item.NUMERO_SOLICITUD;
                            itemEntidad.FECHA_INICIO_ACTIVIDAD = item.FECHA_INICIO_ACTIVIDAD;
                            itemEntidad.ITEM_SOLICITUD = item.ITEM_SOLICITUD;
                            itemEntidad.FECHA_FIN_ACTIVIDAD = item.FECHA_FIN_ACTIVIDAD;
                            itemEntidad.FECHA_PROGRAMADA = item.FECHA_PROGRAMADA;
                            itemEntidad.RESULTADO_ATENCION = item.RESULTADO_ATENCION;

                            db.ORDEN_TRABAJO_DETALLE.AddObject(itemEntidad);
                        }

                        SOLICITUD_CABECERA solicitud = (from u in db.SOLICITUD_CABECERA where u.NUMERO_SOLICITUD == entidad.NUMERO_SOLICITUD select u).FirstOrDefault(); ;

                        solicitud.ESTADO_SOLICITUD = ConstantesUT.ESTADO_SOLICITUD.Aperturado;

                        db.SOLICITUD_CABECERA.ApplyCurrentValues(solicitud);

                        if (db.SaveChanges() < 1)
                        {
                            //throw new Exception("Error en el proceso");
                        }
                        else
                            dbTran.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTran.Rollback();
                        //throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Actualizar(OrdenTrabajoBE entidad)
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

                        ORDEN_TRABAJO_CABECERA entidadActual = (from u in db.ORDEN_TRABAJO_CABECERA where u.NUMERO_ORDEN == entidad.NUMERO_ORDEN select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        entidadActual.FECHA_EMISION_ORDEN = entidad.FECHA_EMISION_ORDEN;
                        entidadActual.FECHA_INICIO_ORDEN = entidad.FECHA_INICIO_ORDEN;
                        entidadActual.FECHA_FIN_ORDEN = entidad.FECHA_FIN_ORDEN;
                        entidadActual.HORAS_TRABAJO_ORDEN = entidad.HORAS_TRABAJO_ORDEN;
                        entidadActual.OBSERVACIONES_ORDEN = entidad.OBSERVACIONES_ORDEN;
                        entidadActual.CODIGO_EMPLEADO = entidad.CODIGO_EMPLEADO;
                        entidadActual.NUMERO_SOLICITUD = entidad.NUMERO_SOLICITUD;
                        entidadActual.ESTADO_ORDEN = entidad.ESTADO_ORDEN;

                        db.ORDEN_TRABAJO_CABECERA.ApplyCurrentValues(entidadActual);

                        #region
                        //Listamos las todas las actividades determinadas del cliente
                        List<ORDEN_TRABAJO_DETALLE> listActCliente = new List<ORDEN_TRABAJO_DETALLE>(); ;
                        foreach (var item in entidad.listaActividades)
                        {
                            listActCliente.Add(new ORDEN_TRABAJO_DETALLE()
                            {
                                ID_ACTIVIDAD = item.ID_ACTIVIDAD,
                                NUMERO_ORDEN = item.NUMERO_ORDEN,
                                ITEM_ORDEN = item.ITEM_ORDEN,
                                NUMERO_SOLICITUD = item.NUMERO_SOLICITUD,
                                FECHA_INICIO_ACTIVIDAD = item.FECHA_INICIO_ACTIVIDAD,
                                ITEM_SOLICITUD = item.ITEM_SOLICITUD,
                                FECHA_FIN_ACTIVIDAD = item.FECHA_FIN_ACTIVIDAD,
                                FECHA_PROGRAMADA = item.FECHA_PROGRAMADA,
                                RESULTADO_ATENCION = item.RESULTADO_ATENCION
                            });
                        }

                        //Listamos las pruebas asociadas a la clasificacion actalmente
                        List<ORDEN_TRABAJO_DETALLE> listActServer = (from actividadesServer in db.ORDEN_TRABAJO_DETALLE
                                                                     where actividadesServer.NUMERO_ORDEN == entidad.NUMERO_ORDEN
                                                                 select actividadesServer).ToList();

                        //Listamos las todas las actividades modificadas por el cliente
                        List<ORDEN_TRABAJO_DETALLE> listActModifica = (from actividadesServer in listActServer
                                                                   join actividadesClient in listActCliente on actividadesServer.ID_ACTIVIDAD equals actividadesClient.ID_ACTIVIDAD
                                                                       where actividadesServer.NUMERO_ORDEN == entidad.NUMERO_ORDEN
                                                                   select actividadesServer).ToList();



                        var cComparerExcept = new ComparerExcept<ORDEN_TRABAJO_DETALLE>();

                        //Determinamos las nuevas actividades
                        List<ORDEN_TRABAJO_DETALLE> listActNuevas = listActCliente.Except(listActServer, cComparerExcept).ToList();

                        //Determinamos las pruebas a desasociar
                        List<ORDEN_TRABAJO_DETALLE> listActElimina = listActServer.Except(listActCliente, cComparerExcept).ToList();


                        //Actualizamos el detalle
                        foreach (var item in listActNuevas)
                        {
                            ORDEN_TRABAJO_DETALLE itemDetalle = new ORDEN_TRABAJO_DETALLE()
                            {
                                #region Datos
                                NUMERO_ORDEN = item.NUMERO_ORDEN,
                                ITEM_ORDEN = item.ITEM_ORDEN,
                                NUMERO_SOLICITUD = item.NUMERO_SOLICITUD,
                                FECHA_INICIO_ACTIVIDAD = item.FECHA_INICIO_ACTIVIDAD,
                                ITEM_SOLICITUD = item.ITEM_SOLICITUD,
                                FECHA_FIN_ACTIVIDAD = item.FECHA_FIN_ACTIVIDAD,
                                FECHA_PROGRAMADA = item.FECHA_PROGRAMADA,
                                RESULTADO_ATENCION = item.RESULTADO_ATENCION
                                #endregion
                            };
                            db.ORDEN_TRABAJO_DETALLE.AddObject(itemDetalle);
                        }
                        foreach (var item in listActModifica)
                        {
                            ORDEN_TRABAJO_DETALLE itemDetalle = (from u in db.ORDEN_TRABAJO_DETALLE
                                                             where (u.ID_ACTIVIDAD == item.ID_ACTIVIDAD)
                                                             select u).FirstOrDefault();
                            #region Datos
                            itemDetalle.NUMERO_ORDEN = item.NUMERO_ORDEN;
                            itemDetalle.ITEM_ORDEN = item.ITEM_ORDEN;
                            itemDetalle.NUMERO_SOLICITUD = item.NUMERO_SOLICITUD;
                            itemDetalle.FECHA_INICIO_ACTIVIDAD = item.FECHA_INICIO_ACTIVIDAD;
                            itemDetalle.ITEM_SOLICITUD = item.ITEM_SOLICITUD;
                            itemDetalle.FECHA_FIN_ACTIVIDAD = item.FECHA_FIN_ACTIVIDAD;
                            itemDetalle.FECHA_PROGRAMADA = item.FECHA_PROGRAMADA;
                            itemDetalle.RESULTADO_ATENCION = item.RESULTADO_ATENCION;
                            #endregion
                            db.ORDEN_TRABAJO_DETALLE.ApplyCurrentValues(itemDetalle);
                        }
                        foreach (var item in listActElimina)
                        {
                            ORDEN_TRABAJO_DETALLE itemDetalle = (from u in db.ORDEN_TRABAJO_DETALLE
                                                             where (u.ID_ACTIVIDAD == item.ID_ACTIVIDAD)
                                                             select u).FirstOrDefault();
                            db.ORDEN_TRABAJO_DETALLE.DeleteObject(itemDetalle);
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

        public void Eliminar(OrdenTrabajoBE entidad)
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

                        ORDEN_TRABAJO_CABECERA entidadActual = (from u in db.ORDEN_TRABAJO_CABECERA where u.NUMERO_ORDEN == entidad.NUMERO_ORDEN select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        #region Validacion

                        #endregion

                        entidadActual.ESTADO_ORDEN = ConstantesUT.ESTADO_ORDEN.Anulada;
                        db.ORDEN_TRABAJO_CABECERA.ApplyCurrentValues(entidadActual);

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

        public OrdenTrabajoBE Visualizar(OrdenTrabajoBE entidad)
        {
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    ORDEN_TRABAJO_CABECERA entidadActual = (from u in db.ORDEN_TRABAJO_CABECERA where u.NUMERO_ORDEN == entidad.NUMERO_ORDEN select u).FirstOrDefault();

                    if (entidad == null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                    entidad.FECHA_EMISION_ORDEN = entidadActual.FECHA_EMISION_ORDEN;
                    entidad.FECHA_INICIO_ORDEN = entidadActual.FECHA_INICIO_ORDEN;
                    entidad.FECHA_FIN_ORDEN = entidadActual.FECHA_FIN_ORDEN;
                    entidad.HORAS_TRABAJO_ORDEN = entidadActual.HORAS_TRABAJO_ORDEN;
                    entidad.OBSERVACIONES_ORDEN = entidadActual.OBSERVACIONES_ORDEN;
                    entidad.CODIGO_EMPLEADO = entidadActual.CODIGO_EMPLEADO;
                    PERSONA entidadEmpleado = (from e in db.PERSONA where e.CODIGO_PERSONA == entidadActual.CODIGO_EMPLEADO select e).FirstOrDefault();
                    if (entidadEmpleado != null)
                    {
                        entidad.NOMBRE_EMPLEADO = entidadEmpleado.NOMBRE_PERSONA + " " + entidadEmpleado.APELLIDO_PATERNO + " " + entidadEmpleado.APELLIDO_MATERNO;
                    }
                    entidad.CODIGO_EMPLEADO = entidadActual.CODIGO_EMPLEADO;
                    entidad.NUMERO_SOLICITUD = entidadActual.NUMERO_SOLICITUD;
                    entidad.ESTADO_ORDEN = entidadActual.ESTADO_ORDEN;

                    entidad.listaActividades = new List<OrdenTrabajoDetalleBE>();
                    //foreach (var itemEntidad in entidadActual.ORDEN_TRABAJO_DETALLE)
                    //{
                    //    OrdenTrabajoDetalleBE item = new OrdenTrabajoDetalleBE();
                    //    item.GUID_ROW = Guid.NewGuid();
                    //    item.ID_ACTIVIDAD = itemEntidad.ID_ACTIVIDAD;
                    //    item.NUMERO_ORDEN = itemEntidad.NUMERO_ORDEN;
                    //    item.ITEM_ORDEN = itemEntidad.ITEM_ORDEN;
                    //    item.NUMERO_SOLICITUD = itemEntidad.NUMERO_SOLICITUD;
                    //    item.FECHA_INICIO_ACTIVIDAD = itemEntidad.FECHA_INICIO_ACTIVIDAD;
                    //    item.ITEM_SOLICITUD = itemEntidad.ITEM_SOLICITUD;
                    //    item.FECHA_FIN_ACTIVIDAD = itemEntidad.FECHA_FIN_ACTIVIDAD;
                    //    item.FECHA_PROGRAMADA = itemEntidad.FECHA_PROGRAMADA;
                    //    item.RESULTADO_ATENCION = itemEntidad.RESULTADO_ATENCION;

                    //    entidad.listaActividades.Add(item);
                    //}
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrdenTrabajoDetalleBE> VisualizarDetalle(OrdenTrabajoBE entidad)
        {
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    var detalleActual = (from OTD in db.ORDEN_TRABAJO_DETALLE
                                         join OT in db.ORDEN_TRABAJO_CABECERA on OTD.NUMERO_ORDEN equals OT.NUMERO_ORDEN
                                         join S in db.SOLICITUD_CABECERA on OT.NUMERO_SOLICITUD equals S.NUMERO_SOLICITUD
                                         join SD in db.SOLICITUD_DETALLE on S.NUMERO_SOLICITUD equals SD.NUMERO_SOLICITUD
                                         join TA in db.ACTIVIDAD_TIPO on SD.CODIGO_TIPO_ACTIVIDAD equals TA.CODIGO_TIPO_ACTIVIDAD
                                         where OT.NUMERO_ORDEN == entidad.NUMERO_ORDEN
                                         select new {
                                             ID_ACTIVIDAD = OTD.ID_ACTIVIDAD,
                                             DESCRIPCION_ACTIVIDAD = SD.DESCRIPCION_ACTIVIDAD,
                                             DESCRIPCION_TIPO_ACTIVIDAD = TA.DESCRIPCION_TIPO_ACTIVIDAD,
                                             NUMERO_ORDEN = OTD.NUMERO_ORDEN,
                                             ITEM_ORDEN = OTD.ITEM_ORDEN,
                                             NUMERO_SOLICITUD = OTD.NUMERO_SOLICITUD,
                                             FECHA_INICIO_ACTIVIDAD = OTD.FECHA_INICIO_ACTIVIDAD,
                                             ITEM_SOLICITUD = OTD.ITEM_SOLICITUD,
                                             FECHA_FIN_ACTIVIDAD = OTD.FECHA_FIN_ACTIVIDAD,
                                             FECHA_PROGRAMADA = OTD.FECHA_PROGRAMADA,
                                             RESULTADO_ATENCION = OTD.RESULTADO_ATENCION,

                                         });

                    if (entidad == null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                    entidad.listaActividades = new List<OrdenTrabajoDetalleBE>();
                    foreach (var itemEntidad in detalleActual)
                    {
                        OrdenTrabajoDetalleBE item = new OrdenTrabajoDetalleBE();
                        item.GUID_ROW = Guid.NewGuid();
                        item.ID_ACTIVIDAD = itemEntidad.ID_ACTIVIDAD;
                        item.DESCRIPCION_ACTIVIDAD = itemEntidad.DESCRIPCION_ACTIVIDAD;
                        item.DESCRIPCION_TIPO_ACTIVIDAD = itemEntidad.DESCRIPCION_TIPO_ACTIVIDAD;
                        item.NUMERO_ORDEN = itemEntidad.NUMERO_ORDEN;
                        item.ITEM_ORDEN = itemEntidad.ITEM_ORDEN;
                        item.NUMERO_SOLICITUD = itemEntidad.NUMERO_SOLICITUD;
                        item.FECHA_INICIO_ACTIVIDAD = itemEntidad.FECHA_INICIO_ACTIVIDAD;
                        item.ITEM_SOLICITUD = itemEntidad.ITEM_SOLICITUD;
                        item.FECHA_FIN_ACTIVIDAD = itemEntidad.FECHA_FIN_ACTIVIDAD;
                        item.FECHA_PROGRAMADA = itemEntidad.FECHA_PROGRAMADA;
                        item.RESULTADO_ATENCION = itemEntidad.RESULTADO_ATENCION;

                        entidad.listaActividades.Add(item);
                    }
                }
                return entidad.listaActividades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<OrdenTrabajoEquipoBE> ListarEquiposPendientes(OrdenTrabajoFiltroBE filtro)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<OrdenTrabajoEquipoBE> result = new List<OrdenTrabajoEquipoBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_EQUIPOS_PENDIENTES_OT", filtro.FECHA_INICIO_ORDEN, filtro.FECHA_FIN_ORDEN))
                {
                    while (oReader.Read())
                    {
                        result.Add(new OrdenTrabajoEquipoBE()
                        {
                            CODIGO_EQUIPO = DataUT.ObjectToString(oReader["CODIGO_EQUIPO"]),
                            NOMBRE_EQUIPO = DataUT.ObjectToString(oReader["NOMBRE_EQUIPO"]),
                            DESCRIPCION_TIPO_EQUIPO = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_EQUIPO"]),
                            NOMBRE_PLAN = DataUT.ObjectToString(oReader["NOMBRE_PLAN"]),
                            NUMERO_SOLICITUD = DataUT.ObjectToString(oReader["NUMERO_SOLICITUD"]),
                            FECHA_INICIO_ORDEN = filtro.FECHA_INICIO_ORDEN,
                            FECHA_FIN_ORDEN = filtro.FECHA_FIN_ORDEN,
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

        //public List<OrdenTrabajoEquipoBE> ListarEquiposPendientes(OrdenTrabajoFiltroBE filtro)
        //{
        //    Database oDatabase = BaseDA.GetSqlDatabase;
        //    try
        //    {
        //        List<OrdenTrabajoEquipoBE> result = new List<OrdenTrabajoEquipoBE>();
        //        using (IDataReader oReader = oDatabase.ExecuteReader("GET_EQUIPOS_PENDIENTES_OT", filtro.FECHA_INICIO_ORDEN, filtro.FECHA_FIN_ORDEN))
        //        {
        //            while (oReader.Read())
        //            {
        //                result.Add(new OrdenTrabajoEquipoBE()
        //                {
        //                    CODIGO_EQUIPO = DataUT.ObjectToString(oReader["CODIGO_EQUIPO"]),
        //                    NOMBRE_EQUIPO = DataUT.ObjectToString(oReader["NOMBRE_EQUIPO"]),
        //                    DESCRIPCION_TIPO_EQUIPO = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_EQUIPO"]),
        //                    NOMBRE_PLAN = DataUT.ObjectToString(oReader["NOMBRE_PLAN"]),
        //                    NUMERO_SOLICITUD = DataUT.ObjectToString(oReader["NUMERO_SOLICITUD"]),
        //                });
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<OrdenTrabajoDetalleBE> ListarActividadesEquiposPendientes(OrdenTrabajoFiltroBE filtro)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                List<OrdenTrabajoDetalleBE> result = new List<OrdenTrabajoDetalleBE>();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_ACTIVIDADES_PENDIENTES_OT", filtro.CODIGO_EQUIPO))
                {
                    while (oReader.Read())
                    {
                        result.Add(new OrdenTrabajoDetalleBE()
                        {
                            ID_ACTIVIDAD = DataUT.ObjectToInt32(oReader["ID_ACTIVIDAD"]),
                            ITEM_ORDEN = DataUT.ObjectToInt32(oReader["ITEM_ORDEN"]),
                            DESCRIPCION_ACTIVIDAD = DataUT.ObjectToString(oReader["DESCRIPCION_ACTIVIDAD"]),
                            DESCRIPCION_TIPO_ACTIVIDAD = DataUT.ObjectToString(oReader["DESCRIPCION_TIPO_ACTIVIDAD"]),
                            FECHA_PROGRAMADA = DataUT.ObjectToDateTimeNull(oReader["FECHA_PROGRAMACION"]),
                            FECHA_CRONOGRAMA = DataUT.ObjectToDateTimeNull(oReader["FECHA_CRONOGRAMA"]),
                            TIEMPO_ACTIVIDAD = DataUT.ObjectToDecimal(oReader["TIEMPO_ACTIVIDAD"]),
                            DESCRIPCION_TIEMPO = DataUT.ObjectToString(oReader["DESCRIPCION_TIEMPO"]),
                            CODIGO_TIEMPO = DataUT.ObjectToInt32(oReader["CODIGO_TIEMPO"]),
                            TIEMPO_ACTIVIDAD_TEXTO = String.Format("{0:0.##}", DataUT.ObjectToDecimal(oReader["TIEMPO_ACTIVIDAD"])) + " " + DataUT.ObjectToString(oReader["DESCRIPCION_TIEMPO"]),
                            CODIGO_EQUIPO = filtro.CODIGO_EQUIPO
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

        public OrdenTrabajoEquipoBE ObtenerDisponibilidadResponsable(OrdenTrabajoFiltroBE filtro)
        {
            Database oDatabase = BaseDA.GetSqlDatabase;
            try
            {
                OrdenTrabajoEquipoBE result = new OrdenTrabajoEquipoBE();
                using (IDataReader oReader = oDatabase.ExecuteReader("GET_DISPONIBILIDAD_RESPONSABLE", filtro.CODIGO_EMPLEADO))
                {
                    while (oReader.Read())
                    {
                        result = new OrdenTrabajoEquipoBE()
                        {
                            CANTIDAD_OT_ASIGNADAS = DataUT.ObjectToInt32(oReader["CANTIDAD_OT"]),
                            HORAS_OT_ASIGNADAS = DataUT.ObjectToDecimal(oReader["HORAS_OT"]),
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
