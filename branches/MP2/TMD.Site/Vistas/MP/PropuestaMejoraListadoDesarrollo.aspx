<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="PropuestaMejoraListadoDesarrollo.aspx.cs" Inherits="TMD.MP.Site.Privado.PropuestaMejoraListadoDesarrollo" %>

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
    <script type="text/javascript" language="javascript">
        function showConfirmationMessage(msg) {
            var resp = confirm(msg);
            return resp;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">LISTADO DE PROPUESTAS DE MEJORA</h1>
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
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:" Width="50px"></asp:Label>
                                    <asp:DropDownList ID="ddlTipo" runat="server">
                                </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;</td>
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
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel ID="upnlPropuestaMejoraListado" runat="server">
        <ContentTemplate>                
            <asp:GridView ID="gvwPropuestaMejoraListado" runat="server" Width="920px" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" DataSource='<%#ObtenerPropuestaMejoraListado() %>' BorderWidth="0px" BorderColor="White" OnRowCommand="gvwPropuestaMejoraListado_RowCommand" OnPageIndexChanging="gvwPropuestaMejoraListado_PageIndexChanging">
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
                            <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO_PROPUESTA","{0:000}") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre Propuesta">
                        <ItemTemplate>
                            <asp:Label ID="lblDescripcion" runat="server" Text='<%#Eval("DESCRIPCION") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo Propuesta">
                        <ItemTemplate>
                            <asp:Label ID="lblTipo" runat="server" Text='<%#Eval("TIPO_PROPUESTA") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%#Eval("FECHA_REGISTRO","{0:dd/MM/yyyy}") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnVer" runat="server" Text="Ver" CommandName="VerPropuesta" CommandArgument='<%#Eval("CODIGO_PROPUESTA") %>' CssClass="table-grilla-link"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>                
            </asp:GridView>

            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnCambiarEstadoEnDesarrollo" runat="server" OnClick="btnCambiarEstadoEnDesarrollo_Click" Text="Cambiar estado en Desarrollo" />
                    </td>
                </tr>
            </table>

            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblMensajeConfirmacion" runat="server" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
