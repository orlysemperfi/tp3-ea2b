﻿<%@ Page Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" CodeBehind="IndicadorFormularioCuanti.aspx.cs" Inherits="TMD.CF.Site.Vistas.MP.IndicadorFormularioCuanti" %>

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
            EDICION DE INDICADOR CUANTITATIVO</div>
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
             <tr>
                <td>
                    Proceso:</td>
                <td >
                    <asp:DropDownList ID="ddlProceso" runat="server" CssClass="estilo_combobox">
                    </asp:DropDownList>
                </td>
            </tr>
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
                    <asp:LinkButton ID="lbtnAgregarICuanti" runat="server" Text="Agregar" 
                        CssClass="estilo_boton" onclick="lbtnAgregarICuanti_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gwEscalasCuanti" runat="server" AutoGenerateColumns="false" DataSource='<%#ObtenerEscalaCuantitativoListado() %>' OnRowCommand="gwEscalasCuanti_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Codigo">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO") %>' Visible=false />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <asp:Label ID="lblUnidad" runat="server" Text='<%#Eval("DESCRIPCION_UNIDAD") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditarCuali" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%#Eval("CODIGO") %>'/>                                    
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEliminarICuanti" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%#Eval("CODIGO") %>' />
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