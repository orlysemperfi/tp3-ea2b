<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="ListaLineaBase.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.LineaBase.ListaLineaBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div id="listaLB" class="content">
        <h1 class="page-title">
            LISTADO DE LINEAS BASE</h1>
        <div class="panel-wrapper">
            <table style="width: 800px;">
                <tr>
                    <td>
                        <label>
                            Proyecto</label><asp:DropDownList ID="ddlProyecto" runat="server" 
                            AutoPostBack="True" onselectedindexchanged="ddlProyecto_SelectedIndexChanged" 
                            Width="200px">
                        </asp:DropDownList>  <asp:CompareValidator ID="proyectoValidator" runat="server" ControlToValidate="ddlProyecto"
            ErrorMessage="El proyecto es requerido." ToolTip="El proyecto es requerido."
            ValidationGroup="BusquedaValidationGroup" ValueToCompare="0" CssClass="failureNotification"
            Operator="NotEqual">*
        </asp:CompareValidator>                      
                    </td>
                    <td>
    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Linea Base" 
        onclick="btnNuevo_Click"  ValidationGroup="BusquedaValidationGroup" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>        
        <div id="mensajeError" style="display:none">
        </div>    
        <asp:UpdatePanel ID="upnlLista" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grvLineaBase" runat="server" AutoGenerateColumns="False" 
                onrowcommand="grvLineaBase_RowCommand" 
                ondatabound="grvLineaBase_DataBound">
                <HeaderStyle CssClass="headGrid" />
                <Columns>
                <asp:TemplateField HeaderText="Editar"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnActualizar" ToolTip="Editar" 
                                ImageUrl="~/Imagenes/edit.jpg" runat="server" CommandName="Actualizar" 
                                CommandArgument='<%# Eval("ProyectoFase.Fase.Id")%>' Height="20px" 
                                Width="19px"
                                Visible='<%# Convert.ToDateTime(Eval("ProyectoFase.FechaFin").ToString()) > DateTime.Now %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnVer" ToolTip="Ver" runat="server" 
                                ImageUrl="~/Imagenes/ver.png" CommandName="Ver" 
                                CommandArgument='<%# Eval("ProyectoFase.Fase.Id")%>' Height="20px" 
                                Width="19px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
        <asp:AsyncPostBackTrigger ControlID="ddlProyecto" EventName="SelectedIndexChanged" />
        </Triggers>
        </asp:UpdatePanel>
        
    </div>

    <script type="text/javascript" language="javascript">
        function validarProyecto() {
            if ($get('<%= ddlProyecto.ClientID %>').selectedIndex == 0) {
                crearMensaje('Seleccione un Proyecto!');
                return true;
            }
        }
    </script>

</asp:Content>
