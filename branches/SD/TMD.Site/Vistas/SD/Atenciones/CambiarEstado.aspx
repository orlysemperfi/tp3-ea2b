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
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Label ID="Label2" runat="server" CssClass="bold" 
                    Text="Estado del Ticket"></asp:Label>
                        </td>
                        <td class="style3">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" 
                    style="margin-left: 0px" Width="117px">
                </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                <asp:Label ID="Label3" runat="server" CssClass="bold" 
                    Text="Motivo del Cambio de Estado"></asp:Label>
                        </td>
                        <td class="style3">
                <asp:TextBox ID="TextBox2" runat="server" Height="94px" Width="714px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                                GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField />
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
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                </asp:Content>
