<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarAuditoria.aspx.cs" Inherits="TMD.ACP.Site.RegistrarAuditoria" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

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
            //Obtener datos de la auditoria a editar
            $("#txtAuditoria").val(window.parent.parent.document.getElementById("MainContent___tempNroAuditoria").value);
            $("#__tempIdEntidadAuditada").val(window.parent.parent.document.getElementById("MainContent___tempIdEntAudi").value);
            $("#txtEntAudi").val(window.parent.parent.document.getElementById("MainContent___tempEntAudi").value);
            $("#txtArea").val(window.parent.parent.document.getElementById("MainContent___tempArea").value);
            $("#__tempIdArea").val(window.parent.parent.document.getElementById("MainContent___tempIdArea").value);
            //Si es editar debo cargar los responsables por area
            if ($("#__tempIdEntidadAuditada").val() != "") {
                window.setTimeout(function () { DoCallBack("RefrescarDatosEntidadAuditada", $("#__tempIdEntidadAuditada").val(), End_fRefrescarEntidadAuditada); }, 1000);
            }
            var idResponsable = window.parent.parent.document.getElementById("MainContent___tempIdResponsable").value;
            $("#ddlResponsable> option[value='" + idResponsable + "']").attr('selected', 'selected');
            $("#txtAlcance").val(window.parent.parent.document.getElementById("MainContent___tempAlcance").value);
            $("#txtObjetivo").val(window.parent.parent.document.getElementById("MainContent___tempObjetivo").value);
            $("#txtFechaInicio").val(window.parent.parent.document.getElementById("MainContent___tempFechaInicio").value);
            $("#txtFechaFin").val(window.parent.parent.document.getElementById("MainContent___tempFechaFin").value);
            //Actualizar datos de la entidad auditada
            window.arrRefFunctions["entidadauditada.refresh"] = fRefrescarEntidadAuditada;
        });

        //*****************************************************************************
        //Actualizar grid de auditoria en caso se haya ingresado o modificado una
        //*****************************************************************************

        function fSaveData() {
            //Validar datos de auditoria
            if ($("#txtEntAudi").val() == '') {
                alert('Seleccionar un proceso o proyecto a auditar');
                return;
            }
            if ($("#ddlResponsable").val() == '-1') {
                alert('Seleccionar responsable a auditar');
                return;
            }
            if ($("#txtAlcance").val() == '') {
                alert('Ingresar alcance');
                return;
            }
            if ($("#txtObjetivo").val() == '') {
                alert('Ingresar objetivo');
                return;
            }

            if ($("#txtFechaInicio").val() == '') {
                alert('Ingresar fecha de inicio');
                return;
            }
            if ($("#txtFechaFin").val() == '') {
                alert('Ingresar fecha fin');
                return;
            }
            if (!isDate($("#txtFechaInicio").val())) {
                alert('Ingresar fecha de inicio correcta');
                return;
            }
            if (!isDate($("#txtFechaFin").val())) {
                alert('Ingresar fecha fin correcta');
                return;
            }
            var d1 = $("#txtFechaInicio").val().split("/");
            var dat1 = new Date(d1[2], parseFloat(d1[1]) - 1, parseFloat(d1[0]));
            var d2 = $("#txtFechaFin").val().split("/");
            var dat2 = new Date(d2[2], parseFloat(d2[1]) - 1, parseFloat(d2[0]));
            if (dat1 >= dat2) {
                alert('Colocar un rango de fechas correcto');
                return;
            }
            if (CalculateDateDiff($("#txtFechaInicio").val(), $("#txtFechaFin").val()) > 3) {
                alert('La auditoria no puede durar mas de 3 meses');
                return;
            }
            if (CalculateDateDiff($("#txtFechaInicio").val(), $("#txtFechaFin").val()) < 1) {
                alert('La auditoria no puede durar menos de 1 mes');
                return;
            }

            window.setTimeout(function () { DoFormCallBack("ValidarAuditoria", null, End_fSaveData); }, 1000)         
        }

        function End_fSaveData(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                if (mData[1] != "") {
                    alert(mData[1]);
                    return;
                }
                //Devolver datos de la auditoria
                window.parent.parent.document.getElementById("MainContent___tempNroAuditoria").value = $("#txtAuditoria").val();
                window.parent.parent.document.getElementById("MainContent___tempIdEntAudi").value = $("#__tempIdEntidadAuditada").val();
                window.parent.parent.document.getElementById("MainContent___tempEntAudi").value = $("#txtEntAudi").val();
                window.parent.parent.document.getElementById("MainContent___tempArea").value = $("#txtArea").val();
                window.parent.parent.document.getElementById("MainContent___tempIdArea").value = $("#__tempIdArea").val();
                window.parent.parent.document.getElementById("MainContent___tempIdResponsable").value = $("#ddlResponsable").val();
                window.parent.parent.document.getElementById("MainContent___tempResponsable").value = $("#ddlResponsable option:selected").text();
                window.parent.parent.document.getElementById("MainContent___tempAlcance").value = $("#txtAlcance").val();
                window.parent.parent.document.getElementById("MainContent___tempObjetivo").value = $("#txtObjetivo").val();
                window.parent.parent.document.getElementById("MainContent___tempFechaInicio").value = $("#txtFechaInicio").val();
                window.parent.parent.document.getElementById("MainContent___tempFechaFin").value = $("#txtFechaFin").val();
                //Actualizar grid de auditorias
                try { parent.arrRefFunctions["auditoria.refresh"](); } catch (e) { }
                window.parent.CloseMultiPopup("keyRegistrarAuditoria");
            }
            else {
                alert(mData[1]);
            }
        }

        //*****************************************************************************
        //Cerrar popup, limpiar hidden
        //*****************************************************************************

        function fClosePopup() {
            try { parent.arrRefFunctions["auditoria.refresh"](); } catch (e) { }
            window.parent.CloseMultiPopup("keyRegistrarAuditoria");
        }

        //*****************************************************************************
        //Abrir popup de matriz de procesos y proyectos
        //*****************************************************************************

        function fBuscarEntidadAuditada() {
           var title = 'MATRIZ DE PROCESO/PROYECTO';
           var id =  $("#__tempIdEntidadAuditada").val();
           window.OpenMultiPopup('ConsultarEntidadAuditada.aspx?id=' + id, title, 700, 400, true, null, null, "keyConsultarEntidadAuditada", "clone", true, false);
        }

        //*****************************************************************************
        //Refrescar datos de la entidad auditada
        //*****************************************************************************

        function fRefrescarEntidadAuditada(id) {
            window.setTimeout(function () { DoCallBack("RefrescarDatosEntidadAuditada", id, End_fRefrescarEntidadAuditada); }, 1000)
        }

        function End_fRefrescarEntidadAuditada(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#__tempIdEntidadAuditada").val(mData[1]);
                $("#__tempIdArea").val(mData[2]);
                $("#txtEntAudi").val(mData[3]);
                $("#txtArea").val(mData[4]);
                $("#tdComboBox").html(mData[5]);
                var idResponsable = window.parent.parent.document.getElementById("MainContent___tempIdResponsable").value;
                $("#ddlResponsable> option[value='" + idResponsable + "']").attr('selected', 'selected');
            }
            else {
                alert(mData[1]);
            }
        }

   </script>

</head>

<body>

    <form id="form1" runat="server">    
    <div style="margin:0px 10px 0px 10px;">
   
        <asp:HiddenField id="__tempIdEntidadAuditada" runat="server"/>    
        <asp:HiddenField id="__tempIdArea" runat="server"/>    

        <table>
            <tr>     
                <td>
                    <asp:Label ID="lblAuditoria" runat="server" Text='Nro. Auditoría' Width="100"/>
                </td>       
                <td>
                    <asp:TextBox ID="txtAuditoria" runat="server" ReadOnly="true" Width="30"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEntAudi" runat="server" Text='Proceso/Proyecto' Width="200"/>
                </td>  
                <td>
                    <asp:TextBox ID="txtEntAudi" runat="server" Width="200" ReadOnly="true"/>
                    <input type="button" id="btnEntidadAuditada" value="Buscar" onclick="javascript:fBuscarEntidadAuditada();"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblArea" runat="server" Text='Area' Width="100"/>
                </td>  
                <td>
                    <asp:TextBox ID="txtArea" runat="server" Width="100" ReadOnly="true"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblResponsable" runat="server" Text='Responsable' Width="250"/>
                </td>  
                <td id="tdComboBox">
                    <asp:DropDownList ID="ddlResponsable" runat="server" Width="250"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAlcance" runat="server" Text='Alcance' Width="200"/>
                </td>  
                <td>
                    <asp:TextBox ID="txtAlcance" runat="server" Width="200" Height="50"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblObjetivo" runat="server" Text='Objetivo' Width="200"/>
                </td>  
                <td>
                    <asp:TextBox ID="txtObjetivo" runat="server" Width="200" Height="50"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFechaInicio" runat="server" Text='Fecha Inicio' Width="200"/>
                </td>  
                <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="100" CssClass="datepicker"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFechaFin" runat="server" Text='Fecha Fin' Width="200"/>
                </td>  
                <td>
                    <asp:TextBox ID="txtFechaFin" runat="server" Width="100" CssClass="datepicker"/>      
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
