using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.CF.Site.Vistas.ACP;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Entidades;
using TMD.Core;
using Ediable_Repeater;
using TMD.CF.Site.Util;

namespace TMD.CF.Site.Presentador.ACP
{
    public class ProgramaAnualPresentadora
    {
        private IProgramaAnualVista _vista;
        private IProgramaAnualLogica _modelo;

        public ProgramaAnualPresentadora(IProgramaAnualVista _vista)
        { 
            this._vista = _vista;
            this._modelo = new ProgramaAnualLogica();
        }

        /// <summary>
        /// Permite cargar los datos del programa anual de auditoria
        /// </summary>
        public void Load()
        {
            try
            {
                ProgramaAnualAuditoria oProgramaAnual = _modelo.ObtenerProgramaAnualDeAuditoria(SesionFachada.Usuario.Id);
                _vista.AnhoPrograma = oProgramaAnual.AnhoPrograma;
                _vista.UsuarioCreacion = oProgramaAnual.UsuarioCreacion;
                _vista.UsuarioAprobacion = oProgramaAnual.UsuarioAprobacion == null ? "" : oProgramaAnual.UsuarioAprobacion;
                _vista.Estado = oProgramaAnual.Estado;
                _vista.IdProgramaAnual = oProgramaAnual.IdProgramaAnual;                
                _vista.IsView = oProgramaAnual.ObjAuditorias.Count == 0 ? "0" : "1";                
                _vista.ObjAuditorias = oProgramaAnual.ObjAuditorias;
                _vista.tempNroAuditoria = (oProgramaAnual.ObjAuditorias.Count != 0) ? (oProgramaAnual.ObjAuditorias.Max(c => c.IdAuditoria.Value) + 1).ToString() : "1";
                DataAuditorias.Instance.Auditoria = oProgramaAnual.ObjAuditorias;

                _vista.IsValid = "1";
            }
            catch (Exception ex)
            {
                _vista.IsValid = "0";
                _vista.Mensaje = ex.Message;
            }
        }

        /// <summary>
        /// Permite actualizar el grid de la auditoria ingresada o modificada
        /// </summary>
        public void GrabarAuditoria()
        {
            try
            {
                //Validar que no hayan colocado la opcion cerrar
                if (_vista.Auditoria != null)
                {
                    //Buscar por id la auditoria para saber si existe o no en el grid
                    int idAuditoria = _vista.Auditoria.IdAuditoria.Value;
                    Auditoria auditoria = DataAuditorias.Instance.Auditoria.Find(e => e.IdAuditoria == idAuditoria);

                    //Si no existe se agrega en el grid, de lo contrario, se actualiza
                    if (auditoria == null)
                    {
                        DataAuditorias.Instance.Auditoria.Add(_vista.Auditoria);
                    }
                    else
                    {
                        Auditoria eAuditoria = DataAuditorias.Instance.Auditoria.Single(e => e.IdAuditoria == idAuditoria);
                        eAuditoria.IdAuditoria = _vista.Auditoria.IdAuditoria;
                        eAuditoria.ObjEntidadAuditada.IdEntidadAuditada = _vista.Auditoria.ObjEntidadAuditada.IdEntidadAuditada;
                        eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada = _vista.Auditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                        eAuditoria.ObjEntidadAuditada.ObjArea.descripcion = _vista.Auditoria.ObjEntidadAuditada.ObjArea.descripcion;
                        eAuditoria.ObjEntidadAuditada.ObjArea.codigo = _vista.Auditoria.ObjEntidadAuditada.ObjArea.codigo;
                        eAuditoria.ObjEntidadAuditada.Responsable = _vista.Auditoria.ObjEntidadAuditada.Responsable;
                        eAuditoria.ObjEntidadAuditada.IdResponsable = _vista.Auditoria.ObjEntidadAuditada.IdResponsable;
                        eAuditoria.Alcance = _vista.Auditoria.Alcance;
                        eAuditoria.Objetivo = _vista.Auditoria.Objetivo;
                        eAuditoria.FechaInicio = _vista.Auditoria.FechaInicio;
                        eAuditoria.FechaFin = _vista.Auditoria.FechaFin;
                        eAuditoria.Estado = _vista.Auditoria.Estado;
                    }
                }

                //Refrescar grid de auditorias y id de auditoria generado
                _vista.ObjAuditorias = DataAuditorias.Instance.Auditoria;
                _vista.tempNroAuditoria = Convert.ToString(DataAuditorias.Instance.NextId);
                _vista.IsValid = "1";
            }
            catch (Exception ex)
            {
                _vista.IsValid = "0";
                _vista.Mensaje = ex.Message;
            }
        }

        /// <summary>
        /// Permite eliminar la auditoria seleccionada en el grid
        /// </summary>
        /// <param name="id">Identificador de auditoria</param>
        public void QuitarAuditoria()
        {
            try
            {
                //Buscar por id la auditoria a eliminar
                int idAuditoria = Convert.ToInt32(_vista.tempNroAuditoria);
                Auditoria auditoria = DataAuditorias.Instance.Auditoria.Single(e => e.IdAuditoria == idAuditoria);

                //Eliminar auditoria
                DataAuditorias.Instance.Auditoria.Remove(auditoria);

                //Refrescar grid de auditorias y id de auditoria generado
                _vista.ObjAuditorias = DataAuditorias.Instance.Auditoria;
                _vista.tempNroAuditoria = Convert.ToString(DataAuditorias.Instance.NextId);
                _vista.IsValid = "1";
            }
            catch (Exception ex)
            {
                _vista.IsValid = "0";
                _vista.Mensaje = ex.Message;
            }
        }

        /// <summary>
        /// Editar una auditoria del grid
        /// </summary>
        public void EditarAuditoria()
        {
            try
            {
                //Buscar por id la auditoria a modificar
                int idAuditoria = Convert.ToInt32(_vista.tempNroAuditoria);
                Auditoria eAuditoria = DataAuditorias.Instance.Auditoria.Single(e => e.IdAuditoria == idAuditoria);
                
                //Devolver los datos de la auditoria a modificar               
                _vista.IsValid = "1";
                _vista.Auditoria = eAuditoria;
            }
            catch (Exception ex)
            {
                _vista.IsValid = "0";
                _vista.Mensaje = ex.Message;
            }
        }

        /// <summary>
        /// Guardar programa anual de auditoria con estado creado
        /// tambien, la lista de auditorias que estan en el grid con estado creado
        /// </summary>
        public void GrabarProgramaAnualAuditoria()
        {
            try
            {
                if (DataAuditorias.Instance.Auditoria == null || DataAuditorias.Instance.Auditoria.Count() == 0 || DataAuditorias.Instance.Auditoria.Count() > 3)
                {
                    _vista.Mensaje = "Ingresar auditorias necesarias";
                }
                else
                {
                    //Obtener datos
                    ProgramaAnualAuditoria oProgramaAnual = new ProgramaAnualAuditoria
                    {
                        AnhoPrograma = _vista.AnhoPrograma,
                        IdUsuarioCreacion = _vista.IdUsuarioCreacion,
                        ObjAuditorias = DataAuditorias.Instance.Auditoria
                    };

                    //Grabar el programa anual de auditoria
                    _modelo.GrabarProgramaAnual(ref oProgramaAnual);

                    //Obtener Auditorias ingresadas
                    DataAuditorias.Instance.Auditoria.Clear();
                    DataAuditorias.Instance.Auditoria = oProgramaAnual.ObjAuditorias;
                    _vista.ObjAuditorias = oProgramaAnual.ObjAuditorias;
                    _vista.IdProgramaAnual = oProgramaAnual.IdProgramaAnual;
                }

                _vista.IsValid = "1";
            }
            catch (Exception ex)
            {
                _vista.IsValid = "0";
                _vista.Mensaje = ex.Message;
            }
        }
    }
}