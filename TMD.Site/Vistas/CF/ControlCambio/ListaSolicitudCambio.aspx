<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaSolicitudCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaSolicitudCambio" %>

<%@ Register Src="../../../Controles/RegistroSolicitudCambio.ascx" TagName="RegistroSolicitudCambio"
    TagPrefix="uc1" %>
<%@ Register src="../../../Controles/AprobarSolicitudCambio.ascx" tagname="AprobarSolicitudCambio" tagprefix="uc2" %>
<%@ Register src="../../../Controles/SubirArchivoSolicitudCambio.ascx" tagname="SubirArchivoSolicitudCambio" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">
            LISTA DE SOLICITUDES</h1>
        <asp:Panel runat="server" ID="pnlBusqueda">
            <div class="panel-wrapper">
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
                            <label>
                                Estado</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="186px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <label>
                                Prioridad</label>
                            <asp:DropDownList ID="ddlPrioridad" runat="server" Width="186px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"
                                OnClientClick="javascript:return validarProyecto();" />
                        </td>
                        <td>
                            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:GridView ID="grvSolicitudCambio" runat="server" AutoGenerateColumns="False"
                OnRowCommand="grvSolicitudCambio_RowCommand">
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
                                CommandName="Cargar" ImageUrl="~/Imagenes/upload.jpg" ToolTip="Cargar Archivo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descargar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnDescargar" runat="server" CommandArgument='<%# Eval("Id")%>'
                                CommandName="Descargar" ImageUrl="~/Imagenes/download.jpg" ToolTip="Descargar Archivo"
                                Visible='<%# (Eval("NombreArchivo")!= null) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <uc1:RegistroSolicitudCambio ID="ucRegistroSolicitudCambio" runat="server" Visible="False" />
        <uc2:AprobarSolicitudCambio ID="ucAprobarSolicitudCambio" runat="server" Visible="False"/>
        <uc3:SubirArchivoSolicitudCambio ID="ucSubirArchivoSolicitudCambio" runat="server" Visible="False" />
    </div>
    <script type="text/javascript" language="javascript">
        function validarProyecto() {
            if ($get('<%= ddlProyecto.ClientID %>').selectedIndex == 0) {
                alert('Seleccione un Proyecto!');
                return false;
            }
        }
    </script>
</asp:Content>
