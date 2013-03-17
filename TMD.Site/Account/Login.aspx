<%@ Page Title="Log In" Language="C#" MasterPageFile="~/SitePublic.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="TMD.MP.Site.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 349px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        Por favor ingrese su usuario y password.
    </p>
    <table border="0">
    <tr>
    <td class="style2">
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
        MembershipProvider="None" OnAuthenticate="LoginUser_Authenticate" FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo."
        DestinationPageUrl="~/Vistas/MP/IndicadorListado.aspx">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" />
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Informaci&oacute;n de la cuenta.</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" Height="23px" 
                            Width="221px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            CssClass="failureNotification" ErrorMessage="El Usuario es requerido." ToolTip="El Usuario es requerido."
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" 
                            TextMode="Password" Width="217px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            CssClass="failureNotification" ErrorMessage="El Password es requerido." ToolTip="El Password es requerido."
                            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server" />
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline"
                            Width="114px">No cerrar sesi&oacute;n.</asp:Label>
                    </p>
                </fieldset>
                &nbsp;<p>
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                        OnClick="LoginButton_Click" />
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
    </td>
    <td align="left" valign="top">
        &nbsp;</td>
    </tr>    
    </table>
    

    
</asp:Content>
