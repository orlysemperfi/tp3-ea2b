<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TMD.GC.Site.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $('#slide-images').cycle();
    });
</script>
<div id="slide-images">
    <asp:Image ID="Image1" EnableViewState="false" ImageUrl="~/Imagenes/bienvenido.png" runat="server" />
    <asp:Image ID="Image2" EnableViewState="false" ImageUrl="~/Imagenes/methodology.jpg" runat="server"/>
    <asp:Image ID="img2" EnableViewState="false" ImageUrl="~/Imagenes/rueda.png" runat="server"/>
</div>
</asp:Content>
