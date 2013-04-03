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
    public class HallazgoData : DataBase, IHallazgoData
    {
        public HallazgoData(String connectionString)
            : base(connectionString)
        {
        }

        public int Agregar(Hallazgo hallazgo)
        {
            int idHallazgoNuevo;

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_INSERTAR_HALLAZGO"))
            {
                DB.AddInParameter(command, "@tipoHallazgo", DbType.String, hallazgo.TipoHallazgo);
                DB.AddInParameter(command, "@descripcion", DbType.String, hallazgo.Descripcion);
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, hallazgo.IdAuditoria);
                DB.AddInParameter(command, "@idPreguntaVerificacion", DbType.Int32, hallazgo.IdPreguntaVerificacion);
                DB.AddInParameter(command, "@estado", DbType.String, hallazgo.Estado);
                DB.AddOutParameter(command, "@idHallazgoCreado", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                idHallazgoNuevo = Convert.ToInt32(DB.GetParameterValue(command, "@idHallazgoCreado"));
            }

            return idHallazgoNuevo;
        }

        public List<Hallazgo> Obtener(Hallazgo filtro)
        {
            List<Hallazgo> lstHallazgo = new List<Hallazgo>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_HALLAZGO"))
            {
                DB.AddInParameter(command, "@idHallazgo", DbType.Int32, filtro.IdHallazgo);
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, filtro.IdAuditoria);
                DB.AddInParameter(command, "@idPreguntaVerificacion", DbType.Int32, filtro.IdPreguntaVerificacion);
                DB.AddInParameter(command, "@estado", DbType.String, filtro.Estado);                

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lstHallazgo.Add(HallazgoDataMap.Select(reader));
                    }
                }
            }

            return lstHallazgo;
        }


        public void Modificar(Hallazgo hallazgo)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_MODIFICAR_HALLAZGO"))
            {
                DB.AddInParameter(command, "@idHallazgo", DbType.Int32, hallazgo.IdHallazgo);
                DB.AddInParameter(command, "@tipoHallazgo", DbType.String, hallazgo.TipoHallazgo);
                DB.AddInParameter(command, "@descripcion", DbType.String, hallazgo.Descripcion);
                DB.AddInParameter(command, "@estado", DbType.String, hallazgo.Estado);
                
                DB.ExecuteNonQuery(command);
            }
        }

        public void Eliminar(int idHallazgo)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_ELIMINAR_HALLAZGO"))
            {
                DB.AddInParameter(command, "@idHallazgo", DbType.Int32, idHallazgo);

                DB.ExecuteNonQuery(command);
            }
        }

        public List<Auditoria> ObtenerAuditoriasSeguimiento(int anhoAuditoria)
        {
            List<Auditoria> lista = new List<Auditoria>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT AUD.CODIGO_AUDITORIA, ENT.descripcion as AUDITORIA, AREA.CODIGO_AREA, AREA.DESCRIPCION as AREA, ");
            sb.Append("AUD.FECHA_INICIO, AUD.FECHA_FIN,AUD.ESTADO ");
            sb.Append("from AUDITORIA AUD ");
            sb.Append("inner join AC_ENTIDAD_AUDITADA ENT on (AUD.CODIGO_ENTIDAD_AUDITADA = ENT.idEntidadAuditada) ");
            sb.Append("inner join AREA AREA on (ENT.idArea = AREA.CODIGO_AREA) ");
            sb.Append(string.Format("WHERE YEAR(AUD.FECHA_INICIO) = {0} ", anhoAuditoria));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(HallazgoDataMap.SelectAuditoriasSeguimientoHallazgo(reader));
                    }
                }
            }

            return lista;
        }

        public List<Hallazgo> ObtenerHallazgosSeguimiento(int idAuditoria, int idHallazgo)
        {
            List<Hallazgo> lista = new List<Hallazgo>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("H.idHallazgo,H.idAuditoria,H.idPreguntaVerificacion,P.descripcionPregunta, H.tipoHallazgo,H.descripcion, ");
            sb.Append("H.fechaCompromiso,H.fechaSeguimiento,H.comentarioSeguimiento,H.idAuditorSeguimiento, ");
            sb.Append("(E.NOMBRES + E.APEPAT + E.APEMAT) AS responsableSeguimiento,H.estado ");
            sb.Append("FROM AC_HALLAZGO H ");
            sb.Append("INNER JOIN AC_PREGUNTA_VERIFICACION P ON H.idAuditoria = P.idAuditoria AND H.idPreguntaVerificacion = P.idPreguntaVerificacion ");
            sb.Append("LEFT JOIN EMPLEADO E ON H.idAuditorSeguimiento = E.CODIGO_EMPLEADO ");
            sb.Append(string.Format("WHERE (H.idAuditoria = {0}) ", idAuditoria));
            sb.Append(string.Format("AND (H.idHallazgo = {0} OR {0} = 0) ", idHallazgo));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(HallazgoDataMap.ObtenerHallazgosSeguimiento(reader));
                    }
                }
            }

            return lista;
        }

        public void GrabarHallazgoSeguimiento(Hallazgo hallazgo)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE AC_HALLAZGO ");
            if (hallazgo.FechaSeguimiento.HasValue)
                sb.Append(string.Format("SET fechaSeguimiento = '{0}', ", hallazgo.FechaSeguimiento.Value.ToString("yyyyMMdd")));
            else
                sb.Append("SET fechaSeguimiento = null, ");
            if (hallazgo.IdAuditorSeguimiento.HasValue)
                sb.Append(string.Format("idAuditorSeguimiento = {0}, ", hallazgo.IdAuditorSeguimiento.Value.ToString()));
            else
                sb.Append("idAuditorSeguimiento = null, ");

            if (!string.IsNullOrEmpty(hallazgo.ComentarioSeguimiento))
                sb.Append(string.Format("comentarioSeguimiento = '{0}', ", hallazgo.ComentarioSeguimiento));
            else
                sb.Append("comentarioSeguimiento = null, ");

            sb.Append(string.Format("estado = '{0}' ", hallazgo.Estado));
            sb.Append(string.Format("WHERE idHallazgo = {0} ", hallazgo.IdHallazgo));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }
        }

        public List<Hallazgo> Obtener_Anio(int AnhoAuditoria)
        {
            List<Hallazgo> lstHallazgo = new List<Hallazgo>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_LISTAR_HALLAZGOS_POR_ANIO"))
            {
                DB.AddInParameter(command, "@anhoAuditoria", DbType.Int32, AnhoAuditoria);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lstHallazgo.Add(HallazgoDataMap.Select_ANIO(reader));
                    }
                }
            }

            return lstHallazgo;
        }

        public List<Hallazgo> ObtenerHallazgosSeguimientoPorPeriodo(int anhoAuditoria, int idHallazgo)
        {
            List<Hallazgo> lista = new List<Hallazgo>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("H.idHallazgo,H.idAuditoria,H.idPreguntaVerificacion,P.descripcionPregunta, ");
            sb.Append("H.tipoHallazgo,H.descripcion,H.fechaCompromiso,H.fechaSeguimiento,H.comentarioSeguimiento,H.idAuditorSeguimiento, ");
            sb.Append("(E.NOMBRES + E.APEPAT + E.APEMAT) AS responsableSeguimiento,H.estado ");
            sb.Append("FROM AC_HALLAZGO H ");
            sb.Append("INNER JOIN AC_PREGUNTA_VERIFICACION P ON H.idAuditoria = P.idAuditoria AND H.idPreguntaVerificacion = P.idPreguntaVerificacion ");
            sb.Append("INNER JOIN AUDITORIA A ON H.idAuditoria = A.CODIGO_AUDITORIA ");
            sb.Append("LEFT JOIN EMPLEADO E ON H.idAuditorSeguimiento = E.CODIGO_EMPLEADO ");
            sb.Append(string.Format("WHERE YEAR(A.FECHA_INICIO) = {0} ", anhoAuditoria));
            sb.Append(string.Format("AND (H.idHallazgo = {0} OR {0} = 0) ", idHallazgo));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(HallazgoDataMap.ObtenerHallazgosSeguimiento(reader));
                    }
                }
            }

            return lista;
        }

        public List<Hallazgo> ObtenerHallazgosSeguimiento_PlanAccion(int idHallazgo)
        {
            List<Hallazgo> lista = new List<Hallazgo>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_HALLAZGOS_SEGUIMIENTO"))
            {
                DB.AddInParameter(command, "@idHallazgo", DbType.Int32, idHallazgo);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(HallazgoDataMap.ObtenerHallazgosSeguimiento_PlanAccion(reader));
                    }
                }
            }

            return lista;
        }

        public void ModificarHallazgoSeguimiento(Hallazgo hallazgo)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_MODIFICAR_HALLAZGO_SEGUIMIENTO"))
            {
                DB.AddInParameter(command, "@idHallazgo", DbType.Int32, hallazgo.IdHallazgo);
                DB.AddInParameter(command, "@fechacompromiso", DbType.DateTime, hallazgo.FechaCompromiso);
                DB.AddInParameter(command, "@causa", DbType.String, hallazgo.Causa);
                DB.AddInParameter(command, "@accioncorrectiva", DbType.String, hallazgo.AccionCorrectiva);
                DB.AddInParameter(command, "@accionpreventiva", DbType.String, hallazgo.AccionPreventiva);
                DB.ExecuteNonQuery(command);
            }
        }

        public bool ValidarUpdate(Int32 IdHallazgo, DateTime dFecCompromiso)
        {
            int count = 0;

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) from AC_HALLAZGO H, AUDITORIA A ");
            sb.Append("WHERE H.idAuditoria=A.CODIGO_AUDITORIA ");
            sb.Append(string.Format(" AND H.idHallazgo={0}", IdHallazgo));
            sb.Append(string.Format("AND CONVERT(VARCHAR(10), A.FECHA_INICIO,112)>= {0} ", dFecCompromiso.ToString("yyyyMMdd")));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {                
                count = Convert.ToInt32(DB.ExecuteScalar(command));
            }
            return count > 0 ? true : false;
        }

        public List<Hallazgo> ObtenerHallazgosPorPreguntaVerificacion(int idAuditoria, int idPreguntaVerificacion)
        {
            List<Hallazgo> lista = new List<Hallazgo>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("H.idHallazgo,H.idAuditoria,H.idPreguntaVerificacion,P.descripcionPregunta, H.tipoHallazgo,H.descripcion, ");
            sb.Append("H.fechaCompromiso,H.fechaSeguimiento,H.comentarioSeguimiento,H.idAuditorSeguimiento, ");
            sb.Append("(E.NOMBRES + E.APEPAT + E.APEMAT) AS responsableSeguimiento,H.estado ");
            sb.Append("FROM AC_HALLAZGO H ");
            sb.Append("INNER JOIN AC_PREGUNTA_VERIFICACION P ON H.idAuditoria = P.idAuditoria AND H.idPreguntaVerificacion = P.idPreguntaVerificacion ");
            sb.Append("LEFT JOIN EMPLEADO E ON H.idAuditorSeguimiento = E.CODIGO_EMPLEADO ");
            sb.Append(string.Format("WHERE (H.idAuditoria = {0}) ", idAuditoria));
            sb.Append(string.Format("AND (H.idPreguntaVerificacion = {0} OR {0} = 0) ", idPreguntaVerificacion));

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(HallazgoDataMap.ObtenerHallazgosSeguimiento(reader));
                    }
                }
            }

            return lista;
        }
    }
}
