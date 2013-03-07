<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanAuditoria.aspx.cs" Inherits="TMD.ACP.Site.PlanAuditoria"
 EnableViewState="false" ValidateRequest="false" EnableEventValidation="false"

 %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
     <link rel="stylesheet" type="text/css" href="Styles/style.css" />
     <link rel="stylesheet" href="css/jquery-ui.css" />      
     <link rel="stylesheet" type="text/css" href="Styles/Site.css" />

     <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
     <script type="text/javascript" src="js/jquery-ui.js"></script>                    
     <script type="text/javascript" src="js/global.js"></script>
     <script type="text/javascript" src="js/utils.js"></script>
   
         
    <script type="text/javascript">
        
        var newRow;

        //*****************************************************************************
        $(function () {
            $("#tabs").tabs();
        });

        //*****************************************************************************               

        $(document).ready(function () {
            window.parent.arrRefFunctions["auditor.refresh"] = fListarAuditores;

            $("[id*='lnkEditActividad']").live('click', OnEditActividad);
            $("[id*='lnkQuitarActividad']").live('click', OnDeleteActividad);
            $("[id*='lnkAddActividad']").click(OnAddActividad);
            //$(".datepicker").datepicker();
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });

            //Si es modo view deshabilita los controles
            if ($("#__IsView").val()=="1"){
                $("#btnEmitir").show();
                $("#btnGrabar").hide();
                $("#trNewRow").hide();
                $(".cLnkEditActividad").hide();
                $(".cLnkQuitarActividad").hide();
                $(".cLnkQuitarAuditor").hide();
                $("#btnAsignarAuditor").attr("disabled", "disabled");
            }
        });        
        //*****************************************************************************
        function OnAddActividad() {
            // Get the row this button is within
            var tr = $("[id*='lnkAddActividad']").closest("tr");
            // Get the first and last name controls in this row
            var idActividad = tr.find("#newIdActividad");
            var responsable = tr.find("#newResponsable option:selected");            
            var descripcionActividad = tr.find("#newDescripcionActividad");
            var lugar = tr.find("#newLugar");
            var fechaInicio = tr.find("#newFechaInicio");
            var fechaFin = tr.find("#newFechaFin");
            
            if (responsable.val() == undefined) {
                alert("El responsable de la actividad es obligatoria");
                return false;
            }

            if (descripcionActividad.val().length < 1) {  
                alert("La descrición de la actividad es obligatoria");  
                return false;
            }

            if (lugar.val().length < 1) {
                alert("El lugar de la actividad es obligatoria");
                return false;
            }

            if (fechaInicio.val().length < 1) {
                alert("La fecha Inicio es obligatoria");
                return false;
            }

            if (fechaFin.val().length < 1) {
                alert("La fecha Fin es obligatoria");
                return false;
            }


            // Create a new row and update idActividad,responsable,descripcionActividad,lugar,fechaInicio,fechaFin elements
            // appropriately
            newRow = NewRow(tr);
                      
            newRow.find("span[id='idActividad']").text(idActividad.val());
            newRow.find("span[id='responsable']").text(responsable.text());
            newRow.find("span[id='descripcionActividad']").text(descripcionActividad.val());
            newRow.find("span[id='lugar']").text(lugar.val());
            newRow.find("span[id='fechaInicio']").text(fechaInicio.val());
            newRow.find("span[id='fechaFin']").text(fechaFin.val());

            AddActividad(idActividad.val(),responsable.val(), descripcionActividad.val(), lugar.val(), fechaInicio.val(), fechaFin.val())

            // Clear everything out to start again
            idActividad.val("");
            responsable.val("");
            descripcionActividad.val("");
            lugar.val("");
            fechaInicio.val("");
            fechaFin.val("");
        }

        //*****************************************************************************
        function AddActividad(idActividad, responsable, descripcionActividad, lugar, fechaInicio, fechaFin) {
            
            if (responsable == null) responsable = "";
            $("#__TmpIdActividad").val(idActividad);            
            $("#__TmpResponsable").val(responsable);
            $("#__TmpDescripcionActividad").val(descripcionActividad);
            $("#__TmpLugar").val(lugar);
            $("#__TmpFechaInicio").val(fechaInicio);
            $("#__TmpFechaFin").val(fechaFin);
   
            window.setTimeout(function () { DoFormCallBack("AddActividad", "", End_fAddActividad); }, 500)
        }

        //*****************************************************************************
        function End_fAddActividad(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {                
                var result = eval('(' + mData[1] + ')');
                newRow.attr("id",mData[1]);
                newRow = null;                
                var tr = $("[id*='lnkAddActividad']").closest("tr");
                tr.find("input[id='newIdActividad']").val(mData[2]);
                $("#__TotalActividades").val(mData[3]);             
            }
        }

        //*****************************************************************************
        function NewRow(tr) {
            // If only one sibling then create a new row
            // otherwise just clone an exisitng one
            if (tr.siblings().length != 1) {
                var clone = tr.prev().clone();
                tr.before(clone);
            }
            else {
                var newRow = "<tr id=''>" +
            "<td align='center' style='width:30px'><span id='idActividad'></span></td>" +
            "<td align='left' style='width:120px'><span id='responsable'></span></td>" +
            "<td align='left' style='width:200px'><span id='descripcionActividad'></span></td>" +
            "<td align='left' style='width:120px'><span id='lugar'></span></td>" +
            "<td align='left' style='width:100px'><span id='fechaInicio'></span></td>" +
            "<td align='left' style='width:100px'><span id='fechaFin'></span></td>" +
            "<td align='center' style='width:60px'><a class='cLnkEditActividad' id='lnkEditActividad' href='#'>Editar</a></td>" +
            "<td align='center' style='width:60px'><a class='cLnkQuitarActividad' id='lnkQuitarActividad' href='#'>Quitar</a></td>" +
        "</tr>";                
                tr.before(newRow);
            }

            return tr.prev();
        }

        //*****************************************************************************
        function OnEditActividad() {
            // Get the row this button is within
            var tr = $(this).closest("tr");
            // Get the first and last name controls in this row
            var responsable = tr.find("span[id='responsable']");
            var descripcionActividad = tr.find("span[id='descripcionActividad']");
            var lugar = tr.find("span[id='lugar']");
            var fechaInicio = tr.find("span[id='fechaInicio']");
            var fechaFin = tr.find("span[id='fechaFin']");

            // Insert an input element before the labels
            // and set the value to the label text
            // Then hide the label            
            
            responsable.before("<select id='responsableEdit' name='responsableEdit' style='width:120px;'>" + $("#newResponsable").html() + "'</select>").hide();
            $("#responsableEdit").find("option:contains(" + responsable.html() + ")").each(function () {
                if ($(this).text() == responsable.html()) {
                    $(this).attr("selected", "selected");
                }
            });
            descripcionActividad.before("<input id='descripcionActividadEdit' style='width:200px;' type='text' value='" + descripcionActividad.text() + "'/>").hide();
            lugar.before("<input id='lugarEdit' style='width:120px;' type='text' style='width:200px;' value='" + lugar.text() + "'/>").hide();
            fechaInicio.before("<input id='fechaInicioEdit' style='width:100px;' class='datepicker' type='text' value='" + fechaInicio.text() + "'/>").hide();
            fechaFin.before("<input id='fechaFinEdit' style='width:100px;' class='datepicker' type='text' value='" + fechaFin.text() + "'/>").hide();            
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
            // Hide the existing buttons and add a save button in there place
            //tr.find("[id*='lnkQuitarActividad']").hide();
            //tr.find("[id*='lnkEditActividad']").before("<img id='save' src='images/base_floppydisk_32.png' />").hide();
            //tr.find("[id*='save']").one('click', OnSaveActividad);
            tr.find("[id*='lnkEditActividad']").before("<a id='lnkGuardarActividad' href='#'>Guardar</a>").hide();
            tr.find("[id*='lnkGuardarActividad']").one('click', OnSaveActividad);
            tr.find("[id*='lnkQuitarActividad']").before("<a id='lnkCancelarActividad' href='#'>Cancelar</a>").hide();
            tr.find("[id*='lnkCancelarActividad']").one('click', OnCancelActividad);
            
        }

        //*****************************************************************************

        function OnSaveActividad() {
            // Get the row this button is within
            var tr = $(this).closest("tr");

            var responsableSelected = tr.find("#responsableEdit option:selected");
            var responsable = tr.find("[id='responsableEdit']");   
            var descripcionActividad = tr.find("[id='descripcionActividadEdit']");
            var lugar = tr.find("[id='lugarEdit']");
            var fechaInicio = tr.find("[id='fechaInicioEdit']");
            var fechaFin = tr.find("[id='fechaFinEdit']");

            if (responsable.val() == undefined) {
                alert("El responsable de la actividad es obligatoria");
                return false;
            }

            if (descripcionActividad.val().length < 1) {
                alert("La descrición de la actividad es obligatoria");
                return false;
            }

            if (lugar.val().length < 1) {
                alert("El lugar de la actividad es obligatoria");
                return false;
            }

            if (fechaInicio.val().length < 1) {
                alert("La fecha Inicio es obligatoria");
                return false;
            }

            if (fechaFin.val().length < 1) {
                alert("La fecha Fin es obligatoria");
                return false;
            }

            // Set the text of the labels from the input elements and show them
            tr.find("span[id='responsable']").text(responsableSelected.text()).show();
            tr.find("span[id='descripcionActividad']").text(descripcionActividad.val()).show();
            tr.find("span[id='lugar']").text(lugar.val()).show();
            tr.find("span[id='fechaInicio']").text(fechaInicio.val()).show();
            tr.find("span[id='fechaFin']").text(fechaFin.val()).show();

            

            // Remove the input elements
            responsable.remove();
            descripcionActividad.remove();
            lugar.remove();
            fechaInicio.remove();
            fechaFin.remove();

            // Show the buttons again and remove the save
            
            tr.find("[id*='lnkQuitarActividad']").show();
            tr.find("[id*='lnkEditActividad']").show();
            tr.find("[id*='lnkGuardarActividad']").remove();
            tr.find("[id*='lnkCancelarActividad']").remove();

            // update the contact on the server
            UpdateActividad(tr.attr("id"), responsable.val(), descripcionActividad.val(), lugar.val(), fechaInicio.val(), fechaFin.val())
        }
                
        //*****************************************************************************

        function OnCancelActividad() {            

            var tr = $(this).closest("tr");

            var responsableSelected = tr.find("#responsableEdit option:selected");
            var responsable = tr.find("[id='responsableEdit']");
            var descripcionActividad = tr.find("[id='descripcionActividadEdit']");
            var lugar = tr.find("[id='lugarEdit']");
            var fechaInicio = tr.find("[id='fechaInicioEdit']");
            var fechaFin = tr.find("[id='fechaFinEdit']");

            // Set the text of the labels from the input elements and show them
            tr.find("span[id='responsable']").text(responsableSelected.text()).show();
            tr.find("span[id='descripcionActividad']").text(descripcionActividad.val()).show();
            tr.find("span[id='lugar']").text(lugar.val()).show();
            tr.find("span[id='fechaInicio']").text(fechaInicio.val()).show();
            tr.find("span[id='fechaFin']").text(fechaFin.val()).show();

            // Remove the input elements
            responsable.remove();
            descripcionActividad.remove();
            lugar.remove();
            fechaInicio.remove();
            fechaFin.remove();

            // Show the buttons again and remove the save

            tr.find("[id*='lnkQuitarActividad']").show();
            tr.find("[id*='lnkEditActividad']").show();
            tr.find("[id*='lnkGuardarActividad']").remove();
            tr.find("[id*='lnkCancelarActividad']").remove();
            
        }

        //*****************************************************************************

        function UpdateActividad(idActividad, responsable, descripcionActividad, lugar, fechaInicio, fechaFin) {

            if (responsable == null) responsable = "";            
            $("#__TmpIdActividad").val(idActividad);
            $("#__TmpResponsable").val(responsable);
            $("#__TmpDescripcionActividad").val(descripcionActividad);
            $("#__TmpLugar").val(lugar);
            $("#__TmpFechaInicio").val(fechaInicio);
            $("#__TmpFechaFin").val(fechaFin);

            window.setTimeout(function () { DoFormCallBack("UpdateActividad", "", End_fUpdateActividad); }, 500)

        }

        //*****************************************************************************
        function End_fUpdateActividad(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#__TotalActividades").val(mData[1]); 
            }
        }
       
        //*****************************************************************************
        function OnDeleteActividad() {
            if(window.confirm("Esta seguro de eliminar la actividad?")){
                var tr = $(this).closest("tr");
                tr.remove();
                DeleteActividad(tr.attr("id"));
            }
        }

        //*****************************************************************************
        function DeleteActividad(idActividad) {
            $("#__TmpIdActividad").val(idActividad);            
            window.setTimeout(function () { DoFormCallBack("DeleteActividad", "", End_fDeleteActividad); }, 500)
        }

        //*****************************************************************************
        function End_fDeleteActividad(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#__TotalActividades").val(mData[1]);                
            }
        }

        //*****************************************************************************
        
        function fConsultarAuditor() {
            var title = 'ASIGNAR AUDITOR';
            window.parent.OpenMultiPopup('ConsultarAuditor.aspx', title, 700, 380, true, null, null, "keyConsultarAuditor", "clone", true,false);
        }
        
        //*****************************************************************************

        function fListarAuditores(ids) {            
            $("#__ListAuditoresIDs").val(ids);
            window.setTimeout(function () { DoCallBack("ListarAuditores", ids, End_fListarAuditores); }, 1000)
        }
        
        //*****************************************************************************
        
        function End_fListarAuditores(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divAuditores").html(mData[1]);
            }
            fCargarComboAuditor();
        }

        //*****************************************************************************

        function fEliminarAuditor(idAuditorEliminado) {
            if(window.confirm("Esta seguro de eliminar el auditor?")){
                $("#tr" + idAuditorEliminado).remove();
                var idsNuevos = "";
                var idseleccionados = $("#__ListAuditoresIDs").val();
                idseleccionados = idseleccionados.split(',');
                for (var num = 0; num < idseleccionados.length; num++) {
                    if (idseleccionados[num] != idAuditorEliminado) {
                        idsNuevos = (idsNuevos == "" ? idseleccionados[num] : idsNuevos + "," + idseleccionados[num]);
	                }
                }
                $("#__ListAuditoresIDs").val(idsNuevos);
                fCargarComboAuditor();
            }
        }

        //*****************************************************************************        
        
        function fCargarComboAuditor() {            
            var ids = $("#__ListAuditoresIDs").val();
            window.setTimeout(function () { DoCallBack("ListarComboAuditores", ids, End_fCargarComboAuditor); }, 1000)
        }

        //***************************************************************************** 
        
        function End_fCargarComboAuditor(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                var tr = $("[id*='lnkAddActividad']").closest("tr");                
                tr.find("td[id='tdNewCboResponsable']").html(mData[1]);
            }
        }
                
        //*****************************************************************************

        function fGrabar() {
            
            if ($("#__ListAuditoresIDs").val().length < 1) {
                alert("Seleccione al menos un auditor");
                return false;
            }

            if ($("#__TotalActividades").val() == "0") {
                alert("Ingrese al menos una actividad");
                return false;
            }            

            if(window.confirm("Esta seguro de guardar el plan de auditoría?")){             
                window.setTimeout(function () { DoFormCallBack("ActualizarPlanAuditoria", "", End_fGrabar); }, 500)
            }
        }
        
        //*****************************************************************************
        
        function End_fGrabar(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                alert("Se grabaron los datos satisfactoriamente");
                $("#btnEmitir").show();
                $("#btnGrabar").hide();
                $("#trNewRow").hide();
                $(".cLnkEditActividad").hide();
                $(".cLnkQuitarActividad").hide();
                $(".cLnkQuitarAuditor").hide();
                $("#btnAsignarAuditor").attr("disabled", "disabled");
            }
        }

        //*****************************************************************************
        
        function fCancelar() {
            window.location.href = "ListaPlanAuditoria.aspx";
        }

        function fEmitirInforme() {
            var title = 'REPORTE DE PLAN AUDITORIA';
            var id = $("#__IdAuditoria").val();
            
            window.parent.OpenMultiPopup('Reportes/RptPlanAuditoriaView.aspx?idAuditoria=' + id, title, 900, 480, true, null, null, "keyEmitirReporte", "clone", true, false,false);
        }


    </script>


</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField id="__ListAuditoresIDs" runat="server"/>
    <asp:HiddenField id="__TmpIdActividad" runat="server"/>
    <asp:HiddenField id="__TmpResponsable" runat="server"/>
    <asp:HiddenField id="__TmpDescripcionActividad" runat="server"/>
    <asp:HiddenField id="__TmpLugar" runat="server"/>
    <asp:HiddenField id="__TmpFechaInicio" runat="server"/>
    <asp:HiddenField id="__TmpFechaFin" runat="server"/>
    <asp:HiddenField id="__TotalActividades" runat="server" Value="0"/>
    <asp:HiddenField id="__IdAuditoria" runat="server"/>
    <asp:HiddenField id="__IsView" runat="server" Value="0"/>
    
    <div>       
         <h1 style="text-align:center">Hallazgos de Auditoria</h1>
        <div style="border:solid 1px black;padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
        <div style="float:left">
            <label>Proceso o Proyecto: </label><asp:Label ID="lblDescrip" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>
            <label>Area: </label><asp:Label ID="lblArea" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>
            <label>Jefe de Proceso: </label><asp:Label ID="lblResponsable" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label></br>           
        </div>
         <div style="float:right">
            Nro:<label style="font-weight:bold;"><asp:Label ID="lblAuditoria" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></label></br>      
         </div>
        </div>
        <div style="margin:10px 20px 0px 20px;height:100%;">
        <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Plan</a></li>
            <li><a href="#tabs-2">Cronograma</a></li>            
        </ul>
        <div id="tabs-1" style="height:300px;">
            <div class="divCampo">
             <span><asp:Literal ID="Literal1" runat="server" Text="Objetivo: "></asp:Literal></span><span><asp:TextBox ID="txtObjetivo" runat="server" TextMode="MultiLine" Width="400" Height="50" Enabled="false"></asp:TextBox></span>
             </div>
             <div class="divCampo">
             <span><asp:Literal ID="Literal2" runat="server" Text="Alcance: "></asp:Literal></span><span><asp:TextBox ID="txtAlcance" runat="server" TextMode="MultiLine" Width="400" Height="50" Enabled="false"></asp:TextBox></span>
             </div>
             <div class="divCampo">
             <span><asp:Literal ID="Literal3" runat="server" Text="Documento de Referencia: "></asp:Literal></span><span><asp:FileUpload ID="fUpload" runat="server" Width="400" ViewStateMode="Inherit" />             
             </span>
             </div>
             <div style="float:left; width:100%;">
             <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:200px;margin:5px 0px 5px 0px;"><asp:Literal ID="Literal4" runat="server" Text="Equipo Auditor: "></asp:Literal></span>             
             <div id="divAuditores" style="float:left;">              
                <asp:Repeater ID="rptEmpleados" runat="server" onitemdatabound="rptEmpleados_ItemDataBound" > 
                <HeaderTemplate >     
                    <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;width:405px">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="ltNombres" runat="server" Text="Auditor"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="ltArea" runat="server" Text="Area"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:50px"><asp:Literal ID="ltOpciones" runat="server" Text="Opciones"></asp:Literal></td>                    
                    </tr>       
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="RowStyle" id="tr<%# Eval("idEmpleado")%>">            
                        <td align="left"   style="width:120px"><asp:Label ID="lblNombres" runat="server"></asp:Label></td>
                        <td align="left"   style="width:80px"><asp:Label ID="lblArea" runat="server"></asp:Label></td>                                       
                        <td align="center" style="width:50px" ><a href="javascript:fEliminarAuditor(<%# Eval("idEmpleado")%>);" style="text-decoration:underline" class="cLnkQuitarAuditor">Quitar</a></td> 
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
                </asp:Repeater>
               </div>
                <div style="float:left;margin:2px 0px 0px 5px;font-size:12px;">              
                   <input type="button" id="btnAsignarAuditor" value="Asignar" onclick="javascript:fConsultarAuditor();"/>
                </div>
             </div>
        </div>
        <div id="tabs-2" style="height:100%">
           <h1 style="text-align:center;font-size:14px;margin:0px 0px 10px 0px;font-weight:bold;">Cronograma de Auditoría</h1>

             
            <asp:Repeater ID="rptActividades" runat="server"> 
            <HeaderTemplate >     
                <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;">
                <tr class="GridCab">                                      
                    <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="ltNro" runat="server" Text="Nro"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:40px"><asp:Literal ID="ltResponsable" runat="server" Text="Responsable"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:40px"><asp:Literal ID="ltActividad" runat="server" Text="Actividad"></asp:Literal></td>                    
                    <td align="center" style="border-color:#E9E9E9;width:40px"><asp:Literal ID="ltLugar" runat="server" Text="Lugar"></asp:Literal></td>                    
                    <td align="center" style="border-color:#E9E9E9;width:30px"><asp:Literal ID="ltFechaInicio" runat="server" Text="Fecha Inicio"></asp:Literal></td>                    
                    <td align="center" style="border-color:#E9E9E9;width:30px"><asp:Literal ID="ltFechaFin" runat="server" Text="Fecha Fin"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="ltEditar" runat="server" Text="Editar"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="ltQuitar" runat="server" Text="Quitar"></asp:Literal></td>
                </tr>       
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="RowStyle" id="<%# Eval("idActividad")%>">            
                <td align="center" style="width:30px"><span id="idActividad"><%# Eval("idActividad")%></span></td>
                <td align="left" style="width:120px"><span id="responsable"><%#ObtenerEmpleado(Eval("idAuditor").ToString())%></span></td>

                    

                <td align="left" style="width:200px"><span id="descripcionActividad"><%# Eval("descripcionActividad")%></span></td>
                <td align="left" style="width:120px"><span id="lugar"><%# Eval("lugar")%></span></td>
                <td align="left" style="width:100px"><span id="fechaInicio"><%# Eval("fechaInicio")%></span></td>
                <td align="left" style="width:100px"><span id="fechaFin"><%# Eval("fechaFin")%></span></td>
                <td align="center" style="width:60px"><a class="cLnkEditActividad" id="lnkEditActividad" href="#">Editar</a></td>
                <td align="center" style="width:60px"><a class="cLnkQuitarActividad" id="lnkQuitarActividad" href="#">Eliminar</a></td>                
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            <tr class="RowStyle" id="trNewRow">            
                <td align="center" style="width:30px"><input type="text" id="newIdActividad" style="width:30px;text-align:center" value="1" readonly="true"/></td>
                <td align="left" style="width:120px" id="tdNewCboResponsable"><select name="newResponsable" id="newResponsable" style="width:120px;"></select></td>
                <td align="left" style="width:200px"><input type="text" id="newDescripcionActividad" style="width:200px;"/></td>
                <td align="left" style="width:120px"><input type="text" id="newLugar" style="width:120px;"/></td>
                <td align="left" style="width:100px"><input type="text" class="datepicker" readonly id="newFechaInicio" style="width:100px;"/></td>
                <td align="left" style="width:100px"><input type="text" class="datepicker" readonly id="newFechaFin" style="width:100px;"/></td>
                <td align="center" style="width:60px"><a id="lnkAddActividad" href="#">Agregar</a></td>
                <td align="center" style="width:60px"></td>
                </tr>
            </table>
            </FooterTemplate>
            </asp:Repeater>

        </div>        
        </div>
        </div>
        <div style="margin:10px 20px 0px 20px;height:100%;float:right;">
            <input type="button" id="btnEmitir" style="display:none" value="Emitir Informe" onclick="javascript:fEmitirInforme();"/>
            <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fGrabar();"/>
            <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();"/>
        </div>
        
    
    </div>

    </form>
</body>
</html>
