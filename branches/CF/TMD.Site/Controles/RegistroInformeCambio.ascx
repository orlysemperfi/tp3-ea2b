<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistroInformeCambio.ascx.cs"
    Inherits="TMD.CF.Site.Controles.RegistroInformeCambio" %>
<asp:Panel runat="server" ID="pnlInformeCambio">
<div class="panel-wrapper form" id="frm-actualizar-sc">
<table>
<tr>
<td colspan="2">
    <h1 class="buttons-wrapp">
        Informe de Cambio</h1>
</td>
</tr>
<tr>
<td colspan="2">
    <p class="buttons-wrapp">
        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar informe" ValidationGroup="GrabarValidationGroup" OnClientClick="javascript: return grabar();"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" onClientClick="javascript:ocultarDiv('divRegistroInforme');"/>
    </p>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Nombre de Informe:</span>
</td>
<td>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="El Nombre es requerido."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Proyecto:</span>
</td>
<td>
        <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:CompareValidator ID="proyectoValidator" runat="server" ControlToValidate="ddlProyecto"
            ErrorMessage="El proyecto es requerido." ToolTip="El proyecto es requerido."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Línea Base:</span>
</td>
<td>
        <asp:DropDownList ID="ddlLineaBase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLineaBase_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:CompareValidator ID="lineaBaseValidator" runat="server" ControlToValidate="ddlLineaBase"
            ErrorMessage="La linea base es requerida." ToolTip="La linea base es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Solicitud:</span>
</td>
<td>
        <asp:DropDownList ID="ddlSolicitud" runat="server">
        </asp:DropDownList>
        <asp:CompareValidator ID="elementoValidador" runat="server" ControlToValidate="ddlSolicitud"
            ErrorMessage="La solicitud es requerida." ToolTip="La solicitud es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Estimación de costo:</span>
</td>
<td>
        <asp:TextBox ID="TxtCosto" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="estimacionCosto" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="La estimación de costo es requerida."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Estimación de esfuerzo:</span>
</td>
<td>
        <asp:TextBox ID="TxtEsfuerzo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="estimacionEsfuerzo" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="La estimación de esfuerzo es requerida"
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
        <span class="label-field">Recursos:</span>
</td>
<td>
        <asp:TextBox ID="TxtRecurso" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Recursos" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="Los recursos son requeridos."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
</td>
</tr>
</table>
        <asp:ValidationSummary ID="GrabarValidationSummary" runat="server" 
        CssClass="failureNotification" ValidationGroup="GrabarValidationGroup" />
</div>

</asp:Panel>
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

