<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistroSolicitudCambio.ascx.cs"
    Inherits="TMD.CF.Site.Controles.RegistroSolicitudCambio" %>
<asp:Panel runat="server" ID="pnlSolicitudCambio">
<div class="panel-wrapper form" id="frm-actualizar-sc">
    <h1>
        Solicitud de Cambio</h1>
            <p class="buttons-wrapp">
        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" 
                    Text="Grabar Solicitud" ValidationGroup="GrabarValidationGroup" 
                    OnClientClick="javascript: return grabar();"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" />
    </p>
    <p>
        <span class="label-field">Nombre:</span>
        <asp:TextBox ID="txtNombre" runat="server" Width="230px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="El Nombre es requerido."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
        <span class="label-field">Proyecto:</span>
        <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" 
            OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged" Width="230px">
        </asp:DropDownList>
        <asp:CompareValidator ID="proyectoValidator" runat="server" ControlToValidate="ddlProyecto"
            ErrorMessage="El proyecto es requerido." ToolTip="El proyecto es requerido."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        <span class="label-field">Linea Base:</span>
        <asp:DropDownList ID="ddlLineaBase" runat="server" AutoPostBack="True" 
            OnSelectedIndexChanged="ddlLineaBase_SelectedIndexChanged" Width="210px">
        </asp:DropDownList>
        <asp:CompareValidator ID="lineaBaseValidator" runat="server" ControlToValidate="ddlLineaBase"
            ErrorMessage="La linea base es requerida." ToolTip="La linea base es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        <span class="label-field">Elemento Configuracion:</span>
        <asp:DropDownList ID="ddlElementoConfiguracion" runat="server" Width="150px">
        </asp:DropDownList>
        <asp:CompareValidator ID="elementoValidador" runat="server" ControlToValidate="ddlElementoConfiguracion"
            ErrorMessage="El elemento de configuraci&oacute;n es requerido." ToolTip="El elemento de configuraci&oacute;n es requerido"
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        <span class="label-field">Prioridad:</span>
        <asp:DropDownList ID="ddlPrioridad" runat="server" Width="100px">
        </asp:DropDownList>
        <asp:CompareValidator ID="prioridadValidador" runat="server" ControlToValidate="ddlPrioridad"
            ErrorMessage="La prioridad es requerida." ToolTip="La prioridad es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        <span class="label-field">Estado:</span>
        <asp:DropDownList Enabled="False" ID="ddlEstado" runat="server" Width="100px">
        </asp:DropDownList>
    </p>
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
