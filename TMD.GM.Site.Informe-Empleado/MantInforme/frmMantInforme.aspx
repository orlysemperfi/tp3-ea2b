<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMantInforme.aspx.cs" Inherits="Web.MantInforme.frmMantInforme" %>
<%@ Register Assembly="GMDatePicker" Namespace="GrayMatterSoft" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
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
                        <a href="http://localhost:41000/"><img src="../Images/logo.jpg" /></a> </td>
                </tr>
                <tr>
                    <td bgcolor="#E9E9E9" align="center">
                        <table style="width: 78%;">
                            <tr>
                                <td align="left" style="font-weight: bold; font-size: large;">
                                    Lista de Informes</td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" style="font-size: x-small">
                                                Número</td>
                                            <td class="style1" width="360" align="left" style="font-size: x-small">
                                                <asp:TextBox ID="txtNumero" runat="server" Width="97px"></asp:TextBox>
                                            </td>
                                            <td align="left" style="font-size: x-small">
                                                Técnico</td>
                                            <td align="left" style="font-size: x-small; width: 150px;">
                                                <asp:DropDownList ID="ddlEmpleado" runat="server" Width="180px" 
                                                    Font-Size="X-Small">
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
                                            <td align="left" style="font-size: x-small; width: 150px;">
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
                                                <asp:Button ID="btnBuscar" runat="server" BackColor="#BDCBDB" 
                                                    BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                                    onclick="btnBuscar_Click" Text="Buscar" BorderWidth="1px" Height="25px" 
                                                    Width="49px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: x-small">
                                    <asp:GridView ID="gvInformes" runat="server" CellPadding="4" 
                                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                                        DataKeyNames="NUMERO_INFORME,CODIGO_EMPLEADO,OBSERVACION_EMPLEADO,FECHA" 
                                        onselectedindexchanged="gvInformes_SelectedIndexChanged">
                                        <AlternatingRowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                                            <asp:BoundField DataField="NUMERO_INFORME" HeaderText="Numero" />
                                            <asp:BoundField DataField="NOMBRES" HeaderText="Empleado" />
                                            <asp:BoundField DataField="FECHA" HeaderText="Fecha" />
                                            <asp:BoundField DataField="OBSERVACION_EMPLEADO" HeaderText="Observación" />
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
                                    <asp:Button ID="btnNuevo" runat="server" BackColor="#BDCBDB" 
                                        BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                        Text="Nuevo" BorderWidth="1px" Height="25px" Width="61px" 
                                        onclick="btnNuevo_Click" />
                                &nbsp;<asp:Button ID="btnModificar" runat="server" BackColor="#BDCBDB" 
                                        BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                        Text="Modificar" BorderWidth="1px" Height="25px" 
                                        Width="60px" onclick="btnModificar_Click" />
                                </td>
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
