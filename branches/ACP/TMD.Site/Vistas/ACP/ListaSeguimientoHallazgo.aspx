<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="ListaSeguimientoHallazgo.aspx.cs" Inherits="TMD.ACP.Site.ListaSeguimientoHallazgo" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    <link rel="stylesheet" type="text/css" href="Styles/style.css" />
    <link rel="stylesheet" href="css/jquery-ui.css" />         

    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>                    
    <script type="text/javascript" src="js/global.js"></script>
    <script type="text/javascript" src="js/utils.js"></script>

    <link rel="stylesheet" type="text/css" href="js/facebox/facebox.css" />

    <script type="text/javascript" src="js/facebox/facebox.js"></script>
    <script type="text/javascript" src="js/utils.js"></script>

    <script type="text/javascript">

        var arrRefFunctions = new Array();

        $(document).ready(function () {
            window.arrRefFunctions["asignarseguimiento.refresh"] = fRefrescarHallazgos;
        });
        //*****************************************************************************
        function fListarHallazgos(idAuditoria,estado) {
            $("#MainContent___IdAuditoria").val(idAuditoria);
            $("#MainContent_ddlEstado").val(estado);
            window.setTimeout(function () { DoCallBack("ListarHallazgos", idAuditoria + ":" + estado, End_fListarHallazgos); }, 1000)
        }
        //*****************************************************************************        
        function End_fListarHallazgos(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divHallazgos").html(mData[1]);                
                $("#spanIdAuditoria").html(mData[2]);                             
            }
        }
        //*****************************************************************************        
        function fAgregar(idAuditoria, idHallazgo) {            
            var title = 'ASIGNAR SEGUIMIENTO';
            window.OpenMultiPopup('AsignarSeguimiento.aspx?idAuditoria=' + idAuditoria + '&idHallazgo=' + idHallazgo, title, 450, 300, true, null, null, "keyAsignarSeguimientoHallazgo", "clone", true, false);
        }
        //*****************************************************************************   
        function fListarHallazgosPorEstados() {
            var id = $("#MainContent___IdAuditoria").val();
            var estado = $("#MainContent_ddlEstado").val();
            fListarHallazgos(id,estado);
        }
        //*****************************************************************************        
        function fQuitarAsignacion(idAuditoria,idHallazgo) {
            if (window.confirm("Esta seguro de quitar la asignación de seguimiento?")) {
                window.setTimeout(function () { DoCallBack("QuitarAsignacion", idAuditoria + ":" + idHallazgo, End_fQuitarAsignacion); }, 1000)
            }
        }
        //*****************************************************************************        
        function End_fQuitarAsignacion(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divHallazgos").html(mData[1]);
                $("#MainContent_ddlEstado").val("");              
            }
        }
        //*****************************************************************************  
        function fRefrescarHallazgos(idAuditoria) {
            $("#MainContent___IdAuditoria").val(idAuditoria);
            $("#MainContent_ddlEstado").val("");
            window.setTimeout(function () { DoCallBack("ListarHallazgos", idAuditoria + ":" + "", End_fListarHallazgos); }, 1000)
        }  
     </script>
     <asp:HiddenField id="__IdAuditoria" runat="server"/>
     <div style="margin:0px 0px 0px;padding:0px 0px 0px 0px"><a href="#" style="color:black">Auditoría</a> / <a href="#" style="color:black">SEGUIMIENTO DE HALLAZGOS</a></div>
     <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-top: 10px;">ASIGNAR SEGUIMIENTO A LOS HALLAZGOS DE AUDITORÍA</div>
   
    <div style="padding:5px 10px 5px 10px;height:15px;font-family:Arial;">
        <div style="float:left">
            <label>Periodo: </label><asp:Literal ID="litPeriodo" runat="server"></asp:Literal>
        </div>        
    </div>
    <div style="float:left; width:100%;"> 
     <div id="divPreguntas" style="margin:10px 0px 10px 0px;height:100%;width:100%;">
    
            <asp:Repeater ID="rptAuditorias" runat="server" OnItemDataBound="rptAuditorias_ItemDataBound">
                    <HeaderTemplate>
                      <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;" width="100%">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="litIdAuditoria" runat="server" Text="Nro"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litDesAuditorias" runat="server" Text="Auditorias"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:100px"><asp:Literal ID="litArea" runat="server" Text="Area"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="litFechaInicio" runat="server" Text="Fecha Inicio"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="litFechaFin" runat="server" Text="Fecha Fin"></asp:Literal></td>                                                                    
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litHallazgos" runat="server" Text="Hallazgos"></asp:Literal></td>
                    </tr>     
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="RowStyle">            
                        <td align="center" style="width:20px">
                            <asp:Literal ID="litIdAuditoria" runat="server"/>
                        </td>
                        <td align="left" style="width:200px">                               
                             <asp:Literal ID="litDesAuditorias" runat="server"/>                      
                        </td>
                        <td align="center" style="width:100px">
                        <asp:Literal ID="litArea" runat="server"/>                
                        </td>
                        <td align="center" style="width:120px">
                         <asp:Literal ID="litFechaInicio" runat="server"/>                
                        </td>
                        <td align="center" style="width:120px">
                            <asp:Literal ID="litFechaFin" runat="server"/>                                    
                        </td>                   
                        <td align="center" style="width:60px">               
                        <a id="lnkHallazgos" class="cLnkEditar" href="javascript:fListarHallazgos(<%# Eval("idAuditoria")%>,'');">Hallazgos</a>                
                        </td>                     
                        </tr>            
                    </ItemTemplate>
                    <FooterTemplate>                                
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>                             
        </div>     
    </div>
    <div style="float:left; width:100%;">
    <div style="float:left; width:100%; padding-bottom:10px">
        <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:100px;margin:5px 0px 5px 0px;"><asp:Literal ID="Literal5" runat="server" Text="Observaciones: "></asp:Literal></span>             
        <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:70px;margin:5px 0px 5px 0px;" id="spanIdAuditoria"></span>             
        <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:70px;margin:5px 0px 5px 0px;"><asp:Literal ID="Literal1" runat="server" Text="Estado: "></asp:Literal></span>             
        <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:140px;margin:0px 0px 0px 0px;">
           <asp:DropDownList ID="ddlEstado" runat="server" Width="130" onChange = "fListarHallazgosPorEstados()">
                              <asp:ListItem Value ="">TODOS</asp:ListItem>
                               <asp:ListItem Value ="PLANIFICADO">PLANIFICADO</asp:ListItem>
                               <asp:ListItem Value ="ASIGNADO">ASIGNADO</asp:ListItem>
                            </asp:DropDownList>
        </span>              
    </div>
    <div id="divHallazgos" style="margin:10px 0px 10px 0px;height:100%;width:100%;">
    
            <asp:Repeater ID="rptHallazgos" runat="server" OnItemDataBound="rptHallazgos_ItemDataBound">
                    <HeaderTemplate>
                      <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;" width="100%">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="litIdHallazgo" runat="server" Text="Nro"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litDescripcion" runat="server" Text="Descripción de Hallazgo"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="litTipoHallazgo" runat="server" Text="Tipo"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:110px"><asp:Literal ID="litFechaHallazgo" runat="server" Text="Fec. Compromiso"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="litResponsable" runat="server" Text="Responsable"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:110px"><asp:Literal ID="litFechaSeguimiento" runat="server" Text="Fec. Seguimiento"></asp:Literal></td>                                                                    
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="litEstado" runat="server" Text="Estado"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litAgregar" runat="server" Text="Agregar"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litQuitar" runat="server" Text="Quitar"></asp:Literal></td>
                    </tr>     
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="RowStyle">            
                        <td align="center" style="width:20px">
                            <asp:Literal ID="litIdHallazgo" runat="server"/>
                        </td>
                        <td align="left" style="width:200px">                               
                             <asp:Literal ID="litDescripcion" runat="server"/>                      
                        </td>
                         <td align="left" style="width:120px">                               
                             <asp:Literal ID="litTipoHallazgo" runat="server"/>                      
                        </td>
                        <td align="center" style="width:110px">
                        <asp:Literal ID="litFechaCompromiso" runat="server"/>                
                        </td>
                        <td align="left" style="width:120px">
                         <asp:Literal ID="litResponsable" runat="server"/>                
                        </td>
                        <td align="center" style="width:110px">
                            <asp:Literal ID="litFechaSeguimiento" runat="server"/>                                    
                        </td>                   
                        <td align="center" style="width:80px">
                            <asp:Literal ID="litEstado" runat="server"/>                                    
                        </td>  
                        <td align="center" style="width:60px">
                        <a id="lnkAgregar" class="cLnkAgregar" href="javascript:fAgregar(<%# Eval("idAuditoria")%>,<%# Eval("idHallazgo")%>);">Agregar</a>                
                        </td>  
                        <td align="center" style="width:60px">               
                        <a id="lnkQuitar" class="cLnkQuitar" href="javascript:fQuitarAsignacion(<%# Eval("idAuditoria")%>,<%# Eval("idHallazgo")%>);">Quitar</a>                
                        </td>                     
                        </tr>            
                    </ItemTemplate>
                    <FooterTemplate>                                
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>                             
        </div>
    </div>
  </asp:Content>