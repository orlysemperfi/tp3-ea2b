<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/MP/TMD-MP.Master" AutoEventWireup="true" CodeBehind="PropuestaMejoraDesarrollo.aspx.cs" Inherits="TMD.CF.Site.Vistas.MP.PropuestaMejoraDesarrollo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="contenedor-pagina">
    <div class="contenedor-pagina-titulo">
        DESARROLLAR PROPUESTA DE MEJORA
    </div>
    <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                Código:
            </td>
            <td class="textbox-espaciado">
                <asp:TextBox ID="tbxCodigo" runat="server" CssClass="estilo_textbox" Width="150px"></asp:TextBox>
            </td>
            <td class="textbox-espaciado">
                Tipo:
            </td>
            <td class="textbox-espaciado">
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="estilo_combobox">
                </asp:DropDownList>
            </td>
            <td class="textbox-espaciado">
                Fecha del:
            </td>
            <td class="textbox-espaciado">
                <asp:TextBox ID="tbxFechaInicio" runat="server" Width="78px"></asp:TextBox>
            </td>
            <td class="textbox-espaciado">
                al: 
            </td>
            <td class="textbox-espaciado">
                <asp:TextBox ID="tbxFechaFin" runat="server" Width="67px"></asp:TextBox>
            </td>
            <td class="textbox-espaciado">
                <asp:LinkButton ID="lbtnBuscar" runat="server" OnClick="lbtnBuscar_Click" CssClass="estilo_boton" Text="Buscar"></asp:LinkButton>
            </td>
        </tr>
    </table>

    <div id="divMensaje" runat="server">
        <br />
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />

    <table border="0" cellpadding="0" cellspacing="0">
        
            <tr>
                <td>
                    <asp:GridView ID="gvwPropuestaMejoraListado" runat="server" AutoGenerateColumns="false" 
                        DataSource='<%#ObtenerPropuestaMejoraListado() %>' 
                        OnRowCommand="gvwPropuestaMejoraDesarrollo_RowCommand" 
                        Width="657px">
                        <Columns>
                            
                            <asp:TemplateField HeaderText="Codigo Propuesta">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("CODIGO_PROPUESTA") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Propuesta">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimSuperior" runat="server" Text='<%#Eval("DESCRIPCION") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimInferior" runat="server" Text='<%#Eval("NOMBRE_ESTADO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lblCalificacion" runat="server" Text='<%#Eval("FECHA_REGISTRO") %>' />
                                </ItemTemplate>
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
                    <asp:LinkButton ID="lbtnCambiarEstadoEnDesarrollo" runat="server" OnClick="ibtnCambiarEstadoEnDesarrollo_Click" CssClass="estilo_boton" Text="En Desarrollo"></asp:LinkButton>
                </td>
                <td class="boton-espaciado">
                    <asp:LinkButton ID="lbtnSalir" runat="server" OnClick="ibtnSalir_Click" CssClass="estilo_boton" Text="Salir"></asp:LinkButton>
                </td>
            </tr>
        </table>

</div>



</asp:Content>
