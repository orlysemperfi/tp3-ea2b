using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Entidades;

namespace TMD.GC.Site.Vistas.LineaBase
{
    public partial class ActualizarLineaBase : System.Web.UI.Page
    {
        Dictionary<int, int> listaResponsable = new Dictionary<int, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Proyecto proyecto = null;
            int idProyecto, idFase = 0, lectura=0;

            if (!Int32.TryParse(Request.QueryString["idProyecto"], out idProyecto) 
                || !Int32.TryParse(Request.QueryString["idFase"], out idFase) 
                || !Int32.TryParse(Request.QueryString["lectura"], out lectura))
            {
                    Response.Redirect("~/Vistas/LineaBase/ListaLineaBase.aspx");
            }
            else
            {
                if (idProyecto == 0)
                {
                    Response.Redirect("~/Vistas/LineaBase/ListaLineaBase.aspx");
                }
                else
                {
                    proyecto = LineaBaseControladora.ProyectoObtenerPorId(idProyecto);

                    if (proyecto == null)
                    {
                        Response.Redirect("~/Vistas/LineaBase/ListaLineaBase.aspx");
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                pnlECS.Visible = false;
                SesionFachada.ListaElementoConfiguracion = null;
                SesionFachada.ListaUsuarioResponsable = LineaBaseControladora.UsuarioListaPorProyecto(idProyecto);

                txtNombreProyecto.Text = proyecto.Nombre;

                if (idFase != 0)
                {
                    ddlFase.DataSource = LineaBaseControladora.ListarFasePorProyecto(idProyecto,true);
                    ddlFase.SelectedValue = idFase.ToString();
                    ddlFase.Enabled = false;

                    //CARGAR DATOS LINEA BASE
                    TMD.Entidades.LineaBase lineaBase =
                        LineaBaseControladora.LineaBaseObtenerPorProyectoFase(idProyecto, idFase);

                    hiddenIdLineaBase.Value = lineaBase.Id.ToString();
                    txtNombre.Text = lineaBase.Nombre;
                    txtDescripcion.Text = lineaBase.Descripcion;
                    
                    if (lineaBase.LineaBaseECS != null)
                    {
                        List<ElementoConfiguracion> lista = LineaBaseControladora.ElementoConfiguracionListarPorFase(idFase);

                        lineaBase.LineaBaseECS.ForEach(x => 
                            {
                                listaResponsable.Add(x.ElementoConfiguracion.Id, x.Responsable.Id);
                                ElementoConfiguracion elemento = lista.Find(ecs => ecs.Id == x.ElementoConfiguracion.Id);
                                if (elemento != null)
                                {
                                    elemento.Seleccionado = true;
                                }
                            }
                         );

                        SesionFachada.ListaElementoConfiguracion = lista;

                        grvElementoConfiguracion.DataSource = lineaBase.LineaBaseECS.Select(x => x.ElementoConfiguracion);
                        grvElementoConfiguracion.DataBind();
                    }
                }
                else
                {
                    ddlFase.DataSource = LineaBaseControladora.ListarFasePorProyecto(idProyecto,false);
                }

                ddlFase.DataValueField = "Id";
                ddlFase.DataTextField = "Nombre";
                ddlFase.DataBind();

                if (lectura == 0)
                {
                    btnCancelar.OnClientClick = "javascript:return cancelar();";
                }
                else
                {
                    txtDescripcion.Enabled = false;
                    txtNombre.Enabled = false;
                    btnAgregarECS.Visible = false;
                    grvElementoConfiguracion.Enabled = false;
                    btnGrabar.Visible = false;
                }
               
            }
        }

        protected void btnAgregarECS_Click(object sender, EventArgs e)
        {
            List<ElementoConfiguracion> lista = SesionFachada.ListaElementoConfiguracion;

            if (lista == null)
            {
                lista = LineaBaseControladora.ElementoConfiguracionListarPorFase(Convert.ToInt32(ddlFase.SelectedValue));

                SesionFachada.ListaElementoConfiguracion = lista;
            }

            grvListaECS.DataSource = lista.Where(x => !x.Seleccionado);
            grvListaECS.DataBind();

            pnlECS.Visible = true;
            btnAgregarECS.Enabled = false;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "_Mostrar_", "mostrarPopup();", true);
            //ModalPopupExtender1.Show();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            List<ElementoConfiguracion> lista = SesionFachada.ListaElementoConfiguracion;

            foreach (GridViewRow item in grvListaECS.Rows)
            {
                if (((CheckBox)((DataControlFieldCell)item.Cells[0]).FindControl("chkElemento")).Checked)
                {
                    int idElemento = Convert.ToInt32(((HiddenField)((DataControlFieldCell)item.Cells[0]).FindControl("hiddenEcsId")).Value);

                    lista.Find(x => x.Id == idElemento).Seleccionado = true;
                }
            }

            GuardarIndiceResponsable();

            SesionFachada.ListaElementoConfiguracion = lista;

            grvElementoConfiguracion.DataSource = lista.Where(x => x.Seleccionado);
            grvElementoConfiguracion.DataBind();            

            pnlECS.Visible = false;
            btnAgregarECS.Enabled = true;

            //ModalPopupExtender1.Hide();
        }

        private void GuardarIndiceResponsable()
        {
            for (int i = 0; i < grvElementoConfiguracion.Rows.Count; i++)
            {
                GridViewRow item = grvElementoConfiguracion.Rows[i];

                int id = Convert.ToInt32(((HiddenField)item.FindControl("hiddenEcsId")).Value);
                int idResponsable = ((DropDownList)item.FindControl("ddlResponsable")).SelectedIndex;

                listaResponsable.Add(id, idResponsable);
            }
        }

        protected void grvElementoConfiguracion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Eliminar":
                    int idElemento = Convert.ToInt32(e.CommandArgument);

                    List<ElementoConfiguracion> lista = SesionFachada.ListaElementoConfiguracion;
                    lista.Find(x => x.Id == idElemento).Seleccionado = false;

                    GuardarIndiceResponsable();

                    grvElementoConfiguracion.DataSource = lista.Where(x => x.Seleccionado);
                    grvElementoConfiguracion.DataBind();

                    break;
                default:
                    break;
            }
        }

        protected void grvElementoConfiguracion_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow item in grvElementoConfiguracion.Rows)
            {
                DropDownList ddlResponsable = (DropDownList)item.FindControl("ddlResponsable");
                int id = Convert.ToInt32(((HiddenField)item.FindControl("hiddenEcsId")).Value);

                ddlResponsable.DataSource = SesionFachada.ListaUsuarioResponsable;
                ddlResponsable.DataTextField = "Nombre";
                ddlResponsable.DataValueField = "Id";

                if (listaResponsable.ContainsKey(id))
                {
                    ddlResponsable.SelectedIndex = listaResponsable[id];
                }

                ddlResponsable.DataBind();
            }
        }

        protected void grvElementoConfiguracion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            int idFase = Convert.ToInt32(Request.QueryString["idFase"]), 
                lectura = Convert.ToInt32(Request.QueryString["lectura"]),
                idProyecto = Convert.ToInt32(Request.QueryString["idProyecto"]);

            List<LineaBaseElementoConfiguracion> lista = new List<LineaBaseElementoConfiguracion>();

            foreach (GridViewRow item in grvElementoConfiguracion.Rows)
            {
                DropDownList ddlResponsable = (DropDownList)item.FindControl("ddlResponsable");
                int id = Convert.ToInt32(((HiddenField)item.FindControl("hiddenEcsId")).Value);

                lista.Add(
                    new LineaBaseElementoConfiguracion
                    {
                        Responsable = new Usuario { Id = Convert.ToInt32(ddlResponsable.SelectedValue) },
                        ElementoConfiguracion = new ElementoConfiguracion { Id = id }
                    }
                );
            }

            if (lectura == 0 && idFase == 0)//NUEVO
            {
                ProyectoFase proyectoFase = 
                    LineaBaseControladora.ProyectoFaseObtenerPorFaseProyecto(idProyecto, Convert.ToInt32(ddlFase.SelectedValue));

                LineaBaseControladora.LineaBaseAgregar(
                    new TMD.Entidades.LineaBase
                    {
                        Id = 0,
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        ProyectoFase = proyectoFase
                    },
                    lista
                );

                ScriptManager.RegisterStartupScript(this, this.GetType(), "_GrabarNuevo_", "exitoNuevo();", true);
            }
            else//ACTUALIZAR
            {
                LineaBaseControladora.LineaBaseActualizar(
                    new TMD.Entidades.LineaBase
                    {
                        Id = Convert.ToInt32(hiddenIdLineaBase.Value),
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text
                    },
                    lista
                );
                ScriptManager.RegisterStartupScript(this, this.GetType(), "_GrabarActualiozar_", "exitoActualizar();", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/LineaBase/ListaLineaBase.aspx");
        }
    }
}