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
    public class InformeCambioData : DataBase, IInformeCambioData
    {
        public InformeCambioData(String connectionString)
            : base(connectionString)
        {
        }

        public void Agregar(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        public void Aprobar(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        public List<InformeCambio> ListarPorLineaBase(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        public InformeCambio ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

