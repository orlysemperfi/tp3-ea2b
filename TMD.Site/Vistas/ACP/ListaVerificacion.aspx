<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="ListaVerificacion.aspx.cs" Inherits="TMD.ACP.Site.ListaVerificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles/Site.css" />

<div>
         <h1 style="text-align:center">Lista de Verificación</h1>

         <div style="padding:10px 10px 10px 10px;height:20px;font-family:Arial;">
            <div style="float:left">
                <label>Periodo: </label><asp:Literal ID="litPeriodo" runat="server"></asp:Literal>
            </div>        
         </div>

         <br/>

         <div>
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

            <asp:TemplateField HeaderText="NroAuditoria" >
                <ItemTemplate><asp:Literal ID="ltrlIdaudi" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proceso/Proyecto" >
                <ItemTemplate><asp:Literal ID="ltrlEntAudi" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Area" >
                <ItemTemplate><asp:Literal ID="ltrlNomArea" runat="server" /></ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Fec. Inicio" >
                <ItemTemplate><asp:Literal ID="ltrlFecIni" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fec. Fin" >
                <ItemTemplate><asp:Literal ID="ltrlFecFin" runat="server" /></ItemTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Estado" >
                <ItemTemplate><asp:Literal ID="ltrlEst" runat="server" /></ItemTemplate>
            </asp:TemplateField>                     
            <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" HeaderText="Seleccionar" >
            <ItemStyle Width="10%" />
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

