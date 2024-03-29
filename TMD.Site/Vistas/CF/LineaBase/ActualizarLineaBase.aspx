﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="ActualizarLineaBase.aspx.cs" Inherits="TMD.CF.Site.Vistas.CF.LineaBase.ActualizarLineaBase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Panel ID="pnlMain" runat="server">
        <asp:HiddenField ID="hiddenIdLineaBase" runat="server" />
        <div id="actualizarLB" class="content">
            <h1 class="page-title">
                ACTUALIZAR LINEA BASE</h1>
            <div class="panel-wrapper">
                <table style="width: 800px;">
                    <tr>
                        <td>
                            <label>
                                Proyecto</label>
                            <asp:DropDownList ID="ddlProyecto" runat="server" style="margin-left: 0px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <label>
                                Fase</label>
                            <asp:DropDownList ID="ddlFase" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlFase_SelectedIndexChanged" >
                            </asp:DropDownList>
                            <asp:CompareValidator ID="FaseValidator" runat="server" ControlToValidate="ddlFase"
                                ErrorMessage="La Fase es requerida." ToolTip="La Fase es requerida." ValidationGroup="GrabarValidationGroup"
                                ValueToCompare="0" CssClass="failureNotification" Operator="NotEqual">*
                            </asp:CompareValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" 
                                OnClientClick="javascript: return grabar();" Text="Grabar Linea Base" 
                                ValidationGroup="GrabarValidationGroup" />
                            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn-cancelar"
                                Text="Cancelar" ValidationGroup="None" />
                        </td>
                    </tr>
                </table>
            </div>
    <div id="mensajeError" style="display:none">
    </div>    
            <div id="form_lineabase" class="panel-wrapper form">
                <asp:ValidationSummary ID="GrabarValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="GrabarValidationGroup" />
                <table style="width: 600px;">
                    <tr>
                        <td>
                            <label>
                                Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" Width="190px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="txtNombre"
                                CssClass="failureNotification" ErrorMessage="El Nombre es requerido." ToolTip="El Nombre es requerido."
                                ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Descripcion</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="431px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DescripcionRequired" runat="server" ControlToValidate="txtDescripcion"
                                CssClass="failureNotification" ErrorMessage="La Descripci&oacute;n es requerida."
                                ToolTip="La Descripci&oacute;n es requerida." ValidationGroup="GrabarValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <p align="right">
                    <asp:CustomValidator ID="ElementoValidator" runat="server" ErrorMessage="Los elementos de configuraci&amp;oacute;n son requeridos."
                        ClientValidationFunction="ClientValidate" ValidationGroup="GrabarValidationGroup"
                        Text="*" ForeColor="White"></asp:CustomValidator>
                    <asp:Button ID="btnAgregarECS" runat="server" Text="Agregar Elemento" OnClick="btnAgregarECS_Click"
                        OnClientClick="javascript:return validarFase();" ValidationGroup="None" /></p>
                <asp:UpdatePanel ID="upnlListaFinalEcs" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="grvElementoConfiguracion" runat="server" AutoGenerateColumns="False"
                            OnRowCommand="grvElementoConfiguracion_RowCommand" OnDataBound="grvElementoConfiguracion_DataBound"
                            OnRowDeleting="grvElementoConfiguracion_RowDeleting">
                            <EmptyDataTemplate>
                                No existen registros.
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Eliminar"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtnEliminar" runat="server" ToolTip="Eliminar" ImageUrl="~/Imagenes/delete.jpg"
                                            CommandName="Eliminar" ValidationGroup="None" 
                                            CommandArgument='<%# Eval("Id")%>' Height="20px" Width="19px" />
                                        <asp:HiddenField ID="hiddenEcsId" runat="server" Value='<%# Eval("Id")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Elemento de Configuraci&oacute;n" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                <asp:TemplateField HeaderText="Responsable"  ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlResponsable" runat="server">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="ResponsableValidator" runat="server" ControlToValidate="ddlResponsable"
                                            ToolTip="El Responsable es requerido." CssClass="failureNotification" ValidationGroup="GrabarValidationGroup"
                                            ValueToCompare="0" Operator="NotEqual">*
                                        </asp:CompareValidator>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSeleccionar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <!-- END #form_lineabase -->
            <div id="ECS-master" class="panel-wrapper" style="display: none;">
            </div>
        </div>
        <!-- END #content -->
        <asp:UpdatePanel ID="upnlLista" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlECS" runat="server" Visible="false">
                    <h1>
                        Lista de Elementos de Configuraci&oacute;n.</h1>
                    <br />
                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar Elemento" 
                        OnClick="btnSeleccionar_Click" />
                    <asp:GridView ID="grvListaECS" runat="server" AutoGenerateColumns="False" Enabled="true">
                        <EmptyDataTemplate>
                            No existen registros.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkElemento" runat="server" />
                                    <asp:HiddenField ID="hiddenEcsId" runat="server" Value='<%# Eval("Id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Nombre" HeaderText="Elemento de Configuraci&oacute;n" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripci&oacute;n" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAgregarECS" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="upnlProxy" runat="server" UpdateMode="Always">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGrabar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

    <script type="text/javascript" language="javascript">

        function mostrarPopup() {
            alert('popup');
        }
        function exitoNuevo() {
            //alert('Linea Base registrada correctamente!');
            window.location = "ListaLineaBase.aspx";
        }
        function exitoActualizar() {
            //alert('Linea Base actualizada correctamente!');
            window.location = "ListaLineaBase.aspx";
        }
        function grabar() {
            if (Page_ClientValidate('GrabarValidationGroup')) {
                Page_BlockSubmit = false;
                return true;// confirm('Desea grabar los datos ingresados?');
            }
            Page_BlockSubmit = false;
            return false;
        }
        function cancelar() {
            return true;
        }
        function validarFase() {
            if ($get('<%= ddlFase.ClientID %>').selectedIndex == 0) {
                crearMensaje('Seleccione una Fase!');
                return true;
            }
        }
        function ClientValidate(source, arguments) {
            if ($get('<%= grvElementoConfiguracion.ClientID %>') == null) {
                arguments.IsValid = false;
            }
            else {
                if ($get('<%= grvElementoConfiguracion.ClientID %>').rows.length > 1) {
                    arguments.IsValid = true;
                }
                else {
                    arguments.IsValid = false;
                }
            }
        }
    </script>
</asp:Content>
