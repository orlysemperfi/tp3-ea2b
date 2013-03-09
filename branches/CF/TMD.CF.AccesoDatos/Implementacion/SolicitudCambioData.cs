using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.AccesoDatos.Core;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;
using System.Data.Common;
using System.Data;
using TMD.CF.AccesoDatos.Map;

namespace TMD.CF.AccesoDatos.Implementacion
{
    public class SolicitudCambioData : DataBase, ISolicitudCambioData
    {

        public SolicitudCambioData(String connectionString)
            : base(connectionString)
        {
        }

        public void Agregar(Entidades.SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }

        public void Aprobar(Entidades.SolicitudCambio solicitudCambio)
        {
            using (DbCommand command = DB.GetStoredProcCommand("USP_SOLICITUD_CAMBIO_ESTADO_UPD"))
            {
                DB.AddInParameter(command, "@CODIGO", DbType.Int32, solicitudCambio.codigo);

                if (solicitudCambio.Estado == 3)
                {
                    using (DbCommand command1 = DB.GetStoredProcCommand("USP_SOLICITUD_CAMBIO_MOTIVO_UPD"))
                    {
                        DB.AddInParameter(command1, "@CODIGO", DbType.Int32, solicitudCambio.codigo);
                        DB.AddInParameter(command1, "@MOTIVO", DbType.String, solicitudCambio.Motivo);
                        DB.ExecuteNonQuery(command1);
                    }
                }

                DB.AddInParameter(command, "@ESTADO", DbType.Int32, solicitudCambio.Estado);
                DB.ExecuteNonQuery(command);
            }
            throw new NotImplementedException();
        }


        public List<Entidades.SolicitudCambio> ListarPorProyectoLineaBase(Entidades.SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }


        public Entidades.SolicitudCambio ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
