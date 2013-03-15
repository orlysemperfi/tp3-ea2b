<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="GeneralError.aspx.cs" Inherits="TMD.CF.Site.Error.GeneralError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Ha ocurrido un error!</h2>
    <p>
        Un error inesperado ha ocurrido en nuestro sitio web.
    </p>
    <ul>
        <li>
            <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Inicio.aspx">Regresar a la p&aacute;gina de inicio.</asp:HyperLink></li>
    </ul>
</asp:Content>
