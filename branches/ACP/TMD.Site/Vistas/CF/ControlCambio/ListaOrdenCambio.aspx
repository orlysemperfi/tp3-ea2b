<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" 
	CodeBehind="ListaOrdenCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaOrdenCambio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../../Controles/CF/ControlCambio/RegistroOrdenCambio.ascx" TagName="RegistroOrdenCambio"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaOrden" class="content">
        <h1 class="page-title">
            LISTADO DE ORDENES DE CAMBIO</h1>
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
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Visible="false"
                                        OnClientClick="javascript:return validarProyecto();" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" 
                                        Text="Nueva Orden" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <center><div id="mensajeError" style="display:none;text-align:center;color:Red"></center>
        </div>    
        <asp:UpdatePanel runat="server" ID="upnlLista">
            <ContentTemplate>
                <asp:GridView ID="grvOrdenCambio" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="grvOrdenCambio_RowCommand" 
                    ondatabound="grvOrdenCambio_DataBound">
                    <HeaderStyle CssClass="headGrid" />
                    <EmptyDataTemplate>
                        No hay registros.
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="Ver" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnVer" ToolTip="Ver" runat="server" ImageUrl="~/Imagenes/ver.png"
                                    CommandName="Ver" CommandArgument='<%# Eval("Id")%>' Height="26px" Width="27px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:TemplateField HeaderText="Codigo">
                            <ItemTemplate>
                                <%# Eval("InformeCambio.Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre Orden">
                            <ItemTemplate>
                                <%# Eval("InformeCambio.Nombre")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Registro">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(Eval("FechaRegistro").ToString()).ToString("dd/MM/yyyy")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Prioridad" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgPrioridad" ToolTip='<%# RecuperarPrioridadNombre(Convert.ToInt32(Eval("Prioridad")))%>'
                                    ImageUrl='<%# RecuperarPrioridadImagen(Convert.ToInt32(Eval("Prioridad")))%>'
                                    Height="26px" Width="27px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cargar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnCargar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                    CommandName="Cargar" ImageUrl="~/Imagenes/upload.png" ToolTip="Cargar Archivo"
                                    Visible='<%# (Eval("NombreArchivo")== null) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descargar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDescargar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                    CommandName="Descargar" ImageUrl="~/Imagenes/download.png" ToolTip="Descargar Archivo"
                                    Visible='<%# (Eval("NombreArchivo")!= null) %>' OnClientClick='<%# String.Format("javascript:return Descargar({0});",Eval("Id"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField runat="server" ID="hidIdOrden" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger runat="server" ControlID="btnBuscar" EventName="Click" />
                <asp:PostBackTrigger runat="server" ControlID="btnDescarga" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upnlControles">
            <ContentTemplate>
            <div id="divRegistroOrden" class="divFlotante" style="display:none;">
                <uc1:registroordencambio id="ucRegistroOrdenCambio" runat="server" visible="False" />
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upnlSubir" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divSubirOrden" class="divFlotante" style="display:none;">
                <asp:Panel runat="server" ID="pnlSubir" Visible="false">
                    <p>
                        Subir archivo de Orden de Cambio</p>
                    <p>
                        Archivo</p>
                    <p>
                        <asp:FileUpload ID="fileUpArchivo" runat="server" />
                    </p>
                    <p>
                        <asp:Button ID="btnGrabarProxy" runat="server" Text="Grabar" OnClick="btnGrabarArchcivo_Click" />
                        <asp:Button ID="btnCancelarArchivo" runat="server" CssClass="btn-cancelar" Text="Cancelar" OnClick="btnCancelarArchcivo_Click" />&nbsp;</p>
                </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger runat="server" ControlID="btnGrabarProxy" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:Button runat="server" ID="btnDescarga" OnClick="btnDescarga_Click" Style="display: none" />
    <script type="text/javascript" language="javascript">
        function Descargar(id) {
            $get('<%= hidIdOrden.ClientID %>').value = id;
            $get('<%= btnDescarga.ClientID %>').click();
            return false;
        }
        function validarProyecto() {
            if ($get('<%= ddlProyecto.ClientID %>').selectedIndex == 0) {
                crearMensaje("Seleccione un Proyecto!");
                return true;
            }
        }
    </script>
</asp:Content>