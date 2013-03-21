<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="PropuestaMejoraFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.PropuestaMejoraFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="listaSol" class="content">
        <h1 class="page-title">EDICIÓN DE PROPUESTA DE MEJORA</h1>
        <div class="panel-wrapper form">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top">
                        <table border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td>
                                    <table id="tblCodigo" runat="server" style="display:none;">
                                        <tr>
                                            <td align="right">
                                                Código:
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnCodigo" runat="server" />
                                                <asp:TextBox ID="tbxCodigo" runat="server" Enabled="false"></asp:TextBox>                                        
                                            </td>                                        
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Área:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlArea" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="ddlArea" InitialValue="0" ErrorMessage="Seleccione un área" ValidationGroup="Propuesta" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Proceso:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProceso" runat="server" 
                                        onselectedindexchanged="ddlProceso_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvProceso" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ErrorMessage="Seleccione un proceso" ValidationGroup="Propuesta" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Tipo de Propuesta:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoPropuesta" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTipoPropuesta" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ErrorMessage="Seleccione un tipo de propuesta" ValidationGroup="Propuesta" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Responsable:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlResponsable" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvResponsable" runat="server" ControlToValidate="ddlResponsable" InitialValue="0" ErrorMessage="Seleccione un responsable" ValidationGroup="Propuesta" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Fecha de Envío:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxFechaEnvio" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="tbxFechaEnvio_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="tbxFechaEnvio">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="rfvFechaEnvio" runat="server" ControlToValidate="tbxFechaEnvio" ErrorMessage="Ingrese una fecha" ValidationGroup="Propuesta" Display="None" />
                                    <%--<asp:RegularExpressionValidator ID="revFechaEnvio" runat="server" ControlToValidate="tbxFechaEnvio" ErrorMessage="Formato de fecha incorrecto" ValidationGroup="Propuesta" Display="None" ValidationExpression="([1-9]|1[012])[- /.]([1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="tblEstado" runat="server" style="display:none;">
                                        <tr>
                                            <td align="right">
                                                Estado:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxEstado" runat="server" Enabled="false"></asp:TextBox>
                                            </td>                                       
                                        </tr>
                                    </table>
                                </td>                                
                            </tr>
                        </table>
                    </td>
                    <td style="padding-left:10px;">
                    </td>
                    <td valign="top">
                        <table border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td valign="top" align="right">
                                    Observaciones:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxObservaciones" runat="server" TextMode="MultiLine"></asp:TextBox>                                        
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    Descripción:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="tbxDescripcion" ErrorMessage="Ingrese una descripción" ValidationGroup="Propuesta" Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    Causa:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxCausa" runat="server" TextMode="MultiLine"></asp:TextBox>                                        
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" align="right">
                                    Beneficios:
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxBeneficios" runat="server" TextMode="MultiLine"></asp:TextBox>                                        
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <fieldset>
                            <legend>Indicadores</legend>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="padding-bottom:10px;">
                                        <asp:GridView ID="gvwIndicadores" runat="server" AutoGenerateColumns="false" Width="800px" BorderWidth="0px" BorderColor="White"
                                            DataSource='<%#ObtenerIndicadorListado() %>'>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Codigo" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Nombre">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("NOMBRE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Frecuencia">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFrecuencia" runat="server" Text='<%#Eval("FRECUENCIA_MEDICION") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fuente">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFuente" runat="server" Text='<%#Eval("FUENTE_MEDICION") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tipo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTipo" runat="server" Text='<%#(Convert.ToInt32(Eval("TIPO"))==0)?"Cuantitativo":"Cualitativo" %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Escoger">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkIndicadorSel" runat="server" CommandName="SeleccionarIndicador" Checked='<%#(Eval("MARCADO").ToString()=="true")? true : false %>' ></asp:CheckBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="Propuesta" />                           
                    </td>
                    <td style="padding-left:5px;">
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
                    </td>
                    <td>
                        <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Propuesta" />
                    </td>
                </tr>
            </table>            
        </div>
    </div>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
