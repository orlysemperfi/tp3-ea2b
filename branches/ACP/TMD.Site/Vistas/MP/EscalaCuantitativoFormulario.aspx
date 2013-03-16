<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscalaCuantitativoFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.EscalaCuantitativaFormulario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/TMD.MP/tmd-mp.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table>            
            <tr><td>Signo:</td><td><asp:TextBox ID="txbLimInferior" runat="server" CssClass="estilo_textbox" Text='<%#Eval("SIGNO") %>'/></td></tr>
            <tr><td>Valor:</td><td><asp:TextBox ID="txbLimSuperior" runat="server" CssClass="estilo_textbox" Text='<%#Eval("VALOR") %>'/></td></tr>
            <tr><td>Unidad:</td><td><asp:DropDownList ID="ddlUnidad" runat="server" CssClass="estilo_combobox" Text='<%#Eval("UNIDAD") %>'/></td></tr>            
        </table>
    </div>
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td><asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="estilo_boton" Text="Guardar"></asp:LinkButton></td>
            <td style="padding-left:5px"><asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass="estilo_boton" Text="Cancelar"></asp:LinkButton></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
