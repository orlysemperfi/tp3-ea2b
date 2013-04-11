<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" 
CodeBehind="IngresarSolucion.aspx.cs" Inherits="TMD.ServiceDesk.Site.Atenciones.IngresarSolucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 150px;
        }
        .style3
        {
            width: 192px;
        }
        .style4
        {
            width: 152px;
        }
        .style5
        {
        }
        .style6
        {
        }
        .style7
        {
            width: 417px;
        }
        .style8
        {
            width: 137px;
        }
        .style9
        {
            width: 131px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td colspan="4" class="title">
                <asp:Label ID="lblTitulo" runat="server" CssClass="title" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#0033CC" Text="SOLUCION DEL TICKET"></asp:Label>
                </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="title">
                <asp:Label ID="Label1" runat="server" CssClass="bold" 
                    Text="Datos del Ticket de Atención"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Número Ticket:</td>
            <td class="style7" colspan="3">
                <asp:TextBox ID="txtNroTicket" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style4">
                Fecha Registro:</td>
            <td>
                <asp:TextBox ID="txtFechaRegistro" runat="server" Width="160px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Tipo Ticket:</td>
            <td class="style7" colspan="3">
                <asp:TextBox ID="txtTipoTicket" runat="server" Width="285px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style4">
                Analista:</td>
            <td>
                <asp:TextBox ID="txtAnalista" runat="server" Width="256px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Servicio:</td>
            <td class="style7" colspan="3">
                <asp:TextBox ID="txtServicio" runat="server" Width="290px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style2">
                Especialista:</td>
            <td class="style3">
                <asp:TextBox ID="txtEspecialista" runat="server" Width="256px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style5">
                Usuario:</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="256px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Descripción Ticket:</td>
            <td class="style5" colspan="4">
                <asp:TextBox ID="txtDescripcionBreve" runat="server" Width="432px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Text="Mensaje"></asp:Label>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2" align="left" valign="top">
                Descripción de la
                Solución:</td>
            <td class="style6" colspan="5">
                <asp:TextBox ID="txtSolucion" runat="server" MaxLength="200" Rows="5" 
                    TextMode="MultiLine" Width="692px" Height="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="txtSolucion" 
                    ErrorMessage="Debe ingresar 20 carácteres como mínimo" ForeColor="Red" 
                    onservervalidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            </td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style8">
                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="130px" 
                    onclick="btnGrabar_Click" />
            </td>
            <td class="style8">
                <asp:Button ID="btnDocumentacion" runat="server" Text="Documentacion" 
                    Width="130px" onclick="btnDocumentacion_Click" />
            </td>
            <td class="style9">
                <asp:Button ID="btnBDC" runat="server" onclick="btnBDC_Click" 
                    Text="Base Conocimiento" Width="130px" />
            </td>
            <td class="style4">
                <asp:Button ID="btnSalir" runat="server" Text="Salir" Width="130px" 
                    onclick="btnSalir_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
