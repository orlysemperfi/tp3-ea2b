<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true"
    CodeBehind="SolucionMejoraFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.SolucionMejoraFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="contenedor-pagina">
        <div class="contenedor-pagina-titulo">
            EDICION DE SOLUCIONES DE MEJORA</div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="right">
                                Código:
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCodigo" runat="server" />
                                <asp:TextBox ID="tbxCodigo" runat="server" Enabled="false" CssClass="estilo_textbox"></asp:TextBox>                                        
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Propuesta:
                            </td>
                            <td>
                                <asp:TextBox ID="tbxPropuesta" runat="server" Enabled="false" CssClass="estilo_textbox"></asp:TextBox>
                                <asp:LinkButton ID="lbtnBuscar" runat="server" OnClick="lbtnBuscar_Click" CssClass="estilo_boton" Text="Buscar"></asp:LinkButton></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="estilo_boton" Text="Guardar" ValidationGroup="Solucion"></asp:LinkButton>                            
                </td>
                <td class="boton-espaciado">
                    <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass="estilo_boton" Text="Cancelar" CausesValidation="false"></asp:LinkButton>
                </td>
                <td>
                    <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Solucion" />
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
