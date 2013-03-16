<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="EscalarTicket.aspx.cs" Inherits="TMD.CF.Site.Vistas.SD.Atenciones.EscalarTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            height: 31px;
        }
        .style3
        {
            height: 32px;
        }
        .style4
        {
            width: 297px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="style1">
        <tr>
            <td colspan="5" class="title">
                <asp:Label ID="lblTitulo" runat="server" CssClass="title" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#0033CC" Text="ESCALAR TICKET"></asp:Label>
                </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" class="title">
                <asp:Label ID="Label1" runat="server" CssClass="bold" 
                    Text="Datos del Ticket de Atención"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Número Ticket:</td>
            <td class="style7" colspan="4">
                <asp:TextBox ID="txtNroTicket" runat="server"></asp:TextBox>
            </td>
            <td class="style12">
                Fecha Registro:</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Tipo Ticket:</td>
            <td class="style7" colspan="4">
                <asp:TextBox ID="txtTipoTicket" runat="server"></asp:TextBox>
            </td>
            <td class="style12">
                Analista:</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Width="199px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Servicio:</td>
            <td class="style7" colspan="4">
                <asp:TextBox ID="TextBox3" runat="server" Width="356px"></asp:TextBox>
            </td>
            <td class="style12">
                Especialista:</td>
            <td class="style3">
                <asp:TextBox ID="TextBox7" runat="server" Width="203px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                Usuario:</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" Width="205px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Descripción Ticket:</td>
            <td class="style5" colspan="5">
                <asp:TextBox ID="TextBox4" runat="server" Width="360px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2" align="left" valign="top">
                Nuevo Especialista:</td>
            <td class="style6" colspan="6">
                <asp:DropDownList ID="cmbEspecialista" runat="server" Height="16px" 
                    Width="366px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style10">
                Motivo:</td>
            <td class="style11" colspan="6" rowspan="2">
                <asp:TextBox ID="txtComentario" runat="server" Height="93px" 
                    TextMode="MultiLine" Width="552px"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td class="style2">
                </td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" 
                    Text="Aceptar" />
            </td>
            <td class="style4">
                <asp:Button ID="btnSalir" runat="server" style="margin-left: 0px" Text="Salir" 
                    Width="66px" />
            </td>
            <td class="style8">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="4">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
