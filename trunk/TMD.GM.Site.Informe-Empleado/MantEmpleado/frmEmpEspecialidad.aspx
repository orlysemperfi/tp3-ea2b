<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEmpEspecialidad.aspx.cs" Inherits="Web.MantEmpleado.frmEmpEspecialidad" %>

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
                                        ForeColor="#666666">Empleados</asp:LinkButton>
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
                                    Asignar 
                                    Actividades / Especialidad</td>
                            </tr>
                            <tr>
                                <td align="left" style="font-weight: bold; font-size: small;">
                                    &nbsp;
                                    <asp:Label ID="lblEmpleado" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" style="font-size: small">
                                                Actividad&nbsp;&nbsp; 
                                            </td>
                                            <td class="style1" align="left">
                                                <asp:DropDownList ID="ddlEspecialidad" runat="server" Width="273px">
                                                </asp:DropDownList>
&nbsp;<asp:Button ID="btnAsignar" runat="server" BackColor="#BDCBDB" 
                                                    BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                                    Text="Asignar" BorderWidth="1px" Height="25px" 
                                                    Width="49px" onclick="btnAsignar_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: x-small">
                                    <asp:GridView ID="gvEspecialidades" runat="server" CellPadding="4" 
                                        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                                        onrowdeleting="gvEspecialidades_RowDeleting" 
                                        DataKeyNames="CODIGO_TIPO_ACTIVIDAD,ESPECIALIDAD" 
                                        onrowdatabound="gvEspecialidades_RowDataBound">
                                        <AlternatingRowStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="DESCRIPCION_TIPO_ACTIVIDAD" 
                                                HeaderText="Actividades" />
                                            <asp:TemplateField HeaderText="Especialidad">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                        Checked='<%# Bind("ESPECIALIDAD") %>' OnCheckedChanged="CheckBox1_OnCheckedChanged" />
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
                                    <br />
&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Button ID="btnRegresar" runat="server" BackColor="#BDCBDB" 
                                                    BorderColor="#333333" Font-Names="Arial" Font-Size="X-Small" 
                                                    Text="&lt; Regresar" BorderWidth="1px" Height="25px" 
                                                    Width="60px" onclick="btnRegresar_Click" />
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
