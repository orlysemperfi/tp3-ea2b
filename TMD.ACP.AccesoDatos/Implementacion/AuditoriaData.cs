using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Core;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Map;


namespace TMD.ACP.AccesoDatos.Implementacion
{
    public class AuditoriaData : DataBase, IAuditoriaData
    {
        public AuditoriaData(String connectionString)
            : base(connectionString)
        {
        }

        public List<Auditoria> Obtener(Auditoria filtro)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_AUDITORIA"))
            {
                DB.AddInParameter(command, "@anhoAuditoria", DbType.Int32, filtro.AnhoAuditoria);
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, filtro.IdAuditoria);                
                DB.AddInParameter(command, "@estado", DbType.String, filtro.Estado);
                DB.AddInParameter(command, "@indChecklistEstablecido", DbType.Boolean, filtro.IndCheckListEstablecido);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(AuditoriaDataMap.Select(reader));
                    }
                }
            }

            return lista;
        }

        public List<Auditoria> ListarPlanAuditorias(int anhoAuditoria, string estAutorizado, string estPlanificado)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_PLAN_AUDITORIAS"))
            {
                DB.AddInParameter(command, "@anhoAuditoria", DbType.Int32, anhoAuditoria);
                DB.AddInParameter(command, "@estado1", DbType.String, estAutorizado);
                DB.AddInParameter(command, "@estado2", DbType.String, estPlanificado);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(AuditoriaDataMap.SelectListaPlanAuditoria(reader));
                    }
                }
            }

            return lista;
        }

        public Auditoria ObtenerPlanAuditoriaPorID(int idAuditoria)
        {
            List<Auditoria> lista = new List<Auditoria>();
            Auditoria eAuditoria = new Auditoria();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_PLAN_AUDITORIA_POR_ID"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        eAuditoria = AuditoriaDataMap.SelectPlanAuditoria(reader);
                        return eAuditoria;
                    }
                }

            }
            return eAuditoria;
        }

        public void GrabarPlanAuditoria(Auditoria eAuditoria)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_PLAN_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, eAuditoria.IdAuditoria);
                DB.AddInParameter(command, "@estado", DbType.String, eAuditoria.Estado);          
                DB.AddInParameter(command, "@archivo_l", DbType.String, eAuditoria.nombreArchivoL);
                DB.AddInParameter(command, "@archivo_f", DbType.String, eAuditoria.nombreArchivoF);
                DB.ExecuteNonQuery(command);
            }
        }

        #region "Programa Anual de Auditoria"

        public ProgramaAnualAuditoria ObtenerProgramaAnualAuditorias()
        {
            ProgramaAnualAuditoria oProgramaAnualAuditoria = null;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_PROGRAMA_ANUAL_AUDITORIA"))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        oProgramaAnualAuditoria = AuditoriaDataMap.SelectProgramaAnualAuditoria(reader);
                        return oProgramaAnualAuditoria;
                    }
                }
            }

            return oProgramaAnualAuditoria;
        }

        public List<Auditoria> ListarAuditoriasPorAnio(int anhoAuditoria)
        {
            List<Auditoria> lista = new List<Auditoria>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_AUDITORIAS_POR_ANIO"))
            {
                DB.AddInParameter(command, "@anhoAuditoria", DbType.Int32, anhoAuditoria);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(AuditoriaDataMap.SelectAuditoriasPorAnio(reader));
                    }
                }
            }

            return lista;
        }

        public int GrabarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual)
        {
            int idPrograma = 0;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_PROGRAMA_ANUAL"))
            {
                DB.AddInParameter(command, "@anio", DbType.Int32, eProgramaAnual.AnhoPrograma);
                DB.AddInParameter(command, "@estado", DbType.String, eProgramaAnual.Estado);
                DB.AddInParameter(command, "@elaboradoPor", DbType.Int32, eProgramaAnual.IdUsuarioCreacion);
                idPrograma = Convert.ToInt32(DB.ExecuteScalar(command));
            }

            return idPrograma;
        }

        public void GrabarAuditoria(Auditoria eAuditoria)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idPrograma", DbType.Int32, eAuditoria.idPrograma);
                DB.AddInParameter(command, "@idEntidadAuditada", DbType.Int32, eAuditoria.ObjEntidadAuditada.IdEntidadAuditada);
                DB.AddInParameter(command, "@responsable", DbType.Int32, eAuditoria.ObjEntidadAuditada.IdResponsable);
                DB.AddInParameter(command, "@alcance", DbType.String, eAuditoria.Alcance);
                DB.AddInParameter(command, "@objetivo", DbType.String, eAuditoria.Objetivo);
                DB.AddInParameter(command, "@fechainicio", DbType.DateTime, eAuditoria.FechaInicio);
                DB.AddInParameter(command, "@fechafin", DbType.DateTime, eAuditoria.FechaFin);
                DB.AddInParameter(command, "@estado", DbType.String, eAuditoria.Estado);
                DB.ExecuteNonQuery(command);
            }
        }

        public bool ValidarAuditoria(int idEntidadAuditada)
        {
            int count = 0;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_VALIDAR_AUDITORIA"))
            {
                DB.AddInParameter(command, "@idEntidadAuditada", DbType.Int32, idEntidadAuditada);
                count = Convert.ToInt32(DB.ExecuteScalar(command));
            }

            return count > 0 ? false : true;
        }


        public void AprobarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual)
        {            
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE AC_PROGRAMA_AUDITORIA ");
            sb.Append("SET fechaAprobacion=GETDATE(), ");
            sb.Append(string.Format("aprobadoPor={0}, ", eProgramaAnual.IdUsuarioAprobacion));
            sb.Append(string.Format("estado='{0}' ", eProgramaAnual.Estado));
            sb.Append(string.Format("WHERE idPrograma = {0} ", eProgramaAnual.IdProgramaAnual));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }            
        }

        public void AprobarAuditoria(Auditoria eAuditoria)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE AUDITORIA ");
            sb.Append(string.Format("SET ESTADO='{0}' ", eAuditoria.Estado));
            sb.Append(string.Format(" WHERE CODIGO_AUDITORIA = {0} ", eAuditoria.IdAuditoria));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }
        }

        public void RechazarProgramaAnualAuditoria(ProgramaAnualAuditoria eProgramaAnual)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM AC_PROGRAMA_AUDITORIA ");            
            sb.Append(string.Format("WHERE idPrograma = {0} ", eProgramaAnual.IdProgramaAnual));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }
        }

        public void RechazarAuditoria(Auditoria eAuditoria)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM AUDITORIA ");
            sb.Append(string.Format("WHERE CODIGO_AUDITORIA = {0} ", eAuditoria.IdAuditoria));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }
        }

        public void GrabarInformeFinalAuditoria(Auditoria eAuditoria)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE AUDITORIA ");
            sb.Append(string.Format("SET DURACION={0}, RESULTADO = '{1}', CONCLUSION= '{2}',RECOMENDACION='{3}', ESTADO='{4}' WHERE CODIGO_AUDITORIA = {5}", eAuditoria.duracion, eAuditoria.resultado, eAuditoria.conclusion, eAuditoria.recomendacion, eAuditoria.Estado, eAuditoria.IdAuditoria));
            
            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }
        }

        public Auditoria ObtenerInformeFinalPorAuditoria(int idAuditoria)
        {
            List<Auditoria> lista = new List<Auditoria>();
            Auditoria eAuditoria = new Auditoria();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT AUD.CODIGO_AUDITORIA, ");
            sb.Append("ENT.idEntidadAuditada,ENT.descripcion as nombreEntidad,AREA.CODIGO_AREA,AREA.descripcion as nombreArea,AUD.FECHA_INICIO,AUD.FECHA_FIN, ");
            sb.Append("AUD.estado,E.NOMBRES + ' ' + E.APEPAT as responsableProyecto,AUD.objetivo,AUD.alcance,AUD.NOMBRE_ARCHIVO_L,AUD.NOMBRE_ARCHIVO_F, ");
            sb.Append("AUD.RESULTADO,AUD.DURACION,AUD.CONCLUSION,AUD.RECOMENDACION,AUD.ESTADO ");            
            sb.Append("from AUDITORIA AUD ");
            sb.Append("inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada) ");
            sb.Append("inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA) ");
            sb.Append("inner join EMPLEADO E on (E.CODIGO_EMPLEADO = AUD.RESPONSABLE_PROCESO) ");
            sb.Append(string.Format("WHERE AUD.CODIGO_AUDITORIA = {0} ", idAuditoria));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {              
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        eAuditoria = AuditoriaDataMap.SelectInformeFinalAuditoria(reader);
                        return eAuditoria;
                    }
                }

            }
            return eAuditoria;
        }

       

        #endregion
    }
}
