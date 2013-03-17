<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="IndicadorListado.aspx.cs" Inherits="TMD.MP.Site.Privado.IndicadoresListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">LISTADO DE INDICADORES</h1>
        <div class="panel-wrapper">
            <asp:UpdatePanel ID="upnlFiltros" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlFiltros">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Width="50px"></asp:Label>
                                    <asp:TextBox ID="tbxNombre" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" Width="50px"></asp:Label>
                                    <asp:DropDownList ID="ddlTipo" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblArea" runat="server" Text="Área:" Width="50px"></asp:Label>
                                    <asp:DropDownList ID="ddlArea" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblProceso" runat="server" Text="Proceso:" Width="50px"></asp:Label>
                                    <asp:DropDownList ID="ddlProceso" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                <td>
                                    <asp:Button ID="btnAgregarIndicadorCuali" runat="server" OnClick="btnAgregarIndicadorCuali_Click" Text="Agregar Cualitativo" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAgregarIndicadorCuanti" runat="server" OnClick="btnAgregarIndicadorCuanti_Click" Text="Agregar Cuantitativo" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel ID="upnlIndicadorListado" runat="server">
    <ContentTemplate>
    <%--<div class="contenedor-pagina">--%>

<%--        <div id="divMensaje" runat="server">
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>--%>
        <br />
<%--        <table id="tblIndicadorListado" runat="server" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>   --%>                 
                    <asp:GridView ID="gvwIndicadorListado" runat="server" 
                        Width="920px" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" 
                        DataSource='<%#ObtenerIndicadorListado()%>' BorderWidth="0px" 
                        BorderColor="White" OnRowCommand="gvwIndicadorListado_RowCommand" OnPageIndexChanging="gvwIndicadorListado_PageIndexChanging">
                        <EmptyDataTemplate>
                                No existen indicadores con los criterios ingresados.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="Código">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("NOMBRE") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Frecuencia">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrecuencia" runat="server" Text='<%#Eval("FRECUENCIA_MEDICION") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipo" runat="server" Text='<%#ObtenerDescTipoIndicador(Eval("TIPO").ToString())%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" CommandName="EditarIndicador" CommandArgument='<%#Eval("CODIGO") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>                           
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEliminar" runat="server" Text="Inactivar" CommandName="InactivarIndicador" CommandArgument='<%#Eval("CODIGO") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>                  
                    </asp:GridView>
<%--                </td>
            </tr>
        </table>--%>
<%--        <div id="divLinea" runat="server" class="linea-separadora">
        </div>
        <table id="tblPaginacion" runat="server" border="0" cellpadding="0" cellspacing="0" style="width:100%">
            <tr>                
                <td align="left">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbtnIzquierdaTodo" runat="server" Text="<<" OnClick="ibtnIzquierdaTodo_Click" CssClass="estilo_boton_pagina"/>
                            </td>
                            <td class="paginado-espaciado">
                                <asp:LinkButton ID="lbtnIzquierda" runat="server" Text="<" OnClick="ibtnIzquierda_Click" CssClass="estilo_boton_pagina"/>
                            </td>
                            <td class="paginado-espaciado">
                                <asp:TextBox ID="tbxPaginaActual" runat="server" CssClass="estilo_textbox" Width="20px" onkey="RefreshUpdatePanel();" AutoPostBack="true" OnTextChanged="tbxPaginaActual_TextChanged" />
                            </td>
                            <td class="paginado-espaciado">
                                de
                            </td>                
                            <td class="paginado-espaciado">
                                <asp:Label ID="lblNumeroPaginas" runat="server" />
                            </td>
                            <td class="paginado-espaciado">
                                <asp:LinkButton ID="lbtnDerecha" runat="server" Text=">" OnClick="ibtnDerecha_Click" CssClass="estilo_boton_pagina"/>
                            </td>
                            <td class="paginado-espaciado">
                                <asp:LinkButton ID="lbtnDerechaTodo" runat="server" Text=">>" OnClick="ibtnDerechaTodo_Click" CssClass="estilo_boton_pagina"/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right">
                    <asp:Label ID="lblNumeroRegistros" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />--%>
<%--        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    
                </td>
                <td class="boton-espaciado">
                    
                </td>
                <td class="boton-espaciado">
                    <asp:LinkButton ID="lbtnSalir" runat="server" OnClick="ibtnSalir_Click" CssClass="estilo_boton" Text="Salir"></asp:LinkButton>
                </td>
            </tr>
        </table>--%>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    <%--</div>--%>
    </ContentTemplate>
<%--    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lbtnBuscar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnIzquierdaTodo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnIzquierda" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tbxPaginaActual" />
        <asp:AsyncPostBackTrigger ControlID="lbtnDerecha" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnDerechaTodo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnAgregarIndicadorCuali" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnAgregarIndicadorCuanti" EventName="Click" />
    </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
