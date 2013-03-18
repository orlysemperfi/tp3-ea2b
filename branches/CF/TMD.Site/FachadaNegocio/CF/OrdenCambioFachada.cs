using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.Entidades;
using System.Configuration;
using TMD.Core;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    public class OrdenCambioFachada
    {
        public IOrdenCambioLogica OrdenCambioLogica { get; set; }
        public IUsuarioLogica UsuarioLogica { get; set; }
        public IProyectoLogica ProyectoLogica { get; set; }
        public ILineaBaseLogica LineaBaseLogica { get; set; }
        public IInformeCambioLogica InformeCambioLogica { get; set; }

        public OrdenCambioFachada()
        {
        }

        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return OrdenCambioLogica.ListarPorProyectoLBase(codigoProyecto, codigoLineaBase);
        }

        public void Agregar(OrdenCambio ordenCambio)
        {
            OrdenCambioLogica.Agregar(ordenCambio);
        }

        public List<Usuario> ListaPorRol(String rol)
        {
            List<Usuario> lista = UsuarioLogica.ListaPorRol(rol);
            lista.Insert(0, new Usuario { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }

        public List<Proyecto> ListarProyectoPorUsuario(int idUsuario)
        {
            List<Proyecto> lista = ProyectoLogica.ListarPorUsuario(new Usuario { Id = idUsuario });
            lista.Insert(0, new Proyecto { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }

        public List<Parametro> ListarEstado()
        {
            return
                new List<Parametro>
                    {
                        new Parametro{Id = 0, Nombre = "--Seleccione--"},
                        new Parametro{Id = Constantes.EstadoAprobado, Nombre = "Aprobado"},
                        new Parametro{Id = Constantes.EstadoDesaprobado, Nombre = "Desaprobado"},
                        new Parametro{Id = Constantes.EstadoPendiente, Nombre = "Pendiente"}
                    };
        }

        public List<Parametro> ListarPrioridad()
        {
            return
                new List<Parametro>
                    {
                        new Parametro{Id = 0, Nombre = "--Seleccione--"},
                        new Parametro{Id = Constantes.PrioridadBaja, Nombre = "Baja"},
                        new Parametro{Id = Constantes.PrioridadMedia, Nombre = "Media"},
                        new Parametro{Id = Constantes.PrioridadAlta, Nombre = "Alta"}
                    };
        }

        public List<LineaBase> LineaBaseListarPorProyectoCombo(int idProyecto)
        {
            List<LineaBase> lista = LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });

            lista.Insert(0, new LineaBase { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }

        public List<InformeCambio> ListarInformePorProyectoLineaBase(int idProyecto, int idLineaBase, int estado)
        {

            List<InformeCambio> lista = InformeCambioLogica.ListarPorProyectoLineaBase(new InformeCambio {Solicitud = new SolicitudCambio { ProyectoFase = new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto } }, LineaBase = new LineaBase { Id = idLineaBase } },},1);

            lista.Insert(0, new InformeCambio { Id = 0, Nombre = "--Seleccione--" });
            
            return lista;
        }

        public OrdenCambio ObtenerPorId(int id)
        {
            return OrdenCambioLogica.ObtenerPorId(id);
        }

        public void ActualizarArchivo(int idOrden, string nombreArchivo, byte[] data)
        {
            string extension = string.IsNullOrEmpty(nombreArchivo) ? "" : System.IO.Path.GetExtension(nombreArchivo).Substring(1, 3);
            OrdenCambioLogica.ActualizarArchivo(new OrdenCambio { Id = idOrden, Data = data, NombreArchivo = nombreArchivo, Extension = extension });
        }

        public OrdenCambio ObtenerArchivo(int idOrdenCambio)
        {
            return OrdenCambioLogica.ObtenerArchivo(idOrdenCambio);
        }
    }
}