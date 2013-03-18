<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDetInforme.aspx.cs" Inherits="Web.MantInforme.frmDetInforme" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; font-family: Arial, Helvetica, sans-serif;">
                <tr>
                    <td bgcolor="#333333">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table style="width:100%;">
                            <tr>
                                <td align="right">
                                    <asp:LinkButton ID="lnkEmpleados" runat="server" Font-Bold="True" 
                                        Font-Names="Arial" Font-Overline="False" Font-Underline="False" 
                                        ForeColor="#666666">Informes</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <img src="../Images/logo.jpg" /></td>
                </tr>
                <tr>
                    <td bgcolor="#E9E9E9" align="center">
                        <table style="width: 78%;">
                            <tr>
                                <td align="left" style="font-weight: bold; font-size: large;">
                                    Mantenimiento de Informe</td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" style="font-size: x-small">
                                                Número</td>
                                            <td class="style1" width="360" align="left" style="font-size: x-small">
                                                <asp:TextBox ID="txtNumero" runat="server" Width="97px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td align="left" style="font-size: x-small">
                                                Técnico</td>
                                            <td align="left" style="font-size: x-small">
                                                <asp:DropDownList ID="ddlEmpleado" runat="server" Width="180px" 
                                                    Font-Size="X-Small" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlEmpleado_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="font-size: x-small">
                                                Observación 
                                            </td>
                                            <td class="style1" width="360" align="left" style="font-size: x-small">
                                                <asp:TextBox ID="txtObservacion" runat="server" Width="350px"></asp:TextBox>
                                            </td>
                                            <td align="left" style="font-size: x-small">
                                                Fecha</td>
                                            <td align="left" style="font-size: x-small">
                                                <cc2:GMDatePicker ID="txtFecha" runat="server" CalendarOffsetX="-98px" CalendarOffsetY="25px"
                                            CalendarTheme="None" CalendarWidth="98%" CallbackEventReference="" CssClass="CajaTexto"
                                            Culture="Spanish (Peru)" EnableDropShadow="True" ImageUrl="../images/calendario.jpg"
                                            InitialValueMode="Null" MaxDate="2999-12-31" MinDate="" NextMonthText=">" NoneButtonText="Niguno"
                                            ShowNoneButton="False" ShowTodayButton="True" TextBoxWidth="80" TodayButtonText="Hoy"
                                            Width="98%" ZIndex="1">
                                            <CalendarTitleStyle CssClass="WebDataGrid_Header" />
                                            <CalendarWeekendDayStyle CssClass="WebCalendar_DayWeekend" />
                                            <CalendarDayHeaderStyle CssClass="WebCalendar_SubHeader" />
                                            <TodayButtonStyle CssClass="BtnFlat" />
                                        </cc2:GMDatePicker>
                                                </td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: x-small">
                                    <asp:GridView ID="gvInformes" runat="server" CellPadding="4" 
                                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                                        DataKeyNames="NUMERO_ORDEN" onrowdatabound="gvInformes_RowDataBound">
                                        <AlternatingRowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0" style="width:100%;">
                                                        <tr>
                                                            <td>
                                                                ORDEN:&nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                                <asp:Label ID="lblNOrd" runat="server" Font-Bold="True" 
                                                                    Text='<%# Bind("NUMERO_ORDEN") %>' Width="75px"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblOOrd" runat="server" Font-Bold="True" 
                                                                    Text='<%# Bind("OBSERVACIONES_ORDEN") %>' Width="300px"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFecha" runat="server" Font-Bold="True" 
                                                                    Text='<%# Bind("FECHA_EMISION_ORDEN") %>' Width="70px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td colspan="3">
                                                                <asp:GridView ID="gvInformesDet" runat="server" AutoGenerateColumns="False" 
                                                                    CellPadding="4" DataKeyNames="ITEM_ORDEN" 
                                                                    ForeColor="#333333" GridLines="None">
                                                                    <AlternatingRowStyle ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ITEM_ORDEN" HeaderText="Item" />
                                                                        <asp:BoundField DataField="FECHA_PROGRAMADA" HeaderText="Fecha" />
                                                                        <asp:BoundField DataField="DESCRIPCION_ACTIVIDAD" HeaderText="Actividad" />
                                                                        <asp:TemplateField HeaderText="Resultado">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtResultado" runat="server" Width="350px" Font-Size="X-Small" 
                                                                                    Text='<%# Bind("RESULTADO_ATENCION") %>'></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EditRowStyle BackColor="#999999" />
                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                    <RowStyle ForeColor="Black" />
                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle Font-Bold="True" ForeColor="Black" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Button ID="btnRegresar" runat="server" BackColor="#BDCBDB" 
                                                    BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                                    Text="&lt; Regresar" BorderWidth="1px" Height="25px" 
                                                    Width="60px" onclick="btnRegresar_Click" />
                                            &nbsp;<asp:Button ID="btnGuardar" runat="server" BackColor="#BDCBDB" 
                                        BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                        Text="Guardar" BorderWidth="1px" Height="25px" Width="61px" 
                                        onclick="btnGuardar_Click" />
                                &nbsp;</td>
                            </tr>
                        </table>
                        </td>
                </tr>
                <tr>
                    <td bgcolor="#D7D7D7">
                        &nbsp;</td>
                </tr>
            </table>
    </form>
</body>
</html>
