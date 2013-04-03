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
    public class PreguntaVerificacionData : DataBase, IPreguntaVerificacionData
    {
        public PreguntaVerificacionData(String connectionString)
            : base(connectionString)
        {
        }

        public List<PreguntaVerificacion> Obtener(int idAuditoria, int idNorma, int idCapitulo)
        {
            List<PreguntaVerificacion> lista = new List<PreguntaVerificacion>();

            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_OBTENER_CHECKLIST"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.Int32, idAuditoria);
                DB.AddInParameter(command, "@idNorma", DbType.Int32, idNorma);
                DB.AddInParameter(command, "@idCapitulo", DbType.Int32, idCapitulo);

                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(PreguntaVerificacionDataMap.Select(reader));
                    }
                }
            }

            return lista;
        }


        public void Modificar(PreguntaVerificacion item)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.ACP_SP_MODIFICAR_PREGUNTA_VERIFICACION"))
            {
                DB.AddInParameter(command, "@idAuditoria", DbType.String, item.ObjAuditoria.IdAuditoria);
                DB.AddInParameter(command, "@idPreguntaVerificacion", DbType.String, item.idPreguntaVerificacion);
                DB.AddInParameter(command, "@respuesta", DbType.Int32, item.Respuesta);
                DB.AddInParameter(command, "@sustento", DbType.String, item.Sustento);
                DB.AddInParameter(command, "@porcentaje", DbType.Double, item.Porcentaje);

                DB.ExecuteNonQuery(command);
            }
        }

        public void GrabarPreguntaVerificacion(PreguntaVerificacion ePreguntaVerificacion)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO AC_PREGUNTA_VERIFICACION (idAuditoria,idPreguntaVerificacion,descripcionPregunta,idNorma,idCapitulo) ");            
            sb.Append(string.Format("VALUES ({0},{1},'{2}',{3},{4}) ", ePreguntaVerificacion.ObjAuditoria.IdAuditoria, ePreguntaVerificacion.idPreguntaVerificacion, ePreguntaVerificacion.DescripcionPregunta, ePreguntaVerificacion.IdNorma,ePreguntaVerificacion.IdCapitulo));            
            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                DB.ExecuteNonQuery(command);
            }
        }




        public List<PreguntaVerificacion> ObtenerListaPreguntaVerificacionPorAuditoria(int idAuditoria)
        {
            List<PreguntaVerificacion> lista = new List<PreguntaVerificacion>();

            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT ");
            sb.Append("idAuditoria,idPreguntaVerificacion,descripcionPregunta,idNorma,idCapitulo,respuesta,sustento,porcentaje ");
            sb.Append("FROM AC_PREGUNTA_VERIFICACION ");
            sb.Append(string.Format("WHERE idAuditoria = {0} ", idAuditoria));          

            using (DbCommand command = DB.GetSqlStringCommand(sb.ToString()))
            {
                using (IDataReader reader = DB.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        lista.Add(PreguntaVerificacionDataMap.SelectPreguntaVerificacionPorAuditoria(reader));
                    }
                }
            }

            return lista;
        }

        

    }
}
