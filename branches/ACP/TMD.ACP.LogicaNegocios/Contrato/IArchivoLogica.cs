using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.Entidades;

namespace TMD.ACP.LogicaNegocios.Contrato
{
    public interface IArchivoLogica
    {
        List<Archivo> SelectAll(int idOrigen, char tipoOrigen);
        Archivo ObtenerArchivo(int idArchivo);
        int InsertarArchivo(int idOrigen, char tipoOrigen, byte[] byteArray, string filename, string mimeType);
        void ModificarArchivo(int idArchivo, int idOrigen, string tipoOrigen);
        void EliminarArchivo(int idArchivo);
        void EliminarGrupoArchivos(int idOrigen, string tipoOrigen);
    }
}
