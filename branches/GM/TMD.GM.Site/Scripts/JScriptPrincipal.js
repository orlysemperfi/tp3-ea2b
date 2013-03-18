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
    $('#divPlanNuevo').dialog({ autoOpen: false, width: 750, height: 400 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divPlanEditar').dialog({ autoOpen: false, width: 750, height: 400 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();  
    $('#divSolicitud').dialog({ autoOpen: false, width: 750, height: 400 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divCalendario').dialog({ autoOpen: false, width: 750, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divEquipos').dialog({ autoOpen: false, width: 750, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    


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

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
        pNumSoli: $('#txtNumSolicitud_Consulta').val(),
            pFechaIni: $("#txtFechaIni_Consulta").val(),
            pFechaFin: $("#txtFechaFin_Consulta").val(),
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

    if (!confirm('¿Está seguro de eliminar el Plan?')) {
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

function PlanActividadEliminar(ParamUrl1, ParamUrl2, ParamCodigo, ParamIdActividad) {

    if (!confirm('¿Está seguro de eliminar la Actividad?')) {
        return;
    }

//    $.ajax({
//        type: "post",
//        url: ParamUrl1,
//        data: { pCodigo: ParamCodigo },
//        cache: false,
//        success: function (data, textStatus, jqXHR) {
//            BuscarPlanesMant(ParamUrl2)
//        },
//        error: function (req, status, error) {
//            alert("fail: " + req + " " + status + " " + error);
//        },
//        complete: function () {
//        }
//    });
}

function PlanActividadEditar(ParamUrl1,ParamIdAc, ParamCodi, ParamItem, ParamTipoActi, ParamDesc, ParamPrio,
ParamCodiFrec,ParamPersRequ, ParamCodiTiem,ParamTiemActi,ParamProc, ParamObse) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { 
        pIdActividad : ParamIdAc,
        pCodigo: ParamCodi, 
        pItem: ParamItem, 
        pTipoActi: ParamTipoActi, 
        pDesc: ParamDesc, 
        pPrio: ParamPrio,
        pCodiFrec: ParamCodiFrec,
        pPersRequ: ParamPersRequ, 
        pCodiTiem: ParamCodiTiem,
        pTiemActi: ParamTiemActi,
        pProc: ParamProc, 
        pObse: ParamObse },
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

function SolicitudActividadEditar(ParamUrl1, ParamIdAc, ParamNumSoli, ParamItemSoli, ParamDescActi, ParamCodiTipo, ParamCodiPrio,
ParamCodiFrec, ParamPersRequ, ParamCodiTiem, ParamTiemActi, ParamFechaProg, ParamOrdeTrab) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pIdActividad: ParamIdAc,
            pNumSoli: ParamNumSoli,
            pItemSoli: ParamItemSoli,
            pDescActi: ParamDescActi,
            pCodiTipo: ParamCodiTipo,
            pCodiPrio: ParamCodiPrio,
            pCodiFrec: ParamCodiFrec,
            pPersRequ: ParamPersRequ,
            pCodiTiem: ParamCodiTiem,
            pTiemActi: ParamTiemActi,
            pFechaProg: ParamFechaProg,
            pOrdeTrab: ParamOrdeTrab
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

function Plan_Aceptar_Click(ParamUrl1) {

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
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function PlanActividad_AceptarClick(ParamUrl1,ParamUrl2) {
   var CodigoPlan = $("#hdCodigoPlan").val();

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pIdActividad: $('#hdIdActividad').val(),
            pCodigo: $("#hdCodigoPlan").val(),
            pItem: $("#txtItem").val(),
            pTipoActi: $("#ddlTipoActividad").val(),
            pDesc: $("#txtActividadDesc").val(),
            pPrio: $("#ddlPrioridad").val(),
            pCodiFrec: $("#ddlFrecuencia").val(),
            pPersRequ: $("#txtPersRequ").val(),
            pCodiTiem: $("#ddlTiempoUnme").val(),
            pTiemActi: $("#txtTiempoDura").val(),
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

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pIdActividad: $('#hdIdActividad').val(),
            pCodigo: $("#hdNumeroSoli").val(),
            pItem: $("#txtItem").val(),
            pTipoActi: $("#ddlTipoActividad").val(),
            pDesc: $("#txtActividadDesc").val(),
            pPrio: $("#ddlPrioridad").val(),
            pCodiFrec: $("#ddlFrecuencia").val(),
            pPersRequ: $("#txtPersRequ").val(),
            pCodiTiem: $("#ddlTiempoUnme").val(),
            pTiemActi: $("#txtTiempoDura").val(),
            pFechaProg: $("#txtFechaProg").val(),
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
function SolicitudRegistrar(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pNumSoli: $('#txtNumSolicitud').val(),
            pFechaSoli: $("#txtFechaSol").val(),
            pTipoSoli: $("#ddlTipoSolicitud").val(),
            pDocuRefe: $("#txtNumDocuRefe").val(),
            pFechaIni: $("#txtFechaIni").val(),
            pFechaFin: $("#txtFechaFin").val(),
            pEstado: $("#ddlEstadoSolicitud").val(),
            pCodiEqui: $("#txtCodigoEquipo").val(),
            pCodiPlan: $("#ddlPlanMante").val(),
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalSolicitud();
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
        data: "",
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
function EquipoSeleccionar(ParamCodEqui, ParamNomEqui, ParamDesArea) {

    $("#txtCodigoEquipo").attr("value", ParamCodEqui);
    $("#txtNombreEquipo").attr("value", ParamNomEqui);
    $("#txtAreaUbi").attr("value", ParamDesArea);

    CerrarModalEquipos();
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