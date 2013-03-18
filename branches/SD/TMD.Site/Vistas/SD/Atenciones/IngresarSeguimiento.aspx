<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" 
CodeBehind="IngresarSeguimiento.aspx.cs"  Inherits="TMD.CF.Site.Vistas.SD.Atenciones.IngresarSeguimiento" %>
                                         
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
        .style5
        {
        }
        .style6
        {
        }
        .style7
        {
      }
        .style8
        {
            width: 137px;
        }
        .style10
      {
          width: 150px;
          height: 153px;
      }
      .style11
      {
          height: 153px;
      }
      .style12
      {
          width: 132px;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table class="style1">
        <tr>
            <td colspan="4" class="title">
                <asp:Label ID="lblTitulo" runat="server" CssClass="title" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#0033CC" Text="SEGUIMIENTO DEL TICKET"></asp:Label>
                </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" class="title">
                <asp:Label ID="Label1" runat="server" CssClass="bold" 
                    Text="Datos del Ticket de Atención"></asp:Label>
            &nbsp;m</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Número Ticket:</td>
            <td class="style7" colspan="3">
                <asp:TextBox ID="txtNroTicket" runat="server" ReadOnly="True" 
                    ontextchanged="txtNroTicket_TextChanged"></asp:TextBox>
            </td>
            <td class="style12">
                Fecha Registro:</td>
            <td>
                <asp:TextBox ID="txtFechaRegistro" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Tipo Ticket:</td>
            <td class="style7" colspan="3">
                <asp:TextBox ID="txtTipoTicket" runat="server" ReadOnly="True" Width="116px"></asp:TextBox>
            </td>
            <td class="style12">
                Analista:</td>
            <td>
                <asp:TextBox ID="txtAnalista" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Servicio:</td>
            <td class="style7" colspan="3">
                <asp:TextBox ID="txtServicio" runat="server" ReadOnly="True" Width="395px"></asp:TextBox>
            </td>
            <td class="style12">
                Especialista:</td>
            <td class="style3">
                <asp:TextBox ID="txtEspecialista" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                Usuario:</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Descripción Ticket:</td>
            <td class="style5" colspan="4">
                <asp:TextBox ID="txtDescripcionBreve" runat="server" Width="393px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2" align="left" valign="top">
                Descripción del seguimiento:</td>
            <td class="style6" colspan="5">
                <asp:TextBox ID="txtSeguimiento" runat="server" CssClass="fieldEdit" 
                    Height="64px" Width="608px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" Width="78px" />
            </td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style10">
                </td>
            <td class="style11" colspan="5">
                <asp:GridView ID="grdSeguimiento" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" 
                    Width="797px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="CODIGO_SEGUIMIENTO" HeaderText="Id" 
                            ReadOnly="True" />
                        <asp:BoundField HeaderText="Fecha Registro" ReadOnly="True" 
                            DataField="FECHA_REGISTRO" />
                        <asp:BoundField HeaderText="Especialista" ReadOnly="True" 
                            DataField="NOMBRE_INTEGRANTE" />
                        <asp:BoundField HeaderText="Descripción del seguimiento" 
                            DataField="DESCRIPCION_SEGUIMIENTO" />
                        <asp:BoundField DataField="Tipo_Seguimiento" HeaderText="Tipo Seguimiento" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style8">
                <asp:Button ID="btnSalir" runat="server" onclick="btnSalir_Click" Text="Salir" 
                    Width="81px" />
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
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
