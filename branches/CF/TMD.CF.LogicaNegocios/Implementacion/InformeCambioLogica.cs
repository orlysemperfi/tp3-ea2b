using System.Collections.Generic;
using System.Transactions;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    /// <summary>
    /// Implementa la Logica de Negocios de la entidad Informe de cambio
    /// </summary>
    public class InformeCambioLogica : IInformeCambioLogica
    {
        private readonly IInformeCambioData _informeCambioData;

        public InformeCambioLogica(IInformeCambioData informeCambioData)
        {
            _informeCambioData = informeCambioData;
        }

        public void Agregar(InformeCambio informeCambio)
        {
            _informeCambioData.Agregar(informeCambio);
        }

        public void Aprobar(InformeCambio informeCambio)
        {
            _informeCambioData.Aprobar(informeCambio);
        }

        public List<InformeCambio> ListarPorProyectoLineaBase(InformeCambio informeCambio, int conNull)
        {
            return _informeCambioData.ListarPorProyectoLineaBase(informeCambio, conNull);
        }

        public InformeCambio ObtenerPorId(int id)
        {
            InformeCambio informeCambio = null;

            using (var scope = new TransactionScope())
            {
                informeCambio = _informeCambioData.ObtenerPorId(id);
                scope.Complete();
            }

            return informeCambio;
        }

        /// <summary>
        /// Obtiene el archivo de un informe de cambio
        /// </summary>
        /// <param name="id">Id del informe de cambio</param>
        /// <returns>Archivo del informe de cambio</returns>
        public InformeCambio ObtenerArchivo(int id)
        {
            InformeCambio informeCambio = null;

            using (var scope = new TransactionScope())
            {
                informeCambio = _informeCambioData.ObtenerArchivo(id);
                scope.Complete();
            }

            return informeCambio;
        }

        /// <summary>
        /// Actualiza el archivo de un informe de cambio
        /// </summary>
        /// <param name="solicitudCambio">Objeto solicutd a actualziar</param>
        public void ActualizarArchivo(InformeCambio informeCambio)
        {
            using (var scope = new TransactionScope())
            {
                _informeCambioData.ActualizarArchivo(informeCambio);
                scope.Complete();
            }
        }
       
    }
}
