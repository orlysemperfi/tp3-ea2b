using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Entidades;
using TMD.ACP.LogicaNegocios.Contrato;
using TMD.ACP.LogicaNegocios.Implementacion;
using TMD.Core;
using TMD.ACP.Site;
using Ediable_Repeater;
using System.Web.Services;
using TMD.CF.Site.Presentador.ACP;
using TMD.CF.Site.Vistas.ACP;
using TMD.CF.Site.Util;

namespace TMD.ACP.Site
{
    public partial class ProgramaAuditoria : BasePage, IProgramaAnualVista
    {
        private readonly ProgramaAnualPresentadora _presentadora;

        public ProgramaAuditoria()
        {
            _presentadora = new ProgramaAnualPresentadora(this);
        }

        /// <summary>
        /// Al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !IsCallback)
            {
                _presentadora.Load();

                AddCallbackValue(__IsValid.Value);
                AddCallbackValue(__Mensaje.Value);
                AddCallbackValue(__tempNroAuditoria.Value);
                AddCallbackControl(rptProgramaAnual);
            }         
        }

        /// <summary>
        /// Pintar grid con los datos de auditoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptProgramaAnual_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem | e.Item.ItemType == ListItemType.Item)
            {
                Auditoria eAuditoria = (Auditoria)e.Item.DataItem;

                Label lblNroAuditoria = (Label)e.Item.FindControl("lblNroAuditoria");
                Label lblEntAudi = (Label)e.Item.FindControl("lblEntAudi");
                Label lblArea = (Label)e.Item.FindControl("lblArea");
                Label lblResponsable = (Label)e.Item.FindControl("lblResponsable");
                Label lblAlcance = (Label)e.Item.FindControl("lblAlcance");
                Label lblObjetivo = (Label)e.Item.FindControl("lblObjetivo");
                Label lblFechaInicio = (Label)e.Item.FindControl("lblFechaInicio");
                Label lblFechaFin = (Label)e.Item.FindControl("lblFechaFin");
                Label lblEstado = (Label)e.Item.FindControl("lblEstado");

                lblNroAuditoria.Text = Convert.ToString(eAuditoria.IdAuditoria.Value);
                lblEntAudi.Text = eAuditoria.ObjEntidadAuditada.NombreEntidadAuditada;
                lblArea.Text = eAuditoria.ObjEntidadAuditada.ObjArea.descripcion;
                lblResponsable.Text = eAuditoria.ObjEntidadAuditada.Responsable;
                lblAlcance.Text = eAuditoria.Alcance;
                lblObjetivo.Text = eAuditoria.Objetivo;
                lblFechaInicio.Text = eAuditoria.FechaInicio.ToShortDateString();
                lblFechaFin.Text = eAuditoria.FechaFin.ToShortDateString();
                lblEstado.Text = eAuditoria.Estado;
            }
        }

        /// <summary>
        /// Permite actualizar el grid de la auditoria ingresada o modificada
        /// </summary>
        public void GrabarAuditoria()
        {
            _presentadora.GrabarAuditoria();

            AddCallbackValue(__IsValid.Value);
            AddCallbackValue(__Mensaje.Value);
            AddCallbackValue(__tempNroAuditoria.Value);
            AddCallbackControl(rptProgramaAnual);
        }

        /// <summary>
        /// Permite eliminar la auditoria seleccionada en el grid
        /// </summary>
        /// <param name="id">Identificador de auditoria</param>
        public void QuitarAuditoria(string id)
        {
            __tempNroAuditoria.Value = id;

            _presentadora.QuitarAuditoria();

            AddCallbackValue(__IsValid.Value);
            AddCallbackValue(__Mensaje.Value);
            AddCallbackValue(__tempNroAuditoria.Value);
            AddCallbackControl(rptProgramaAnual);
        }

        /// <summary>
        /// Permite devolver los datos de la auditoria a modificar en el popup
        /// </summary>
        /// <param name="id">Identificado de auditoria</param>
        public void EditarAuditoria(string id)
        {
            __tempNroAuditoria.Value = id;

            _presentadora.EditarAuditoria();
        }

        /// <summary>
        /// Guardar programa anual de auditoria con estado creado
        /// tambien, la lista de auditorias que estan en el grid con estado creado
        /// </summary>
        public void GrabarProgramaAnualAuditoria()
        {
            _presentadora.GrabarProgramaAnualAuditoria();

            AddCallbackValue(__IsValid.Value);
            AddCallbackValue(__Mensaje.Value);
            AddCallbackControl(lblIdPrograma);
            AddCallbackControl(rptProgramaAnual);
        }

        #region IProgramaAnualVista Members

        public int IdProgramaAnual
        {
            set
            {
                lblIdPrograma.Text = value.ToString();
            }
        }

        public int AnhoPrograma
        {
            get
            {
                return DateTime.Today.Year;
            }
            set
            {
                lblPeriodo.Text = value.ToString();
            }
        }

        public int IdUsuarioCreacion
        {
            get
            {
                return SesionFachada.Usuario.Id;
            }
        }

        public string UsuarioCreacion
        {
            set
            {
                lblElaboradoPor.Text = value.ToString();
            }
        }

        public string UsuarioAprobacion
        {
            set
            {
                lblAprobadoPor.Text = value.ToString();
            }
        }

        public string Estado
        {
            set
            {
                lblEstado.Text = value.ToString();
            }
        }

        public List<Auditoria> ObjAuditorias
        {
            set
            {
                rptProgramaAnual.DataSource = value;
                rptProgramaAnual.DataBind();
            }
        }

        public string IsView
        {
            set
            {
                __IsView.Value = value;
            }
        }

        public string tempNroAuditoria
        {
            get
            {
                return __tempNroAuditoria.Value;
            }
            set
            {
                __tempNroAuditoria.Value = value;
            }
        }

        public Auditoria Auditoria
        {
            get
            {
                if (Request["ctl00$MainContent$__tempIdEntAudi"] != "")
                {
                    return new Auditoria
                    {
                        IdAuditoria = Convert.ToInt32(Request["ctl00$MainContent$__tempNroAuditoria"]),
                        ObjEntidadAuditada = new EntidadAuditada
                        {
                            IdEntidadAuditada = Convert.ToInt32(Request["ctl00$MainContent$__tempIdEntAudi"]),
                            NombreEntidadAuditada = Convert.ToString(Request["ctl00$MainContent$__tempEntAudi"]),
                            ObjArea = new AreaEntidad
                            {
                                descripcion = Convert.ToString(Request["ctl00$MainContent$__tempArea"]),
                                codigo = Convert.ToInt32(Request["ctl00$MainContent$__tempIdArea"]),
                            },
                            Responsable = Convert.ToString(Request["ctl00$MainContent$__tempResponsable"]),
                            IdResponsable = Convert.ToInt32(Request["ctl00$MainContent$__tempIdResponsable"]),
                        },
                        Alcance = Convert.ToString(Request["ctl00$MainContent$__tempAlcance"]),
                        Objetivo = Convert.ToString(Request["ctl00$MainContent$__tempObjetivo"]),
                        FechaInicio = Convert.ToDateTime(Request["ctl00$MainContent$__tempFechaInicio"]),
                        FechaFin = Convert.ToDateTime(Request["ctl00$MainContent$__tempFechaFin"]),
                        Estado = EstadoAuditoria.Creado
                    };
                }
                else
                {
                    return null;
                }
            }
            set
            {
                AddCallbackValue(__IsValid.Value);
                AddCallbackValue(__Mensaje.Value);
                AddCallbackValue(Convert.ToString(value.IdAuditoria.Value));
                AddCallbackValue(Convert.ToString(value.ObjEntidadAuditada.IdEntidadAuditada));
                AddCallbackValue(value.ObjEntidadAuditada.NombreEntidadAuditada);
                AddCallbackValue(value.ObjEntidadAuditada.ObjArea.descripcion);
                AddCallbackValue(Convert.ToString(value.ObjEntidadAuditada.ObjArea.codigo.Value));
                AddCallbackValue(Convert.ToString(value.ObjEntidadAuditada.IdResponsable));
                AddCallbackValue(value.ObjEntidadAuditada.Responsable);
                AddCallbackValue(value.Alcance);
                AddCallbackValue(value.Objetivo);
                AddCallbackValue(value.FechaInicio.ToShortDateString());
                AddCallbackValue(value.FechaFin.ToShortDateString());
            }
        }

        public string Mensaje
        {
            set
            {
                __Mensaje.Value = value;
            }
        }

        public string IsValid
        {
            set
            {
                __IsValid.Value = value;
            }
        }

        #endregion
    }
}