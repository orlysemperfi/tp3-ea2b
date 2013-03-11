<%@ Page Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" CodeBehind="EscalaCuantitativoFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.EscalaCuantitativaFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
         <table>            
            <tr><td>Signo:</td><td><asp:TextBox ID="txbSigno" runat="server" CssClass="estilo_textbox" Text='<%#Eval("SIGNO") %>'/></td></tr>
            <tr><td>Valor:</td><td><asp:TextBox ID="txbValor" runat="server" CssClass="estilo_textbox" Text='<%#Eval("VALOR") %>'/></td></tr>
            <tr><td>Unidad:</td><td><asp:DropDownList ID="ddlUnidad" runat="server" CssClass="estilo_combobox" /></td></tr>            
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
</asp:Content>
