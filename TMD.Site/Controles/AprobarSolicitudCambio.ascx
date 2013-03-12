<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AprobarSolicitudCambio.ascx.cs" Inherits="TMD.CF.Site.Controles.AprobarSolicitudCambio" %>
<p>
    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
</p>
<p>
    Motivo:</p>
<p>
    <asp:TextBox ID="txtMotivo" runat="server" Height="105px" Width="367px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="motivoRequired" runat="server" ControlToValidate="txtMotivo"
            CssClass="failureNotification" ErrorMessage="El motivo es requerido." ToolTip="El motivo es requerido."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
</p>
<p>
    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" 
        ValidationGroup="GrabarValidationGroup" 
        OnClientClick="javascript: return grabar();" onclick="btnGrabar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
        onclick="btnCancelar_Click" />&nbsp;</p>
        <asp:HiddenField ID="hidIdSolicitud" runat="server" />
<asp:HiddenField ID="hidIdEstado" runat="server" />
        <asp:ValidationSummary ID="GrabarValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="GrabarValidationGroup" />
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
