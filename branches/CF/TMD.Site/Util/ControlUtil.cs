using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TMD.CF.Site.Util
{
    public static class ControlUtil
    {
        public static void EnlazarDatos<T>(this DropDownList combo, List<T> lista, String texto, String valor, int indice = -1, int id = 0)
        {
            EnlazarDatosInterno(combo, lista, texto, valor, indice, id);
        }

        public static void EnlazarValorDefecto(this DropDownList combo)
        {
            EnlazarDatosInterno<String>(combo, null, "", "");
        }

        private static void EnlazarDatosInterno<T>(DropDownList combo, List<T> lista, String texto, String valor, int indice=-1, int id = 0)
        {
            combo.ClearSelection();
            combo.Items.Clear();

            if (lista == null || lista.Count == 0)
            {
                combo.Items.Add(new ListItem { Text = "--Seleccione--", Value = "0", Selected = true });
                combo.DataBind();
            }
            else
            {
                combo.DataSource = lista;
                combo.DataTextField = texto;
                combo.DataValueField = valor;
                combo.SelectedIndex = (indice >= 0 ? indice : -1);
                combo.DataBind();

                combo.SelectedValue = id > 0 ? id.ToString() : null;
            }
        }
    }
}