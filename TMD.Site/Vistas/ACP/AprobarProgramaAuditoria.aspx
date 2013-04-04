<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="AprobarProgramaAuditoria.aspx.cs" Inherits="TMD.ACP.Site.AprobarProgramaAuditoria" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
            //Si existen auditorias, no debo mostrar los botones
            if ($("#MainContent___IsView").val() == "1") {
                $("#btnAprobar").hide();
                $("#btnRechazar").hide();               
            }
        });

        //*****************************************************************************
        //Al seleccionar la opcion aprobar programa anual
        //*****************************************************************************

        function fAprobar() {
            if (window.confirm("Esta seguro de aprobar el programa anual de auditoría?")) {
                window.setTimeout(function () { DoFormCallBack("AprobarProgramaAnualAuditoria", "", End_fAprobar); }, 500)
            }
        }

        function End_fAprobar(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {                
                alert("Se grabaron los datos satisfactoriamente");
                $("#divProgramaAnual").html(mData[1]);
                $("#btnAprobar").hide();
                $("#btnRechazar").hide();                
            }
        }

        //*****************************************************************************
        //Al seleccionar la opcion rechazar programa anual
        //*****************************************************************************

        function fRechazar() {
            if (window.confirm("Esta seguro de rechazar el programa anual de auditoría?")) {
                window.setTimeout(function () { DoFormCallBack("RechazarProgramaAnualAuditoria", "", End_fRechazar); }, 500)
            }
        }

        function End_fRechazar(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                alert("Se grabaron los datos satisfactoriamente");
                $("#divProgramaAnual").html(mData[1]);
                $("#btnAprobar").hide();
                $("#btnRechazar").hide();
            }
        }


        

        //*****************************************************************************
        //Al seleccionar la opcion cancelar programa anual
        //*****************************************************************************
        function fCancelar() {
            window.location.href = "../../Inicio.aspx";
        }

    </script>
    <asp:HiddenField id="__IsView" runat="server" Value="0"/>

    <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">APROBAR PROGRAMA ANUAL DE AUDITORÍA</div>       
       
        <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
            <div style="float:left;font-weight:bold;">
                <div><label style="width:140px;">Periodo: </label><asp:Label ID="lblPeriodo" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div>
                <div><label style="width:140px;" >Elaborado por: </label><asp:Label ID="lblElaboradoPor" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div>
                <div><label style="width:140px;">Aprobado por: </label><asp:Label ID="lblAprobadoPor" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></div></br>                                 
            </div>
            <div style="float:right;text-align:right;font-weight:bold;">
                <div><label style="width:140px;">Nro: </label><div id="divIdPrograma"><asp:Label ID="lblIdPrograma" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></div></div>
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
                    </tr>
                </ItemTemplate>
                <FooterTemplate>                   
                </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <br/>

        <div style="margin:10px 20px 0px 20px;height:100%;float:right;">
            <input type="button" id="btnAprobar" value="Aprobar" onclick="javascript:fAprobar();"/>
            <input type="button" id="btnRechazar" value="Rechazar" onclick="javascript:fRechazar();"/>
            <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();"/>
        </div>
    </div>

</asp:Content>
