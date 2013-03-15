using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;

namespace TMD.CF.Site.Controladora
{
    /// <summary>
    /// Controladora del paquete Linea Base
    /// </summary>
    class LineaBaseControladora : Base
    {
        private static readonly IProyectoFaseLogica _proyectoFaseLogica = new ProyectoFaseLogica(new ProyectoFaseData(BaseDatos));
        private static readonly IUsuarioLogica _usuarioLogica = new UsuarioLogica(new UsuarioData(BaseDatos));
        private static readonly IProyectoLogica _proyectoLogica = new ProyectoLogica(new ProyectoData(BaseDatos));
        private static readonly ILineaBaseLogica _lineaBaseLogica = new LineaBaseLogica(new LineaBaseData(BaseDatos),new LineaBaseElementoConfiguracionData(BaseDatos));
        private static readonly IFaseLogica _faseLogica = new FaseLogica(new FaseData(BaseDatos));
        private static readonly IElementoConfiguracionLogica _elementoConfiguracionLogica = new ElementoConfiguracionLogica(new ElementoConfiguracionData(BaseDatos));

        public static ProyectoFase ProyectoFaseObtenerPorFaseProyecto(int idProyecto, int idFase)
        {
            return _proyectoFaseLogica.ObtenerPorFaseProyecto(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } });
        }

        public static LineaBase LineaBaseObtenerPorProyectoFase(int idProyecto,int idFase)
        {
            return _lineaBaseLogica.ObtenerPorProyectoFase(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } });
        }
        public static LineaBase LineaBaseObtenerPorProyectoFaseUsuario(int idProyecto, int idFase,int idUsuario)
        {
            return _lineaBaseLogica.ObtenerPorProyectoFase(new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto }, Fase = new Fase { Id = idFase } }, new Usuario { Id = idUsuario });
        }

        public static void LineaBaseAgregar(LineaBase lineaBase, List<LineaBaseElementoConfiguracion> listaECS)
        {
            listaECS.ForEach(x =>
                {
                    x.Version = new Entidades.Version
                    {
                        Mayor = 1,
                        Menor = 0
                    };
                    x.LineaBase = lineaBase;
                }
            );

            lineaBase.LineaBaseECS = listaECS;
            _lineaBaseLogica.Agregar(lineaBase);
        }

        public static void LineaBaseActualizar(LineaBase lineaBase, List<LineaBaseElementoConfiguracion> listaECS)
        {
            listaECS.ForEach(x =>
                {
                    x.Version = new Entidades.Version
                    {
                        Mayor = 1,
                        Menor = 0
                    };
                    x.LineaBase = lineaBase;
                }
            );

            lineaBase.LineaBaseECS = listaECS;
            _lineaBaseLogica.Actualizar(lineaBase);
        }

        public static List<Usuario> UsuarioListaPorProyecto(int idProyecto)
        {
            List<Usuario> lista = _usuarioLogica.ListaPorProyecto(new Proyecto { Id = idProyecto });
            lista.Insert(0, new Usuario { Id = 0, Nombre = "--Seleccione--" });

            return lista;
        }

        public static List<Proyecto> ListarProyectoPorUsuario(int idUsuario)
        {
            List<Proyecto> lista = _proyectoLogica.ListarPorUsuario(new Usuario { Id = idUsuario });
            lista.Insert(0, new Proyecto { Id = 0 , Nombre = "--Seleccione--" });

            return lista;
        }

        public static Proyecto ProyectoObtenerPorId(int idProyecto)
        {
            return _proyectoLogica.ObtenerPorId(idProyecto);
        }

        public static List<LineaBase> LineaBaseListarPorProyecto(int idProyecto)
        {
            return _lineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });
        }

        public static List<LineaBase> LineaBaseListarPorProyectoUsuario(int idProyecto, int idUsuario)
        {
            return _lineaBaseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto }, new Usuario { Id = idUsuario });
        }

        public static List<Fase> ListarFasePorProyecto(int idProyecto,bool todos)
        {
            List<Fase> lista = _faseLogica.ListarPorProyecto(new Proyecto { Id = idProyecto });
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
            return _elementoConfiguracionLogica.ListarPorFase(new Fase { Id = idfase });
        }

        public static void ActualizarArchivo(int idLineaBaseDetalle, string nombreArchivo, byte[] data)
        {
            string extension = System.IO.Path.GetExtension(nombreArchivo).Substring(1, 3); ;
            _lineaBaseLogica.ActualizarArchivo(new LineaBaseElementoConfiguracion { Id = idLineaBaseDetalle, Extension = extension, Nombre = nombreArchivo, Data = data });
        }

        public static LineaBaseElementoConfiguracion ObtenerArchivo(int id)
        {
            return _lineaBaseLogica.ObtenerArchivo(id);
        }
    }
}