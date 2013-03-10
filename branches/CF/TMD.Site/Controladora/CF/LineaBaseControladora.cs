using System.Collections.Generic;
using System.Linq;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;

namespace TMD.CF.Site.Controladora.CF
{
    /// <summary>
    /// Controladora del paquete Linea Base
    /// </summary>
    class LineaBaseControladora : Base
    {
        private static readonly IProyectoFaseLogica ProyectoFaseLogica = new ProyectoFaseLogica(new ProyectoFaseData(BaseDatos));
        private static readonly IUsuarioLogica UsuarioLogica = new UsuarioLogica(new UsuarioData(BaseDatos));
        private static readonly IProyectoLogica ProyectoLogica = new ProyectoLogica(new ProyectoData(BaseDatos));
        private static readonly ILineaBaseLogica LineaBaseLogica = new LineaBaseLogica(new LineaBaseData(BaseDatos),new LineaBaseElementoConfiguracionData(BaseDatos));
        private static readonly IFaseLogica FaseLogica = new FaseLogica(new FaseData(BaseDatos));
        private static readonly IElementoConfiguracionLogica ElementoConfiguracionLogica = new ElementoConfiguracionLogica(new ElementoConfiguracionData(BaseDatos));
        private static readonly ILineaBaseDetalleLogica LineaBaseDetalleLogica = new LineaBaseDetalleLogica(new LineaBaseElementoConfiguracionData(BaseDatos));

        public static ProyectoFase ProyectoFaseObtenerPorFaseProyecto(int idProyecto, int idFase)
        {
            return ProyectoFaseLogica.ObtenerPorFaseProyecto(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } });
        }

        public static LineaBase LineaBaseObtenerPorProyectoFase(int idProyecto,int idFase)
        {
            return LineaBaseLogica.ObtenerPorProyectoFase(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } });
        }
        public static LineaBase LineaBaseObtenerPorProyectoFaseUsuario(int idProyecto, int idFase,int idUsuario)
        {
            return LineaBaseLogica.ObtenerPorProyectoFase(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } }, new Usuario { Id = idUsuario });
        }

        public static void LineaBaseAgregar(LineaBase lineaBase, List<LineaBaseElementoConfiguracion> listaEcs)
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
            LineaBaseLogica.Agregar(lineaBase);
        }

        public static void LineaBaseActualizar(LineaBase lineaBase, List<LineaBaseElementoConfiguracion> listaEcs)
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

        public static List<Usuario> UsuarioListaPorProyecto(int idProyecto)
        {
            List<Usuario> lista = UsuarioLogica.ListaPorProyecto(new Proyecto { Id = idProyecto });
            lista.Insert(0, new Usuario { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }

        public static List<Proyecto> ListarProyectoPorUsuario(int idUsuario)
        {
            List<Proyecto> lista = ProyectoLogica.ListarPorUsuario(new Usuario { Id = idUsuario });
            lista.Insert(0, new Proyecto { Id = 0 , Nombre = "--Seleccione--" });

            return lista;
        }

        public static Proyecto ProyectoObtenerPorId(int idProyecto)
        {
            return ProyectoLogica.ObtenerPorId(idProyecto);
        }

        public static List<LineaBase> LineaBaseListarPorProyecto(int idProyecto)
        {
            return LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });
        }

        public static List<LineaBase> LineaBaseListarPorProyectoCombo(int idProyecto)
        {
            List<LineaBase> lista = LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });

            lista.Insert(0, new LineaBase { Id = 0, Nombre = "--Seleccione--"});

            return lista;
        }

        public static List<LineaBase> LineaBaseListarPorProyectoUsuario(int idProyecto, int idUsuario)
        {
            return LineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto }, new Usuario { Id = idUsuario });
        }

        public static List<Fase> ListarFasePorProyecto(int idProyecto,bool todos)
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

        public static List<ElementoConfiguracion> ElementoConfiguracionListarPorFase(int idfase)
        {
            return ElementoConfiguracionLogica.ListarPorFase(new Fase { Id = idfase });
        }

        public static List<LineaBaseElementoConfiguracion> ElementoConfiguracionListarPorLineaBase(int idLineaBase)
        {
            var lista = LineaBaseDetalleLogica.ListarPorLineaBase(new LineaBase { Id =  idLineaBase});

            lista.Insert(0, new LineaBaseElementoConfiguracion { Id = 0, NombreEcs = "--Seleccione--" });

            return lista;
        }

        public static void ActualizarArchivo(int idLineaBaseDetalle, string nombreArchivo, byte[] data)
        {
            string extension = string.IsNullOrEmpty(nombreArchivo) ? "" : System.IO.Path.GetExtension(nombreArchivo).Substring(1, 3);
            LineaBaseLogica.ActualizarArchivo(new LineaBaseElementoConfiguracion { Id = idLineaBaseDetalle, Extension = extension, Nombre = nombreArchivo, Data = data });
        }

        public static LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            return LineaBaseLogica.ObtenerArchivo(id);
        }
    }
}