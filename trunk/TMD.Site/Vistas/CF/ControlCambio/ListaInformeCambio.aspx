<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaInformeCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaInformeCambio" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../../Controles/RegistroInformeCambio.ascx" TagName="RegistroInformeCambio"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Controles/AprobarInformeCambio.ascx" TagName="AprobarInformeCambio"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">
            LISTADO DE INFORMES</h1>
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
                                        Width="170px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label>
                                        LineaBase</label>
                                    <asp:DropDownList ID="ddlLineaBase" runat="server" Width="170px">
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
                                    <label>
                                        Estado</label>
                                    <asp:DropDownList ID="ddlEstado" runat="server" Width="170px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar Informes"
                                        OnClientClick="javascript:return validarProyecto();" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" 
                                        Text="Nuevo Informe" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    <div id="mensajeError" style="display:none">
    </div>    
    </div>
            <asp:UpdatePanel runat="server" ID="upnlLista">
            <ContentTemplate>
                <asp:GridView ID="grvInformeCambio" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="grvInformeCambio_RowCommand" 
                    ondatabound="grvInformeCambio_DataBound">
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
                        <asp:TemplateField HeaderText="Código solicitud">
                            <ItemTemplate>
                                <%# Eval("Solicitud.Id ")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre de solicitud">
                            <ItemTemplate>
                                <%# Eval("Solicitud.Nombre")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha Aprobación">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(Eval("Solicitud.FechaAprobacion").ToString()).ToString("dd/MM/yyyy")%>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Código de informe">
                            <ItemTemplate>
                                <%# Eval("Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre de informe">
                            <ItemTemplate>
                                <%# Eval("Nombre")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgEstado" ToolTip='<%# RecuperarEstadoNombre(Convert.ToInt32(Eval("Estado")))%>'
                                    ImageUrl='<%# RecuperarEstadoImagen(Convert.ToInt32(Eval("Estado")))%>' Height="26px"
                                    Width="27px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cargar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnCargar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                    CommandName="Cargar" ImageUrl="~/Imagenes/upload.png" ToolTip="Cargar Archivo"
                                    Visible='<%# Convert.ToInt32(Eval("Estado")) == TMD.Core.Constantes.EstadoPendiente %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descargar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDescargar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                    CommandName="Descargar" ImageUrl="~/Imagenes/download.png" ToolTip="Descargar Archivo"
                                    Visible='<%# (Eval("NombreArchivo")!= null) %>' OnClientClick='<%# String.Format("javascript:return Descargar({0});",Eval("Id"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Aprobar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnAprobar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                    CommandName="Aprobar" ImageUrl="~/Imagenes/Estado/aprobar.png" ToolTip="Aprobar Solicitud"
                                    Visible='<%# Convert.ToInt32(Eval("Estado")) == TMD.Core.Constantes.EstadoPendiente %>'
                                    Height="26px" Width="27px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rechazar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnRechazar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                    CommandName="Rechazar" ImageUrl="~/Imagenes/Estado/rechazar.png" ToolTip="Rechazar Solicitud"
                                    Visible='<%# Convert.ToInt32(Eval("Estado")) == TMD.Core.Constantes.EstadoPendiente %>'
                                    Height="26px" Width="27px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField runat="server" ID="hidIdInforme" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger runat="server" ControlID="btnBuscar" EventName="Click" />
                <asp:PostBackTrigger runat="server" ControlID="btnDescarga" />
            </Triggers>
        </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" ID="upnlControles">
            <ContentTemplate>
                <div id="divRegistroInforme" class="divFlotante" style="display:none;">
                    <uc1:registroinformecambio id="ucRegistroInformeCambio" runat="server" Visible="False" />
                </div>
                <div id="divAprobarInforme" class="divFlotante" style="display:none;">
                    <uc2:aprobarinformecambio id="ucAprobarInformeCambio" runat="server" Visible="False" />                
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upnlSubir" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divSubirInforme" class="divFlotante" style="display:none;">
                <asp:Panel runat="server" ID="pnlSubir" Visible="false">
                <table>
                <tr>
                <td>Subir archivo de Informe de Cambio</td>
                <td></td>
                </tr>
                <tr>
                <td>        <asp:Button ID="btnCancelarArchivo" runat="server" CssClass="btn-cancelar" Text="Cancelar" OnClick="btnCancelarArchcivo_Click" />&nbsp;
                <asp:Button ID="btnGrabarProxy" runat="server" Text="Grabar archivo" OnClick="btnGrabarArchcivo_Click" /></td>
                <td>Archivo <asp:FileUpload ID="fileUpArchivo" runat="server" /></td>
                </tr>
                </table>
                </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger runat="server" ControlID="btnGrabarProxy" />
            </Triggers>
        </asp:UpdatePanel>
    
    <asp:Button runat="server" ID="btnDescarga" OnClick="btnDescarga_Click" Style="display: none" />
    <script type="text/javascript" language="javascript">
        function Descargar(id) {
            $get('<%= hidIdInforme.ClientID %>').value = id;
            $get('<%= btnDescarga.ClientID %>').click();
            return false;
        }

        function validarProyecto() {
            var elemento;
            if ($get('<%= ddlProyecto.ClientID %>').selectedIndex == 0) {
                crearMensaje("Seleccione un Proyecto!");
                return false;
            }
            
            if ($get('<%= ddlLineaBase.ClientID %>').selectedIndex == 0) {
                crearMensaje("Seleccione una Línea Base!");
                return false;
            }
        }
    </script>
</asp:Content>