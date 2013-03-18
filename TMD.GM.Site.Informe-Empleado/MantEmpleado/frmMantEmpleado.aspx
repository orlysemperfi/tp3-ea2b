<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMantEmpleado.aspx.cs" Inherits="Web.MantEmpleado.frmMantEmpleado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 440px;
        }
    </style>
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
                                        ForeColor="#666666">Empleados</asp:LinkButton>
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
                                    &nbsp;Mantenimiento de Empleado</td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" style="font-size: small">
                                                Nombre
                                            </td>
                                            <td class="style1" width="360">
                                                <asp:TextBox ID="txtNombres" runat="server" Width="350px"></asp:TextBox>
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
                                    <asp:GridView ID="gvEmpleados" runat="server" CellPadding="4" 
                                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                                        DataKeyNames="CODIGO_EMPLEADO,NOMBRES,APELLIDO_PATERNO,APELLIDO_MATERNO" 
                                        onselectedindexchanged="gvEmpleados_SelectedIndexChanged">
                                        <AlternatingRowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                                            <asp:BoundField DataField="APELLIDO_PATERNO" HeaderText="Ape. Paterno" />
                                            <asp:BoundField DataField="APELLIDO_MATERNO" HeaderText="Ape. Materno" />
                                            <asp:BoundField DataField="NOMBRES" HeaderText="Nombres" />
                                            <asp:BoundField DataField="DNI_PERSONA" HeaderText="Dni" />
                                            <asp:BoundField DataField="DESCRIPCION_AREA" HeaderText="Area" />
                                            <asp:BoundField DataField="DESCRIPCION_PUESTO" HeaderText="Puesto" />
                                            <asp:BoundField DataField="CODIGO_EMPLEADO" />
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
                                        Text="Nuevo Empleado" BorderWidth="1px" Height="25px" Width="97px" />
                                &nbsp;<asp:Button ID="btnNuevo0" runat="server" BackColor="#BDCBDB" 
                                        BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                        Text="Asignar Especialidad" BorderWidth="1px" Height="25px" 
                                        Width="111px" onclick="btnNuevo0_Click" />
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
