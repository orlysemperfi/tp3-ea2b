<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="SolucionMejoraFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.SolucionMejoraFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">EDICIÓN DE SOLUCIÓN DE MEJORA</h1>
        <div class="panel-wrapper form">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
                <tr>
                    <td valign="top">
                        <table border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td align="right">
                                    Código:
                                </td>
                                <td>
                                                
                                    <asp:TextBox ID="tbxCodigo" runat="server" Enabled="false"></asp:TextBox>                                        
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnCodigo" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Propuesta:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxPropuesta" runat="server" Enabled="false"></asp:TextBox>
                                                
                                </td>
                                <td style="padding-left:5px;">
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="Solucion" />
                                </td>
                                <td style="padding-left:5px;">
                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
                                </td>
                                <td>
                                    <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Solucion" />
                                </td>
                            </tr>
                        </table>
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
