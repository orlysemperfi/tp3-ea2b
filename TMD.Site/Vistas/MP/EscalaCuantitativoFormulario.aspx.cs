using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.Entidades;
using TMD.MP.Comun;
using TMD.MP.LogicaNegocios.Contrato;
using TMD.MP.LogicaNegocios.Implementacion;

namespace TMD.MP.Site.Privado
{
    public partial class EscalaCuantitativaFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlUnidad.Items.Add(new ListItem("Tiempo","1"));


        }

        protected void CargarUnidades()
        {
          
            IUnidadLogica oUnidadLogica = UnidadLogica.getInstance();
            List<UnidadEntidad> oUnidadCollection = oUnidadLogica.SeleccionarUnidadTodas();

            ddlUnidad.DataSource = oUnidadCollection;
            ddlUnidad.DataTextField="codigo";
            ddlUnidad.DataValueField = "medida";
            ddlUnidad.DataBind();
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_IndicadorFormulario,true);
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}