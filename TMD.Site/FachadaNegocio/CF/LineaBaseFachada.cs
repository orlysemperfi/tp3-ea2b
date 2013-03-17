using System.Collections.Generic;
using System.Linq;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;
using System.Configuration;
using TMD.Core.Caching;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    /// <summary>
    /// Controladora del paquete Linea Base
    /// </summary>
    public class LineaBaseFachada
    {
        public IProyectoFaseLogica ProyectoFaseLogica { get; set; }
        public IUsuarioLogica UsuarioLogica { get; set; }
        public IUsuarioProyectoLogica UsuarioProyectoLogica { get; set; }
        public IProyectoLogica ProyectoLogica { get; set; }
        public ILineaBaseLogica LineaBaseLogica { get; set; }
        public IFaseLogica FaseLogica { get; set; }
        public IElementoConfiguracionLogica ElementoConfiguracionLogica { get; set; }
        public ILineaBaseDetalleLogica LineaBaseDetalleLogica { get; set; }

        public LineaBaseFachada()
        {
        }
        
        public ProyectoFase ProyectoFaseObtenerPorFaseProyecto(int idProyecto, int idFase)
        {
            return ProyectoFaseLogica.ObtenerPorFaseProyecto(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } });
        }

        public LineaBase LineaBaseObtenerPorProyectoFase(int idProyecto,int idFase)
        {
            return LineaBaseLogica.ObtenerPorProyectoFase(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } });
        }
        public LineaBase LineaBaseObtenerPorProyectoFaseUsuario(int idProyecto, int idFase,int idUsuario)
        {
            return LineaBaseLogica.ObtenerPorProyectoFase(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } }, new Usuario { Id = idUsuario });
        }

        public void LineaBaseAgregar(LineaBase lineaBase, List<LineaBaseElementoConfiguracion> listaEcs)
        {
            listaEcs.ForEach(x =>
                {
                    x.Version = new Entidades.Version
                    {
                        Mayor = 1,
                        Menor = 0
                    };
                    x.LineaBase = lineaBase;
                }
            );

            lineaBase.LineaBaseECS = listaEcs;
            LineaBaseLogica.Agregar(lineaBase, null);
        }

        public void LineaBaseActualizar(LineaBase lineaBase, List<LineaBaseElementoConfiguracion> listaEcs)
        {
            listaEcs.ForEach(x =>
                {
                    x.Version = new Entidades.Version
                    {
                        Mayor = 1,
                        Menor = 0
                    };
                    x.LineaBase = lineaBase;
                }
            );

            lineaBase.LineaBaseECS = listaEcs;
            LineaBaseLogica.Actualizar(lineaBase);
        }

        public List<Usuario> UsuarioListaPorProyecto(int idProyecto)
        {
            List<Usuario> lista = UsuarioLogica.ListaPorProyecto(new Proyecto { Id = idProyecto });
            lista.Insert(0, new Usuario { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }

        public List<Proyecto> ListarProyectoPorUsuario(int idUsuario)
        {
            List<Proyecto> lista = ProyectoLogica.ListarPorUsuario(new Usuario { Id = idUsuario });
            lista.Insert(0, new Proyecto { Id = 0 , Nombre = "--Seleccione--" });

            return lista;
        }

        public Proyecto ProyectoObtenerPorId(int idProyecto)
        {
            return ProyectoLogica.ObtenerPorId(idProyecto);
        }

        public List<LineaBase> LineaBaseListarPorProyecto(int idProyecto)
        {
            return LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });
        }

        public List<LineaBase> LineaBaseListarPorProyectoCombo(int idProyecto)
        {
            List<LineaBase> lista = LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });

            lista.Insert(0, new LineaBase { Id = 0, Nombre = "--Seleccione--"});

            return lista;
        }

        public List<LineaBase> LineaBaseListarPorProyectoUsuario(int idProyecto, int idUsuario)
        {
            return LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto }, new Usuario { Id = idUsuario });
        }

        public List<Fase> ListarFasePorProyecto(int idProyecto,bool todos)
        {
            List<Fase> lista = FaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });
            lista.Insert(0, new Fase { Id = 0, Nombre = "--Seleccione--", LineaBase = new LineaBase { Id = 0 } });

            if (todos)
            {
                return lista;
            }
            else
            {
                return lista.Where(x => x.LineaBase.Id == 0).ToList();
            }
        }

        public List<ElementoConfiguracion> ElementoConfiguracionListarPorFase(int idfase)
        {
            return ElementoConfiguracionLogica.ListarPorFase(new Fase { Id = idfase });
        }

        public List<LineaBaseElementoConfiguracion> ElementoConfiguracionListarPorLineaBase(int idLineaBase)
        {
            var lista = LineaBaseDetalleLogica.ListarPorLineaBase(new LineaBase { Id =  idLineaBase});

            lista.Insert(0, new LineaBaseElementoConfiguracion { Id = 0, NombreEcs = "--Seleccione--" });

            return lista;
        }

        public void ActualizarArchivo(int idLineaBaseDetalle, string nombreArchivo, byte[] data)
        {
            string extension = string.IsNullOrEmpty(nombreArchivo) ? "" : System.IO.Path.GetExtension(nombreArchivo).Substring(1, 3);
            LineaBaseLogica.ActualizarArchivo(new LineaBaseElementoConfiguracion { Id = idLineaBaseDetalle, Extension = extension, Nombre = nombreArchivo, Data = data });
        }

        public LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            return LineaBaseLogica.ObtenerArchivo(id);
        }
    }
}