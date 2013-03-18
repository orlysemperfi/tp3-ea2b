<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaSolicitudCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaSolicitudCambio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../../Controles/RegistroSolicitudCambio.ascx" TagName="RegistroSolicitudCambio"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Controles/AprobarSolicitudCambio.ascx" TagName="AprobarSolicitudCambio"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">
            LISTA DE SOLICITUDES</h1>
        <div class="panel-wrapper">
            <asp:UpdatePanel runat="server" ID="upnlFiltro">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlBusqueda">
                        <table style="width: 800px;">
                            <tr>
                                <td>
                                    <label>
                                        Proyecto</label>
                                    <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" script="width: auto;"
                                        onselectedindexchanged="ddlProyecto_SelectedIndexChanged">
                                    </asp:DropDownList><asp:CompareValidator ID="proyectoValidator" runat="server" ControlToValidate="ddlProyecto"
            ErrorMessage="El proyecto es requerido." ToolTip="El proyecto es requerido."
            ValidationGroup="BusquedaValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>
                                </td>
                                <td>
                                    <label>
                                        LineaBase</label>
                                    <asp:DropDownList ID="ddlLineaBase" runat="server" Width="170px">
                                    </asp:DropDownList>
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
                                    <label>
                                        Prioridad</label>
                                    <asp:DropDownList ID="ddlPrioridad" runat="server" Width="170px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr align="right">
                                <td colspan="4" align="right" style="padding-top: 10px;">
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar Solicitudes"  ValidationGroup="BusquedaValidationGroup"/>
                                    &nbsp;
                                    <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" 
                                        Text="Nueva Solicitud" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel runat="server" ID="upnlLista">
            <ContentTemplate>
                <asp:GridView ID="grvSolicitudCambio" runat="server" AutoGenerateColumns="False"
                    OnRowCommand="grvSolicitudCambio_RowCommand" 
                    ondatabound="grvSolicitudCambio_DataBound">
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
                        <asp:TemplateField HeaderText="Fecha Registro">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(Eval("FechaRegistro").ToString()).ToString("dd/MM/yyyy")%>
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
                <asp:HiddenField runat="server" ID="hidIdSolicitud" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger runat="server" ControlID="btnBuscar" EventName="Click" />
                <asp:PostBackTrigger runat="server" ControlID="btnDescarga" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upnlControles">
            <ContentTemplate>
                <div id="divRegistroSolicitud" class="divFlotante" style="display:none;">
                    <uc1:registrosolicitudcambio id="ucRegistroSolicitudCambio" runat="server" visible="False" />
                </div>
                <div id="divAprobarSolicitud" class="divFlotante" style="display:none;">
                    <uc2:aprobarsolicitudcambio id="ucAprobarSolicitudCambio" runat="server" visible="False" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upnlSubir" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divSubirSolicitud" class="divFlotante" style="display:none;">
                <asp:Panel runat="server" ID="pnlSubir" Visible="false">
                <table>
                <tr>
                <td>Subir Archivo Solicitud Cambio</td>
                <td></td>
                </tr>
                <tr>
                <td>        <asp:Button ID="btnCancelarArchivo" runat="server" CssClass="btn-cancelar" Text="Cancelar" OnClick="btnCancelarArchcivo_Click" />&nbsp;
                <asp:Button ID="btnGrabarProxy" runat="server" Text="Grabar" OnClick="btnGrabarArchcivo_Click" /></td>
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
    </div>
    <asp:Button runat="server" ID="btnDescarga" OnClick="btnDescarga_Click" Style="display: none" />
    <script type="text/javascript" language="javascript">
        function Descargar(id) {
            $get('<%= hidIdSolicitud.ClientID %>').value = id;
            $get('<%= btnDescarga.ClientID %>').click();
            return false;
        }
        function validarProyecto() {
            if ($get('<%= ddlProyecto.ClientID %>').selectedIndex == 0) {
                //alert('Seleccione un Proyecto!');
                return true;
            }
        }

        function mostrarDiv(idDiv) {
            document.getElementById(idDiv).style.display = 'inline-block';
        }

        function ocultarDiv(idDiv) {
            document.getElementById(idDiv).style.display = 'none';
        }

        function prueba() {
            alert("prueba");
        }
    </script>
</asp:Content>
