using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.CF.LogicaNegocios.Error;
using TMD.CF.AccesoDatos.Contrato;
using TMD.Core;

namespace TMD.CF.LogicaNegocios.Implementacion
{
    //PATRON: DECORADOR
    public class OrdenCambioValidacionLogica : IOrdenCambioLogica
    {
        private readonly IOrdenCambioLogica _ordenCambioLogica;
        private readonly IOrdenCambioData _ordenCambioData;

        public OrdenCambioValidacionLogica(IOrdenCambioLogica ordenCambioLogica,IOrdenCambioData ordenCambioData)
        {
            _ordenCambioLogica = ordenCambioLogica;
            _ordenCambioData = ordenCambioData;
        }

        public void Agregar(Entidades.OrdenCambio ordenCambio)
        {

            if (_ordenCambioData.ObtenerPorInforme(ordenCambio.InformeCambio.Id) != null)
            {
                //REGLA: No puede agregarse mas de una orden de cambio a un informe.
                throw new ReglaNegocioException("No se puede agregar más de una orden a un informe.");
            }
            
            //REGLA: Solo se puede agregar una orden de cambio a un proyecto que no haya finalizado.
            _ordenCambioLogica.Agregar(ordenCambio);
        }

        public List<Entidades.OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return _ordenCambioLogica.ListarPorProyectoLBase(codigoProyecto,codigoLineaBase);
        }

        public Entidades.OrdenCambio ObtenerPorId(int id)
        {
            return _ordenCambioLogica.ObtenerPorId(id);
        }

        public OrdenCambio ObtenerPorInforme(int id)
        {
            return _ordenCambioData.ObtenerPorInforme(id);
        }

        public Entidades.OrdenCambio ObtenerArchivo(int id)
        {
            return _ordenCambioLogica.ObtenerArchivo(id);
        }

        public void ActualizarArchivo(Entidades.OrdenCambio ordenCambio)
        {
            _ordenCambioLogica.ActualizarArchivo(ordenCambio);
        }
    }
}
