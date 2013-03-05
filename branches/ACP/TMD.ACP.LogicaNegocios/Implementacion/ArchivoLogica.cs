using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class ArchivoLogica : IArchivoLogica
    {
        private readonly DLArchivo _objData;

        public ArchivoLogica()
        {
            _objData = new DLArchivo("TMD");
        }

        public int InsertarArchivo(int idOrigen, char tipoOrigen, byte[] byteArray, string filename, string mimeType)
        {
            Archivo oArchivo = new Archivo() 
            {
                idOrigen = idOrigen,
                tipoOrigen = tipoOrigen.ToString(),
                dataBinaria = byteArray,
                nombreArchivo = filename,
                mimeType = mimeType
            };

            return _objData.InsertarArchivo(oArchivo);
        }

        public void ModificarArchivo(int idArchivo, int idOrigen, string tipoOrigen)
        {
            _objData.ModificarArchivo(idArchivo, idOrigen, tipoOrigen);
        }

        public Archivo ObtenerArchivo(int idArchivo)
        {
            return _objData.ObtenerArchivo(idArchivo);
        }

        public List<Archivo> SelectAll(int idOrigen, char tipoOrigen)
        {
            return _objData.SelectAll(idOrigen, tipoOrigen);
        }
        
        public void EliminarArchivo(int idArchivo)
        {
            _objData.EliminarArchivo(idArchivo);
        }
        
        public void EliminarGrupoArchivos(int idOrigen, string tipoOrigen)
        {
            _objData.EliminarGrupoArchivos(idOrigen, tipoOrigen);
        }
                        
    }
}
