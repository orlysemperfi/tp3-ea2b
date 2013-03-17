<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="Atenciones.aspx.cs" Inherits="ServiceDesk.Seguimiento.Atenciones" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .style7
        {
        }
        .style8
        {
        }
        .style9
        {
            width: 66px;
            height: 14px;
        }
        .style13
        {
        }
        .style14
        {
            width: 971px;
        }
        .style15
        {
            height: 5px;
            width: 222px;
        }
        .style17
        {
            width: 67px;
        }
        .style20
        {
            height: 9px;
            width: 222px;
        }
        .style21
        {
            height: 5px;
            width: 102px;
        }
        .style23
        {
            height: 14px;
        }
        .style24
        {
            width: 67px;
            height: 14px;
        }
        .style25
        {
            height: 14px;
            width: 222px;
        }
        </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style14">
        <tr>
            <td class="style15" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Filtro Avanzado:" Font-Bold="True"></asp:Label>


            </td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style13" colspan="8" valign="bottom">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" 
                    Text="Mensaje de error"></asp:Label>


            </td>
        </tr>
        <tr>
            <td class="style20" colspan="2">


            </td>
            <td colspan="2">
                &nbsp;</td>
            <td class="style13" colspan="2" valign="bottom">
                <asp:Label ID="Label3" runat="server" Text="Actividades" Font-Bold="True"></asp:Label>


            </td>
            <td class="style17">
                &nbsp;</td>
            <td class="style8" colspan="4">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style25" colspan="2">
                Proyecto/Analista :</td>
            <td class="style9">
                <%--<asp:HyperLink ID="lnkNuevoTicket" runat="server" ForeColor="Red" Width="36px" Height="34px" 
                    ImageUrl="~/Imagenes/AddNewitem.jpg" 
                    NavigateUrl="~/Vistas/SD/Atenciones/NuevaAtencion.aspx?registro=N" 
                    ToolTip="Agrega nuevo ticket" >Nuevo Ticket</asp:HyperLink>--%>
            </td>
            <td class="style23" colspan="2" >
                <asp:DropDownList ID="cmbActividad" runat="server" Height="28px" Width="206px">
                </asp:DropDownList>
            </td>
            <td class="style23" colspan="2">
                <asp:Button ID="btnIr" runat="server" Height="28px"   Text="Ir" 
                Width="99px"   onclick="btnInfoSeguimiento_Click" />
            </td>
            <td class="style24">
                </td>
            <td class="style24">
                </td>
            <td class="style24">
                </td>
            <td class="style24">
                </td>
            <td class="style24">
                </td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                <asp:DropDownList ID="cmbAnalistas" runat="server" Height="23px" Width="219px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            
            <td class="style15" colspan="2">
                Proyecto/Especialista:</td>

            <td rowspan="11" class="style7" colspan="10">
                <asp:GridView ID="grdTickets" runat="server" CellPadding="4" ForeColor="Black" 
                    GridLines="None" AutoGenerateColumns="False" 
                    AutoGenerateSelectButton="True" Caption="Listado de Tickets de Atención" 
                    AllowPaging="True" AllowSorting="True" CaptionAlign="Top" 
                    ShowHeaderWhenEmpty="True" Width="509px" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Nro Ticket" DataField="Codigo_Ticket" />
                        <asp:BoundField HeaderText="Fecha Registro" DataField="Fecha_Registro" 
                            DataFormatString="{0:g}" />
                        <asp:BoundField HeaderText="Fecha Expiracion" DataField="Fecha_Expiracion" 
                            DataFormatString="{0:g}" />
                        <asp:BoundField HeaderText="Descripcion breve" DataField="Descripcion_Corta" />
                        <asp:BoundField HeaderText="Nombre Usuario" DataField="Nombre_UsuarioCliente" />
                        <asp:BoundField HeaderText="Analista" DataField="Empleado_Propietario" />
                        <asp:BoundField HeaderText="Especialista" DataField="Empleado_Asignado" />
                        <asp:BoundField HeaderText="Prioridad" DataField="Prioridad_Ticket" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Top" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
               
            </td>

        </tr>
        <tr>
            <td class="style15" colspan="2">
                <asp:DropDownList ID="cmbEspecialistas" runat="server" Height="18px" 
                    Width="215px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                Tipo Ticket:</td>
        </tr>

        <tr>
            <td class="style15" colspan="2">
                <asp:DropDownList ID="LstTipoTicket" runat="server" Height="25px" Width="222px">
                    
                </asp:DropDownList>
             </td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                Estado Ticket:</td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                <asp:DropDownList ID="cmbEstado" runat="server" Height="25px">
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                Fecha Registro:</td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                Desde:  <asp:TextBox ID="txtFechaRegInicio" Width="80px"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                Hasta: <asp:TextBox ID="txtFechaRegFin" Width="80px"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style21">
                
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click1" 
                    Text="Buscar" Width="70px" />
             
            </td>
            <td class="style15">
                
                <asp:Button ID="btnSalir" runat="server" onclick="btnSalir_Click" Text="Salir" 
                    Width="70px" />
            </td>
        </tr>
        <tr>
            <td class="style15" colspan="2">
                
                &nbsp;</td>
        </tr>
    </table>

    
</asp:Content>
