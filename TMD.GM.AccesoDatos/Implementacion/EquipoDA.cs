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
        public List<EquipoBE> BuscarEquipos(EquipoBE equipoBE)
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

                        var listaDatos = (from u in db.EQUIPO_COMPUTO where u.ESTADO_EQUIPO == ConstantesUT.ESTADO_GENERICO.Activo 
                                          && (u.CODIGO_EQUIPO == equipoBE.CODIGO_EQUIPO || equipoBE.CODIGO_EQUIPO == "")
                                          && (u.NOMBRE_EQUIPO.Contains(equipoBE.NOMBRE_EQUIPO) || equipoBE.NOMBRE_EQUIPO == "")
                                          && (u.SERIE_EQUIPO.Contains( equipoBE.SERIE_EQUIPO) || equipoBE.SERIE_EQUIPO == "")
                                          select u);

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

        public void Registrar(EquipoBE equipoBE)
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

                        EQUIPO_COMPUTO entidad = new EQUIPO_COMPUTO();

                        entidad.CODIGO_EQUIPO = equipoBE.CODIGO_EQUIPO;
                        entidad.NOMBRE_EQUIPO = equipoBE.NOMBRE_EQUIPO;
                        entidad.SERIE_EQUIPO = equipoBE.SERIE_EQUIPO;
                        entidad.MARCA_EQUIPO = equipoBE.MARCA_EQUIPO;
                        entidad.MODELO_EQUIPO = equipoBE.MODELO_EQUIPO;
                        entidad.CARACTERISTICAS_EQUIPO = equipoBE.CARACTERISTICAS_EQUIPO;
                        entidad.FECHA_COMPRA = equipoBE.FECHA_COMPRA;
                        entidad.FECHA_EXPIRACION_GARANTIA = equipoBE.FECHA_EXPIRACION_GARANTIA;
                        entidad.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = equipoBE.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO;
                        entidad.CODIGO_AREA = equipoBE.CODIGO_AREA;
                        entidad.CODIGO_TIPO_EQUIPO = equipoBE.CODIGO_TIPO_EQUIPO;
                        entidad.CODIGO_PLAN = equipoBE.CODIGO_PLAN;
                        entidad.PROCEDENCIA_EQUIPO = equipoBE.PROCEDENCIA_EQUIPO;
                        entidad.ESTADO_EQUIPO = equipoBE.ESTADO_EQUIPO ? ConstantesUT.ESTADO_GENERICO.Activo : ConstantesUT.ESTADO_GENERICO.Inactivo;

                        #region Validacion
                        //EQUIPO_COMPUTO entidadActual = (from u in db.EQUIPO_COMPUTO where u.CODIGO_PLAN == planBE.CODIGO_PLAN select u).FirstOrDefault();
                        //if (entidadActual != null)
                        //    throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteCodigo);

                        EQUIPO_COMPUTO entidadActual = (from u in db.EQUIPO_COMPUTO where u.NOMBRE_EQUIPO == equipoBE.NOMBRE_EQUIPO select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteNombre);

                        entidadActual = (from u in db.EQUIPO_COMPUTO where u.SERIE_EQUIPO == equipoBE.SERIE_EQUIPO select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteNumSerie);
                        #endregion

                        db.EQUIPO_COMPUTO.AddObject(entidad);
                        
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

        public void Actualizar(EquipoBE equipoBE)
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

                        EQUIPO_COMPUTO entidad = (from u in db.EQUIPO_COMPUTO where u.CODIGO_EQUIPO == equipoBE.CODIGO_EQUIPO select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        #region Validacion
                        EQUIPO_COMPUTO entidadActual = (from u in db.EQUIPO_COMPUTO
                                                        where (u.NOMBRE_EQUIPO == equipoBE.NOMBRE_EQUIPO && u.CODIGO_EQUIPO != equipoBE.CODIGO_EQUIPO)
                                                                     select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteNombre);

                        entidadActual = (from u in db.EQUIPO_COMPUTO 
                                         where u.SERIE_EQUIPO == equipoBE.SERIE_EQUIPO && u.CODIGO_EQUIPO != equipoBE.CODIGO_EQUIPO
                                         select u).FirstOrDefault();
                        if (entidadActual != null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.YaExisteNumSerie);

                        #endregion


                        entidad.NOMBRE_EQUIPO = equipoBE.NOMBRE_EQUIPO;
                        entidad.SERIE_EQUIPO = equipoBE.SERIE_EQUIPO;
                        entidad.MARCA_EQUIPO = equipoBE.MARCA_EQUIPO;
                        entidad.MODELO_EQUIPO = equipoBE.MODELO_EQUIPO;
                        entidad.CARACTERISTICAS_EQUIPO = equipoBE.CARACTERISTICAS_EQUIPO;
                        entidad.FECHA_COMPRA = equipoBE.FECHA_COMPRA;
                        entidad.FECHA_EXPIRACION_GARANTIA = equipoBE.FECHA_EXPIRACION_GARANTIA;
                        entidad.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = equipoBE.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO;
                        entidad.CODIGO_AREA = equipoBE.CODIGO_AREA;
                        entidad.CODIGO_TIPO_EQUIPO = equipoBE.CODIGO_TIPO_EQUIPO;
                        entidad.CODIGO_PLAN = equipoBE.CODIGO_PLAN;
                        entidad.PROCEDENCIA_EQUIPO = equipoBE.PROCEDENCIA_EQUIPO;
                        entidad.ESTADO_EQUIPO = equipoBE.ESTADO_EQUIPO ? ConstantesUT.ESTADO_GENERICO.Activo : ConstantesUT.ESTADO_GENERICO.Inactivo;

                        db.EQUIPO_COMPUTO.ApplyCurrentValues(entidad);


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

        public void Eliminar(EquipoBE equipoBE)
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

                        EQUIPO_COMPUTO entidad = (from u in db.EQUIPO_COMPUTO where u.CODIGO_EQUIPO == equipoBE.CODIGO_EQUIPO select u).FirstOrDefault(); ;

                        if (entidad == null)
                            throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                        #region Validacion

                        #endregion

                        db.EQUIPO_COMPUTO.DeleteObject(entidad);

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

        public List<EquipoBE> ListarEquiposTodos(EquipoBE equipoBE)
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

                        var listaDatos = (from u in db.EQUIPO_COMPUTO
                                          where (u.CODIGO_EQUIPO == equipoBE.CODIGO_EQUIPO || equipoBE.CODIGO_EQUIPO == "")
                                          && (u.NOMBRE_EQUIPO.Contains(equipoBE.NOMBRE_EQUIPO) || equipoBE.NOMBRE_EQUIPO == "")
                                          && (u.SERIE_EQUIPO.Contains( equipoBE.SERIE_EQUIPO) || equipoBE.SERIE_EQUIPO == "")
                                          select u);

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

        public EquipoBE Visualizar(EquipoBE equipoBE)
        {
            try
            {
                using (var db = BaseDA.GetEntityDatabase)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Closed)
                        db.Connection.Open();

                    EQUIPO_COMPUTO entidad = (from u in db.EQUIPO_COMPUTO where u.CODIGO_EQUIPO == equipoBE.CODIGO_EQUIPO select u).FirstOrDefault(); ;

                    if (entidad == null)
                        throw new Exception(ConstantesUT.MENSAJES_ERROR.NoExiste);

                    equipoBE.NOMBRE_EQUIPO = entidad.NOMBRE_EQUIPO;
                    equipoBE.SERIE_EQUIPO = entidad.SERIE_EQUIPO;
                    equipoBE.MARCA_EQUIPO = entidad.MARCA_EQUIPO;
                    equipoBE.MODELO_EQUIPO = entidad.MODELO_EQUIPO;
                    equipoBE.CARACTERISTICAS_EQUIPO = entidad.CARACTERISTICAS_EQUIPO;
                    equipoBE.FECHA_COMPRA = entidad.FECHA_COMPRA;
                    equipoBE.FECHA_EXPIRACION_GARANTIA = entidad.FECHA_EXPIRACION_GARANTIA;
                    equipoBE.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO = entidad.FECHA_ULTIMO_MANTENIMIENTO_EQUIPO;
                    equipoBE.CODIGO_AREA = DataUT.ObjectToInt32( entidad.CODIGO_AREA);
                    equipoBE.CODIGO_TIPO_EQUIPO = DataUT.ObjectToInt32(entidad.CODIGO_TIPO_EQUIPO);
                    equipoBE.CODIGO_PLAN = entidad.CODIGO_PLAN;
                    equipoBE.PROCEDENCIA_EQUIPO = entidad.PROCEDENCIA_EQUIPO;
                    equipoBE.ESTADO_EQUIPO = (entidad.ESTADO_EQUIPO == ConstantesUT.ESTADO_GENERICO.Activo);

                }
                return equipoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
