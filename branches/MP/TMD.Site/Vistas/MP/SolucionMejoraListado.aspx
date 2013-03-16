<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" CodeBehind="SolucionMejoraListado.aspx.cs" Inherits="TMD.MP.Site.Privado.SolucionMejoraListado" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= tbxPaginaActual.ClientID %>', '');
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="upnlSolucionMejoraListado" runat="server">
    <ContentTemplate>
    <div class="contenedor-pagina">
        <div class="contenedor-pagina-titulo">
            LISTADO DE SOLUCIONES DE MEJORA
        </div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    Código:
                </td>
                <td class="textbox-espaciado">
                    <asp:TextBox ID="tbxCodigo" runat="server" CssClass="estilo_textbox" Width="50px"></asp:TextBox>
                </td>
                <td class="textbox-espaciado">
                    Propuesta:
                </td>
                <td class="textbox-espaciado">
                    <asp:TextBox ID="tbxPropuesta" runat="server" CssClass="estilo_textbox" 
                        Width="50px"></asp:TextBox>
                </td>
                <td class="textbox-espaciado">
                    Fecha:
                </td>
                <td class="textbox-espaciado">
                    <asp:TextBox ID="tbxFechaInicio" runat="server" CssClass="estilo_textbox" Width="75px"></asp:TextBox>
                </td>
                <td class="textbox-espaciado">
                    a
                </td>
                <td class="textbox-espaciado">
                    <asp:TextBox ID="tbxFechaFin" runat="server" CssClass="estilo_textbox" Width="75px"></asp:TextBox>
                </td>
                <td class="textbox-espaciado">
                    <asp:LinkButton ID="lbtnBuscar" runat="server" OnClick="lbtnBuscar_Click" CssClass="estilo_boton" Text="Buscar"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <div id="divMensaje" runat="server">
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table id="tblSolucionMejoraListado" runat="server" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>                    
                    <asp:GridView ID="gvwSolucionMejoraListado" runat="server" CssClass="tabla-grilla" Width="920px" AutoGenerateColumns="false" AllowPaging="true" PageSize="4" DataSource='<%#ObtenerSolucionMejoraListado() %>' BorderWidth="0px" BorderColor="White" OnRowCommand="gvwSolucionMejoraListado_RowCommand">
                        <HeaderStyle CssClass="tabla-grilla-cabecera" />
                        <RowStyle CssClass="tabla-grilla-filas" />
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
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("CODIGO_ESTADO").ToString()=="1" ? "Registrada": Eval("CODIGO_ESTADO").ToString()=="2" ? "Aprobada": Eval("CODIGO_ESTADO").ToString()=="3" ? "Rechazada": "En Desarrollo" %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditar" runat="server" Text="Editar" CommandName="EditarSolucion" CommandArgument='<%#Eval("CODIGO_SOLUCION") %>' CssClass="table-grilla-link"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEliminar" runat="server" Text="Eliminar" CommandName="EliminarSolucion" CommandArgument='<%#Eval("CODIGO_SOLUCION") %>' CssClass="table-grilla-link" Enabled='<%# Eval("CODIGO_ESTADO").ToString()=="1" ? true : false %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                        </PagerTemplate>                   
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div id="divLinea" runat="server" class="linea-separadora">
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
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnAgregarSolucion" runat="server" OnClick="ibtnAgregarSolucion_Click" CssClass="estilo_boton" Text="Agregar"></asp:LinkButton>
                </td>
                <td class="boton-espaciado">
                    <asp:LinkButton ID="lbtnSalir" runat="server" OnClick="ibtnSalir_Click" CssClass="estilo_boton" Text="Salir"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbxFechaInicio" Format="MM/dd/yyyy">
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbxFechaFin" Format="MM/dd/yyyy">
    </ajaxToolkit:CalendarExtender>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lbtnBuscar" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnIzquierdaTodo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnIzquierda" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tbxPaginaActual" />
        <asp:AsyncPostBackTrigger ControlID="lbtnDerecha" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnDerechaTodo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtnAgregarSolucion" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>
