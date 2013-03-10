using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.CF.Site.Controladora.CF;
using TMD.Entidades;
using TMD.CF.Site.Controladora;
using TMD.CF.Site.Util;

namespace TMD.CF.Site.Vistas.LineaBase
{
    public partial class ActualizarECS : System.Web.UI.Page
    {
        int idProyecto, idFase = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Proyecto proyecto = null;
            Fase fase = null;            

            if (!Int32.TryParse(Request.QueryString["idProyecto"], out idProyecto)
                || !Int32.TryParse(Request.QueryString["idFase"], out idFase))
            {
                Response.Redirect("~/Vistas/CF/LineaBase/ListaLineaBase.aspx");
            }
            else
            {
                if (idProyecto == 0)
                {
                    Response.Redirect("~/Vistas/CF/LineaBase/ListaLineaBase.aspx");
                }
                else
                {
                    proyecto = LineaBaseControladora.ProyectoObtenerPorId(idProyecto);

                    if (proyecto == null)
                    {
                        Response.Redirect("~/Vistas/CF/LineaBase/ListaLineaBase.aspx");
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                TMD.Entidades.LineaBase lineaBase =
                        LineaBaseControladora.LineaBaseObtenerPorProyectoFaseUsuario(idProyecto, idFase,SesionFachada.Usuario.Id);

                hiddenIdLineaBase.Value = lineaBase.Id.ToString();
                txtNombre.Text = lineaBase.Nombre;
                txtDescripcion.Text = lineaBase.Descripcion;

                grvElementoConfiguracion.DataSource = lineaBase.LineaBaseECS;
                grvElementoConfiguracion.DataBind();

                txtNombreProyecto.Text = proyecto.Nombre;

                List<Fase> listaFase = LineaBaseControladora.ListarFasePorProyecto(idProyecto, true);
                fase = listaFase.FirstOrDefault(x => x.Id == idFase);

                if (fase == null)
                {
                    Response.Redirect("~/Vistas/CF/LineaBase/ListaLineaBase.aspx");
                }
                else
                {
                    txtNombreFase.Text = fase.Nombre;
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/CF/LineaBase/ListaLineaBase.aspx");
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            byte[] archivo = fileUpElemento.FileBytes;
            String nombre = System.IO.Path.GetFileName(fileUpElemento.FileName);

            LineaBaseControladora.ActualizarArchivo(Convert.ToInt32(hiddenIdLineaBase.Value), nombre, archivo);

            TMD.Entidades.LineaBase lineaBase =
                        LineaBaseControladora.LineaBaseObtenerPorProyectoFaseUsuario(idProyecto, idFase, SesionFachada.Usuario.Id);
            
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

                    LineaBaseElementoConfiguracion archivo = LineaBaseControladora.ObtenerArchivo(idElemento);

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