using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.Entidades;
using TMD.ACP.AccesoDatos.Contrato;
using TMD.ACP.AccesoDatos.Implementacion;
using TMD.Core;

namespace TMD.ACP.LogicaNegocios.Implementacion
{
    public class HallazgoLogica : IHallazgoLogica
    {
        private readonly IHallazgoData _objData;

        public HallazgoLogica()
        {
            _objData = new HallazgoData("TMD");
        }

        public int Agregar(Hallazgo hallazgo)
        {
            hallazgo.Estado = EstadoHallazgo.Creado;
            return _objData.Agregar(hallazgo);
        }

        public List<Hallazgo> Obtener(Hallazgo filtro)
        {
            return _objData.Obtener(filtro);
        }
        
        public string Modificar(Hallazgo hallazgo)
        {
            string strRespuesta = string.Empty;

            List<Hallazgo> lstBusquedaHallazgo = _objData.Obtener(new Hallazgo() { IdHallazgo = hallazgo.IdHallazgo, IdAuditoria = null });

            if (lstBusquedaHallazgo.Count > 0)
            {
                if (lstBusquedaHallazgo[0].Estado == EstadoHallazgo.Creado)
                {
                    if (String.IsNullOrWhiteSpace(hallazgo.TipoHallazgo)) hallazgo.TipoHallazgo = null;
                    if (String.IsNullOrWhiteSpace(hallazgo.Descripcion)) hallazgo.Descripcion = null;
                    if (String.IsNullOrWhiteSpace(hallazgo.Estado)) hallazgo.Estado = null;

                    _objData.Modificar(hallazgo);
                }
                else
                {
                    strRespuesta = "El Hallazgo con Id " + hallazgo.IdHallazgo.ToString() + " no se encuentra en estado CREADO para ser modificado.";
                }
            }
            else
            {
                strRespuesta = "No existe el Hallazgo con Id " + hallazgo.IdHallazgo.ToString();
            }

            return strRespuesta;
        }

        public string Eliminar(int idHallazgo)
        {
            string strRespuesta = string.Empty;
            ArchivoLogica _objArchivoLogica = null;
 
            List<Hallazgo> lstBusquedaHallazgo = _objData.Obtener(new Hallazgo() { IdHallazgo = idHallazgo });

            if (lstBusquedaHallazgo.Count > 0)
            {
                if (lstBusquedaHallazgo[0].Estado == EstadoHallazgo.Creado)
                {
                    _objArchivoLogica = new ArchivoLogica();
                    using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required))
                    {
                        _objArchivoLogica.EliminarGrupoArchivos(idHallazgo, "H");
                        _objData.Eliminar(idHallazgo);
                        tran.Complete();
                    }
                }
                else
                {
                    strRespuesta = "El Hallazgo con Id " + idHallazgo.ToString() + " no se encuentra en estado CREADO para ser eliminado.";
                }
            }
            else
            {
                strRespuesta = "No existe el Hallazgo con Id " + idHallazgo.ToString();
            }

            return strRespuesta;
        }
    }
}
