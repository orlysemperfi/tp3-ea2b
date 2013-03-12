<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProgramaAuditoria.aspx.cs" Inherits="TMD.ACP.Site.ProgramaAuditoria" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    <link rel="stylesheet" type="text/css" href="Styles/style.css" />
    <link rel="stylesheet" href="css/jquery-ui.css" />         
    <link rel="stylesheet" type="text/css" href="js/facebox/facebox.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>                    
    <script type="text/javascript" src="js/global.js"></script>
    <script type="text/javascript" src="js/utils.js"></script>
    <script type="text/javascript" src="js/facebox/facebox.js"></script>
    <script type="text/javascript" src="js/utils.js"></script>

    <script type="text/javascript">

        var newRow;
        var arrRefFunctions = new Array();

        //*****************************************************************************
        //Al cargar el formulario
        //*****************************************************************************

        $(document).ready(function () {
            //Actualizar grid con datos de auditoria si es necesario
            window.arrRefFunctions["auditoria.refresh"] = fRefrescarAuditorias;
            //Si existen auditorias, no debo mostrar los botones
            if ($("#MainContent___IsView").val() == "1") {
                $("#btnGrabar").hide();
                $("#btnCancelar").hide();
                $(".cLnkEditarAuditoria").hide();
                $(".cLnkQuitarAuditoria").hide();
                $(".cLnkAgregarAuditoria").hide();
            }
        });

        //*****************************************************************************
        //Al seleccionar la opcion editar del grid
        //*****************************************************************************

        function fEditarAuditoria(id) {
            var title = 'EDITAR AUDITORIA';
            window.setTimeout(function () { DoCallBack("EditarAuditoria", id, End_fEditarAuditoria); }, 1000)
        }
 
        function End_fEditarAuditoria(arg) {
            var title = 'EDITAR AUDITORIA';
            var mData = arg.split(":::")
            if (mData[0] == "1") {            
                $("#MainContent___tempNroAuditoria").val(mData[1]);
                $("#MainContent___tempIdEntAudi").val(mData[2]);
                $("#MainContent___tempEntAudi").val(mData[3]);
                $("#MainContent___tempArea").val(mData[4]);
                $("#MainContent___tempIdArea").val(mData[5]);
                $("#MainContent___tempIdResponsable").val(mData[6]);
                $("#MainContent___tempResponsable").val(mData[7]);
                $("#MainContent___tempAlcance").val(mData[8]);
                $("#MainContent___tempObjetivo").val(mData[9]);
                $("#MainContent___tempFechaInicio").val(mData[10]);
                $("#MainContent___tempFechaFin").val(mData[11]);
                window.OpenMultiPopup('RegistrarAuditoria.aspx', title, 800, 550, true, null, null, "keyRegistrarAuditoria", "clone", true, false);
            }
        }

        //*****************************************************************************
        //Al seleccionar la opcion agregar del grid
        //*****************************************************************************

        function fAgregarAuditoria() {
            var title = 'NUEVA AUDITORIA';
            window.OpenMultiPopup('RegistrarAuditoria.aspx', title, 800, 550, true, null, null, "keyRegistrarAuditoria", "clone", true, false);
        }

        //*****************************************************************************
        //Al seleccionar la opcion eliminar del grid
        //*****************************************************************************

        function fQuitarAuditoria(id) {
            if (window.confirm("Esta seguro de eliminar la auditoría?")) {
                window.setTimeout(function () { DoCallBack("QuitarAuditoria", id, End_fQuitarAuditoria); }, 1000)
            }
        }

        function End_fQuitarAuditoria(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divProgramaAnual").html(mData[1]);
                $("#MainContent___tempNroAuditoria").val(mData[2]);
                $("#MainContent___tempIdEntAudi").val('');
                $("#MainContent___tempEntAudi").val('');
                $("#MainContent___tempArea").val('');
                $("#MainContent___tempIdArea").val('');
                $("#MainContent___tempIdResponsable").val('');
                $("#MainContent___tempResponsable").val('');
                $("#MainContent___tempAlcance").val('');
                $("#MainContent___tempObjetivo").val('');
                $("#MainContent___tempFechaInicio").val('');
                $("#MainContent___tempFechaFin").val('');
            }
        }

        //*****************************************************************************
        //Al refrescar grid de auditoria con la insercion, modificacion o eliminacion
        //*****************************************************************************

        function fRefrescarAuditorias() {
            window.setTimeout(function () { DoFormCallBack("GrabarAuditoria", "", End_fRefrescarAuditorias); }, 1000)
        }

        function End_fRefrescarAuditorias(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divProgramaAnual").html(mData[1]);
                $("#MainContent___tempNroAuditoria").val(mData[2]);
                $("#MainContent___tempIdEntAudi").val('');
                $("#MainContent___tempEntAudi").val('');
                $("#MainContent___tempArea").val('');
                $("#MainContent___tempIdArea").val('');
                $("#MainContent___tempIdResponsable").val('');
                $("#MainContent___tempResponsable").val('');
                $("#MainContent___tempAlcance").val('');
                $("#MainContent___tempObjetivo").val('');
                $("#MainContent___tempFechaInicio").val('');
                $("#MainContent___tempFechaFin").val('');           
            }
        }

        //*****************************************************************************
        //Al seleccionar la opcion grabar programa anual
        //*****************************************************************************

        function fGrabar() {
            if (window.confirm("Esta seguro de guardar el programa anual de auditoría?")) {
                window.setTimeout(function () { DoFormCallBack("GrabarProgramaAnualAuditoria", "", End_fGrabar); }, 500)
            }
        }

        function End_fGrabar(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                if (mData[1] != "") {
                    alert(mData[1]);
                    return;
                }
                alert("Se grabaron los datos satisfactoriamente");
                $("#divIdPrograma").html(mData[2]);
                $("#divProgramaAnual").html(mData[3]);
                $("#btnGrabar").hide();
                $("#btnCancelar").hide();
                $(".cLnkEditarAuditoria").hide();
                $(".cLnkQuitarAuditoria").hide();
                $(".cLnkAgregarAuditoria").hide();       
            }
        }

        //*****************************************************************************
        //Al seleccionar la opcion cancelar programa anual
        //*****************************************************************************

        function fCancelar() {
            window.location.href = "Index.aspx";
        }

    </script>
    
    <asp:HiddenField id="__tempNroAuditoria" runat="server"/>
    <asp:HiddenField id="__tempIdEntAudi" runat="server"/>
    <asp:HiddenField id="__tempEntAudi" runat="server"/>
    <asp:HiddenField id="__tempArea" runat="server"/>
    <asp:HiddenField id="__tempIdArea" runat="server"/>
    <asp:HiddenField id="__tempIdResponsable" runat="server"/> 
    <asp:HiddenField id="__tempResponsable" runat="server"/>    
    <asp:HiddenField id="__tempAlcance" runat="server"/>
    <asp:HiddenField id="__tempObjetivo" runat="server"/>
    <asp:HiddenField id="__tempFechaInicio" runat="server"/>
    <asp:HiddenField id="__tempFechaFin" runat="server"/>
    <asp:HiddenField id="__IsView" runat="server" Value="0"/>
    <asp:HiddenField id="__TotalAuditorias" runat="server" Value="0"/>

    <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">PROGRAMA ANUAL DE AUDITORÍA</div>       
       
        <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
            <div style="float:left;font-weight:bold;">
                <div><label style="width:140px;">Periodo:</label><asp:Label ID="lblPeriodo" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div>
                <div><label style="width:140px;" >Elaborado por: </label><asp:Label ID="lblElaboradoPor" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div>
                <div><label style="width:140px;">Aprobado por: </label><asp:Label ID="lblAprobadoPor" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div></br>                                 
            </div>
            <div style="float:right;text-align:right;font-weight:bold;">
                <div><label style="width:140px;">Nro: </label><div id="divIdPrograma"><asp:Label ID="lblIdPrograma" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></div></div></br>
                <div><label style="width:140px;">Estado: </label><asp:Label ID="lblEstado" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div> 
            </div>        
        </div>

        <br/>

        <div id="divProgramaAnual" style="float:left;width:100%">              
            <asp:Repeater ID="rptProgramaAnual" runat="server" OnItemDataBound="rptProgramaAnual_ItemDataBound" > 
                <HeaderTemplate >     
                    <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;width:100%">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="ltNroAuditoria" runat="server" Text="NroAuditoria"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="ltEntAudi" runat="server" Text="Proceso / Proyecto"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="ltArea" runat="server" Text="Area"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:100px"><asp:Literal ID="ltResponsable" runat="server" Text="Responsable"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:100px;display:none"><asp:Literal ID="ltAlcance" runat="server" Text="Alcance"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:100px;display:none"><asp:Literal ID="ltObjetivo" runat="server" Text="Objetivo"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="ltFechaInicio" runat="server" Text="Fec. Inicio"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="ltFechaFin" runat="server" Text="Fec. Fin"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:50px"><asp:Literal ID="ltEstado" runat="server" Text="Estado"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:50px" class="cLnkEditarAuditoria"><asp:Literal ID="Literal1" runat="server" Text="Editar"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:50px" class="cLnkQuitarAuditoria"><asp:Literal ID="Literal2" runat="server" Text="Quitar"></asp:Literal></td>
                    </tr>       
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="RowStyle">            
                        <td align="center" style="width:20px"><asp:Label ID="lblNroAuditoria" runat="server"></asp:Label></td>
                        <td align="left"   style="width:200px"><asp:Label ID="lblEntAudi" runat="server"></asp:Label></td>                                       
                        <td align="left"   style="width:80px"><asp:Label ID="lblArea" runat="server"></asp:Label></td>                                       
                        <td align="left"   style="width:100px"><asp:Label ID="lblResponsable" runat="server"></asp:Label></td>                                       
                        <td align="left"   style="width:100px; display:none"><asp:Label ID="lblAlcance" runat="server"></asp:Label></td>                                       
                        <td align="left"   style="width:100px; display:none"><asp:Label ID="lblObjetivo" runat="server"></asp:Label></td>                                       
                        <td align="center" style="width:80px"><asp:Label ID="lblFechaInicio" runat="server"></asp:Label></td>                                       
                        <td align="center" style="width:80px"><asp:Label ID="lblFechaFin" runat="server"></asp:Label></td>                                       
                        <td align="center" style="width:50px"><asp:Label ID="lblEstado" runat="server"></asp:Label></td>                                       
                        <td align="center" style="width:50px" class="cLnkEditarAuditoria"><a href="javascript:fEditarAuditoria(<%# Eval("idAuditoria")%>);" style="text-decoration:underline">Editar</a></td> 
                        <td align="center" style="width:50px" class="cLnkQuitarAuditoria"><a href="javascript:fQuitarAuditoria(<%# Eval("idAuditoria")%>);" style="text-decoration:underline">Quitar</a></td>                    
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                     <tr class="RowStyle">         
                        <td align="left"   style="width:20px"></td>
                        <td align="left"   style="width:200px"></td>                                       
                        <td align="left"   style="width:80px"></td>                                                        
                        <td align="left"   style="width:100px"></td>   
                        <td align="left"   style="width:100px;display:none"></td>   
                        <td align="left"   style="width:100px;display:none"></td>   
                        <td align="left"   style="width:80px"></td>                                       
                        <td align="left"   style="width:80px"></td>                                       
                        <td align="left"   style="width:50px"></td>    
                        <td align="center" style="width:50px" class="cLnkAgregarAuditoria"><a href="javascript:fAgregarAuditoria();" style="text-decoration:underline">Agregar</a></td>                    
                        <td align="left"   style="width:50px" class="cLnkQuitarAuditoria"></td>                        
                    </tr>
                </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <br/>

        <div style="margin:10px 20px 0px 20px;height:100%;float:right;">
            <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fGrabar();"/>
            <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();"/>
        </div>
    </div>

</asp:Content>