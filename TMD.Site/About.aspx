<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="TMD.CF.Site.About" %>

<%@ Register src="Controles/RegistroSolicitudCambio.ascx" tagname="RegistroSolicitudCambio" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        Put content here.
    </p>
<uc1:RegistroSolicitudCambio ID="RegistroSolicitudCambio1" runat="server" />
</asp:Content>
