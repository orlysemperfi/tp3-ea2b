<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaSolicitudCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaSolicitudCambio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">
            LISTA DE SOLICITUDES</h1>
        <div class="panel-wrapper">
            <table style="width: 800px;">
                <tr>
                    <td>
                        <label>
                            Proyecto</label>
                        <asp:DropDownList ID="ddlProyecto" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            LineaBase</label>
                        <asp:DropDownList ID="ddlLineaBase" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="grvSolicitudCambio" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Ver" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtnVer" ToolTip="Ver" runat="server" ImageUrl="~/Imagenes/select.jpg"
                            CommandName="Ver" CommandArgument='<%# Eval("Id")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Proyecto">
                    <ItemTemplate>
                        <%# Eval("ProyectoFase.Proyecto.Nombre")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Linea Base">
                    <ItemTemplate>
                        <%# Eval("LineaBase.Nombre")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Image runat="server" ID="imgEstado" ToolTip='<%# RecueprarEstadoNombre(Convert.ToInt32(Eval("Estado")))%>'
                            ImageUrl='<%# RecueprarEstadoImagen(Convert.ToInt32(Eval("Estado")))%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prioridad" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemTemplate>
                        <asp:Image runat="server" ID="imgPrioridad" ToolTip='<%# RecueprarPrioridadNombre(Convert.ToInt32(Eval("Prioridad")))%>'
                            ImageUrl='<%# RecueprarPrioridadImagen(Convert.ToInt32(Eval("Prioridad")))%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Registro">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("FechaRegistro").ToString()).ToString("dd/MM/yyyy")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Aprobación">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("FechaAprobacion").ToString()).ToString("dd/MM/yyyy")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
