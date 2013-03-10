<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" 
    CodeBehind="IndicadorFormularioCuali.aspx.cs" Inherits="TMD.MP.Site.Privado.IndicadoresFormulario" %>

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
            EDICION DE INDICADOR 
            CUALITATIVO</div>
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

        </table>
    </div>
    
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:LinkButton ID="lbtnAgregarICuali" runat="server" Text="Agregar" 
                    CssClass="estilo_boton" onclick="lbtnAgregarICuali_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gwEscalasCuali" runat="server" AutoGenerateColumns="false" DataSource='<%#ObtenerEscalaCualitativoListado() %>'>
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
                        <asp:TemplateField HeaderText="Principal">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkResultadoExpec" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEliminarICuali" runat="server" Text="Eliminar" />                                    
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
 

</asp:Content>