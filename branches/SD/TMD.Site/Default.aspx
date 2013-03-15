<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TMD.CF.Site._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="default">
        <div id="button-container">
            <a href="~/Account/Login.aspx" ID="HeadLoginStatus" runat="server"></a>
        </div>
    </div>
</asp:Content>
