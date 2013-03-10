<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AprobarSolicitudCambio.ascx.cs" Inherits="TMD.CF.Site.Controles.AprobarSolicitudCambio" %>
<p>
    Aprobar Solicitud</p>
<p>
    Motivo:</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server" Height="105px" Width="367px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="GrabarValidationGroup" OnClientClick="javascript: return grabar();"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />&nbsp;</p>

<script type="text/javascript" language="javascript">
    function grabar() {
        if (Page_ClientValidate('GrabarValidationGroup')) {
            Page_BlockSubmit = false;
            return confirm('Desea grabar los datos ingresados?');
        }
        Page_BlockSubmit = false;
        return false;
    }
</script>
