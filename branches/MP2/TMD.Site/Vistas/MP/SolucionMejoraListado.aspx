<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="SolucionMejoraListado.aspx.cs" Inherits="TMD.MP.Site.Privado.SolucionMejoraListado" %>

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
                                    <asp:Label ID="lblPropuesta" runat="server" Text="Propuesta:" Width="75px"></asp:Label>
                                    <asp:TextBox ID="tbxPropuesta" runat="server" Width="75px"></asp:TextBox>
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
                                    <asp:Label ID="lblA" runat="server" Text="a" Width="75px"></asp:Label>
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
                                    <asp:Label ID="lblCodigoPropuesta" runat="server" Text='<%#Eval("PROPUESTA") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción">
                                <ItemTemplate>
                                    <asp:Label ID="lblSolucion" runat="server" Text='<%#Eval("DESCRIPCION") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("NOMBRE_ESTADO") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Text='<%#Eval("FECHA_REGISTRO_INICIO","{0:d}") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditar" runat="server" Text='<%#Eval("NOMBRE_ESTADO").ToString() == "APROBADA" ? "Ver" : "Editar" %>' CommandName="EditarSolucion" CommandArgument='<%#Eval("CODIGO_SOLUCION") %>' CssClass="table-grilla-link"></asp:LinkButton>
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
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblMensajeConfirmacion" runat="server" ForeColor="Green"></asp:Label>
                    <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
