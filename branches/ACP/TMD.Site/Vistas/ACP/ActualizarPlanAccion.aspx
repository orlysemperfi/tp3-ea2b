<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="ActualizarPlanAccion.aspx.cs" Inherits="TMD.ACP.Site.Vistas.ACP.ActualizarPlanAccion" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
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


        //*****************************************************************************

        $(document).ready(function () {
        });

        //*****************************************************************************

        function fCancelar() {
            window.location.href = "ListaPlanAccion.aspx";
        }

        //********************************************************************
        function fGrabar() {
            var accionCorrectiva = $("#MainContent_txtAccionCorrectiva").val();
            if ($.trim(accionCorrectiva) == "") {
                alert("Ingrese una accion correctiva");
                return false;
            } 
            var accionPreventiva = $("#MainContent_txtAccionCorrectiva").val();
            if ($.trim(accionPreventiva) == "") {
                alert("Ingrese una accion preventiva");
                return false;
            }

            var fcompromiso = $("#MainContent_txtFechaCompromiso").val();

            if (isDate(fcompromiso) == false) {
                alert("Ingrese una fecha de compromiso correcto");
                return false;
            }

            window.setTimeout(function () { DoFormCallBack("GrabarHallazgo", null, End_fSaveData); }, 1000)
        }
        
        //*****************************************************************************
        
        function End_fSaveData(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                window.location.href = "ListaActSeguimientoHallazgo.aspx";
            }
        }

        //*****************************************************************************

    </script>
    <asp:HiddenField id="__IdHallazgo" runat="server"/>
    
    <div style="margin:0px 0px 0px;padding:0px 0px 0px 0px"><a href="#" style="color:black">Auditoría</a> / <a href="#" style="color:black">Actualizar Seguimiento de Hallazgo</a></div>
    <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">
        ESTABLECER PLAN DE ACCION - HALLAZGOS</div>
        
    <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
    <div style="float:left;font-weight:bold;">
        <label style="width:140px;">Proceso o Proyecto:</label><asp:Label ID="lblDescrip" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>
        <label style="width:140px;" >Area: </label><asp:Label ID="lblArea" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>
        <label style="width:140px;">Jefe de Proceso: </label><asp:Label ID="lblResponsable" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>           
    </div>
    <div style="float:right;text-align:right;font-weight:bold;">
    <label style="">Nro:<asp:Label ID="lblAuditoria" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></label></br>      
    </div>
    </div>



     <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
    <div style="float:left;font-weight:bold;">
        <label style="width:140px;">Hallazgo:</label><asp:Label ID="lblDescripcion" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></br>
        <label style="width:140px;" >Estado:</label><asp:Label ID="lblEstado" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>
        <label style="width:140px;">Tipo:</label><asp:Label ID="lblTipo" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></br>           
    </div>
    <div style="float:right;text-align:right;font-weight:bold;">
    <label style="">Nro:<asp:Label ID="lblIdHallazgo" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></label></br>      
    </div>
    </div>

    <div style="padding:0px 10px 0px 10px;font-family:Arial;margin:10px 20px 10px 20px;">
        <div style="float:left;font-weight:bold;width:100%;height:130px;">
             <p>
             <label>Accion Correctiva:</label>
             <asp:TextBox ID="txtAccionCorrectiva" runat="server" TextMode="MultiLine" Height="50" Width="500"/>
             </p>
             <p>
             <label>Accion Preventiva:</label>
             <asp:TextBox ID="txtAccionPreventiva" runat="server" TextMode="MultiLine" Height="50" Width="500"/>
             </p>
             <label>Fecha Compromiso:</label>
             <asp:TextBox ID="txtFechaCompromiso" runat="server" Width="100" ReadOnly="true" CssClass="datepicker"/>
        </div>
    </div>
 
    <div style="padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
          <div style="margin:10px 30px 10px 30px;height:100%;float:right;">
            <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fGrabar();" class="TButton"/>
            <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();" class="TButton"/>
        </div>
    </div>
    
</asp:Content>

