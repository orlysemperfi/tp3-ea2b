<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ActualizarECS.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.LineaBase.ActualizarECS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <asp:Panel ID="pnlMain" runat="server">
            <asp:HiddenField ID="hiddenIdLineaBase" runat="server" />
            <div id="actualizarLB" class="content">
                <h1 class="page-title">
                    ACTUALIZAR ELEMENTO DE CONFIGURACION</h1>
                <div class="panel-wrapper">
                    <table style="width: 800px;">
                        <tr>
                            <td>
                                <label>
                                    Proyecto</label>
                                <asp:TextBox ID="txtNombreProyecto" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <label>
                                    Fase</label>
                                <asp:TextBox ID="txtNombreFase" runat="server" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" 
                                    Text="Cancelar " ValidationGroup="None" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="form_lineabase" class="panel-wrapper form">
                    <table style="width: 600px;">
                        <tr>
                            <td>
                                <label>
                                    Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" Width="190px" Enabled="False" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Descripcion</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="431px" Enabled="False" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                                <asp:GridView ID="grvElementoConfiguracion" runat="server" 
                                    AutoGenerateColumns="False" OnRowCommand="grvElementoConfiguracion_RowCommand">
                                    <EmptyDataTemplate>
                                        No existen registros.
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <%# Eval("ElementoConfiguracion.Nombre")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo">
                                            <ItemTemplate>
                                                <%# Eval("ElementoConfiguracion.Tipo")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Archivo" />
                                        <asp:BoundField DataField="Extension" HeaderText="Extension" />
                                        <asp:BoundField DataField="Version" HeaderText="Version" />
                                        <asp:TemplateField HeaderText="Cargar" ItemStyle-HorizontalAlign="Center" 
                                            ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBtnCargar" runat="server" 
                                                    CommandArgument='<%# Eval("Id")%>' CommandName="Cargar" 
                                                    ImageUrl="~/Imagenes/upload.jpg" ToolTip="Cargar Archivo" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Descargar" ItemStyle-HorizontalAlign="Center" 
                                            ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgBtnDescargar" runat="server" 
                                                    CommandArgument='<%# Eval("Id")%>' CommandName="Descarga" 
                                                    ImageUrl="~/Imagenes/download.jpg" ToolTip="Descargar Archivo" Visible='<%# (Eval("Nombre")!= null) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                </div>
                <!-- END #form_lineabase -->
            </div>
            <!-- END #content -->
            <asp:UpdatePanel ID="upnlProxy" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
            <asp:Panel ID="pnlCargar" runat="server" Visible="false">
                        <h1>
                            Carga de Elementos de Configuraci&oacute;n.
                        </h1>                        
                        <br />
                        <asp:FileUpload ID="fileUpElemento" runat="server" />
                        &nbsp;<asp:Button ID="btnCargar" runat="server" Text="Cargar Elemento" 
                            OnClick="btnCargar_Click" />
                    </asp:Panel>
        </asp:Panel>
    </center>
</asp:Content>
