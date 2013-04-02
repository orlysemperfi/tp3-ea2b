<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="NuevaAtencion.aspx.cs" Inherits="TMD.ServiceDesk.Site.Atenciones.NuevaAtencion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
        }
        .style3
        {
            width: 167px;
        }
        .style4
        {
            width: 7px;
        }
        .style6
        {
            width: 92px;
        }
        .style7
        {
            width: 167px;
            height: 24px;
        }
        .style8
        {
            height: 24px;
        }
        .style9
        {
            width: 167px;
            height: 30px;
        }
        .style10
        {
            height: 30px;
        }
        
        .style11
        {
            width: 167px;
            height: 36px;
        }
        .style12
        {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
     <ContentTemplate>
    <table class="style1">
        <tr>
            <td class="style2" colspan="4">
                <asp:Label ID="lblTitulo" runat="server" CssClass="title" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#0033CC" Text="Datos Ticket Atención"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblTicket" runat="server" Text="Nro Ticket:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNroTicket" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style6">
                Fecha Registro:</td>
            <td>
                <asp:TextBox ID="txtFechaRegistro" runat="server" ReadOnly="True" Width="169px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Usuario:</td>
            <td class="style4">
                <asp:DropDownList ID="cmbUsuarioCliente" runat="server" Height="24px" 
                    onselectedindexchanged="cmbUsuarioCliente_SelectedIndexChanged" 
                    Width="209px" AutoPostBack="True" CssClass="fieldEdit">
                </asp:DropDownList>
            </td>
            <td class="style6">
                Sede:</td>
            <td>
                <asp:TextBox ID="txtSede" runat="server" Width="171px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Servicio:</td>
            <td class="style4">
                <asp:DropDownList ID="cmbServicio" runat="server" Height="24px" Width="331px" 
                    AutoPostBack="True" CssClass="fieldEdit" 
                    onselectedindexchanged="cmbServicio_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:Label ID="Label7" runat="server" Text="Tipo Registro:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbTipoRegistro" runat="server" Height="19px" 
                    Width="178px" CssClass="fieldEdit">
                    <asp:ListItem>Internet</asp:ListItem>
                    <asp:ListItem>Correo</asp:ListItem>
                    <asp:ListItem>Llamada</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Cliente:</td>
            <td>
                <asp:TextBox ID="txtCliente" runat="server" Width="324px" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="lblcodcliente" runat="server" Text="Label" Visible="False" 
                    Width="10px"></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="Label8" runat="server" Text="Tipo Atención:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbTipoAtencion" runat="server" Height="23px" 
                    Width="178px" CssClass="fieldEdit">
                    <asp:ListItem>Incidente</asp:ListItem>
                    <asp:ListItem>Requerimiento</asp:ListItem>
                    <asp:ListItem>Problema</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Proyecto:</td>
            <td colspan="3">
                <asp:DropDownList ID="cmbProyecto" runat="server" AutoPostBack="True" 
                    CssClass="fieldEdit" Height="31px" 
                    onselectedindexchanged="cmbProyecto_SelectedIndexChanged" Width="330px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:Label ID="Label3" runat="server" Text="Descripcion breve:"></asp:Label>
            </td>
            <td colspan="3" class="style10">
                <asp:TextBox ID="txtDescripcionBreve" runat="server" Height="23px" 
                    MaxLength="50" Width="482px" CssClass="fieldEdit"></asp:TextBox>
                <asp:CustomValidator ID="CVDescripcionBreve" runat="server" 
                    ControlToValidate="txtDescripcionBreve" 
                    ErrorMessage="Debe ingresar 15 caracteres como mínimo" 
                    onservervalidate="CustomValidator1_ServerValidate" 
                    ValidateEmptyText="True" ForeColor="Red" ValidationGroup="ValidarAtencion"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label4" runat="server" Text="SLA:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSLA" runat="server" Width="334px"></asp:TextBox>
            </td>
            <td>
                Prioridad:</td>
            <td>
                <asp:TextBox ID="txtPrioridad" runat="server" CssClass="fieldEdit" 
                    Width="165px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Fecha Expiración:</td>
            <td colspan="3">
                <asp:TextBox ID="txtFechaExpiracion" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label6" runat="server" Text="Especialista:"></asp:Label>
            </td>
            <td class="style8">
                <asp:DropDownList ID="cmbEspecialista" runat="server" AutoPostBack="True" 
                    Height="31px" Width="348px" CssClass="fieldEdit" 
                    onselectedindexchanged="cmbEspecialista_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style8">
                Equipo:</td>
            <td class="style8">
                <asp:DropDownList ID="cmbEquipo" runat="server" CssClass="fieldEdit" 
                    Height="31px" Width="177px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Elemento de Configuración:</td>
            <td colspan="3">
                <asp:DropDownList ID="cmbCMDB" runat="server" CssClass="fieldEdit" 
                    Height="31px" Width="350px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3" valign="top">
                Descripción detallada:<br />
                (min=20 y max=1000 carácteres)</td>
            <td colspan="3">
                <asp:TextBox ID="txtDescripcionDetallada" runat="server" Height="94px" 
                    MaxLength="1000" Rows="10" Width="696px" CssClass="fieldEdit" 
                    ValidationGroup="ValidarAtencion"></asp:TextBox><br />
                <asp:CustomValidator ID="CVDescripcionDetallada" runat="server" 
                    ErrorMessage="Debe ingresar 20 caracteres como mínimo" 
                    onservervalidate="CVDescripcionDetallada_ServerValidate" 
                    ValidateEmptyText="True" ValidationGroup="ValidarAtencion" ForeColor="Red" 
                    ControlToValidate="txtDescripcionDetallada"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td colspan="3">
                <asp:ValidationSummary ID="ValidarCampos" runat="server" ForeColor="Red" 
                    ShowMessageBox="True" ShowSummary="False" 
                    HeaderText="Validación de campos" ValidationGroup="ValidarAtencion" 
                    Width="579px" />
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Button ID="btnGrabar" runat="server" onclick="btnGrabar_Click" 
                    Text="Grabar" Width="100px" ValidationGroup="ValidarAtencion" />
            </td>
            <td colspan="3" class="style12">
                <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                    Text="Cancelar" Width="77px" />
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td colspan="3" class="style12">
                &nbsp;</td>
        </tr>
    </table>
    </ContentTemplate>     
    </asp:UpdatePanel> 
</asp:Content>
