<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizarSeguimientoHallazgo.aspx.cs" Inherits="TMD.ACP.Site.Vistas.ACP.ActualizarSeguimientoHallazgo" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

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
            window.location.href = "ListaActSeguimientoHallazgo.aspx";
        }

        //********************************************************************
        function fGrabar() {         
            var comentarios = $("#MainContent_txtComentarios").val();
            if ($.trim(comentarios) == "") {
                alert("Comentario es obligatorio");          
            } else {
                window.setTimeout(function () { DoFormCallBack("GrabarHallazgo", null, End_fSaveData); }, 1000)
            }
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
    <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">ACTUALIZAR SEGUIMIENTO DE HALLAZGO</div>
        
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
            <label>Estado:</label>
             <asp:DropDownList ID="ddlEstado" runat="server" Width="130">
                <asp:ListItem Value ="COMPLETO">COMPLETO</asp:ListItem>                               
            </asp:DropDownList>   
         </p>
         
         <label>Comentarios:</label>
         <asp:TextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Height="50" Width="500"/>
         </div>
    </div>
 
    <div style="padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
          <div style="margin:10px 30px 10px 30px;height:100%;float:right;">
            <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fGrabar();" class="TButton"/>
            <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();" class="TButton"/>
        </div>
    </div>
    
</asp:Content>

