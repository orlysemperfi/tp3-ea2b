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
        public static int id = 1;
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        int codigo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarUnidades();
            action = Convert.ToInt32(Request.QueryString["Action"]);
            codigo = Convert.ToInt32(Request.QueryString["Codigo"]);
            if (action == Constantes.ACTION_UPDATE)
            {
                CargarEscalaCuantitativo(codigo);
            }

        }

        protected void CargarUnidades()
        {
          
            IUnidadLogica oUnidadLogica = UnidadLogica.getInstance();
            ddlUnidad.DataSource = oUnidadLogica.ObtenerListaUnidadTodas();
            ddlUnidad.DataTextField = "DESCRIPCION";
            ddlUnidad.DataValueField = "CODIGO";
            ddlUnidad.DataBind();
            
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {

            if (action == Constantes.ACTION_INSERT)
            {
                EscalaCuantitativoEntidad oEscalaCuantitativo = new EscalaCuantitativoEntidad();
                oEscalaCuantitativo.signo = txbSigno.Text;
                oEscalaCuantitativo.valor = Convert.ToDouble(txbValor.Text);
                oEscalaCuantitativo.codigo_Unidad = Convert.ToInt32(ddlUnidad.SelectedValue);
                oEscalaCuantitativo.descripcion_unidad = ddlUnidad.SelectedItem.Text;
                oEscalaCuantitativo.codigo = id;
                id = id + 1;
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo.Add(oEscalaCuantitativo);
            }
            if (action == Constantes.ACTION_UPDATE)
            {

                EscalaCuantitativoEntidad oEscalaCuantitativo = new EscalaCuantitativoEntidad();                
                oEscalaCuantitativo = ObtenerEscalaCuantitativo(codigo);
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo.Remove(oEscalaCuantitativo);
                oEscalaCuantitativo.signo = txbSigno.Text;
                oEscalaCuantitativo.valor = Convert.ToDouble(txbValor.Text);
                oEscalaCuantitativo.codigo_Unidad = Convert.ToInt32(ddlUnidad.SelectedValue);
                oEscalaCuantitativo.descripcion_unidad = ddlUnidad.SelectedItem.Text;
                oEscalaCuantitativo.codigo = codigo;
                Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo.Add(oEscalaCuantitativo);
                
            }
            Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuanti + "?Action=" + action, true);


        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuanti + "?Action=" + action, true);
        }
        protected void CargarEscalaCuantitativo(int codigo)
        {
            EscalaCuantitativoEntidad oEscalaCuantitativo = ObtenerEscalaCuantitativo(codigo);
            txbSigno.Text = oEscalaCuantitativo.signo;
            txbValor.Text = oEscalaCuantitativo.valor.ToString();
            ddlUnidad.SelectedValue = oEscalaCuantitativo.codigo_Unidad.ToString();


        }
        
        protected EscalaCuantitativoEntidad ObtenerEscalaCuantitativo(int codigo)
        {
            EscalaCuantitativoEntidad oEscalaCuantitativo = new EscalaCuantitativoEntidad();
            foreach (EscalaCuantitativoEntidad obj in Sesiones.IndicadorSeleccionado.lstEscalaCuantitativo)
            {
                if (obj.codigo == codigo)
                {
                    return obj;

                }
            }
            return null;

        }
    }
}