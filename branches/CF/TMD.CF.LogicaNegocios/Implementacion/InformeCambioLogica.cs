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

        public List<InformeCambio> ListarPorProyectoLineaBase(InformeCambio informeCambio)
        {
            return _informeCambioData.ListarPorProyectoLineaBase(informeCambio);
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
       
    }
}
