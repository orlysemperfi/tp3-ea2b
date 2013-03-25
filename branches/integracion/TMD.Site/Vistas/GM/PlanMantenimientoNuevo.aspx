<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PlanMantenimientoNuevo.aspx.cs" Inherits="TMD.ACP.Site.PlanMantenimientoNuevo" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <fieldset>
        <legend>Plan de Mantenimiento</legend>
        <div id="divError" class="error" runat="server" visible="false">
            <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label>
        </div>
        <div id="divExito" class="exito" runat="server" visible="false">
            <asp:Label ID="lblMensajeExito" runat="server" Text=""></asp:Label>
        </div>
        
        <div>
            <label>
                Nombre de Plan:</label>
            <asp:TextBox ID="txtPlan" runat="server" CssClass="CuadroTexto" Width="340px"></asp:TextBox>
             <label>
                Fecha Registro:</label>
            <asp:TextBox ID="txtFechaRegistro" CssClass="CuadroTextoDeshab" Enabled="false" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>
                Responsable:</label>
            <asp:TextBox ID="txtResponsable" runat="server" CssClass="CuadroTexto"></asp:TextBox>
        </div>
        <fieldset>
            <legend>Detalle</legend>
            <div>
                <label>
                    Codigo:</label>
                <asp:TextBox ID="txtDetalleIdEquipo" runat="server" CssClass="CuadroTextoDeshab" Enabled="false"></asp:TextBox>
                <asp:TextBox ID="txtDetalleEquipo" runat="server" Width="500" CssClass="CuadroTextoDeshab" Enabled="false"></asp:TextBox>
                <asp:ImageButton ID="imbBuscaEquipo" runat="server" ImageUrl="Imagenes/magnifier.png" ToolTip="Buscar un Equipo registrada previamente"
                    OnClick="imbBuscaEquipo_Click" />
            </div>
            <div>
                <label>
                    Frecuencia:</label>
                <asp:TextBox ID="txtFrecuencia" runat="server" CssClass="CuadroTextoDeshab" Enabled="false"></asp:TextBox>
            </div>

            <div>
                <label>
                    Fecha Inicio:
                </label>
                <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="CuadroTexto"></asp:TextBox>
                <asp:ImageButton ID="imbFechaInicio" runat="server" ImageUrl="~/Imagenes/calendar.png" />
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"
                    Format="dd/MM/yyyy" PopupButtonID="imbFechaInicio">
                </asp:CalendarExtender>
            </div>
            <div>
                <label>
                    Fecha Fin:
                </label>
                <asp:TextBox ID="txtFechaFin" runat="server" CssClass="CuadroTexto"></asp:TextBox>
                <asp:ImageButton ID="imbFechaFin" runat="server" ImageUrl="~/Imagenes/calendar.png" />
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFin"
                    Format="dd/MM/yyyy" PopupButtonID="imbFechaFin">
                </asp:CalendarExtender>
            </div>
            <div>
                <label>
                    Perfil de RRHH:</label>
                <asp:TextBox ID="txtPerfil" runat="server" CssClass="CuadroTexto"></asp:TextBox>
            </div>
            <div class="contenedorBotones">
                <asp:ImageButton ID="imbNuevoEquipo" runat="server" ToolTip="Agregar Equipo"
                    ImageUrl="~/Imagenes/add.png" onclick="imbNuevoEquipo_Click" />
            </div>

            <div>
                <asp:GridView ID="gvDetallePlan" runat="server" AutoGenerateColumns="False"
                    CssClass="mGrid" PagerStyle-CssClass="pgr">
                    <PagerStyle CssClass="pgr" />
                    <Columns>
                        <asp:BoundField DataField="IdEquipo" HeaderText="ID Equipo" HeaderStyle-Width="40" />
                        <asp:TemplateField HeaderText="Equipo" HeaderStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblOrigen" Text='<%# Eval("Equipo.Serie") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" HeaderStyle-Width="20" />
                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" HeaderStyle-Width="20" />
                        <asp:BoundField DataField="Frecuencia" HeaderText="Frecuencia" HeaderStyle-Width="20" />
                        <asp:BoundField DataField="Responsable" HeaderText="Responsable" HeaderStyle-Width="20" />
                        <asp:ButtonField CommandName="Select"  Text="Eliminar" HeaderStyle-Width="30px" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <label>
                    Observaciones</label>
                
                <br />
                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" 
                    CssClass="CuadroTexto" Width="691px"></asp:TextBox>
            </div>
              <div >
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ToolTip="Grabar los datos ingresados en el sistema"
                        onclick="btnGrabar_Click" />
                    <asp:ConfirmButtonExtender ID="cbeGrabar" TargetControlID="btnGrabar" ConfirmText="¿Está seguro de grabar?" runat="server">
                    </asp:ConfirmButtonExtender>
                    <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
                </div>
         </fieldset>
       
        
    </fieldset>
    <asp:ModalPopupExtender ID="mpeEquipo" PopupControlID="pnlEquipos" TargetControlID="imbNuevoEquipo"
        BackgroundCssClass="modalBackground" runat="server">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlEquipos" runat="server" CssClass="modalPopup" Style="display: none">
        <legend>Búsqueda de Equipos</legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <label for="txtIdEquipo" accesskey="d">
                        I<span class="u">d</span>.:</label>
                    <asp:TextBox ID="txtIdEquipo" runat="server" CssClass="CuadroTexto" />
                </div>
                <div>
                    <asp:ImageButton ID="imbBuscar" runat="server" ToolTip="Buscar equipos registrados"
                        ImageUrl="~/Imagenes/magnifier.png" onclick="imbBuscar_Click" />
                </div>
                <asp:GridView ID="gvBusqueda" runat="server" AutoGenerateColumns="False" CssClass="mGridSearch"
                    PagerStyle-CssClass="pgr">
                    <PagerStyle CssClass="pgr" />
                    <SelectedRowStyle BackColor="#CCFFCC" BorderColor="#009900" />
                    <Columns>
                        <asp:BoundField DataField="IdEquipo" HeaderText="Codigo." HeaderStyle-Width="60px" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Equipo" HeaderStyle-Width="90px" />
                        <asp:ButtonField CommandName="SelectEquipo" Text="Sel." HeaderStyle-Width="30px" />
                    </Columns>
                </asp:GridView>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
