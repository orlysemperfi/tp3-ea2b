<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaSolicitudCambio.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.ControlCambio.ListaSolicitudCambio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<center>

    <div id="listaSol" class="content">
        <h1 class="page-title">
            LISTA DE SOLICITUDES</h1>
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
                        <label>
                            LineaBase</label>
                        <asp:DropDownList ID="ddlLineaBase" runat="server">
                        </asp:DropDownList>                        
                    </td>
                    <td>
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar"/>
                    </td>
                </tr>
            </table>
        </div>        
 
 
        <asp:UpdatePanel ID="upnlLista" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="grvSolicitudCambio" runat="server" AutoGenerateColumns="False" 
                onrowcommand="grvSolicitudCambio_RowCommand" 
                ondatabound="grvSolicitudCambio_DataBound">
                <Columns>
                <asp:TemplateField HeaderText="Editar"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnActualizar" ToolTip="Editar" 
                                ImageUrl="~/Imagenes/edit.jpg" runat="server" CommandName="Actualizar" 
                                CommandArgument='<%# Eval("Id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ver"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtnVer" ToolTip="Ver" runat="server" 
                                ImageUrl="~/Imagenes/select.jpg" CommandName="Ver" 
                                CommandArgument='<%# Eval("Id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Id" HeaderText="Codigo" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        
    </div>
</center>

</asp:Content>
