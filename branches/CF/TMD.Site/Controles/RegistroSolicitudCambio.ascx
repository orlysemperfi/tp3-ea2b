<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegistroSolicitudCambio.ascx.cs" Inherits="TMD.CF.Site.Controles.RegistroSolicitudCambio" %>
<asp:Panel runat="server" ID="pnlSolicitudCambio">
<p>
    Solicitud de Cambio</p>
<p>
    Codigo:
    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
</p>
<p>
    Nombre:
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
</p>
<p>
    Proyecto:
    <asp:DropDownList ID="ddlProyecto" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlProyecto_SelectedIndexChanged">
    </asp:DropDownList>
</p>
<p>
    Linea Base:
    <asp:DropDownList ID="ddlLineaBase" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlLineaBase_SelectedIndexChanged">
    </asp:DropDownList>
</p>
<p>
    Elemento Configuracion:  
    <asp:DropDownList ID="ddlElementoConfiguracion" runat="server">
    </asp:DropDownList>
</p>
<p>
    Prioridad:
    <asp:DropDownList ID="ddlPrioridad" runat="server">
    </asp:DropDownList>
</p>
<p>
  Estado:
    <asp:DropDownList ID="ddlEstado" runat="server">
    </asp:DropDownList>
</p>
<p>
    <asp:Button ID="btnGrabar" runat="server" onclick="btnGrabar_Click" 
        Text="Grabar" />
    <asp:Button ID="btnSalir" runat="server" Text="Salir" />
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
</asp:Panel>