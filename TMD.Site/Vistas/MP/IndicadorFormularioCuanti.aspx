﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="IndicadorFormularioCuanti.aspx.cs" Inherits="TMD.CF.Site.Vistas.MP.IndicadorFormularioCuanti" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
    <div id="listaSol" class="content">
        <h1 class="page-title">EDICIÓN DE INDICADOR CUANTITATIVO</h1>
        <div class="panel-wrapper form">
            <table border="0" cellpadding="0" cellspacing="0">
                 <tr>
                    <td>
                        Proceso:</td>
                    <td >
                        <asp:DropDownList ID="ddlProceso" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProceso" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ValidationGroup="IndicadorC" ErrorMessage="Seleccione un proceso" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nombre:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbxNombre" ValidationGroup="IndicadorC" ErrorMessage="Ingrese un nombre" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Frecuencia de Medición:
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlFrecuenciaMed" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvFrecuenciaMed" runat="server" ControlToValidate="ddlFrecuenciaMed" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una frecuencia de medición" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fuente de Medición:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxFuenteMed" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFuenteMed" runat="server" ControlToValidate="tbxFuenteMed" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una fuente de medición" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Expresión Matemática:
                    </td>
                    <td>
                        <asp:TextBox ID="tbxExpresionMat" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvExpresionMat" runat="server" ControlToValidate="tbxExpresionMat" ValidationGroup="IndicadorC" ErrorMessage="Ingrese una expresión matemática" Display="None"></asp:RequiredFieldValidator>
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        Plazo:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPlazo" runat="server"></asp:DropDownList>
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
                                        <asp:Button ID="btnAgregarICuanti" runat="server" Text="Agregar" 
                                            onclick="ButtonAdd_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom:10px;">
                                        <asp:GridView ID="gwEscalasCuanti" runat="server" AutoGenerateColumns="false" AllowPaging="false" Width="800px" BorderWidth="0px" BorderColor="White" DataSource='<%#ObtenerEscalaCuantitativoListado() %>' OnRowEditing="gwEscalasCuanti_RowEditing" OnRowCancelingEdit="gwEscalasCuanti_RowCancelingEdit" OnRowUpdating="gwEscalasCuanti_RowUpdating" OnRowDeleting="gwEscalasCuanti_RowDeleting" OnRowDataBound="gwEscalasCuanti_RowDataBound" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Código" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Signo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSigno" runat="server" Text='<%#Eval("SIGNO") %>'  />
                                                    </ItemTemplate>
                                                 <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlSigno" runat="server"></asp:DropDownList>
                                                </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Valor">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblValor" runat="server" Text='<%#Eval("VALOR") %>' />
                                                    </ItemTemplate>
                                                 <EditItemTemplate>
                                                    <asp:TextBox ID="tbxValor" runat="server" Text='<%#Eval("VALOR") %>' onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </EditItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unidad">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnidad" runat="server" Text='<%#Eval("DESCRIPCION_UNIDAD") %>' />
                                                    </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlUnidad" runat="server"></asp:DropDownList>
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
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="IndicadorC" />
                    </td>
                    <td style="padding:5px">
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
                    </td>
                    <td>
                        <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="IndicadorC" />
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