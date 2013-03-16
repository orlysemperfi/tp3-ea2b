
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaPlanAccion.aspx.cs" Inherits="TMD.ACP.Site.ListaPlanAccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" type="text/css" href="Styles/Site.css" />

<div>
         <h1 style="text-align:center">SEGUIMIENTO DE AUDITORIA DE HALLAZGO</h1>

         <div style="padding:10px 10px 10px 10px;height:20px;font-family:Arial;">
            <div style="float:left">
                <label>Periodo:</label><asp:Literal ID="litPeriodo" runat="server"></asp:Literal>
            </div>        
         </div>

         <br/>

         <div>
                                                                                                                                                                                        <asp:GridView ID="gvHallazgo" runat="server" 
    AllowPaging="False"
    AutoGenerateColumns="false"
    CssClass="Grid"
    Width="100%"
    OnRowDataBound="gvHallazgo_RowDataBound"
    OnRowCommand="gvHallazgo_RowCommand"
    DataKeyNames="idHallazgo"
    >
        <RowStyle CssClass ="RowStyle"/>
        <HeaderStyle CssClass ="GridCab"/>
        <PagerStyle CssClass ="GridPage" />
        <SelectedRowStyle  CssClass ="SelectedRow" />

        <Columns>

            <asp:TemplateField HeaderText="Nro" >
                <ItemTemplate><asp:Literal ID="ltrlIdHallazgo" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="NroAuditoria" >
                <ItemTemplate><asp:Literal ID="ltrlIdaudi" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pregunta" >
                <ItemTemplate><asp:Literal ID="ltrlPregunta" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="50%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hallazgo" >
                <ItemTemplate><asp:Literal ID="ltrlHallazgo" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Documentos" >
                <ItemTemplate><asp:Literal ID="ltrlDocumentos" runat="server" /></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo" >
                <ItemTemplate><asp:Literal ID="ltrlTipo" runat="server" /></ItemTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Estado" >
                <ItemTemplate><asp:Literal ID="ltrlEst" runat="server" /></ItemTemplate>
            </asp:TemplateField>                     
            <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" HeaderText="Seleccionar" >
            <ItemStyle Width="10%" />
            </asp:ButtonField>

        </Columns>

    </asp:GridView>
            <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="Red"
            Width="496px"></asp:Label><br />
        </div>

    </div>
</asp:Content>

