<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="ActResultadoFinalAuditoria.aspx.cs" Inherits="TMD.ACP.Site.Vistas.ACP.ActResultadoFinalAuditoria" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
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
            if ($("#MainContent___IsView").val() == "1") {
                $("#btnGrabar").hide();
            }
        });

        //*****************************************************************************

        function fCancelar() {
            window.location.href = "ResultadoFinalAuditoria.aspx";
        }

        //********************************************************************
        function fGrabar() {           
            var resultados = $("#MainContent_txtResultados").val();
            var conclusiones = $("#MainContent_txtConclusiones").val();
            var recomendaciones = $("#MainContent_txtRecomendaciones").val();
            bValida = false;
            if ($.trim(resultados) == "") {
                alert("Ingrese resultados para el informe final de auditoría");
                $("#MainContent_txtResultados").focus();
                bValida = true;
            } else if ($.trim(conclusiones) == "") {
                alert("Ingrese las conclusiones para el informe final de auditoría");
                $("#MainContent_txtConclusiones").focus();
                bValida = true;
            } else if ($.trim(recomendaciones) == "") {
                alert("Ingrese las recomendaciones para el informe final de auditoría");
                $("#MainContent_txtRecomendaciones").focus();
                bValida = true;
            } 

            if (bValida == false) {
                window.setTimeout(function () { DoFormCallBack("GrabarInformeFinal", null, End_fSaveData); }, 1000)
            } 
        }        
        //*****************************************************************************
        
        function End_fSaveData(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                alert("Se grabaron los datos satisfactoriamente.");
                window.location.href = "ResultadoFinalAuditoria.aspx";
            } else {
                alert(mData[1]);
            }
        }


    </script>
    <asp:HiddenField id="__IdAuditoria" runat="server"/>
    <asp:HiddenField id="__IsView" runat="server" Value="0"/>
    
    <div style="margin:0px 0px 0px;padding:0px 0px 0px 0px"><a href="#" style="color:black">Auditoría</a> / <a href="#" style="color:black">Actualizar resultados final de auditoría</a></div>
    <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">INFORME FINAL DE AUDITORÍA</div>
        
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

    <div style="padding:0px 10px 0px 10px;font-family:Arial;margin:5px 20px 5px 20px;">
     <div style="float:left;font-weight:bold;width:100%;height:280px;">    
         <p style="display:none">
             <label style="padding-right:20px">Duración:</label>             
             <asp:TextBox ID="txtDuracion" runat="server" Width="120"/>
         </p>         
         <p style="width:200px;">
             <label style="width:80px">Resultados de Auditoría:</label>            
         </p>
         <p>
            <asp:TextBox ID="txtResultados" runat="server" TextMode="MultiLine" Height="30" Width="100%"/>
         </p>

         <p style="width:150px;">
             <label style="width:80px">Conclusiones:</label>            
         </p>
         <p>
          <asp:TextBox ID="txtConclusiones" runat="server" TextMode="MultiLine" Height="30" Width="100%"/>
         </p>
          <p style="width:150px;">
             <label style="width:80px">Recomendaciones:</label>             
         </p>
         <p>
         <asp:TextBox ID="txtRecomendaciones" runat="server" TextMode="MultiLine" Height="30" Width="100%"/>
         </p>
         </div>
    </div>
 
    <div style="padding:0px 10px 0px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
          <div style="margin:10px 30px 10px 30px;height:100%;float:right;">
            <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fGrabar();" class="TButton"/>
            <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();" class="TButton"/>
        </div>
    </div>
    
</asp:Content>

