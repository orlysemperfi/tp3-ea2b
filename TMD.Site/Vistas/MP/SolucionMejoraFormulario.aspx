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
                                <asp:DropDownList ID="ddlPropuesta" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                <asp:RequiredFieldValidator ID="rfvPropuesta" runat="server" ControlToValidate="ddlPropuesta" InitialValue="0" ErrorMessage="Seleccione una propuesta" ValidationGroup="Solucion" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Empleado:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEmpleado" runat="server" />
                                </td>
                                <td>
                                <asp:RequiredFieldValidator ID="rfvEmpleado" runat="server" ControlToValidate="ddlEmpleado" InitialValue="0" ErrorMessage="Seleccione un empleado" ValidationGroup="Solucion" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    Descripción:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="tbxDescripcion" ErrorMessage="Ingrese una descripción" ValidationGroup="Solucion" Display="None" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>Acciones</legend>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding-bottom:10px;">
                                                    <asp:Button ID="btnAgregarAccion" runat="server" Text="Agregar" 
                                                        onclick="ButtonAdd_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-bottom:10px;">
                                                    <asp:GridView ID="gwAcciones" runat="server" AutoGenerateColumns="false" AllowPaging="false" Width="760px" BorderWidth="0px" BorderColor="White" DataSource='<%#ObtenerAccionesListado() %>' OnRowEditing="gwAcciones_RowEditing" OnRowCancelingEdit="gwAcciones_RowCancelingEdit" OnRowUpdating="gwAcciones_RowUpdating" OnRowDeleting="gwAcciones_RowDeleting" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Código" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>'/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Acción">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAccion" runat="server" Text='<%#Eval("DESCRIPCION") %>' />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="tbxAccion" runat="server" Text='<%#Eval("DESCRIPCION") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width=" 640px" />
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
