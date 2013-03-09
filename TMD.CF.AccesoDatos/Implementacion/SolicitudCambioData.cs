using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.AccesoDatos.Contrato;
using TMD.CF.AccesoDatos.Core;

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
            throw new NotImplementedException();
        }

        public List<Entidades.SolicitudCambio> ListarPorProyectoLineaBase(Entidades.SolicitudCambio solicitudCambio)
        {
            throw new NotImplementedException();
        }
    }
}
