$(document).ready(function () {

    $(".divLoading").hide();
    $(".divLoadingMensaje").hide();

    $(".divLoading").ajaxStart(function () {
        $(".divLoadingMensaje").show();
        $(this).show();
    })
    $(".divLoading").ajaxComplete(function () {
        $(".divLoadingMensaje").hide();
        $(this).hide();
    });
    $('#divActividad').dialog({ autoOpen: false, width: 750, height: 400 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divPlanNuevo').dialog({ autoOpen: false, width: 1000, height: 450 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divPlanEditar').dialog({ autoOpen: false, width: 1000, height: 450 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();  
    $('#divSolicitud').dialog({ autoOpen: false, width: 1000, height: 560 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divCalendario').dialog({ autoOpen: false, width: 750, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divEquipos').dialog({ autoOpen: false, width: 750, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#ModalMensajeError').dialog({ autoOpen: false, width: 548, height: 250 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
   

});

function PlanActividad_Nuevo(ParamUrl1, ParamCodigo) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pCodigo:ParamCodigo},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divActividad").html(data);
            //
            //            $("#spnModalidaEstudio_Permiso").text($("#spnModalidaEstudio").text());


            MostrarModalPlanDetalle();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function BuscarPlanesMant(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGrid").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function BuscarSolicitudes(ParamUrl1) {
    
    var dpIni = $("#dpFechaIni_Consulta").data("kendoDatePicker");
    var dpFin = $("#dpFechaFin_Consulta").data("kendoDatePicker");

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
        pNumSoli: $('#txtNumSolicitud_Consulta').val(),
            pFechaIni: kendo.toString(dpIni.value(), 'dd/MM/yyyy') ,
            pFechaFin: kendo.toString(dpFin.value(), 'dd/MM/yyyy'),
            pTipoSoli: $("#ddlTipoSolicitud_Consulta").val(),
            pDocuRefe: $("#txtNumDocuRefe_Consulta").val(),
            pEstaSoli: $("#ddlEstadoSolicitud_Consulta").val(),
            pCodiEqui: $("#txtCodigoEquipo_Consulta").val(),
            pPlanMant: $("#ddlPlanMante_Consulta").val()
            },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridSolicitudesConsulta").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function PlanMantNuevo(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divPlanNuevo").html(data);
            MostrarModalPlanNuevo();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function PlanMantEditar(ParamUrl1, ParamUrl2, ParamCodigo, ParamNombre, ParamEstado) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodigo: ParamCodigo, pNombre: ParamNombre, pEstado: ParamEstado },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divPlanEditar").html(data);
            MostrarModalPlanEditar();
            $.ajax({
                type: "POST",
                url: ParamUrl2,
                data: { pCodigo: ParamCodigo },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#pnlGridActividades").html(data);
                },
                error: function (req, status, error) {
                    alert("fail: " + req + " " + status + " " + error);
                },
                complete: function () {
                }
            });
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function PlanMantEliminar(ParamUrl1, ParamUrl2, ParamCodigo) {

    if (!confirm('¿Está seguro de eliminar el registro?')) {
        return;
    }

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodigo: ParamCodigo },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            BuscarPlanesMant(ParamUrl2)
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function PlanActividadEliminar(ParamUrl1, ParamUrl2, ParamGuid) {

    if (!confirm('¿Está seguro de eliminar la Actividad?')) {
        return;
    }
     $.ajax({
                type: "POST",
                url: ParamUrl1,
                data: {pGuidActividad : ParamGuid },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#pnlGridActividades").html(data);
                },
                error: function (req, status, error) {
                    alert("fail: " + req + " " + status + " " + error);
                },
                complete: function () {
                }
            });
}

function PlanActividadEditar(ParamUrl1, ParamGuid) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pGuidActividad : ParamGuid },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divActividad").html(data);
            MostrarModalActividadEditar();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function SolicitudNueva(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divSolicitud").html(data);
            MostrarModalSolicitud();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function SolicitudEditar(ParamUrl1, ParamUrl2, ParamNumSoli, ParamFechaSoli, ParamTipoSoli, ParamDocuRefe, ParamFechaIni, ParamFechaFin, ParamCodiEsta, ParamCodiEqui, ParamCodiPlan) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pNumSoli:ParamNumSoli, pFechaSoli:ParamFechaSoli, pTipoSoli:ParamTipoSoli, pDocuRefe:ParamDocuRefe, pFechaIni:ParamFechaIni, pFechaFin:ParamFechaFin,pEstado:ParamCodiEsta,pCodiEqui:ParamCodiEqui, pCodiPlan:ParamCodiPlan},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divSolicitud").html(data);
            MostrarModalSolicitud();

            $.ajax({
                type: "POST",
                url: ParamUrl2,
                data: { pNumSoli: ParamNumSoli },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#pnlGridActividades").html(data);
                },
                error: function (req, status, error) {
                    alert("fail: " + req + " " + status + " " + error);
                },
                complete: function () {
                }
            });
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function SolicitudActividadEditar(ParamUrl1, ParamGuid) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pGuidActividad: ParamGuid  },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divActividad").html(data);
            MostrarModalActividadEditar();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function SolicitudEliminar(ParamUrl1, ParamUrl2, ParamCodigo) {

    if (!confirm('¿Está seguro de eliminar el registro?')) {
        return;
    }

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodigo: ParamCodigo },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            BuscarSolicitudes(ParamUrl2)
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function SolicitudActividadNueva(ParamUrl1, ParamNumSoli) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pNumSoli: ParamNumSoli
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divActividad").html(data);
            MostrarModalActividadEditar();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function Plan_Aceptar_Click(ParamUrl1,ParamUrl2) {
    //Validaciones del cliente
    if($.trim($('#txtCodigo').val()) == '')
    {
        alert('Debe ingresar el código del plan');
        $('#txtCodigo').focus();
        return;
    }
    if($.trim($('#txtNombre').val()) == '')
    {
        alert('Debe ingresar el Nombre del plan');
        $('#txtNombre').focus();
        return;
    }

    //------------------------
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pCodigo: $('#txtCodigo').val(),
            pNombre: $("#txtNombre").val(),
            pEstado: $("#checkEstado").is(':checked')
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalPlanNuevo();
            CerrarModalPlanEditar();
            BuscarPlanesMant(ParamUrl2);
        },
        error: function (req, status, error) {
//            alert("fail: " + req + " " + status + " " + error);
                $('#ModalMensajeError').dialog('option', 'modal', true).dialog('open');
                $("#ModalMensajeError").html(req.responseText);
        },
        complete: function () {
        }
    });
}
function PlanActividad_AceptarClick(ParamUrl1,ParamUrl2) {
   var CodigoPlan = $("#hdCodigoPlan").val();

   var ntbTiempoDura = $("#ntbTiempoDura").data("kendoNumericTextBox");
   var ntbPersRequ = $("#ntbPersRequ").data("kendoNumericTextBox");
   var ntbItem = $("#ntbItem").data("kendoNumericTextBox");

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pItem: ntbItem.value(),
            pTipoActi: $("#ddlTipoActividad").val(),
            pDesc: $("#txtActividadDesc").val(),
            pPrio: $("#ddlPrioridad").val(),
            pCodiFrec: $("#ddlFrecuencia").val(),
            pPersRequ: ntbPersRequ.value(),
            pCodiTiem: $("#ddlTiempoUnme").val(),
            pTiemActi: ntbTiempoDura.value(),
            pProc: $("#txtProcedimiento").val(),
            pObse: $("#txtObservaciones").val()
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalActividadEditar();
            //Actualizar la grilla de actividades
            $.ajax({
                type: "POST",
                url: ParamUrl2,
                data: { pCodigo: CodigoPlan },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#pnlGridActividades").html(data);
                },
                error: function (req, status, error) {
                    alert("fail: " + req + " " + status + " " + error);
                },
                complete: function () {
                }
            });
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function SolicitudActividad_AceptarClick(ParamUrl1, ParamUrl2) {
    var Codigo = $("#hdNumeroSoli").val();
    var dpFechaProg = $("#dpFechaProg").data("kendoDatePicker");   
    var ntbTiempoDura = $("#ntbTiempoDura").data("kendoNumericTextBox");
    var ntbPersRequ = $("#ntbPersRequ").data("kendoNumericTextBox");
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pItem: $("#txtItem").val(),
            pTipoActi: $("#ddlTipoActividad").val(),
            pDesc: $("#txtActividadDesc").val(),
            pPrio: $("#ddlPrioridad").val(),
            pCodiFrec: $("#ddlFrecuencia").val(),
            pPersRequ: ntbPersRequ.value(),
            pCodiTiem: $("#ddlTiempoUnme").val(),
            pTiemActi: ntbTiempoDura.value(),
            pFechaProg: kendo.toString(dpFechaProg.value(), 'dd/MM/yyyy'),
            pOrdeTrab: $("#txtNumOT").val()
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalActividadEditar();
            //Actualizar la grilla de actividades
            $.ajax({
                type: "POST",
                url: ParamUrl2,
                data: { pNumSoli: Codigo },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#pnlGridActividades").html(data);
                },
                error: function (req, status, error) {
                    alert("fail: " + req + " " + status + " " + error);
                },
                complete: function () {
                }
            });
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function SolicitudRegistrar(ParamUrl1,ParamUrl2) {

    var dpSol = $("#dpFechaSol").data("kendoDatePicker");
    var dpIni = $("#dpFechaIni").data("kendoDatePicker");
    var dpFin = $("#dpFechaFin").data("kendoDatePicker");

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pNumSoli: $('#txtNumSolicitud').val(),
            pFechaSoli: kendo.toString(dpSol.value(), 'dd/MM/yyyy') ,
            pTipoSoli: $("#ddlTipoSolicitud").val(),
            pDocuRefe: $("#txtNumDocuRefe").val(),
            pFechaIni: kendo.toString(dpIni.value(), 'dd/MM/yyyy') ,
            pFechaFin: kendo.toString(dpFin.value(), 'dd/MM/yyyy') ,
            pEstado: $("#ddlEstadoSolicitud").val(),
            pCodiEqui: $("#txtCodigoEquipo").val(),
            pCodiPlan: $("#ddlPlanMante").val(),
            pCronGene: $("#hdCronogramaGenerado").val(),
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalSolicitud();
            BuscarSolicitudes(ParamUrl2);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function SolicitudActividadEliminar(ParamUrl1, ParamGuid) {

    if (!confirm('¿Está seguro de eliminar la Actividad?')) {
        return;
    }
     $.ajax({
                type: "POST",
                url: ParamUrl1,
                data: {pGuidActividad : ParamGuid },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#pnlGridActividades").html(data);
                },
                error: function (req, status, error) {
                    alert("fail: " + req + " " + status + " " + error);
                },
                complete: function () {
                }
            });
}
function EquipoConsulta(ParamUrl1) {
    
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divEquipos").html(data);
            MostrarModalEquipos();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}



function EquiposEjecutarBusqueda(ParamUrl1) {
    
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
        pCodiEqui: $('#txtCodigoEquipo_Consulta').val(),
        pNombEqui: $('#txtNombreEquipo_Consulta').val(),
        pSeriEqui: $('#txtSerieEquipo_Consulta').val(),
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#gridEquipos").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function SolicitudGenerarCronograma(ParamUrl1, ParamNumeSoli){

 var dpIni = $("#dpFechaIni").data("kendoDatePicker");
    var dpFin = $("#dpFechaFin").data("kendoDatePicker");
  $.ajax({
        type: "POST",
        url: ParamUrl1,
        data: { pNumeSoli: ParamNumeSoli,
        pFechaInicio:  kendo.toString(dpIni.value(), 'dd/MM/yyyy'),
        pFechaFin: kendo.toString(dpFin.value(), 'dd/MM/yyyy') 
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#pnlGridActividades").html(data);
            $('#btnVerCalendario').prop('disabled', false).removeClass('k-state-disabled');
            
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function EquipoSeleccionar(ParamCodEqui, ParamNomEqui, ParamDesArea) {

    $("#txtCodigoEquipo").attr("value", ParamCodEqui);
    $("#txtNombreEquipo").attr("value", ParamNomEqui);
    $("#txtAreaUbi").attr("value", ParamDesArea);

    CerrarModalEquipos();
}

function EquiposNuevo(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divEquipos").html(data);
            MostrarModalEquipos();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function EquiposEditar(ParamUrl1, ParamCodEquipo) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data:{pCodiEqui:ParamCodEquipo },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divEquipos").html(data);
            MostrarModalEquipos();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function EquiposRegistrar(ParamUrl1,ParamUrl2) {
     var dpFCompra = $("#txtFechaCompra").data("kendoDatePicker");
     var dpFExpira = $("#txtFechaExpira").data("kendoDatePicker");
     var dpFUltMan = $("#txtFechaUltiMant").data("kendoDatePicker");

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pCodiEqui: $('#txtCodigoEquipo').val(),
            pNombEqui: $("#txtNombreEquipo").val(),
            pSerie: $("#txtSerieEquipo").val(),
            pMarca: $("#txtMarcaEquipo").val(),
            pModel: $("#txtModeloEquipo").val(),
            pCarac: $("#txtCaracteristicaEquipo").val(),
            pFechaComp: kendo.toString(dpFCompra.value(), 'dd/MM/yyyy') ,
            pFechaExpi: kendo.toString(dpFExpira.value(), 'dd/MM/yyyy') ,
            pFechaUltiMant: kendo.toString(dpFUltMan.value(), 'dd/MM/yyyy') ,
            pCodiArea: $("#ddlArea").val(),
            pCodiTipo: $("#ddlTipoEquipo").val(),
            pCodiPlan: $("#ddlPlanMant").val(),
            pProced: $("#txtProcedEquipo").val(),
            pEstaEqui: $("#checkEstado").val()
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalEquipos();
            EquiposEjecutarBusqueda(ParamUrl2);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function EquiposEliminar(ParamUrl1, ParamUrl2, ParamCodigo) {

    if (!confirm('¿Está seguro de eliminar el registro?')) {
        return;
    }

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodigo: ParamCodigo },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            EquiposEjecutarBusqueda(ParamUrl2)
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function MostrarCalendario(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divCalendario").html(data);
            MostrarModalCalendario();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function MostrarModalPlanDetalle() {
    $('#divActividad').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlanDetalle(ParamUrl1, ParamUrl2) {
    $('#divActividad').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalPlanNuevo() {
    $('#divPlanNuevo').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlanNuevo( ) {
    $('#divPlanNuevo').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalPlanEditar() {
    $('#divPlanEditar').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlanEditar() {
    $('#divPlanEditar').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalActividadEditar() {
    $('#divActividad').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalActividadEditar() {
    $('#divActividad').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalSolicitud() {
    $('#divSolicitud').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalSolicitud() {
    $('#divSolicitud').dialog('option', 'modal', true).dialog('close');
};


function MostrarModalCalendario() {
    $('#divCalendario').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalCalendario() {
    $('#divCalendario').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalEquipos() {
    $('#divEquipos').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalEquipos() {
    $('#divEquipos').dialog('option', 'modal', true).dialog('close');
};

function BuscarOT(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pd_Fini: $("#txtFechaIni").val(),
            pd_Ffin: $("#txtFechaFin").val()
         },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGrid").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function NuevaOT(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divNuevaOT").html(data);
            MostrarCreaOT();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function MostrarCreaOT() {
    $('#divNuevaOT').dialog('option', 'modal', true).dialog('open');
    return true;
}