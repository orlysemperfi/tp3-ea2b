<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="CambiarEstado.aspx.cs" Inherits="TMD.CF.Site.Vistas.SD.Atenciones.CambiarEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 147px;
        }
        .style3
        {
            width: 493px;
        }
        .style4
        {
            width: 185px;
        }
        .style5
        {
            width: 147px;
            height: 9px;
        }
        .style6
        {
            width: 493px;
            height: 9px;
        }
        .style7
        {
            height: 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <asp:Label ID="lblTitulo" runat="server" CssClass="title" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#0033CC" Text="ACTUALIZAR ESTADO DEL TICKET"></asp:Label>
                <br />
                <br />
                <table class="style1">
                    <tr>
                        <td class="style2">
                <asp:Label ID="Label1" runat="server" CssClass="bold" 
                    Text="Número Ticket"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtNroTicket" runat="server"></asp:TextBox>
                        </td>
                        <td class="style3">
                            Fecha Registro:</td>
                        <td class="style3">
                            <asp:TextBox ID="txtFechaRegistro" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Label ID="Label4" runat="server" CssClass="bold" 
                    Text="Descripción Ticket"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:TextBox ID="txtDescripcionBreve" runat="server" Width="368px"></asp:TextBox>
                        </td>
                        <td class="style3">
                            Usuario:</td>
                        <td class="style3">
                            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Estado Actual</td>
                        <td class="style3">
                            <asp:TextBox ID="txtEstadoActual" runat="server"></asp:TextBox>
                        </td>
                        <td class="style3">
                            Tipo Ticket</td>
                        <td class="style3">
                            <asp:TextBox ID="txtTipoTicket" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                <asp:Label ID="Label2" runat="server" CssClass="bold" 
                    Text="Estado del Ticket"></asp:Label>
                        </td>
                        <td class="style6" colspan="3">
                            <asp:DropDownList ID="cmbEstado" runat="server" Height="16px" Width="148px">
                            </asp:DropDownList>
                        </td>
                        <td class="style7">
                            </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3" colspan="3">
                            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Label ID="Label3" runat="server" CssClass="bold" 
                    Text="Motivo del Cambio de Estado"></asp:Label>
                        </td>
                        <td class="style3" colspan="3">
                            <asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine" Width="754px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style4">
                            <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" 
                                Text="Aceptar" />
                        </td>
                        <td class="style4">
                            <asp:Button ID="btnSalir" runat="server" onclick="btnSalir_Click1" 
                                style="margin-left: 0px" Text="Salir" Width="77px" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3" colspan="3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:GridView ID="grdEstados" runat="server" CellPadding="4" ForeColor="#333333" 
                                GridLines="None" AutoGenerateColumns="False" Width="690px">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="CODIGO_SEGUIMIENTO" HeaderText="Id" />
                                    <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="Nombre_Integrante" HeaderText="Integrante" />
                                    <asp:BoundField DataField="Descripcion_Seguimiento" HeaderText="Detalle" />
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
                        <td class="style3" colspan="3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3" colspan="3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                </asp:Content>
