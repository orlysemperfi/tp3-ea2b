<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistroSolicitudCambio.ascx.cs"
    Inherits="TMD.CF.Site.Controles.RegistroSolicitudCambio" %>
<asp:Panel runat="server" ID="pnlSolicitudCambio">
    <p>
        Solicitud de Cambio</p>
    <p>
        Codigo:
        <asp:Label ID="lblCodigo" runat="server"></asp:Label>
    </p>
    <p>
        Nombre:
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="El Nombre es requerido."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Proyecto:
        <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:CompareValidator ID="proyectoValidator" runat="server" ControlToValidate="ddlProyecto"
            ErrorMessage="El proyecto es requerido." ToolTip="El proyecto es requerido."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        Linea Base:
        <asp:DropDownList ID="ddlLineaBase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLineaBase_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:CompareValidator ID="lineaBaseValidator" runat="server" ControlToValidate="ddlLineaBase"
            ErrorMessage="La linea base es requerida." ToolTip="La linea base es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        Elemento Configuracion:
        <asp:DropDownList ID="ddlElementoConfiguracion" runat="server">
        </asp:DropDownList>
        <asp:CompareValidator ID="elementoValidador" runat="server" ControlToValidate="ddlElementoConfiguracion"
            ErrorMessage="El elemento de configuraci&oacute;n es requerido." ToolTip="El elemento de configuraci&oacute;n es requerido"
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        Prioridad:
        <asp:DropDownList ID="ddlPrioridad" runat="server">
        </asp:DropDownList>
        <asp:CompareValidator ID="prioridadValidador" runat="server" ControlToValidate="ddlPrioridad"
            ErrorMessage="La prioridad es requerida." ToolTip="La prioridad es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        Estado:
        <asp:DropDownList Enabled="False" ID="ddlEstado" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" ValidationGroup="GrabarValidationGroup" OnClientClick="javascript: return grabar();"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
    </p>
    <p>
        &nbsp;<asp:ValidationSummary ID="GrabarValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="GrabarValidationGroup" />
        <p>
            &nbsp;</p>
        <p>
        </p>
    </p>
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
