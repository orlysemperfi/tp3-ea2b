<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarSeguimiento.aspx.cs" Inherits="TMD.ACP.Site.Vistas.ACP.AsignarSeguimiento" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    <link rel="stylesheet" href="css/jquery-ui.css" />       
    <link rel="stylesheet" type="text/css" href="js/facebox/facebox.css" />
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
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
        //Obtener valores al cargar formulario
        //*****************************************************************************

        $(document).ready(function () {
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });            
        });

        //*****************************************************************************
        //Actualizar grid de auditoria en caso se haya ingresado o modificado una
        //*****************************************************************************

        function fSaveData() {
            var fechaCompromiso = $("#tdFechaCompromiso").html();
            fechaCompromiso = $.trim(fechaCompromiso);            
            var fechaSeguimiento = $("#txtFechaSeguimiento").val();
            if ($.trim(fechaSeguimiento) == ""){
                alert("La fecha de seguimiento es obligatoria");
            } else if (compare_dates(fechaCompromiso, fechaSeguimiento)){
                alert("La fecha de seguimiento no puede ser menor a la fecha de compromiso");
            } else {                  
                window.setTimeout(function () { DoFormCallBack("GrabarHallazgo", null, End_fSaveData); }, 1000)
            }


        }

        //*****************************************************************************
        //Actualizar grid de auditoria en caso se haya ingresado o modificado una
        //*****************************************************************************
        function End_fSaveData(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                if (mData[1] != "") {
                    alert(mData[1]);
                    return;
                }           
                var idAuditoria = $("#__IdAuditoria").val();                
                try { parent.arrRefFunctions["asignarseguimiento.refresh"](idAuditoria); } catch (e) { }
                window.parent.CloseMultiPopup("keyAsignarSeguimientoHallazgo");
            }
        }

   </script>

</head>

<body>

    <form id="form1" runat="server">    
    <asp:HiddenField id="__IdHallazgo" runat="server"/>
    <asp:HiddenField id="__IdAuditoria" runat="server"/>
    <div style="margin:0px 10px 0px 10px;">
 
        <table>
            <tr>     
                <td>
                    <asp:Label ID="lblDescripcionHallazgo" runat="server" Text='Hallazgo' Width="120"/>
                </td>       
                <td>                    
                    <asp:Literal ID="litDescripcionHallazgo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo" Width="120"/>
                </td>  
                <td>
                   <asp:Literal ID="litTipo" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFechaCompromiso" runat="server" Text='Fec. Compromiso' Width="120"/>
                </td>  
                <td id="tdFechaCompromiso">
                     <asp:Literal ID="litFechaCompromiso" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFechaSeguimiento" runat="server" Text='Fec. Seguimiento' Width="120"/>
                </td>  
                <td>                    
                    <asp:TextBox ID="txtFechaSeguimiento" runat="server" Width="100" ReadOnly="true" CssClass="datepicker"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblResponsable" runat="server" Text='Responsable' Width="120"/>
                </td>  
                <td>
                    <asp:DropDownList ID="ddlResponsable" runat="server" Width="200"></asp:DropDownList>
                </td>
            </tr>                             
        </table>
    </div>
    </form>
</body>

</html>
