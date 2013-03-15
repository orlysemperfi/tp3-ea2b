using System.Collections.Generic;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;
using TMD.Core;
using System.Configuration;

namespace TMD.CF.Site.Controladora.CF
{
    class InformeCambioFachada
    {
        private readonly IInformeCambioLogica InformeCambioLogica;

        public InformeCambioFachada()
        {
            string baseDatos = ConfigurationManager.AppSettings["BaseDatos"];
            InformeCambioLogica = new InformeCambioLogica(new InformeCambioData(baseDatos));
        }

 
        public List<InformeCambio> ListarPorProyectoLineaBase(int idProyecto, int idLineaBase, int estado)
        {
            return
                InformeCambioLogica.ListarPorProyectoLineaBase(
                    new InformeCambio
                    {
                        Solicitud = new SolicitudCambio { ProyectoFase = new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto } }, LineaBase = new LineaBase { Id = idLineaBase} },                       
                    });
        }
    }
}