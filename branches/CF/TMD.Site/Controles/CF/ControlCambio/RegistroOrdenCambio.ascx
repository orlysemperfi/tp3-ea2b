<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistroOrdenCambio.ascx.cs" 
	Inherits="TMD.CF.Site.Controles.CF.ControlCambio.RegistroOrdenCambio" %>
<asp:Button ID="btnRegresar" runat="server" Text="Regresar" 
        onclick="btnRegresar_Click" />
<asp:Panel runat="server" ID="pnlOrdenCambio">
<div class="panel-wrapper form" id="frm-actualizar-sc">
    <h1>
        Orden de Cambio</h1>
            <p class="buttons-wrapp">
        <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" 
                    Text="Grabar Orden" ValidationGroup="GrabarValidationGroup" 
                    OnClientClick="javascript: return grabar();"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" cssClass="btn-cancelar"
            onclick="btnCancelar_Click" onClientClick="javascript:ocultarDiv('divRegistroOrden');"/>
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
        <span class="label-field">Informe:</span>
        <asp:DropDownList ID="ddlInforme" runat="server" Width="150px">
        </asp:DropDownList>
        <asp:CompareValidator ID="informeValidator" runat="server" ControlToValidate="ddlInforme"
            ErrorMessage="El informe es requerido." ToolTip="El informe es requerido."
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
        <span class="label-field">Usuario Asignado:</span>
        <asp:DropDownList ID="ddlUsuario" runat="server">
        </asp:DropDownList>
        <asp:CompareValidator ID="usuarioValidator" runat="server" ControlToValidate="ddlUsuario"
            ErrorMessage="El usuario es requerido." ToolTip="El usuario es requerido."
            ValidationGroup="GrabarValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
    </p>
        <asp:ValidationSummary ID="GrabarValidationSummary" runat="server" 
        CssClass="failureNotification" ValidationGroup="GrabarValidationGroup" />
        <div id="divRN" style="display:none">
            <asp:TextBox ID="txtRN" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RNValidator" runat="server" ControlToValidate="txtRN"
                CssClass="failureNotification" ErrorMessage=""
                ValidationGroup="GrabarValidationGroup"></asp:RequiredFieldValidator>
        </div>
        
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
