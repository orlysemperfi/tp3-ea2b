<%@ Page Title="" Language="C#" MasterPageFile="~/Privado/TMD-MP.Master" AutoEventWireup="true" CodeBehind="Prueba2.aspx.cs" Inherits="TMD.MP.Site.Privado.Prueba2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>


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
    <div id="IndicadorCualitativo">
        <table>
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnAgregarICuali" runat="server" Text="Agregar" CssClass="estilo_boton" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gwEscalasCuali" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="3">
                        <Columns>
                            <asp:TemplateField HeaderText="Limite Superior">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimSuperior" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Limite Inferior">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimInferior" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calificacion">
                                <ItemTemplate>
                                    <asp:Label ID="lblCalificacion" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnEliminarICuali" runat="server" AlternateText="Editar" ImageUrl="~/App_Themes/Imagenes/icnEliminar.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div id="IndicadorCuantitativo">
        <table>
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnAgregarICuanti" runat="server" Text="Agregar" CssClass="estilo_boton" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gwEscalasCuanti" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="3">
                        <Columns>
                            <asp:TemplateField HeaderText="Signo">
                                <ItemTemplate>
                                    <asp:Label ID="lblSigno" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor">
                                <ItemTemplate>
                                    <asp:Label ID="lblValor" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Unidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblUnidad" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtnEliminarICuanti" runat="server" AlternateText="Editar" ImageUrl="~/App_Themes/Imagenes/icnEliminar.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
     <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Guardar" CssClass="estilo_boton" />
            </td>
            <td style="padding:5px">
                <asp:LinkButton ID="LinkButton2" runat="server" Text="Cancelar" CssClass="estilo_boton" />
            </td>
        </tr>
    </table>
        <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </div>


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

<ajaxToolkit:ModalPopupExtender
OkControlID="ibtnGuardar_ECualitativa"
CancelControlID="ibtnCancelar_ECualitativa"
runat="server"
PopupControlID="pnlEscalaCualitativo"
id="ModalPopupExtender2"
TargetControlID="lbtnAgregarICuali"
BackgroundCssClass="modalBackground" /> 

<ajaxToolkit:ModalPopupExtender
OkControlID="ibtnGuardar_ECuantitativo"
CancelControlID="ibtnCancelar_ECuantitativo"
runat="server"
PopupControlID="pnlEscalaCuantitativa"
id="ModalPopupExtender3"
TargetControlID="lbtnAgregarICuanti"
BackgroundCssClass="modalBackground" /> 

</asp:Content>
