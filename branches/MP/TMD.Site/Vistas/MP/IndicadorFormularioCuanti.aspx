<%@ Page Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" CodeBehind="IndicadorFormularioCuanti.aspx.cs" Inherits="TMD.CF.Site.Vistas.MP.IndicadorFormularioCuanti" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        document.getElementById("IndicadorCuantitativo").style.visibility = "hidden";
    </script>
    <script type="text/javascript" language="javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="contenedor-pagina">
        <div class="contenedor-pagina-titulo">
            EDICION DE INDICADOR CUANTITATIVO</div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
             <tr>
                <td>
                    Proceso:</td>
                <td >
                    <asp:DropDownList ID="ddlProceso" runat="server" CssClass="estilo_combobox">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvProceso" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ValidationGroup="IndicadorC" ErrorMessage="Seleccione un proceso" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Nombre:
                </td>
                <td>
                    <asp:TextBox ID="tbxNombre" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbxNombre" ValidationGroup="IndicadorC" ErrorMessage="Ingrese un nombre" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Frecuencia de Medición:
                </td>
                <td>
                     <asp:DropDownList ID="ddlFrecuenciaMed" runat="server" CssClass="estilo_combobox"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvFrecuenciaMed" runat="server" ControlToValidate="ddlFrecuenciaMed" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una frecuencia de medición" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Fuente de Medicion:
                </td>
                <td>
                    <asp:TextBox ID="tbxFuenteMed" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFuenteMed" runat="server" ControlToValidate="tbxFuenteMed" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una fuente de medición" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Expresion Matematica:
                </td>
                <td>
                    <asp:TextBox ID="tbxExpresionMat" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvExpresionMat" runat="server" ControlToValidate="tbxExpresionMat" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una expresión matemática" Display="None"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td>
                    Plazo:
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlazo" runat="server" CssClass="estilo_combobox" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvPlazo" runat="server" ControlToValidate="ddlPlazo" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una plazo" Display="None"></asp:RequiredFieldValidator>
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
                                    <asp:LinkButton ID="lbtnAgregarICuanti" runat="server" Text="Agregar" 
                                        CssClass="estilo_boton" onclick="ButtonAdd_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-bottom:10px;">
                                    <asp:GridView ID="gwEscalasCuanti" runat="server" AutoGenerateColumns="false" AllowPaging="false" CssClass="tabla-grilla" Width="800px" BorderWidth="0px" BorderColor="White" DataSource='<%#ObtenerEscalaCuantitativoListado() %>' OnRowEditing="gwEscalasCuanti_RowEditing" OnRowCancelingEdit="gwEscalasCuanti_RowCancelingEdit" OnRowUpdating="gwEscalasCuanti_RowUpdating" OnRowDeleting="gwEscalasCuanti_RowDeleting" OnRowDataBound="gwEscalasCuanti_RowDataBound" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" >
                                        <HeaderStyle CssClass="tabla-grilla-cabecera" />
                                        <RowStyle CssClass="tabla-grilla-filas" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Codigo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Signo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSigno" runat="server" Text='<%#Eval("SIGNO") %>'  />
                                                </ItemTemplate>
                                             <EditItemTemplate>
                                                <asp:DropDownList ID="ddlSigno" runat="server" CssClass="estilo_combobox"></asp:DropDownList>
                                            </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valor">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblValor" runat="server" Text='<%#Eval("VALOR") %>' />
                                                </ItemTemplate>
                                             <EditItemTemplate>
                                                <asp:TextBox ID="tbxValor" runat="server" Text='<%#Eval("VALOR") %>' CssClass="estilo_textbox" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </EditItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unidad">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnidad" runat="server" Text='<%#Eval("DESCRIPCION_UNIDAD") %>' />
                                                </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlUnidad" runat="server" CssClass="estilo_combobox"></asp:DropDownList>
                                            </EditItemTemplate>
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
                    <asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="estilo_boton" Text="Guardar" ValidationGroup="IndicadorC"></asp:LinkButton>
                </td>
                <td style="padding:5px">
                    <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass="estilo_boton" Text="Cancelar" CausesValidation="false"></asp:LinkButton>
                </td>
                <td>
                    <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="IndicadorC" />
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