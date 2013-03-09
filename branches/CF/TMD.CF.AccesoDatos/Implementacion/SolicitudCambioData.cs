using System;
using System.Collections.Generic;
using TMD.CF.AccesoDatos.Core;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using System.Data.Common;
using System.Data;

namespace TMD.CF.AccesoDatos.Implementacion
{
    public class SolicitudCambioData : DataBase, ISolicitudCambioData
    {

        public SolicitudCambioData(String connectionString)
            : base(connectionString)
        {
        }

        public void Agregar(SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("dbo.USP_SOLICITUD_CAMBIO_INS"))
            {
                DB.AddInParameter(command, "@NOMBRE", DbType.String, solicitudCambio.Nombre);
                DB.AddInParameter(command, "@CODIGO_PROYECTO", DbType.Int32, solicitudCambio.ProyectoFase.Proyecto.Id);
                DB.AddInParameter(command, "@CODIGO_LINEABASE", DbType.Int32, solicitudCambio.LineaBase.Id);
                DB.AddInParameter(command, "@CODIGO_USUARIO", DbType.Int32, solicitudCambio.Usuario.Id);
                DB.AddInParameter(command, "@FECHA_REGISTRO", DbType.DateTime, DateTime.Now);
                DB.AddInParameter(command, "@ESTADO", DbType.Int32, solicitudCambio.Estado);
                DB.AddInParameter(command, "@CODIGO_ECS", DbType.Int32, solicitudCambio.ElementoConfiguracion.Id);
                DB.AddInParameter(command, "@PRIORIDAD", DbType.Int32, solicitudCambio.Prioridad);

                DB.AddOutParameter(command, "@CODIGO", DbType.Int32, 4);

                DB.ExecuteNonQuery(command);

                solicitudCambio.Id = Convert.ToInt32(DB.GetParameterValue(command, "@CODIGO"));
            }
        }

        public void Aprobar(SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("USP_SOLICITUD_CAMBIO_ESTADO_UPD"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, solicitudCambio.Id);

                if (solicitudCambio.Estado == 3)
                {
                    using (DbCommand command1 = DB.GetStoredProcCommand("USP_SOLICITUD_CAMBIO_MOTIVO_UPD"))
                    {
                        DB.AddInParameter(command1, "@CODIGO", DbType.Int32, solicitudCambio.Id);
                        DB.AddInParameter(command1, "@MOTIVO", DbType.String, solicitudCambio.Motivo);
                        DB.ExecuteNonQuery(command1);
                    }
                }

                DB.AddInParameter(command, "@ESTADO", DbType.Int32, solicitudCambio.Estado);
                DB.ExecuteNonQuery(command);
            }
            throw new NotImplementedException();
        }


        public List<SolicitudCambio> ListarPorProyectoLineaBase(SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }


        public SolicitudCambio ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
