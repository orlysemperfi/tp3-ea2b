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