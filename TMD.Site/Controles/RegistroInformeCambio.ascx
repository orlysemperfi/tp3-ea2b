<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistroInformeCambio.ascx.cs"
    Inherits="TMD.CF.Site.Controles.RegistroInformeCambio" %>
<asp:Panel runat="server" ID="pnlInformeCambio">
    <p>
        Informe de Cambio</p>
    <p>
        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" ValidationGroup="GrabarValidationGroup" OnClientClick="javascript: return grabar();"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" />
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
        Solicitud:
        <asp:DropDownList ID="ddlSolicitud" runat="server">
        </asp:DropDownList>
        <asp:CompareValidator ID="elementoValidador" runat="server" ControlToValidate="ddlSolicitud"
            ErrorMessage="La solicitud es requerida." ToolTip="La solicitud es requerida."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
    <p>
        Estimación de costo:
        <asp:TextBox ID="TxtCosto" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="estimacionCosto" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="La estimación de costo es requerida."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Estimación de esfuerzo:
        <asp:TextBox ID="TxtEsfuerzo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="estimacionEsfuerzo" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="La estimación de esfuerzo es requerida"
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
    </p>
    <p>
        Recursos:
        <asp:TextBox ID="TxtRecurso" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Recursos" runat="server" ControlToValidate="txtNombre"
            CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="Los recursos son requeridos."
            ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
    </p>
        <asp:ValidationSummary ID="GrabarValidationSummary" runat="server" 
        CssClass="failureNotification" ValidationGroup="GrabarValidationGroup" />
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

