<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="Atenciones.aspx.cs" Inherits="ServiceDesk.Atenciones.Atenciones" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style5
        {
            height: 5px;
            width: 26px;
        }
        .style6
        {
            height: 5px;
            width: 110px;
        }
        .style7
        {
            width: 400px;
        }
        </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="style6">
                <asp:Label ID="Label1" runat="server" Text="Filtro Avanzado:" Font-Bold="True"></asp:Label>


            </td>
            <td class="style5">
                &nbsp;</td>
            <td rowspan="2" class="style7">
                <asp:HyperLink ID="lnkNuevoTicket" runat="server" ForeColor="Red" Width="36px" Height="34px" 
                    ImageUrl="~/Imagenes/AddNewitem.jpg" 
                    NavigateUrl="~/Vistas/SD/Atenciones/NuevaAtencion.aspx?registro=N" 
                    ToolTip="Agrega nuevo ticket" >Nuevo Ticket</asp:HyperLink>
                <br />
            </td>
            <td rowspan="2" class="style7">
                <asp:Button ID="bntIngresarSolucion" runat="server" Height="27px" Text="Solución" 
                    Width="110px" onclick="bntIngresarSolucion_Click" />
            </td>
            <td rowspan="2" class="style7">
                <asp:Button ID="btnInfoSeguimiento" runat="server" Height="27px" 
                    Text="Seguimiento" Width="110px" onclick="btnInfoSeguimiento_Click" />
            </td>
            <td rowspan="2" class="style7">
                <asp:Button ID="btnAdjuntarDocumentacion" runat="server" Height="27px" Text="Documentación" 
                    Width="110px" onclick="btnAdjuntarDocumentacion_Click" />

            </td>
            <td rowspan="2" class="style7">
                <asp:Button ID="btnCambioEstado" runat="server" Height="27px" Text="Estado" 
                    Width="110px" onclick="btnCambioEstado_Click" />

                </td>
            <td rowspan="2" class="style7">
                <asp:Button ID="btnEditar" runat="server" Height="27px" Text="Editar" 
                    Width="110px" onclick="btnEditar_Click" />
                </td>
        </tr>
        <tr>
            <td class="style6">
                Proyecto/Analista :</td>
            <td class="style5">
                </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:DropDownList ID="cmbAnalistas" runat="server" Height="23px" Width="219px">
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            
            <td class="style6">
                Proyecto/Especialista:</td>
            <td class="style5">
                </td>

            <td rowspan="11" class="style7" colspan="6">
                <asp:GridView ID="grdTickets" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" AutoGenerateColumns="False" 
                    AutoGenerateSelectButton="True" Caption="Listado de Tickets de Atención" 
                    AllowPaging="True" AllowSorting="True" CaptionAlign="Top" 
                    ShowHeaderWhenEmpty="True" >
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
            <td class="style6">
                <asp:DropDownList ID="cmbEspecialistas" runat="server" Height="18px" 
                    Width="215px">
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Tipo Ticket:</td>
            <td class="style5">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="style6">
                <asp:DropDownList ID="LstTipoTicket" runat="server" Height="25px" Width="222px">
                    
                </asp:DropDownList>
             </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Estado Ticket:</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <asp:DropDownList ID="cmbEstado" runat="server" Height="25px">
                    
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Fecha Registro:</td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Desde:  <asp:TextBox ID="txtFechaRegInicio" Width="80px"  runat="server"></asp:TextBox>
            </td>
            <td class="style6">
             
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Hasta: <asp:TextBox ID="txtFechaRegFin" Width="80px"  runat="server"></asp:TextBox>
            </td>
            <td class="style6">
             
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click1" 
                    Text="Buscar" Width="70px" />
             
            </td>
        </tr>
        <tr>
            <td class="style6">
                
                &nbsp;</td>
            <td class="style6">
                <asp:Button ID="btnSalir" runat="server" onclick="btnSalir_Click" Text="Salir" 
                    Width="70px" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                
                &nbsp;</td>
            <td class="style6">
             
                &nbsp;</td>
        </tr>
    </table>


   


</asp:Content>
