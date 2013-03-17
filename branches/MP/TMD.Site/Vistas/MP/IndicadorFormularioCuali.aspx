<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" 
    CodeBehind="IndicadorFormularioCuali.aspx.cs" Inherits="TMD.MP.Site.Privado.IndicadoresFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">


        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function confirmacion() { 
            if (confirm("¿Seguro que desea actualizar?")) {
                alert('Se actualizó la información del Indicador');
                return true;
            }else
                return false;
        }

        function validarRangos() {
            var tbxLimSuperior = document.getElementById("tbxLimSuperior");
            var tbxLimInferior = document.getElementById("tbxLimInferior");



           
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">EDICIÓN DE INDICADOR CUALITATIVO</h1>
        <div class="panel-wrapper form">
            <table border="0" cellpadding="0" cellspacing="0">
                 <tr>
                    <td>
                        Proceso:</td>
                    <td >
                        <asp:DropDownList ID="ddlProceso" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProceso" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ValidationGroup="Indicador" ErrorMessage="Seleccione un proceso" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbxNombre" ValidationGroup="Indicador" ErrorMessage="Ingrese un nombre" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Frecuencia de Medición:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFrecuenciaMed" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvFrecuenciaMed" runat="server" ControlToValidate="ddlFrecuenciaMed" InitialValue="0" ValidationGroup="Indicador" ErrorMessage="Ingrese una frecuencia de medición" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fuente de Medición:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxFuenteMed" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFuenteMed" runat="server" ControlToValidate="tbxFuenteMed" ValidationGroup="Indicador" ErrorMessage="Ingrese una fuente de medición" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Plazo:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPlazo" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvPlazo" runat="server" ControlToValidate="ddlPlazo" ValidationGroup="Indicador" InitialValue="0" ErrorMessage="Ingrese un plazo" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Escalas</legend>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom:10px;">
                                        <asp:Button ID="btnAgregarICuali" runat="server" Text="Agregar" 
                                            onclick="ButtonAdd_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom:10px;">
                                        <asp:GridView ID="gwEscalasCuali" runat="server" AutoGenerateColumns="false" AllowPaging="false" Width="800px" BorderWidth="0px" BorderColor="White" DataSource='<%#ObtenerEscalaCualitativoListado() %>' OnRowEditing="gwEscalasCuali_RowEditing" OnRowCancelingEdit="gwEscalasCuali_RowCancelingEdit" OnRowUpdating="gwEscalasCuali_RowUpdating" OnRowDeleting="gwEscalasCuali_RowDeleting" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Código" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Límite Superior">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLimSuperior" runat="server" Text='<%#Eval("LIMITE_SUPERIOR") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxLimSuperior" runat="server" Text='<%#Eval("LIMITE_SUPERIOR") %>' onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Límite Inferior">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLimInferior" runat="server" Text='<%#Eval("LIMITE_INFERIOR") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxLimInferior" runat="server" Text='<%#Eval("LIMITE_INFERIOR") %>' onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Calificación">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCalificacion" runat="server" Text='<%#Eval("CALIFICACION") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="tbxCalificacion" runat="server" Text='<%#Eval("CALIFICACION") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Principal">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkPrincipal0" runat="server"  Checked='<%#(Eval("PRINCIPAL").ToString()=="1")? true : false %>' Enabled="false"/>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="chkPrincipal" runat="server"  Checked='<%#(Eval("PRINCIPAL").ToString()=="1")? true : false %>' />
                                                    </EditItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width=" 0px" />
                                                </asp:TemplateField>
                                            </Columns>                        
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server"  OnClick="btnGuardar_Click"  Text="Guardar" ValidationGroup="Indicador" />
                    </td>
                    <td style="padding:5px">
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
                    </td>
                    <td>
                        <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Indicador" />
                    </td>
                </tr>
            </table>
        </div>
    </div> 
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>