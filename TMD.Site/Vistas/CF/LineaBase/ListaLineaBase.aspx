<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaLineaBase.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.LineaBase.ListaLineaBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ButtonContent" runat="server">
    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Linea Base" 
        onclick="btnNuevo_Click" OnClientClick="javascript:return validarProyecto();" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>

    <div id="listaLB" class="content">
        <h1 class="page-title">
            LISTA DE LINEA BASE</h1>
        <div class="panel-wrapper">
            <table style="width: 800px;">
                <tr>
                    <td>
                        <label>
                            Proyecto</label>
                        <asp:DropDownList ID="ddlProyecto" runat="server">
                        </asp:DropDownList>                        
                    </td>
                    <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"  
                        OnClientClick="javascript:return validarProyecto();" />
                    </td>
                </tr>
            </table>
        </div>        

        <asp:UpdatePanel ID="upnlLista" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grvLineaBase" runat="server" AutoGenerateColumns="False" 
                onrowcommand="grvLineaBase_RowCommand" 
                ondatabound="grvLineaBase_DataBound">
                <Columns>
                <asp:TemplateField HeaderText="Editar"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnActualizar" ToolTip="Editar" 
                                ImageUrl="~/Imagenes/edit.jpg" runat="server" CommandName="Actualizar" 
                                CommandArgument='<%# Eval("ProyectoFase.Fase.Id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnVer" ToolTip="Ver" runat="server" 
                                ImageUrl="~/Imagenes/select.jpg" CommandName="Ver" 
                                CommandArgument='<%# Eval("ProyectoFase.Fase.Id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="Codigo" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:TemplateField HeaderText="Fase">
                        <ItemTemplate>
                            <%# Eval("ProyectoFase.Fase.Nombre")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n" />                
                    <asp:TemplateField HeaderText="Fecha Inicio">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("ProyectoFase.FechaInicio").ToString()).ToString("dd/MM/yyyy")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Fin">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("ProyectoFase.FechaFin").ToString()).ToString("dd/MM/yyyy")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        
        </center>
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
