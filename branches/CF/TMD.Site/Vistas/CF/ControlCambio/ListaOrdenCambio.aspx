<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaOrdenCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaOrdenCambio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaOrden" class="content">
        <h1 class="page-title">
            LISTA DE ORDEN CAMBIO</h1>
        <div class="panel-wrapper">
            <asp:UpdatePanel runat="server" ID="upnlFiltro">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlBusqueda">
                        <table style="width: 800px;">
                            <tr>
                                <td>
                                    <label>
                                        Proyecto</label>
                                    <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged"
                                        Width="186px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label>
                                        LineaBase</label>
                                    <asp:DropDownList ID="ddlLineaBase" runat="server" Width="186px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"/>
                                </td>
                                <td>
                                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel runat="server" ID="upnlLista">
            <ContentTemplate>
                <asp:GridView ID="grvOrdenCambio" runat="server" AutoGenerateColumns="False">
                    <EmptyDataTemplate>
                        No hay registros.
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="Ver" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnVer" ToolTip="Ver" runat="server" ImageUrl="~/Imagenes/select.jpg"
                                    CommandName="Ver" CommandArgument='<%# Eval("Id")%>' Height="26px" Width="27px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Codigo">
                            <ItemTemplate>
                                <%# Eval("InformeCambio.Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <%# Eval("InformeCambio.Nombre")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Registro">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(Eval("FechaRegistro").ToString()).ToString("dd/MM/yyyy")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id" HeaderText="Codigo" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
