using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMD.MP.Comun;
using TMD.Entidades;
namespace TMD.MP.Site.Privado
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int id = 1;
        int action = Constantes.ACTION_INSERT; //0:Insertar 1:Actualizar
        int codigo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            action = Convert.ToInt32(Request.QueryString["Action"]);
            codigo = Convert.ToInt32(Request.QueryString["Codigo"]);
            if (action == Constantes.ACTION_UPDATE)
            {
                CargarEscalaCualitativo(codigo);
            }
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {


            if (action == Constantes.ACTION_INSERT)
            {
                EscalaCualitativoEntidad oEscalaCualitativo = new EscalaCualitativoEntidad();
                oEscalaCualitativo.limite_inferior = Convert.ToDouble(txbLimInferior.Text);
                oEscalaCualitativo.limite_superior = Convert.ToDouble(txbLimSuperior.Text);
                oEscalaCualitativo.calificacion = txbCalifacion.Text;
                oEscalaCualitativo.principal = (chkPrincipal.Checked) ? 1 : 0;
                oEscalaCualitativo.codigo = id;
                id = id + 1;
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo.Add(oEscalaCualitativo);
            }
            if (action == Constantes.ACTION_UPDATE)
            {

                EscalaCualitativoEntidad oEscalaCualitativo = new EscalaCualitativoEntidad();
                oEscalaCualitativo = ObtenerEscalaCualitativo(codigo);
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo.Remove(oEscalaCualitativo);
                oEscalaCualitativo.limite_inferior = Convert.ToDouble(txbLimInferior.Text);
                oEscalaCualitativo.limite_superior = Convert.ToDouble(txbLimSuperior.Text);
                oEscalaCualitativo.calificacion = txbCalifacion.Text;
                oEscalaCualitativo.principal = (chkPrincipal.Checked) ? 1 : 0;
                oEscalaCualitativo.codigo = codigo;
                Sesiones.IndicadorSeleccionado.lstEscalaCualitativo.Add(oEscalaCualitativo);
            }



            Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuali + "?Action=" + action, true);
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Paginas.TMD_MP_IndicadorFormularioCuali + "?Action=" + action, true);
        }

        protected void CargarEscalaCualitativo(int codigo) 
        {
            EscalaCualitativoEntidad oEscalaCualitativo = ObtenerEscalaCualitativo(codigo);
            txbLimInferior.Text = oEscalaCualitativo.limite_inferior.ToString();
            txbLimSuperior.Text = oEscalaCualitativo.limite_superior.ToString();
            txbCalifacion.Text = oEscalaCualitativo.calificacion;
            chkPrincipal.Checked = (oEscalaCualitativo.principal == 1) ? true : false;


        }

        protected EscalaCualitativoEntidad ObtenerEscalaCualitativo(int codigo)
        {
            EscalaCualitativoEntidad oEscalaCuantitativo = new EscalaCualitativoEntidad();
            foreach (EscalaCualitativoEntidad obj in Sesiones.IndicadorSeleccionado.lstEscalaCualitativo)
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