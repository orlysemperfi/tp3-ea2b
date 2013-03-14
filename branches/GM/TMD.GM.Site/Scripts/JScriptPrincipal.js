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
    $('#pnlPlanDetalle').dialog({ autoOpen: false, width: 548, height: 380 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divNuevoPlan').dialog({ autoOpen: false, width: 548, height: 380 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divNuevaSolicitud').dialog({ autoOpen: false, width: 680, height: 400 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    


});

function Plan_BtnAgregar_click(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#pnlPlanDetalle").html(data);
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
        data: "",
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
            $("#divNuevoPlan").html(data);
            MostrarModalPlanNuevo();
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
            $("#divNuevaSolicitud").html(data);
            MostrarModalSolicitudNueva();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function Plan_BtnAceptarDetalle_click(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#pnlPlanDetalle").html(data);
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

function MostrarModalPlanDetalle() {
    $('#pnlPlanDetalle').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlanDetalle(ParamUrl1, ParamUrl2) {
    $('#pnlPlanDetalle').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalPlanNuevo() {
    $('#divNuevoPlan').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlanNuevo( ) {
    $('#divNuevoPlan').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalSolicitudNueva() {
    $('#divNuevaSolicitud').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalSolicitudNueva() {
    $('#divNuevaSolicitud').dialog('option', 'modal', true).dialog('close');
};