﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="SolucionMejoraListado.aspx.cs" Inherits="TMD.MP.Site.Privado.SolucionMejoraListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
  <link rel="stylesheet" href="../ACP/css/jquery-ui.css" />    

    <script type="text/javascript">
        $(function () {
            $("#<%=tbxFechaInicio.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%=tbxFechaInicio.ClientID %>").datepicker();
            $("#<%=tbxFechaFin.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy' });
            $("#<%=tbxFechaFin.ClientID %>").datepicker();
        });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">LISTADO DE SOLUCIONES DE MEJORA</h1>
        <div class="panel-wrapper">
            <asp:UpdatePanel ID="upnlFiltros" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlFiltros">
                       <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblCodigo" runat="server" Text="Código:" Width="50px"></asp:Label>
                                    <asp:TextBox ID="tbxCodigo" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblPropuesta" runat="server" Text="Propuesta:" Width="50px"></asp:Label>
                                    <asp:TextBox ID="tbxPropuesta" runat="server"
                                        Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFecha" runat="server" Text="Fecha:" Width="50px"></asp:Label>
                                    <asp:TextBox ID="tbxFechaInicio" runat="server" Width="75px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblA" runat="server" Text="a" Width="50px"></asp:Label>
                                    <asp:TextBox ID="tbxFechaFin" runat="server" Width="75px"></asp:TextBox>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAgregarSolucion" runat="server" OnClick="btnAgregarSolucion_Click" Text="Agregar" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel ID="upnlSolucionMejoraListado" runat="server">
    <ContentTemplate>
<%--    <div class="contenedor-pagina"> --%>
<%--        <div id="divMensaje" runat="server">
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />--%>
<%--        <table id="tblSolucionMejoraListado" runat="server" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>  --%>                  
                    <asp:GridView ID="gvwSolucionMejoraListado" runat="server" Width="920px" AutoGenerateColumns="false" AllowPaging="true" PageSize="4" DataSource='<%#ObtenerSolucionMejoraListado() %>' BorderWidth="0px" BorderColor="White" OnRowCommand="gvwSolucionMejoraListado_RowCommand" OnPageIndexChanging="gvwSolucionMejoraListado_PageIndexChanging">
                        <EmptyDataTemplate>
                                No existen soluciones con los criterios ingresados.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="Código">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO_SOLUCION","{0:000}") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Propuesta">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigoPropuesta" runat="server" Text='<%#Eval("CODIGO_PROPUESTA","{0:000}") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("NOMBRE_ESTADO") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" CommandName="EditarSolucion" CommandArgument='<%#Eval("CODIGO_SOLUCION") %>' CssClass="table-grilla-link"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEliminar" runat="server" Text="Eliminar" CommandName="EliminarSolucion" CommandArgument='<%#Eval("CODIGO_SOLUCION") %>' CssClass="table-grilla-link" OnClientClick="if(showConfirmationMessage('¿Desea borrar la solucion?')==false){return false;}"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                        </PagerTemplate>                   
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
    </div>
    </ContentTemplate>
<%--    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lbtnBuscar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnIzquierdaTodo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnIzquierda" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tbxPaginaActual" />
        <asp:AsyncPostBackTrigger ControlID="lbtnDerecha" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnDerechaTodo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnAgregarSolucion" EventName="Click" />
    </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
