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
    /// <summary>
    /// Implmentacion  del Acceso a datos de la entidad informe de cambio.
    /// </summary>
    public class InformeCambioData : DataBase, IInformeCambioData
    {
        public InformeCambioData(String connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Agrega un informe de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto informe a agregar</param>
        public void Agregar(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Aprueba un informe de cambio
        /// </summary>
        /// <param name="informeCambio">Objeto informe a aprobar</param>
        public void Aprobar(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista los informes de una linea base
        /// </summary>
        /// <param name="informeCambio">Linea Base</param>
        /// <returns>Lista informes de cambio</returns>
        public List<InformeCambio> ListarPorLineaBase(InformeCambio informeCambio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene un informe de cambio por el id
        /// </summary>
        /// <param name="id">Id informe</param>
        /// <returns>Informe de cambio</returns>
        public InformeCambio ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

