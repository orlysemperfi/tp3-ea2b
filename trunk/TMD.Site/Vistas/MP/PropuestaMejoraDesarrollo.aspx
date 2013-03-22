<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" 
    CodeBehind="PropuestaMejoraDesarrollo.aspx.cs" Inherits="TMD.CF.Site.Vistas.MP.PropuestaMejoraDesarrollo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">DESARROLLAR PROPUESTA DE MEJORA</h1>
        <div class="panel-wrapper">
            <asp:UpdatePanel ID="upnlFiltros" runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="pnlFiltros">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblCodigo" runat="server" Text="Código:" Width="50px"></asp:Label>
                                    <asp:TextBox ID="tbxCodigo" runat="server" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" Width="50px"></asp:Label>
                                    <asp:DropDownList ID="ddlTipo" runat="server">
                                    </asp:DropDownList>
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
                                    <asp:Button ID="btnCambiarEstadoEnDesarrollo" runat="server" OnClick="btnCambiarEstadoEnDesarrollo_Click" Text="En Desarrollo" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
<%--<div class="contenedor-pagina">--%>
<%--    <div id="divMensaje" runat="server">
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />--%>
<%--    <table border="0" cellpadding="0" cellspacing="0">        
            <tr>
                <td>--%>
                    <asp:GridView ID="gvwPropuestaMejoraDesarrolloListado" runat="server" AutoGenerateColumns="false" 
                        DataSource='<%#ObtenerPropuestaMejoraDesarrolloListado() %>' 
                        
                        Width="920px" AllowPaging="true" PageSize="10" BorderWidth="0px" BorderColor="White" >
                        <EmptyDataTemplate>
                                No existen propuestas con los criterios ingresados.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPropuestaSel" runat="server" CommandName="SeleccionarPropuesta"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Código Propuesta">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO_PROPUESTA") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Propuesta">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%#Eval("DESCRIPCION") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo Propuesta">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoPropuesta" runat="server" Text='<%#Eval("TIPO_PROPUESTA") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaRegistro" runat="server" Text='<%#Eval("FECHA_REGISTRO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                        
                        </Columns>                        
                    </asp:GridView>

        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
<%--</div>--%>
</asp:Content>
