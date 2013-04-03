using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TMD.CF.Site.FachadaNegocio.CF;
using TMD.Entidades;
using TMD.CF.Site.Util;
using TMD.Strings;
using System.Web;
using Microsoft.Practices.Unity;

namespace TMD.CF.Site.Vistas.CF.LineaBase
{
    public partial class ActualizarECS : System.Web.UI.Page
    {
        int idProyecto, idFase = 0;
        protected LineaBaseFachada lineaBaseFachada;

        protected void Page_Load(object sender, EventArgs e)
        {
            var accessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;
            var container = accessor.Container;
            lineaBaseFachada = container.Resolve<LineaBaseFachada>();

            Proyecto proyecto = null;
            Fase fase = null;            

            if (!Int32.TryParse(Request.QueryString["idProyecto"], out idProyecto)
                || !Int32.TryParse(Request.QueryString["idFase"], out idFase))
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
                    proyecto = lineaBaseFachada.ProyectoObtenerPorId(idProyecto);

                    if (proyecto == null)
                    {
                        Response.Redirect(Pagina.LineaBase);
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                TMD.Entidades.LineaBase lineaBase =
                        lineaBaseFachada.LineaBaseObtenerPorProyectoFaseUsuario(idProyecto, idFase, SesionFachada.Usuario.Id);

                hiddenIdLineaBase.Value = lineaBase.Id.ToString();
                txtNombre.Text = lineaBase.Nombre;
                txtDescripcion.Text = lineaBase.Descripcion;

                grvElementoConfiguracion.DataSource = lineaBase.LineaBaseECS;
                grvElementoConfiguracion.DataBind();

                txtNombreProyecto.Text = proyecto.Nombre;

                List<Fase> listaFase = lineaBaseFachada.ListarFasePorProyecto(idProyecto, true);
                fase = listaFase.FirstOrDefault(x => x.Id == idFase);

                if (fase == null)
                {
                    Response.Redirect(Pagina.LineaBase);
                }
                else
                {
                    txtNombreFase.Text = fase.Nombre;
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Pagina.LineaBase);
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            byte[] archivo = fileUpElemento.FileBytes;
            String nombre = System.IO.Path.GetFileName(fileUpElemento.FileName);

            lineaBaseFachada.ActualizarArchivo(Convert.ToInt32(hiddenIdLineaBase.Value), nombre, archivo);

            TMD.Entidades.LineaBase lineaBase =
                        lineaBaseFachada.LineaBaseObtenerPorProyectoFaseUsuario(idProyecto, idFase, SesionFachada.Usuario.Id);
            
            grvElementoConfiguracion.DataSource = lineaBase.LineaBaseECS;
            grvElementoConfiguracion.DataBind();

            pnlCargar.Visible = false;
        }

        protected void grvElementoConfiguracion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Descarga":
                    int idElemento = Convert.ToInt32(e.CommandArgument);

                    LineaBaseElementoConfiguracion archivo = lineaBaseFachada.ObtenerArchivo(idElemento);

                    if (archivo != null && archivo.Data != null)
                    {
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}",archivo.Nombre));
                        Response.Flush();
                        Response.Buffer = true;
                        Response.BinaryWrite(archivo.Data);
                    }

                    break;
                case "Cargar":
                    pnlCargar.Visible = true;

                    hiddenIdLineaBase.Value = e.CommandArgument.ToString();

                    break;
                default:
                    break;
            }
        }
    }
}