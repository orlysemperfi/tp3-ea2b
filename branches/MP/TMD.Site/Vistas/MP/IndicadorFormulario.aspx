<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/TMD-MP.Master" AutoEventWireup="true" 
    CodeBehind="IndicadorFormulario.aspx.cs" Inherits="TMD.MP.Site.Privado.IndicadoresFormulario" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        document.getElementById("IndicadorCuantitativo").style.visibility = "hidden";
    </script>
    <script type="text/javascript" language="javascript">

//        function cerrarPopup() {
//            window.close();
//        }
        function mostrarIndicador() {
            tipo = document.getElementById("ddlTipo").value;
            if (tipo == "0") {
                document.getElementById("IndicadorCualitativo").style.visibility = "visible";
                document.getElementById("IndicadorCuantitativo").style.visibility = "hidden";
            }

            else {
                document.getElementById("IndicadorCualitativo").style.visibility = "hidden";
                document.getElementById("IndicadorCuantitativo").style.visibility = "visible";
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="contenedor-pagina">
        <div class="contenedor-pagina-titulo">
            EDICION DE INDICADOR</div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    Nombre:
                </td>
                <td>
                    <asp:TextBox ID="tbxNombre" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Frecuencia de Medición:
                </td>
                <td>
                    <asp:TextBox ID="tbxFrecuenciaMed" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Fuente de Medicion:
                </td>
                <td>
                    <asp:TextBox ID="tbxFuenteMed" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Expresion Matematica:
                </td>
                <td>
                    <asp:TextBox ID="tbxExpresionMat" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Plazo:
                </td>
                <td>
                    <asp:TextBox ID="tbxPlaxo" runat="server" CssClass="estilo_textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Tipo:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="estilo_combobox">
                        <asp:ListItem Text="Cualitativo" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Cuantitativo" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlIndicadorCualitativo" runat="server" style="display:none">    
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnAgregarICuali" runat="server" Text="Agregar" CssClass="estilo_boton" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gwEscalasCuali" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" DataSource='<%#ObtenerEscalaCualitativoListado() %>'>
                        <Columns>
                            <asp:TemplateField HeaderText="Limite Superior">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimSuperior" runat="server" Text='<%#Eval("LIMITE_SUPERIOR") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Limite Inferior">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimInferior" runat="server" Text='<%#Eval("LIMITE_INFERIOR") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calificacion">
                                <ItemTemplate>
                                    <asp:Label ID="lblCalificacion" runat="server" Text='<%#Eval("CALIFICACION") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Resultado">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkResultadoExpec" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEliminarICuanli" runat="server" Text="Eliminar" />                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>                        
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlIndicadorCuantitativo" runat="server">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnAgregarICuanti" runat="server" Text="Agregar" CssClass="estilo_boton" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gwEscalasCuanti" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" DataSource='<%#ObtenerEscalaCuantitativoListado() %>'>
                        <Columns>
                            <asp:TemplateField HeaderText="Signo">
                                <ItemTemplate>
                                    <asp:Label ID="lblSigno" runat="server" Text='<%#Eval("SIGNO") %>'  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor">
                                <ItemTemplate>
                                    <asp:Label ID="lblValor" runat="server" Text='<%#Eval("VALOR") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnidad" runat="server" Text='<%#Eval("CODIGO_UNIDAD") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEliminarICuanti" runat="server" Text="Eliminar" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>                        
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:LinkButton ID="lbtnGuardar" runat="server" OnClick="lbtnGuardar_Click" CssClass="estilo_boton" Text="Guardar"></asp:LinkButton>
            </td>
            <td style="padding:5px">
                <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click" CssClass="estilo_boton" Text="Cancelar"></asp:LinkButton>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajeError" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlEscalaCualitativo" runat="server" style="display:none">
    <div id="divEscalaCualitativo">
            <table>            
            <tr><td>Limite Inferior:</td><td><asp:TextBox ID="txbLimInferior" runat="server"/></td></tr>
            <tr><td>Limite Superior:</td><td><asp:TextBox ID="txbLimSuperior" runat="server"/></td></tr>
            <tr><td>Calificacion:</td><td><asp:TextBox ID="txbCalifacion" runat="server"/></td></tr>           
        </table>    
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td><asp:ImageButton ID="ibtnGuardar_ECualitativa" runat="server" 
                    AlternateText="Guardar" ImageUrl="../App_Themes/Imagenes/btnGuardar.png" 
                     /> </td>
            <td style="padding-left:5px"><asp:ImageButton ID="ibtnCancelar_ECualitativa" runat="server" AlternateText="Cancelar" ImageUrl="../App_Themes/Imagenes/btnCancelar.png"/></td>
        </tr>
    </table>
    </div>        
</asp:Panel>

<asp:Panel ID="pnlEscalaCuantitativa" runat="server" style="display:none">
        <div id="divEscalaCuantitativo">
                <table>            
                <tr><td>Signo:</td><td><asp:TextBox ID="txbSigno" runat="server"/></td></tr>
                <tr><td>Valor:</td><td><asp:TextBox ID="txbValor" runat="server"/></td></tr>
                <tr><td>Unidad:</td><td><asp:DropDownList ID="ddlUnidadEC" runat="server" /></td></tr>            
            </table>
    
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td><asp:ImageButton ID="ibtnGuardar_ECuantitativo" runat="server" AlternateText="Guardar" ImageUrl="../App_Themes/Imagenes/btnGuardar.png" /> </td>
                <td style="padding-left:5px"><asp:ImageButton ID="ibtnCancelar_ECuantitativo" runat="server" AlternateText="Cancelar" ImageUrl="../App_Themes/Imagenes/btnCancelar.png"/></td>
            </tr>
        </table>
        </div>
</asp:Panel>
    <asp:ModalPopupExtender
    OkControlID="ibtnGuardar_ECualitativa"
    CancelControlID="ibtnCancelar_ECualitativa"
    runat="server"
    PopupControlID="pnlEscalaCualitativo"
    id="ModalPopupExtender1"
    TargetControlID="lbtnAgregarICuali" /> 

    <asp:ModalPopupExtender
    OkControlID="ibtnGuardar_ECuantitativo"
    CancelControlID="ibtnCancelar_ECuantitativo"
    runat="server"
    PopupControlID="pnlEscalaCuantitativa"
    id="ModalPopupExtender2"
    TargetControlID="lbtnAgregarICuanti" /> 
</asp:Content>