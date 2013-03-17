﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.LogicaNegocios.Contrato;
using TMD.CF.LogicaNegocios.Implementacion;
using TMD.CF.AccesoDatos.Implementacion;
using TMD.Entidades;
using System.Configuration;
using TMD.Core;

namespace TMD.CF.Site.FachadaNegocio.CF
{
    class OrdenCambioControladora
    {
        private readonly IOrdenCambioLogica ordenCambioLogica;
        private readonly IUsuarioLogica usuarioLogica;
        private readonly IProyectoLogica ProyectoLogica;
        private readonly ILineaBaseLogica LineaBaseLogica;
        private readonly IInformeCambioLogica InformeCambioLogica;

        public OrdenCambioControladora()
        {
            string baseDatos = ConfigurationManager.AppSettings["BaseDatos"];

            ordenCambioLogica = new OrdenCambioLogica(new OrdenCambioData(baseDatos));
            usuarioLogica = new UsuarioLogica(new UsuarioData(baseDatos));
            ProyectoLogica = new ProyectoLogica(new ProyectoData(baseDatos));
            InformeCambioLogica = new InformeCambioLogica(new InformeCambioData(baseDatos));
            LineaBaseLogica = new LineaBaseLogica(new LineaBaseData(baseDatos),null,null,null);
        }

        public List<OrdenCambio> ListarPorProyectoLBase(int codigoProyecto, int codigoLineaBase)
        {
            return ordenCambioLogica.ListarPorProyectoLBase(codigoProyecto, codigoLineaBase);
        }

        public void Agregar(OrdenCambio ordenCambio)
        {
            ordenCambioLogica.Agregar(ordenCambio);
        }

        public List<Usuario> ListaPorRol(String rol)
        {
            List<Usuario> lista = usuarioLogica.ListaPorRol(rol);
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
            return
                InformeCambioLogica.ListarPorProyectoLineaBase(
                    new InformeCambio
                    {
                        Solicitud = new SolicitudCambio { ProyectoFase = new ProyectoFase { Proyecto = new Proyecto { Id = idProyecto } }, LineaBase = new LineaBase { Id = idLineaBase } },
                    });
        }

        public OrdenCambio ObtenerPorId(int id)
        {
            return ordenCambioLogica.ObtenerPorId(id);
        }

        public void ActualizarArchivo(int idOrden, string nombreArchivo, byte[] data)
        {
            string extension = string.IsNullOrEmpty(nombreArchivo) ? "" : System.IO.Path.GetExtension(nombreArchivo).Substring(1, 3);
            ordenCambioLogica.ActualizarArchivo(new OrdenCambio { Id = idOrden, Data = data, NombreArchivo = nombreArchivo, Extension = extension });
        }

        public OrdenCambio ObtenerArchivo(int idOrdenCambio)
        {
            return ordenCambioLogica.ObtenerArchivo(idOrdenCambio);
        }
    }
}