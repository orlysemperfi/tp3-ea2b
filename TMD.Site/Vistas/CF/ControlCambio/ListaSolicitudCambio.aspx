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
 
    </div>
</center>

</asp:Content>
