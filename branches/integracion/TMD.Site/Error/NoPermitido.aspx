﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="NoPermitido.aspx.cs" Inherits="TMD.CF.Site.Error.NoPermitido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        No tiene permisos para visualizar esta opci&oacute;n!</h2>
    <ul>
        <li>
            <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Inicio.aspx">Regresar a la p&aacute;gina de inicio.</asp:HyperLink></li>
    </ul>
</asp:Content>
