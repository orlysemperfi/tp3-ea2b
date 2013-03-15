<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" 
    CodeBehind="IndicadorFormularioCuali.aspx.cs" Inherits="TMD.MP.Site.Privado.IndicadoresFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">


        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function confirmacion() { 
            if (confirm("¿Seguro que desea actualizar?")) {
                alert('Se actualizo la infromacion del Indicador');
                return true;
            }else
                return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="contenedor-pagina">
        <div class="contenedor-pagina-titulo">
            EDICION DE INDICADOR 
            CUALITATIVO</div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
             <tr>
                <td>
                    Proceso:</td>
                <td >
                    <asp:DropDownList ID="ddlProceso" runat="server" CssClass="estilo_combobox">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProceso" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ValidationGroup="Indicador" ErrorMessage="Seleccione un proceso" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre:
                </td>
                <td>
                    <asp:TextBox ID="tbxNombre" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbxNombre" ValidationGroup="Indicador" ErrorMessage="Ingrese un nombre" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Frecuencia de Medición:
                </td>
                <td>
                    <asp:TextBox ID="tbxFrecuenciaMed" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFrecuenciaMed" runat="server" ControlToValidate="tbxFrecuenciaMed" ValidationGroup="Indicador" ErrorMessage="Ingrese una frecuencia de medición" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Fuente de Medicion:
                </td>
                <td>
                    <asp:TextBox ID="tbxFuenteMed" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFuenteMed" runat="server" ControlToValidate="tbxFuenteMed" ValidationGroup="Indicador" ErrorMessage="Ingrese una fuente de medición" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Expresion Matematica:
                </td>
                <td>
                    <asp:TextBox ID="tbxExpresionMat" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvExpresionMat" runat="server" ControlToValidate="tbxExpresionMat" ValidationGroup="Indicador" ErrorMessage="Ingrese una expresión matemática" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Plazo:
                </td>
                <td>
                    <asp:TextBox ID="tbxPlazo" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPlazo" runat="server" ControlToValidate="tbxPlazo" ValidationGroup="Indicador" ErrorMessage="Ingrese un plazo" Display="None"></asp:RequiredFieldValidator>
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
                                    <asp:LinkButton ID="lbtnAgregarICuali" runat="server" Text="Agregar" 
                                        CssClass="estilo_boton" onclick="ButtonAdd_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-bottom:10px;">
                                    <asp:GridView ID="gwEscalasCuali" runat="server" AutoGenerateColumns="false" AllowPaging="false" CssClass="tabla-grilla" Width="800px" BorderWidth="0px" BorderColor="White" DataSource='<%#ObtenerEscalaCualitativoListado() %>' OnRowEditing="gwEscalasCuali_RowEditing" OnRowCancelingEdit="gwEscalasCuali_RowCancelingEdit" OnRowUpdating="gwEscalasCuali_RowUpdating" OnRowDeleting="gwEscalasCuali_RowDeleting" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                                        <HeaderStyle CssClass="tabla-grilla-cabecera" />
                                        <RowStyle CssClass="tabla-grilla-filas" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Codigo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Limite Superior">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLimSuperior" runat="server" Text='<%#Eval("LIMITE_SUPERIOR") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbxLimSuperior" runat="server" Text='<%#Eval("LIMITE_SUPERIOR") %>' CssClass="estilo_textbox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Limite Inferior">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLimInferior" runat="server" Text='<%#Eval("LIMITE_INFERIOR") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbxLimInferior" runat="server" Text='<%#Eval("LIMITE_INFERIOR") %>' CssClass="estilo_textbox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Calificacion">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCalificacion" runat="server" Text='<%#Eval("CALIFICACION") %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbxCalificacion" runat="server" Text='<%#Eval("CALIFICACION") %>' CssClass="estilo_textbox"></asp:TextBox>
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
                    <asp:LinkButton ID="lbtnGuardar" runat="server"  OnClick="lbtnGuardar_Click"  CssClass="estilo_boton" Text="Guardar" ValidationGroup="Indicador"></asp:LinkButton>
                </td>
                <td style="padding:5px">
                    <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass="estilo_boton" Text="Cancelar" CausesValidation="false"></asp:LinkButton>
                </td>
                <td>
                    <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Indicador" />
                </td>
            </tr>
        </table>
    </div>    
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>