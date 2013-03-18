<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="AdjuntarDocumento.aspx.cs" Inherits="TMD.CF.Site.Vistas.SD.Atenciones.AdjuntarDocumento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="title">
                <asp:Label ID="lblTitulo" runat="server" CssClass="title" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#0033CC" 
                    Text="INFORMACIÓN ADICIONAL DEL TICKET"></asp:Label>            
            </td>
        </tr>
    </table>
    <table class="style1">
        <tr>
            <td colspan="2" class="title">
                <asp:Label ID="Label1" runat="server" CssClass="bold" 
                    Text="Datos del Ticket de Atención"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Número Ticket:</td>
            <td class="style7">
                <asp:TextBox ID="txtNroTicket" runat="server" ReadOnly="True" Width="116px"></asp:TextBox>
            </td>
            <td class="style12">
                Fecha Registro:</td>
            <td>
                <asp:TextBox ID="txtFechaRegistro" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Tipo Ticket:</td>
            <td class="style7">
                <asp:TextBox ID="txtTipoTicket" runat="server" ReadOnly="True" Width="116px"></asp:TextBox>
            </td>
            <td class="style12">
                Analista:</td>
            <td>
                <asp:TextBox ID="txtAnalista" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Servicio:</td>
            <td class="style7">
                <asp:TextBox ID="txtServicio" runat="server" ReadOnly="True" Width="395px"></asp:TextBox>
            </td>
            <td class="style12">
                Especialista:</td>
            <td class="style3">
                <asp:TextBox ID="txtEspecialista" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style12">
                Usuario:</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Descripción Ticket:</td>
            <td class="style5" colspan="2">
                <asp:TextBox ID="txtDescripcionBreve" runat="server" ReadOnly="True" 
                    Width="398px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2" align="left" valign="top">
                Descripción del documento:</td>
            <td class="style6" colspan="3">
                <asp:TextBox ID="txtDescripcionDocumento" runat="server" CssClass="fieldEdit" 
                    Height="64px" Width="608px" TextMode="MultiLine"></asp:TextBox><br />
                <asp:CustomValidator ID="CVDescripcionDocumento" runat="server" 
                    ControlToValidate="txtDescripcionDocumento" 
                    ErrorMessage="Debe ingresar 20 caracteres como mínimo" 
                    onservervalidate="CustomValidator1_ServerValidate" 
                    ValidateEmptyText="True" ForeColor="Red" ValidationGroup="ValidarAtencion"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
           <td class="style2" align="left" valign="top">
                Nombre del archivo:</td>
            <td class="style6" colspan="3">
                <asp:TextBox ID="txtNombreArchivo" runat="server" Width="398px" CssClass="fieldEdit"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td class="style2" align="left" valign="top">
                Ruta del archivo:</td>
            <td class="style6" colspan="3">
                <asp:TextBox ID="txtRutaArchivo" runat="server" Width="398px" CssClass="fieldEdit">C:\Documentos</asp:TextBox>
            </td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7">
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" Width="78px" ValidationGroup="ValidarAtencion" />

                <asp:Button ID="btnSalir" runat="server" onclick="btnSalir_Click" Text="Salir" 
                    Width="81px" />
            </td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td class="style12">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
           <td class="style2">
                &nbsp;</td>
            <td class="style7" colspan="3">
                <asp:GridView ID="grdDocumentoTicket" runat="server" 
                    AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="grdDocumentoTicket_SelectedIndexChanged1" Width="713px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Codigo_DocumentoTicket" HeaderText="Id" />
                        <asp:BoundField DataField="Fecha_Registro" HeaderText="Fecha Registro" />
                        <asp:BoundField DataField="Nombre_DocumentoTicket" 
                            HeaderText="Nombre Documento" />
                        <asp:BoundField DataField="Descripcion_DocumentoTicket" 
                            HeaderText="Descripcion" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
