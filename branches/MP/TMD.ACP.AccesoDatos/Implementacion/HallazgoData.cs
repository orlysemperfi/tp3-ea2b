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
    }
}
