using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.CF.LogicaNegocios.Contrato
{
    public interface IInformeCambioLogica
    {
        void Agregar(InformeCambio informeCambio);
        void Aprobar(InformeCambio informeCambio);
        List<InformeCambio> ListarPorLineaBase(InformeCambio informeCambio);
        InformeCambio ObtenerPorId(int id);
    }
}
