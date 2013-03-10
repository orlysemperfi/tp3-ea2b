<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true"
    CodeBehind="PropuestaMejoraFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.PropuestaMejoraFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function popup(ancho, alto) {
            var posicion_x;
            var posicion_y;
            posicion_x = (screen.width / 2) - (ancho / 2);
            posicion_y = (screen.height / 2) - (alto / 2);
            window.open('../Privado/IndicadorFormulario.aspx', "Nuevo Indicador", "width=" + ancho + ",height=" + alto + ",menubar=0,toolbar=0,directories=0,scrollbars=no,resizable=no,left=" + posicion_x + ",top=" + posicion_y + "");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
            <div class="contenedor-pagina">
                <div class="contenedor-pagina-titulo">
                    EDICION DE PROPUESTA DE MEJORA</div>
                <br />
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td align="right">
                                        Código:
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnCodigo" runat="server" />
                                        <asp:TextBox ID="tbxCodigo" runat="server" Enabled="false" CssClass="estilo_textbox"></asp:TextBox>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Area:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="estilo_combobox">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="ddlArea" InitialValue="0" ErrorMessage="Seleccione un área" ValidationGroup="Propuesta" Display="None" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Proceso:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProceso" runat="server" CssClass="estilo_combobox" 
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
                                        <asp:DropDownList ID="ddlTipoPropuesta" runat="server" CssClass="estilo_combobox">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvTipoPropuesta" runat="server" ControlToValidate="ddlProceso" InitialValue="0" ErrorMessage="Seleccione un tipo de propuesta" ValidationGroup="Propuesta" Display="None" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Responsable:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlResponsable" runat="server" CssClass="estilo_combobox" />
                                        <asp:RequiredFieldValidator ID="rfvResponsable" runat="server" ControlToValidate="ddlResponsable" InitialValue="0" ErrorMessage="Seleccione un responsable" ValidationGroup="Propuesta" Display="None" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Fecha de Envío:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxFechaEnvio" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                                        <asp:CalendarExtender ID="tbxFechaEnvio_CalendarExtender" runat="server" Format="MM/dd/yyyy"
                                            TargetControlID="tbxFechaEnvio">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="rfvFechaEnvio" runat="server" ControlToValidate="tbxFechaEnvio" ErrorMessage="Ingrese una fecha" ValidationGroup="Propuesta" Display="None" />
                                        <%--<asp:RegularExpressionValidator ID="revFechaEnvio" runat="server" ControlToValidate="tbxFechaEnvio" ErrorMessage="Formato de fecha incorrecto" ValidationGroup="Propuesta" Display="None" ValidationExpression="([1-9]|1[012])[- /.]([1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d" />--%>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right">
                                        Estado:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxEstado" runat="server" Enabled="false" CssClass="estilo_textbox"></asp:TextBox>
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
                                        <asp:TextBox ID="tbxObservaciones" runat="server" TextMode="MultiLine" CssClass="estilo_textbox"></asp:TextBox>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="right">
                                        Descripción:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxDescripcion" runat="server" TextMode="MultiLine" CssClass="estilo_textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="tbxDescripcion" ErrorMessage="Ingrese una descripción" ValidationGroup="Propuesta" Display="None" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="right">
                                        Causa:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxCausa" runat="server" TextMode="MultiLine" CssClass="estilo_textbox"></asp:TextBox>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="right">
                                        Beneficios:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxBeneficios" runat="server" TextMode="MultiLine" CssClass="estilo_textbox"></asp:TextBox>                                        
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
                                            <asp:GridView ID="gvwIndicadores" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                                PageSize="5" CssClass="tabla-grilla" Width="800px" BorderWidth="0px" BorderColor="White"
                                                DataSource='<%#ObtenerIndicadorListado() %>' OnRowCommand="gvwIndicadores_RowCommand">
                                                <HeaderStyle CssClass="tabla-grilla-cabecera" />
                                                <RowStyle CssClass="tabla-grilla-filas" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Codigo">
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
                            <asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="estilo_boton" Text="Guardar" ValidationGroup="Propuesta"></asp:LinkButton>
                            
                        </td>
                        <td class="boton-espaciado">
                            <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass="estilo_boton" Text="Cancelar"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:ValidationSummary ID="vsumGuardar" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="Propuesta" />
                        </td>
                    </tr>
                </table>
            </div>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
</asp:Content>
