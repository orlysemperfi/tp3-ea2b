<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsultaAuditoria.aspx.cs" Inherits="TMD.ACP.Site._ConsultaAuditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div>
        <h1 style="text-align:center">Listado de Auditorías Planificadas</h1>
    
        <link rel="stylesheet" type="text/css" href="Styles/Site.css" />

        <div style="padding:10px 10px 10px 10px;height:20px;font-family:Arial;">
        <div style="float:left">
            <label>Periodo:</label><label>2012</label>
        </div>
         <div style="float:right">
            Nro:<label style="font-weight:bold;"></label><label>PA00001</label>     
         </div>
         </div>



    <br />
    <div id="divGvLista">
        <asp:GridView ID="gvAuditoria" runat="server" 
        AllowPaging="true"
        AutoGenerateColumns="false"
        CssClass="Grid"
        Width="100%"
        OnRowDataBound="gvAuditoria_RowDataBound"
        OnRowCommand="gvAuditoria_RowCommand"
        DataKeyNames="idAuditoria"
        >
        <RowStyle CssClass ="RowStyle"/>
        <HeaderStyle CssClass ="GridCab"/>
        <PagerStyle CssClass ="GridPage" />
        <SelectedRowStyle  CssClass ="SelectedRow" />

        <Columns>

            <asp:TemplateField HeaderText="Nro" >
                <ItemTemplate><asp:Literal ID="ltrlIdaudi" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proceso/Proyecto" >
                <ItemTemplate><asp:Literal ID="ltrlEntAudi" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area" >
                <ItemTemplate><asp:Literal ID="ltrlNomArea" runat="server" /></ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Fecha Inicio" >
                <ItemTemplate><asp:Literal ID="ltrlFecIni" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Fin" >
                <ItemTemplate><asp:Literal ID="ltrlFecFin" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>                       
            <asp:ButtonField CommandName="Hallazgo" Text="Ver Hallazgo" HeaderText="" >
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:ButtonField>

        </Columns>
        <PagerTemplate>
            <asp:Button ID="Button1" runat="server" CommandName="Page" ToolTip="Prim. Pagina" CommandArgument="First" CssClass="primero"/>
            <asp:Button ID="Button2" runat="server" CommandName="Page" ToolTip="Pag. anterior" CommandArgument="Prev" CssClass="anterior"/>
            <asp:Button ID="Button3" runat="server" CommandName="Page" ToolTip="Sig. Pagina" CommandArgument="Next" CssClass="siguiente"/>
            <asp:Button ID="Button4" runat="server" CommandName="Page" ToolTip="Ult. Pagina" CommandArgument="Last" CssClass="ultimo"/>
            Pagina <% Convert.ToString(gvAuditoria.PageIndex+1); %> de <% gvAuditoria.PageCount.ToString(); %>
        </PagerTemplate>
    </asp:GridView>
    <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="Red"
    Width="496px"></asp:Label><br />
  </div>
    </div>  
</asp:Content>




