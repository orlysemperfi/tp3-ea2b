<%@ Page Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" CodeBehind="EscalaCualitativoFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>            
            <tr><td>Limite Inferior:</td><td><asp:TextBox ID="txbLimInferior" runat="server" CssClass="estilo_textbox"/></td></tr>
            <tr><td>Limite Superior:</td><td><asp:TextBox ID="txbLimSuperior" runat="server" CssClass="estilo_textbox"/></td></tr>
            <tr><td>Calificacion:</td><td><asp:TextBox ID="txbCalifacion" runat="server" CssClass="estilo_textbox"/></td></tr>            
            <tr><td>Principal:</td><td><asp:CheckBox ID="chkPrincipal" runat="server"/></td></tr>            
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
