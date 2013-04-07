<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="ActualizarPlanAuditoria.aspx.cs" Inherits="TMD.CF.Site.Vistas.ACP._ActualizarPlanAuditoria" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
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

    var newRow;
    var arrRefFunctions = new Array();
    var mMode = 0;

    //*****************************************************************************
    
    $(function () {
        $("#tabs").tabs();
    });

    //*****************************************************************************

    $(document).ready(function () {
        //window.arrRefFunctions["auditor.refresh"] = fListarAuditores;
        window.arrRefFunctions["auditor.refresh"] = fAgregarEquipoAuditor;
        $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });

        //Si es modo view deshabilita los controles
        if ($("#MainContent___IsView").val() == "1") {

            $("#btnEmitir").show();
            $("#btnGrabar").hide();
            $("#btnAsignar").hide();
            $("#btnAsignarAuditor").attr("disabled", "disabled");
            $("#trNewRow").hide();

            $(".cLnkDeleteAuditor").hide();
            $(".cLnkEditActividad").hide();
            $(".cLnkDeleteActividad").hide();
            $(".cLnkSaveActividad").hide();
            $(".cLnkCancelActividad").hide();

            Replace(2);
            $(".lnkReemplazar").hide();  
            $("#trBtnUpload").hide(); 
        }
    });

    //*****************************************************************************

    function fCancelar() {
        window.location.href = "ListaPlanAuditoria.aspx";
    }

    //*****************************************************************************

    function fEmitirInforme() {
        var title = 'REPORTE DE PLAN AUDITORIA';
        var id = $("#MainContent___IdAuditoria").val();        
        window.OpenMultiPopup('Reportes/RptPlanAuditoriaView.aspx?idAuditoria=' + id, title, 900, 480, true, null, null, "keyEmitirReporte", "clone", true, false, false);
    }

    //*****************************************************************************
//    function fAsignarAuditores() {
//        var title = 'ASIGNAR EQUIPO AUDITOR';
//        window.OpenMultiPopup('ConsultarAuditor.aspx', title, 700, 380, true, null, null, "keyConsultarAuditor", "clone", true, false);
//    }

    //*****************************************************************************
    function fAsignarAuditores() {
        window.setTimeout(function () { DoCallBack("ObtenerAuditoresIds", "", End_fAsignarAuditores); }, 1000)
    }
    //*****************************************************************************
    function End_fAsignarAuditores(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            var title = 'ASIGNAR EQUIPO AUDITOR';            
            window.OpenMultiPopup('ConsultarAuditor.aspx?ids=' + mData[1], title, 700, 380, true, null, null, "keyConsultarAuditor", "clone", true, false);
        }
    }
    //*****************************************************************************
    function fAgregarEquipoAuditor(ids) {
        window.setTimeout(function () { DoCallBack("AgregarAuditores", ids, End_fAgregarEquipoAuditor); }, 1000)
    }
    //*****************************************************************************
    function End_fAgregarEquipoAuditor(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            $("#divEquipoAuditor").html(mData[1]);
            fListarActividadesAuditoria();
        }
    }
    //*****************************************************************************
    function fQuitarAuditor(idAuditor) {   
        if (window.confirm("Esta seguro de eliminar el auditor?")) {
            window.setTimeout(function () { DoCallBack("QuitarAuditor", idAuditor, End_fQuitarAuditor); }, 1000)
        }
    }
    //*****************************************************************************
    function End_fQuitarAuditor(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            if (mData[3] == "") {
                $("#divEquipoAuditor").html(mData[1]);
                fListarActividadesAuditoria();
            }
            else {
                alert(mData[3]);
            }
        }
    }
    //*****************************************************************************
    function fListarActividadesAuditoria() {
        window.setTimeout(function () { DoCallBack("CargarActividadesAuditoria", "", End_fListarActividadesAuditoria); }, 1000)
    }    
    //*****************************************************************************    
    function End_fListarActividadesAuditoria(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            $("#divActividadesAuditoria").html(mData[1]);
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });      
        }
    }
    //*****************************************************************************
    function fAgregarActividadAuditoria() {                        
        
        var idActividad = $("#MainContent_rptActividadesAuditoria_txtNuevoActividad").val();
        var responsable = $("#MainContent_rptActividadesAuditoria_ddlNuevoAuditor").val();
        var descripcion = $("#MainContent_rptActividadesAuditoria_txtNuevoDescripcionActividad").val();        
        var lugar = $("#MainContent_rptActividadesAuditoria_txtNuevoLugar").val();
        var fechaInicio = $("#MainContent_rptActividadesAuditoria_txtNuevoFechaInicio").val();
        var fechaFin = $("#MainContent_rptActividadesAuditoria_txtNuevoFechaFin").val();
        
              if ($.trim(responsable) == "") {
            alert("El responsable de la actividad es obligatoria");           
        }
        else 
        if ($.trim(descripcion) == "") {
            alert("La descrición de la actividad es obligatoria");            
        }
        else
        if ($.trim(lugar) == "") {
            alert("El lugar de la actividad es obligatoria");            
        }
        else
        if ($.trim(fechaInicio) == "") {
            alert("La fecha Inicio es obligatoria");            
        }
        else
        if ($.trim(fechaFin) == "") {
            alert("La fecha Fin es obligatoria");
        }
        else
        if (compare_dates(fechaInicio, fechaFin)) {
           alert("fechaInicio es mayor a fechaFin");
        }
        else{

            $("#MainContent___TmpIdActividad").val(idActividad);
            $("#MainContent___TmpResponsable").val(responsable);
            $("#MainContent___TmpDescripcionActividad").val(descripcion);
            $("#MainContent___TmpLugar").val(lugar);
            $("#MainContent___TmpFechaInicio").val(fechaInicio);
            $("#MainContent___TmpFechaFin").val(fechaFin);
       
            window.setTimeout(function () { DoFormCallBack("AgregarActividadAuditoria", null, End_fAgregarActividadAuditoria); }, 500)
        }
    }
    //*****************************************************************************    
    function End_fAgregarActividadAuditoria(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            if (mData[2] == "") {
                $("#divActividadesAuditoria").html(mData[1]);
                $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
            }
            else {
                alert(mData[2]);
            }
        }
    }

     //*****************************************************************************
    function fEditarActividadAuditoria(id){
        $("#ModoEdicion" + id).show();
        $("#ModeVista" + id).hide();
    }
    //***************************************************************************** 
    function fGrabarActividadAuditoria(id) {        
        
        var responsable = ""
        
        $("#ModoEdicion" + id + " :input").each(function () {
            //alert($(this).attr("id"));alert($(this).val());                        
            if ($(this).attr("id").indexOf('MainContent_rptActividadesAuditoria_ddlAuditor_') >= 0) responsable = $(this).val();            
        });
       
        var idActividad = $('#ModoEdicion' + id + ' input[id*="MainContent_rptActividadesAuditoria_txtActividad_"]').val();        
        var descripcion = $('#ModoEdicion' + id + ' input[id*="MainContent_rptActividadesAuditoria_txtDescripcionActividad_"]').val();
        var lugar = $('#ModoEdicion' + id + ' input[id*="MainContent_rptActividadesAuditoria_txtLugar_"]').val();
        var fechaInicio = $('#ModoEdicion' + id + ' input[id*="MainContent_rptActividadesAuditoria_txtFechaInicio_"]').val();
        var fechaFin = $('#ModoEdicion' + id + ' input[id*="MainContent_rptActividadesAuditoria_txtFechaFin_"]').val();

        if ($.trim(responsable) == "") {
            alert("El responsable de la actividad es obligatoria");           
        }
        else 
        if ($.trim(descripcion) == "") {
            alert("La descrición de la actividad es obligatoria");            
        }
        else
        if ($.trim(lugar) == "") {
            alert("El lugar de la actividad es obligatoria");            
        }
        else
        if ($.trim(fechaInicio) == "") {
            alert("La fecha Inicio es obligatoria");            
        }
        else
        if ($.trim(fechaFin) == "") {
            alert("La fecha Fin es obligatoria");
        }
        else
        if (compare_dates(fechaInicio, fechaFin)) {
                alert("fechaInicio es mayor a fechaFin");
        }
        else{
            $("#MainContent___TmpIdActividad").val(idActividad);
            $("#MainContent___TmpResponsable").val(responsable);
            $("#MainContent___TmpDescripcionActividad").val(descripcion);
            $("#MainContent___TmpLugar").val(lugar);
            $("#MainContent___TmpFechaInicio").val(fechaInicio);
            $("#MainContent___TmpFechaFin").val(fechaFin);
        
            window.setTimeout(function () { DoFormCallBack("GrabarActividadAuditoria", null, End_fGrabarActividadAuditoria); }, 500)
        }
    }
    //*****************************************************************************    
    function End_fGrabarActividadAuditoria(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            $("#divActividadesAuditoria").html(mData[1]);
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
        }
    }    
    //***************************************************************************** 
    function fCancelarActividadAuditoria(id) {
        $("#ModeVista" + id).show();
        $("#ModoEdicion" + id).hide();
    }
    //***************************************************************************** 
    function fQuitarActividadAuditoria(id) {
        if (window.confirm("Esta seguro de eliminar la actividad?")) {            
            window.setTimeout(function () { DoCallBack("QuitarActividadAuditoria", id, End_fQuitarActividadAuditoria); }, 500)
        }        
    }
    //***************************************************************************** 
    function End_fQuitarActividadAuditoria(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            $("#divActividadesAuditoria").html(mData[1]);
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
        }
    }
    //***************************************************************************** 
    function fValidarPlanAuditoria() {
        window.setTimeout(function () { DoFormCallBack("ValidarPlanAuditoria", "", End_fValidarPlanAuditoria); }, 500)
    }
    //*****************************************************************************     
    function End_fValidarPlanAuditoria(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            mMode = 1;
            SaveFile(mMode);
        }
        if (mData[0] == "2") {
            alert("Debe registrar al menos un empleado");
        }
        if (mData[0] == "3") {
            alert("Debe registrar al menos una actividad");
        }
    }
    //***************************************************************************** 
    function fGrabarPlanAuditoria(){                                         
        if (window.confirm("Esta seguro de guardar el plan de auditoría?")) {
            window.setTimeout(function () { DoFormCallBack("GrabarPlanAuditoria", "", End_fGrabarPlanAuditoria); }, 500)
        }        
    }

    //***************************************************************************** 
    function fSaveAll() {
        window.setTimeout(function () { fSaveGeneral(); }, 500)
    }

    //***************************************************************************** 
    function fSaveGeneral() {
        fGrabarPlanAuditoria();
        //if (window.confirm("Esta seguro de guardar el plan de auditoría?")) {
        //  window.setTimeout(function () { DoFormCallBack("GrabarPlanAuditoria", "", End_fGrabarPlanAuditoria); }, 500)
        //}        
    }

    //***************************************************************************** 
    function End_fGrabarPlanAuditoria(arg) {
        var mData = arg.split(":::")
        if (mData[0] == "1") {
            $("#btnEmitir").show();
            $("#btnGrabar").hide();
            $("#btnAsignar").hide();
            $("#btnAsignarAuditor").attr("disabled", "disabled");
            $("#trNewRow").hide();
            $(".cLnkDeleteAuditor").hide();
            $(".cLnkEditActividad").hide();
            $(".cLnkDeleteActividad").hide();
            $(".cLnkSaveActividad").hide();
            $(".cLnkCancelActividad").hide();
            $(".lnkReemplazar").hide();            
            $("#trBtnUpload").hide();            
            alert("Se grabaron los datos satisfactoriamente");
            
        }
        if (mData[0] == "2") {
            alert("Debe registrar al menos un empleado");
        }
        if (mData[0] == "3") {
            alert("Debe registrar al menos una actividad");
        }
    }

    //***************************************************************************** 
    function fUpload() {
        document.getElementById("trBtnUpload").style.display = "none"
        SaveFile(2);              
    }
    //***************************************************************************** 
    function SaveFile(mode) {
        var iframe = document.getElementById("iUpload").contentWindow
        iframe.questionUpload("FileUpload", mode)
    }

    //********************************************************************
    function Replace(mode) {
        document.getElementById("tdUpload").style.display = (mode == 1) ? "" : "none"
        document.getElementById("tdShow").style.display = (mode == 1) ? "none" : ""
        document.getElementById("trBtnUpload").style.display = (mode == 1) ? "" : "none"
    }

    //********************************************************************
    function RefreshFile() {
        window.setTimeout(function () { RefreshFileUpload(); }, 200)
    }
    //********************************************************************
    function RefreshFileUpload() {           
        //DoFormCallBack("RefreshFileUpload", "", EndRefreshFileUpload)
    }
    //********************************************************************
    function EndRefreshFileUpload(arg) {
        var mData = arg.split(":::")
        document.getElementById("MainContent___Message").value = ""
        if (mData[0] == "1") {
            document.getElementById("MainContent___FileActual").value = mData[2]
            document.getElementById("MainContent_lblFile").innerHTML = mData[1]
            Replace(2);
        } else {
            document.getElementById("trBtnUpload").style.display = ""            
        }
    }
    //********************************************************************

    </script>
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


    <asp:TextBox ID="__FileName" style="display:none" runat="server"></asp:TextBox>
    <asp:TextBox ID="__File" style="display:none" runat="server"></asp:TextBox>
    <asp:TextBox ID="__Duration" style="display:none" runat="server"></asp:TextBox>
    <asp:TextBox ID="__Size" style="display:none" runat="server"></asp:TextBox>
    <asp:TextBox ID="__Message" style="display:none"  runat="server"></asp:TextBox>
    <asp:TextBox ID="__Extension" style="display:none" runat="server"></asp:TextBox>
    <asp:HiddenField ID="__FileOriginal" runat="server" />
    <asp:HiddenField ID="__FileActual" runat="server" />
    <asp:HiddenField ID="__FilePrev" runat="server" />
    
    
    
    <div style="margin:0px 0px 0px;padding:0px 0px 0px 0px"><a href="#" style="color:black">Auditoría</a> / <a href="#" style="color:black">Actualizar Plan de Auditoría</a></div>
    <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">PLAN DE AUDITORÍA</div>
        
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
    <div style="margin:10px 20px 0px 20px;height:100%;">
         <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Plan</a></li>
            <li><a href="#tabs-2">Cronograma</a></li>            
        </ul>
        <div id="tabs-1" style="height:350px;">
            <div class="divCampo">
             <span><asp:Literal ID="Literal1" runat="server" Text="Objetivo: "></asp:Literal></span><span><asp:TextBox ID="txtObjetivo" runat="server" TextMode="MultiLine" Width="400" Height="50" Enabled="false"></asp:TextBox></span>
             </div>
             <div class="divCampo">
             <span><asp:Literal ID="Literal2" runat="server" Text="Alcance: "></asp:Literal></span><span><asp:TextBox ID="txtAlcance" runat="server" TextMode="MultiLine" Width="400" Height="50" Enabled="false"></asp:TextBox></span>
             </div>
             <div class="divCampo">
             <span><asp:Literal ID="Literal3" runat="server" Text="Documento de Referencia: "></asp:Literal></span><span>
             <asp:FileUpload ID="fUpload" runat="server" Width="400" ViewStateMode="Inherit" EnableViewState="false" Visible="false"/>            
             





              <table cellpadding="0" cellspacing="0">
             <tr>
               <td id="tdUpload">
                <iframe id="iUpload" src="SaveAttachment.aspx" frameborder="0" width="400px;" height="50px;" scrolling="no"></iframe> 
               </td>
             </tr>
             <tr>
               <td id="tdShow" style="display: none">
                 <asp:Label ID="lblFile" Font-Bold="true" runat="server"></asp:Label>&nbsp;<asp:HyperLink
                   ID="lnkReplace" CssClass="lnkReemplazar" runat="server" NavigateUrl="javascript:Replace(1)"
                   Text="[Reemplazar]"></asp:HyperLink>
               </td>
               <td id="trBtnUpload" style="display: none" height="23px">
                <a href="javascript:Replace(2)" class="labelCancel">Cancel</a>
                </td>
             </tr>
             

           </table>
           


             </span>
             </div>
              <div style="float:left; width:100%;">
                <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:200px;margin:5px 0px 5px 0px;"><asp:Literal ID="Literal5" runat="server" Text="Equipo Auditor: "></asp:Literal></span>             
                <div id="divEquipoAuditor" style="float:left;">              
                <asp:Repeater ID="rptEquipoAuditor" runat="server" onitemdatabound="rptEquipoAuditor_ItemDataBound" > 
                <HeaderTemplate >     
                    <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;width:405px">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="ltNombres" runat="server" Text="Auditor"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="ltArea" runat="server" Text="Area"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:50px"><asp:Literal ID="ltOpciones" runat="server" Text="Opciones"></asp:Literal></td>                    
                    </tr>       
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="RowStyle" id="tr<%# Eval("codigo")%>">            
                        <td align="left"   style="width:120px"><asp:Label ID="lblNombres" runat="server"></asp:Label></td>
                        <td align="left"   style="width:80px"><asp:Label ID="lblArea" runat="server"></asp:Label></td>                                       
                        <td align="center" style="width:50px" ><a class="cLnkDeleteAuditor" href="javascript:fQuitarAuditor(<%# Eval("codigo")%>);" style="text-decoration:underline" class="cLnkQuitarAuditor">Quitar</a></td> 
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
                </asp:Repeater>
               </div>
                <div style="float:left;font-size:8pt;margin-left:4px;">   
                <input type="button" id="btnAsignar" value="Asignar" onclick="javascript:fAsignarAuditores();" class="TButton"/>
                </div>
              </div>
        </div>
        <div id="tabs-2" style="height:100%">
           <h1 style="text-align:center;font-size:14px;margin:0px 0px 10px 0px;font-weight:bold;">Cronograma de Auditoría</h1>                   
            <div id="divActividadesAuditoria">
                                   
                <asp:Repeater ID="rptActividadesAuditoria" runat="server" OnItemDataBound="rptActividadesAuditoria_ItemDataBound">
                <HeaderTemplate>
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
                <tr class="RowStyle" id="ModeVista<%# Eval("idActividad")%>">            
                <td align="center" style="width:30px">
                    <asp:Literal ID="litIdActividad" runat="server" Text='<%# Eval("idActividad") %>' />
                </td>
                <td align="left" style="width:120px">                               
                       <asp:Literal ID="litAuditor" runat="server"/>                      
                </td>
                <td align="left" style="width:130px">
                <asp:Literal ID="litDescripcionActividad" runat="server" Text='<%# Eval("descripcionActividad") %>' />                
                </td>
                <td align="left" style="width:80px">
                 <asp:Literal ID="litLugar" runat="server" Text='<%# Eval("lugar") %>' />                
                </td>
                <td align="left" style="width:80px">
                    <asp:Literal ID="litFechaInicio" runat="server" Text='<%# Eval("fechaInicio") %>' />                                    
                </td>
                <td align="left" style="width:80px">                
                <asp:Literal ID="litFechaFin" runat="server" Text='<%# Eval("fechaFin") %>' />                
                </td>
                <td align="center" style="width:60px">               
                <a id="lnkEditarActividad" class="cLnkEditActividad" href="javascript:fEditarActividadAuditoria(<%# Eval("idActividad")%>);">Editar</a>                
                </td>
                <td align="center" style="width:60px">
                <a id="lnkQuitarActividad" class="cLnkDeleteActividad" href="javascript:fQuitarActividadAuditoria(<%# Eval("idActividad")%>);">Quitar</a>                
                </td>   
                </tr>

                <tr class="RowStyle" id="ModoEdicion<%# Eval("idActividad")%>" style="display:none">  
                     <td align="center" style="width:30px">
                        <asp:TextBox ID="txtActividad" runat="server" Text='<%# Eval("idActividad") %>' ReadOnly="true" Width="30"/>
                     </td>   
                     <td align="left" style="width:120px">    
                        <asp:DropDownList ID="ddlAuditor" runat="server" Width="120"></asp:DropDownList>
                     </td> 
                     <td align="left" style="width:130px">                          
                        <asp:TextBox ID="txtDescripcionActividad" runat="server" Text='<%# Eval("descripcionActividad") %>' Width="130"/>
                     </td> 
                     <td align="left" style="width:80px">    
                        <asp:TextBox ID="txtLugar" runat="server" Text='<%# Eval("lugar") %>' Width="80"/>
                     </td> 
                     <td align="left" style="width:80px">    
                        <asp:TextBox ID="txtFechaInicio" runat="server" Text='<%# Eval("fechaInicio") %>' Width="80" CssClass="datepicker"/>
                     </td> 
                     <td align="left" style="width:80px">    
                        <asp:TextBox ID="txtFechaFin" runat="server" Text='<%# Eval("fechaFin") %>' Width="80" CssClass="datepicker"/>                
                     </td> 
                     <td align="center" style="width:60px"> 
                        <a id="lnkGrabarActividad" class="cLnkSaveActividad" href="javascript:fGrabarActividadAuditoria(<%# Eval("idActividad")%>);">Grabar</a>
                     </td> 
                     <td align="center" style="width:60px">
                        <a id="lnkCancelarActividad" class="cLnkCancelActividad" href="javascript:fCancelarActividadAuditoria(<%# Eval("idActividad")%>);">Cancelar</a>                
                     </td>
                 </tr>

                </ItemTemplate>
                <FooterTemplate>             
                   <tr class="RowStyle" id="trNewRow">            
                    <td align="center" style="width:30px">
                    <asp:TextBox ID="txtNuevoActividad" runat="server" ReadOnly="true" Width="30"/>          
                    </td>
                    <td align="left" style="width:120px">
                    <asp:DropDownList ID="ddlNuevoAuditor" runat="server" Width="120"></asp:DropDownList>
                    </td>
                    <td align="left" style="width:130px">
                    <asp:TextBox ID="txtNuevoDescripcionActividad" runat="server" Width="130"/>                
                    </td>
                    <td align="left" style="width:80px">
                    <asp:TextBox ID="txtNuevoLugar" runat="server" Width="120"/> 
                    </td>
                    <td align="left" style="width:80px">                
                    <asp:TextBox ID="txtNuevoFechaInicio" runat="server" Width="80" ReadOnly="true" CssClass="datepicker"/>
                    </td>
                    <td align="left" style="width:80px">
                        <asp:TextBox ID="txtNuevoFechaFin" runat="server" Width="80" ReadOnly="true" CssClass="datepicker"/>                
                    </td>
                    <td align="center" style="width:60px">                
                    <a id="lnkAddActividad" href="javascript:fAgregarActividadAuditoria();">Agregar</a>
                    </td>
                    <td align="center" style="width:60px"></td>
                    </tr>
                </table>
                </FooterTemplate>
                </asp:Repeater>                             
           </div>
        </div>        
        </div>
    </div>
    <div style="margin:10px 30px 10px 30px;height:100%;float:right;">
        <input type="button" id="btnEmitir" style="display:none" value="Emitir Informe" onclick="javascript:fEmitirInforme();" class="TButton"/>
        <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fValidarPlanAuditoria();" class="TButton"/>
        <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();" class="TButton"/>
    </div>
    
</asp:Content>
