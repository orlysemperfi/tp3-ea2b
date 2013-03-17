using System.Collections.Generic;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.Entidades;
using TMD.Core;
using System.Configuration;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    public class InformeCambioFachada
    {
        public IInformeCambioLogica InformeCambioLogica { get; set; }

        public InformeCambioFachada()
        {
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

        public void Agregar(InformeCambio informeCambio)
        {
            InformeCambioLogica.Agregar(informeCambio);
        }

        public void Aprobar(int idInforme, int idEstado, string motivo)
        {
            InformeCambioLogica.Aprobar(new InformeCambio { Id = idInforme, Estado = idEstado, Motivo = motivo });
        }

        public void ActualizarArchivo(int idInforme, string nombreArchivo, byte[] data)
        {
            string extension = string.IsNullOrEmpty(nombreArchivo) ? "" : System.IO.Path.GetExtension(nombreArchivo).Substring(1, 3);
            InformeCambioLogica.ActualizarArchivo(new InformeCambio { Id = idInforme, Data = data, NombreArchivo = nombreArchivo, Extension = extension });
        }

        public InformeCambio ObtenerArchivo(int idInformeCambio)
        {
            return InformeCambioLogica.ObtenerArchivo(idInformeCambio);
        }
    }
}