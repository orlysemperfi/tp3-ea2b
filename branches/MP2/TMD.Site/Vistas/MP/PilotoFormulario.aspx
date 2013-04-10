<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="PilotoFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.PilotoFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
  <link rel="stylesheet" href="../ACP/css/jquery-ui.css" />    

    <script type="text/javascript">
        $(function () {
            $("#<%=tbxFechaInicio.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%=tbxFechaInicio.ClientID %>").datepicker();
            $("#<%=tbxFechaFin.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%=tbxFechaFin.ClientID %>").datepicker();
        });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">EDICIÓN DE PILOTO</h1>
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
                                    Fecha Inicio:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxFechaInicio" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Fecha Fin:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxFechaFin" runat="server"></asp:TextBox>            
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Solucion:
                                </td>
                                <td>
                                <asp:DropDownList ID="ddlSolucion" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Empleado:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEmpleado" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    Descripción:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>                                    
                                    <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="tbxFechaInicio" ErrorMessage="Ingrese una fecha de Inicio" ValidationGroup="Piloto" Display="Dynamic" ForeColor="Red" />
                                <br />                        
                                    <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server" ControlToValidate="tbxFechaFin" ErrorMessage="Ingrese una fecha de Fin" ValidationGroup="Piloto" Display="Dynamic" ForeColor="Red" />
                                <br />
                                <asp:RequiredFieldValidator ID="rfvSolucion" runat="server" ControlToValidate="ddlSolucion" InitialValue="0" ErrorMessage="Seleccione una solucion" ValidationGroup="Piloto" Display="Dynamic" ForeColor="Red" />
                                <br />
                                <asp:RequiredFieldValidator ID="rfvEmpleado" runat="server" ControlToValidate="ddlEmpleado" InitialValue="0" ErrorMessage="Seleccione un empleado" ValidationGroup="Piloto" Display="Dynamic" ForeColor="Red" />
                                <br />
                                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="tbxDescripcion" ErrorMessage="Ingrese una descripción" ValidationGroup="Piloto" Display="Dynamic" ForeColor="Red" />
                                    <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="false" ShowSummary="false" ValidationGroup="Piloto" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="Piloto" />
                                </td>
                                <td style="padding-left:5px;">
                                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
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
