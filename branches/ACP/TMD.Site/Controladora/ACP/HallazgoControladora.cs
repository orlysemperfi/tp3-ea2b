﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.ACP.AccesoDatos.Implementacion;
using TMD.Entidades;

namespace TMD.Site.Controladora.ACP
{
    class HallazgoControladora : Base
    {
        private static readonly IArchivoLogica _archivoLogica = new ArchivoLogica();
        private static readonly IHallazgoLogica _hallazgoLogica = new HallazgoLogica();
        private static readonly IEmpleadoLogica _empleadoLogica = new EmpleadoLogica();

        public static Archivo ObtenerArchivo(int idArchivo)
        {
            return _archivoLogica.ObtenerArchivo(idArchivo);
        }

        public static int InsertarArchivo(int idOrigen, char tipoOrigen, byte[] byteArray, string filename, string mimeType)
        {
            return _archivoLogica.InsertarArchivo(idOrigen, tipoOrigen, byteArray, filename, mimeType);
        }

        public static void ModificarArchivo(int idArchivo, int idOrigen, string tipoOrigen)
        {
            _archivoLogica.ModificarArchivo(idArchivo, idOrigen, tipoOrigen);
        }

        public static void EliminarArchivo(int idArchivo)
        {
            _archivoLogica.EliminarArchivo(idArchivo);
        }

        public static void EliminarGrupoArchivos(int idOrigen, string tipoOrigen)
        {
            _archivoLogica.EliminarGrupoArchivos(idOrigen, tipoOrigen);
        }

        public static EmpleadoEntidad ObtenerEmpleado(int idEmpleado)
        {
            return _empleadoLogica.ObtenerEmpleado(idEmpleado);
        }

        public static List<EmpleadoEntidad> ListarEmpleados()
        {
            return _empleadoLogica.ListarEmpleados();
        }

        public static List<Hallazgo> ObtenerHallazgo(Hallazgo filtro)
        {
            return _hallazgoLogica.Obtener(filtro);
        }

        public static int AgregarHallazgo(Hallazgo hallazgo)
        {
            return _hallazgoLogica.Agregar(hallazgo);
        }

        public static string EliminarHallazgo(int hallazgo)
        {
            return _hallazgoLogica.Eliminar(hallazgo);
        }

        public static string ModificarrHallazgo(Hallazgo hallazgo)
        {
            return _hallazgoLogica.Modificar(hallazgo);
        }
    }
}