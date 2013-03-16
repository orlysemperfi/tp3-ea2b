﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PropuestaMejoraListado.aspx.cs" Inherits="TMD.MP.Site.Privado.PropuestaMejoraLista" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        function showConfirmationMessage(msg) {
            var resp = confirm(msg);
            return resp;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">LISTADO DE PROPUESTAS DE MEJORA</h1>
        <div class="panel-wrapper">
            <asp:UpdatePanel ID="upnlFiltros" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlFiltros">
                        <table style="width: 800px;">
                            <tr>
                                <td>
                                    <label>
                                        Código:</label>
                                    <asp:TextBox ID="tbxCodigo" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td>
                                    <label>
                                        Tipo:</label>
                                    <asp:DropDownList ID="ddlTipo" runat="server">
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
                                        Fecha:</label>
                                    <asp:TextBox ID="tbxFechaInicio" runat="server" Width="75px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbxFechaInicio" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    <label>
                                        a</label>
                                    <asp:TextBox ID="tbxFechaFin" runat="server" Width="75px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbxFechaFin" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                                </td>
                                <td>
                                    <asp:Button ID="btnAgregarPropuesta" runat="server" OnClick="btnAgregarPropuesta_Click" Text="Agregar" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel ID="upnlPropuestaMejoraListado" runat="server">
        <ContentTemplate>
        <%--<div class="contenedor-pagina">--%>
<%--            <div id="divMensaje" runat="server">
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
<%--            <table id="tblPropuestaMejoraListado" runat="server" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>  --%>                  
                        <asp:GridView ID="gvwPropuestaMejoraListado" runat="server" CssClass="tabla-grilla" Width="920px" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" DataSource='<%#ObtenerPropuestaMejoraListado() %>' BorderWidth="0px" BorderColor="White" OnRowCommand="gvwPropuestaMejoraListado_RowCommand">
<%--                            <HeaderStyle CssClass="tabla-grilla-cabecera" />
                            <RowStyle CssClass="tabla-grilla-filas" />--%>
                            <EmptyDataTemplate>
                                No existen propuestas con los criterios ingresados.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Código">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO_PROPUESTA","{0:000}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Área">
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" runat="server" Text='<%#Eval("NOMBRE_AREA") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipo" runat="server" Text='<%#Eval("TIPO_PROPUESTA") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Solicitante">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSolicitante" runat="server" Text='<%#Eval("NOMBRE_RESPONSABLE") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("NOMBRE_ESTADO") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFecha" runat="server" Text='<%#Eval("FECHA_REGISTRO","{0:dd/MM/yyyy}") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEditar" runat="server" Text='<%#Eval("NOMBRE_ESTADO").ToString() == "REGISTRADA" ? "Editar" : "Ver" %>' CommandName="EditarPropuesta" CommandArgument='<%#Eval("CODIGO_PROPUESTA") %>' CssClass="table-grilla-link"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEliminar" runat="server" Text="Eliminar" CommandName="EliminarPropuesta" CommandArgument='<%#Eval("CODIGO_PROPUESTA") %>' CssClass="table-grilla-link" OnClientClick="if(showConfirmationMessage('¿Desea borrar la propuesta?')==false){return false;}"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                            </PagerTemplate>                   
                        </asp:GridView>
<%--                    </td>
                </tr>
            </table>--%>
            <%--<div id="divLinea" runat="server" class="linea-separadora">
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
<%--            <table border="0" cellpadding="0" cellspacing="0">
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
        <%--</div>--%>
        </ContentTemplate>
<%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbtnBuscar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbtnIzquierdaTodo" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbtnIzquierda" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="tbxPaginaActual" />
            <asp:AsyncPostBackTrigger ControlID="lbtnDerecha" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbtnDerechaTodo" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbtnAgregarPropuesta" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
</asp:Content>
