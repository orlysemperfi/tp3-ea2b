using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora.CF;
using TMD.CF.Site.Util;
using TMD.Entidades;
using TMD.Strings;

namespace TMD.CF.Site.Vistas.CF.LineaBase
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
                Response.Redirect(Pagina.LineaBase);
            }
            else
            {
                if (idProyecto == 0)
                {
                    Response.Redirect(Pagina.LineaBase);
                }
                else
                {
                    proyecto = new LineaBaseControladora().ProyectoObtenerPorId(idProyecto);

                    if (proyecto == null)
                    {
                        Response.Redirect(Pagina.LineaBase);
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                pnlECS.Visible = false;
                SesionFachada.ListaElementoConfiguracion = null;
                SesionFachada.ListaUsuarioResponsable = new LineaBaseControladora().UsuarioListaPorProyecto(idProyecto);

                ddlProyecto.EnlazarDatos(new LineaBaseControladora().ListarProyectoPorUsuario(SesionFachada.Usuario.Id), "Nombre", "Id", -1, proyecto.Id);
                ddlProyecto.Enabled = false;
                
                if (idFase != 0)
                {
                    ddlFase.DataSource = new LineaBaseControladora().ListarFasePorProyecto(idProyecto, true);
                    ddlFase.SelectedValue = idFase.ToString();
                    ddlFase.Enabled = false;
                    ddlProyecto.Enabled = false;

                    //CARGAR DATOS LINEA BASE
                    TMD.Entidades.LineaBase lineaBase =
                        new LineaBaseControladora().LineaBaseObtenerPorProyectoFase(idProyecto, idFase);

                    hiddenIdLineaBase.Value = lineaBase.Id.ToString();
                    txtNombre.Text = lineaBase.Nombre;
                    txtDescripcion.Text = lineaBase.Descripcion;
                    
                    if (lineaBase.LineaBaseECS != null)
                    {
                        List<ElementoConfiguracion> lista = new LineaBaseControladora().ElementoConfiguracionListarPorFase(idFase);

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
                    ddlFase.DataSource = new LineaBaseControladora().ListarFasePorProyecto(idProyecto, false);
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
                lista = new LineaBaseControladora().ElementoConfiguracionListarPorFase(Convert.ToInt32(ddlFase.SelectedValue));

                SesionFachada.ListaElementoConfiguracion = lista;
            }

            grvListaECS.DataSource = lista.Where(x => !x.Seleccionado);
            grvListaECS.DataBind();

            pnlECS.Visible = true;
            btnAgregarECS.Enabled = false;
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
                    new LineaBaseControladora().ProyectoFaseObtenerPorFaseProyecto(idProyecto, Convert.ToInt32(ddlFase.SelectedValue));

                new LineaBaseControladora().LineaBaseAgregar(
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
                new LineaBaseControladora().LineaBaseActualizar(
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
            Response.Redirect(Pagina.LineaBase);
        }
        
        protected void ddlFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            SesionFachada.ListaElementoConfiguracion = null;
            grvElementoConfiguracion.DataSource = null;
            grvElementoConfiguracion.DataBind();
        }
    }
}