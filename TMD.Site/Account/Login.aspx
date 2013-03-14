<%@ Page Title="Log In" Language="C#" MasterPageFile="~/SitePublic.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="TMD.CF.Site.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<script type="text/javascript">
    $(document).ready(function () {
        $('.txtfield input').each(function () {
            if ($(this).val() != '') {
                $(this).addClass('focus');
            }
        });

        $('.txtfield input').focus(function () {
            $(this).keyup(function () {
                if ($(this).val() != '') {
                    $(this).addClass('focus');
                } else {
                    $(this).removeClass('focus');
                }
            });


        }).blur(function () {
            if ($(this).val() == "") {
                $(this).removeClass('focus');
            }
        });

    });
</script>
    
<div id="login-wrapper">

    <div id="login-content">
        <div id="header-login">
            <h2>
            Log In
            </h2>
            <p>
                Por favor ingrese su usuario y password.
            </p>
        </div>
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
            MembershipProvider="None" OnAuthenticate="LoginUser_Authenticate" FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo."
            DestinationPageUrl="~/Index.aspx">
            <LayoutTemplate>
                <span class="failureNotification error2">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" />
                <div class="accountInfo">
                    <fieldset class="login">
                        <legend>Informaci&oacute;n de la cuenta.</legend>
                        <p id="username-wrapper" class="txtfield">
                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                CssClass="failureNotification" ErrorMessage="El Usuario es requerido." ToolTip="El Usuario es requerido."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p id="pwd-wrapper" class="txtfield">
                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="failureNotification" ErrorMessage="El Password es requerido." ToolTip="El Password es requerido."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p id="no-cerrar">
                            <asp:CheckBox ID="RememberMe" runat="server" />
                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline"
                                Width="114px">No cerrar sesi&oacute;n.</asp:Label>
                        </p>
                        <p class="submitButton">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="" ValidationGroup="LoginUserValidationGroup"
                                OnClick="LoginButton_Click" />
                        </p>
                    </fieldset>
                    
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>


</div>
    
</asp:Content>
