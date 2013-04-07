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
    $('#divPlan').dialog({ autoOpen: false, width: 1000, height: 450 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divSolicitud').dialog({ autoOpen: false, width: 1000, height: 600 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divCalendario').dialog({ autoOpen: false, width: 900, height: 440 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divEquipos').dialog({ autoOpen: false, width: 750, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divResponsables').dialog({ autoOpen: false, width: 750, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divOrdenTrabajo').dialog({ autoOpen: false, width: 1000, height: 550 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divOTGenerar').dialog({ autoOpen: false, width: 1000, height: 600 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divAsignacionReponsable').dialog({ autoOpen: false, width: 1000, height: 400 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divActividadesResumen').dialog({ autoOpen: false, width: 750, height: 300 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    $('#divActividadesResponsable').dialog({ autoOpen: false, width: 900, height: 500 }).parent('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
    
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
        data: {pCodigo:$('#txtCodigo_Consulta').val(),
        pNombre:$('#txtNombre_Consulta').val()},
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
            $("#divPlan").html(data);
            MostrarModalPlan();
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
            $("#divPlan").html(data);
            MostrarModalPlan();
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

function SolicitudEditar(ParamUrl1, ParamUrl2, ParamNumSoli, ParamFechaSoli, ParamTipoSoli, ParamDocuRefe, ParamFechaIni, ParamFechaFin, ParamCodiEsta, ParamCodiEqui, ParamCodiPlan, ParamNombEqui, ParamDescArea) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pNumSoli:ParamNumSoli, pFechaSoli:ParamFechaSoli, pTipoSoli:ParamTipoSoli, pDocuRefe:ParamDocuRefe, pFechaIni:ParamFechaIni, pFechaFin:ParamFechaFin,pEstado:ParamCodiEsta,pCodiEqui:ParamCodiEqui, pCodiPlan:ParamCodiPlan, pNombEqui:ParamNombEqui, pDescArea:ParamDescArea},
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
            CerrarModalPlan();
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

   //Validaciones del cliente
    if($.trim($('#txtActividadDesc').val()) == '')
    {
        alert('Debe ingresar la descripción');
        $('#txtActividadDesc').focus();
        return;
    }

    if(ntbPersRequ.value() == 0)
    {
        alert('Debe ingresar el N° de personal requerido');
        ntbPersRequ.focus();
        return;
    }

    if(ntbTiempoDura.value() == 0)
    {
        alert('Debe ingresar el tiempo de la actividad');
        ntbTiempoDura.focus();
        return;
    }

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
            pItem: ntbItem.value(),
            pTipoActi: $("#ddlTipoActividad").val(),
            pTipoActiDes: $("#ddlTipoActividad option:selected").text(),
            pDesc: $("#txtActividadDesc").val(),
            pPrio: $("#ddlPrioridad").val(),
            pCodiFrec: $("#ddlFrecuencia").val(),
            pCodiFrecDes: $("#ddlFrecuencia option:selected").text(),
            pPersRequ: ntbPersRequ.value(),
            pCodiTiem: $("#ddlTiempoUnme").val(),
            pCodiTiemDes: $("#ddlTiempoUnme option:selected").text(),
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

    if($.trim($('#txtNumSolicitud').val()) == '')
        { alert('Debe ingresar el Código');$('#txtNumSolicitud').focus();return;  }
    if(dpSol.value() == null)
        { alert('Debe ingresar la Fecha Solicitud');dpSol.focus();return;  }
    if($.trim($('#ddlTipoSolicitud').val()) == '' || $.trim($('#ddlTipoSolicitud').val()) == '0')
        { alert('Debe seleccionar el Tipo');$('#ddlTipoSolicitud').focus();return;  }
    if($.trim($('#txtNumDocuRefe').val()) == '')
        { alert('Debe ingresar el Documento Referencia');$('#txtNumDocuRefe').focus();return;  }
    if(dpIni.value() == null)
        { alert('Debe ingresar la Fecha Inicio');dpIni.focus();return;  }
    if(dpFin.value() == null)
        { alert('Debe ingresar la Fecha Fin');dpFin.focus();return;  }
    if($.trim($('#ddlEstadoSolicitud').val()) == '' || $.trim($('#ddlEstadoSolicitud').val()) == '0')
        { alert('Debe seleccionar el Estado');$('#ddlEstadoSolicitud').focus();return;  }
    if($.trim($('#txtCodigoEquipo').val()) == '')
        { alert('Debe ingresar el Código Equipo');$('#txtCodigoEquipo').focus();return;  }
    if($.trim($('#ddlPlanMante').val()) == '' || $.trim($('#ddlPlanMante').val()) == '0')
        { alert('Debe seleccionar el Plan');$('#ddlPlanMante').focus();return;  }

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
            pCronGene: $("#hdCronogramaGenerado").val()
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
function SolicitudActividadEliminarTodos(ParamUrl1) {

    if (!confirm('¿Está seguro de eliminar las Actividades?')) {
        return;
    }
     $.ajax({
                type: "POST",
                url: ParamUrl1,
                data: "",
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
function EquipoConsulta(ParamUrl1, ParamFormProc) {
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pFormProc:ParamFormProc},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divEquipos").html(data);
            MostrarModalEquipos();
            $("#hdFormPocedencia").attr("value", ParamFormProc);

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
        pSeriEqui: $('#txtSerieEquipo_Consulta').val()
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
            //$('#btnVerCalendario').prop('disabled', false).removeClass('k-state-disabled');
            
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}
function EquipoSeleccionar(ParamCodEqui, ParamNomEqui, ParamDesArea, ParamCodiPlan) {
    
    if($('#hdFormPocedencia').val() == 'PagePopup')
    {
        $("#txtCodigoEquipo").attr("value", ParamCodEqui);
        $("#txtNombreEquipo").attr("value", ParamNomEqui);
        $("#txtAreaUbi").attr("value", ParamDesArea);
        $("#ddlPlanMante").attr("value", ParamCodiPlan);
    }
    if($('#hdFormPocedencia').val() == 'PageBase')
    {
        $("#txtCodigoEquipo_ConsultaPrincipal").attr("value", ParamCodEqui);
        $("#txtNombreEquipo_ConsultaPrincipal").attr("value", ParamNomEqui);
    }

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
     var ddlArea = $("#ddlArea").data("kendoComboBox");
     var ddlTipoEquipo = $("#ddlTipoEquipo").data("kendoComboBox");
     var ddlPlanMant = $("#ddlPlanMant").data("kendoComboBox");
     var ddlProcedEquipo = $("#ddlProcedEquipo").data("kendoComboBox");

    if($.trim($('#txtCodigoEquipo').val()) == '')
        { alert('Debe ingresar el código');$('#txtCodigoEquipo').focus();return;  }
    if($.trim($('#txtNombreEquipo').val()) == '')
        { alert('Debe ingresar el nombre');$('#txtNombreEquipo').focus();return;  }
    if($.trim($('#txtSerieEquipo').val()) == '')
        { alert('Debe ingresar el N° de Serie');$('#txtSerieEquipo').focus();return;  }
    if($.trim($('#txtMarcaEquipo').val()) == '')
        { alert('Debe ingresar la Marca');$('#txtMarcaEquipo').focus();return;  }
    if($.trim($('#txtModeloEquipo').val()) == '')
        { alert('Debe ingresar el Modelo');$('#txtModeloEquipo').focus();return;  }
    if($.trim($('#txtCaracteristicaEquipo').val()) == '')
        { alert('Debe ingresar las Características');$('#txtCaracteristicaEquipo').focus();return;  }
    if(dpFCompra.value() == null)
        { alert('Debe ingresar las Fecha de Compra');dpFCompra.input.focus();return;  }
    if(dpFExpira.value() == null)
        { alert('Debe ingresar las Fecha de Expiración de Garantía');dpFExpira.input.focus();return;  }
    if(ddlArea.value() == '' || ddlArea.value() == '0')
        { alert('Debe seleccionar el Área');ddlArea.focus();return;  }
    if(ddlTipoEquipo.value() == '' || ddlTipoEquipo.value() == '0')
        { alert('Debe seleccionar el Tipo');ddlTipoEquipo.focus();return;  }
    if(ddlPlanMant.value() == '' || ddlPlanMant.value() == '0')
        { alert('Debe seleccionar el Plan');ddlPlanMant.focus();return;  }
    if(ddlProcedEquipo.value() == '' || ddlProcedEquipo.value() == '0')
        { alert('Debe seleccionar la Procedencia');ddlProcedEquipo.focus();return;  }

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
            pCodiArea: ddlArea.value(),
            pCodiTipo: ddlTipoEquipo.value(),
            pCodiPlan: ddlPlanMant.value(),
            pProced: ddlProcedEquipo.value(),
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


function EmpleadoConsulta(ParamUrl1, ParamFormProc) {
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pFormProc:ParamFormProc},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divResponsables").html(data);
            MostrarModalEmpleados();
            $("#hdFormPocedencia").attr("value", ParamFormProc);

        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}



function EmpleadoEjecutarBusqueda(ParamUrl1) {
    
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {
        pDNI: $('#txtDNIPers_Consulta').val(),
        pNombre: $('#txtNombPers_Consulta').val()
        },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridPersonal").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function EmpleadoSeleccionar(ParamCodEmpl, ParamNomEmpl) {
    
    if($('#hdFormPocedencia').val() == 'PagePopup')
    {
        $("#txtCodiEmpl").attr("value", ParamCodEmpl);
        $("#txtNombEmpl").attr("value", ParamNomEmpl);
    }
    if($('#hdFormPocedencia').val() == 'PageBase')
    {
        $("#txtCodigoResp_ConsultaPrincipal").attr("value", ParamCodEmpl);
        $("#txtNombreResp_ConsultaPrincipal").attr("value", ParamNomEmpl);
    }
    if ($('#hdFormPocedencia').val() == 'PageAsigna') {
        $("#txtCodiResp_LAR").attr("value", ParamCodEmpl);
        $("#txtNombResp_LAR").attr("value", ParamNomEmpl);

        OTObtenerEspecialidadResponsable("/OrdenTrabajo/EspecialidadesResponsable", ParamCodEmpl);
    }

    CerrarModalEmpleados();
}

function MostrarModalPlanDetalle() {
    $('#divActividad').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlanDetalle(ParamUrl1, ParamUrl2) {
    $('#divActividad').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalPlan() {
    $('#divPlan').dialog('option', 'modal', true).dialog('open');
    return true;
}
function CerrarModalPlan( ) {
    $('#divPlan').dialog('option', 'modal', true).dialog('close');
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

function MostrarModalEmpleados() {
    $('#divResponsables').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalEmpleados() {
    $('#divResponsables').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalOT() {
    $('#divOrdenTrabajo').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalOT() {
    $('#divOrdenTrabajo').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalOTGenerar() {
    $('#divOTGenerar').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalOTGenerar() {
    $('#divOTGenerar').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalOTAsignaResponsable() {
    $('#divAsignacionReponsable').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalOTAsignaResponsable() {
    $('#divAsignacionReponsable').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalOTActividadesResumen() {
    $('#divActividadesResumen').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalOTActividadesResumen() {
    $('#divActividadesResumen').dialog('option', 'modal', true).dialog('close');
};

function MostrarModalOTActividadesResponsable() {
    $('#divActividadesResponsable').dialog('option', 'modal', true).dialog('open');
    return true;
};
function CerrarModalOTActividadesResponsable() {
    $('#divActividadesResponsable').dialog('option', 'modal', true).dialog('close');
};

function BuscarOT(ParamUrl1) {

    var dpFIni = $("#dpFechaIni_Consulta").data("kendoDatePicker");
    var dpFFin = $("#dpFechaFin_Consulta").data("kendoDatePicker");
    var ddlEstado = $("#ddlEstadoOT_Consulta").data("kendoComboBox");

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { 
            pNumOT:$("#txtNumOT_Consulta").val(),
            pFechaIni: kendo.toString(dpFIni.value(), 'dd/MM/yyyy'),
            pFechaFin: kendo.toString(dpFFin.value(), 'dd/MM/yyyy'),
            pNumSoli:$("#txtNumSolicitud_Consulta").val(),
            pEstadoCodi: ddlEstado.value(),
            pCodiResp:$("#txtCodigoResp_ConsultaPrincipal").val()
         },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridOTConsulta").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OrdenTrabajoEliminar(ParamUrl1, ParamUrl2, ParamCodigo) {

    if (!confirm('¿Está seguro de anular el registro?')) {
        return;
    }

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodigo: ParamCodigo },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            BuscarOT(ParamUrl2)
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

function OrdenTrabajoEditar(ParamUrl1, ParamUrl2, ParamNumOrden) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pNumOrden:ParamNumOrden},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divOrdenTrabajo").html(data);
            MostrarModalOT();

            $.ajax({
                type: "POST",
                url: ParamUrl2,
                data: { pNumOrden: ParamNumOrden },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    $("#divGridOTActividades").html(data);
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
function OTGenerar(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divOTGenerar").html(data);
            MostrarModalOTGenerar();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTEquipoPendiente(ParamUrl1) {

    var dpFIni = $("#dpFechaIni_Genera").data("kendoDatePicker");
    var dpFFin = $("#dpFechaFin_Genera").data("kendoDatePicker");

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pFechaIni: kendo.toString(dpFIni.value(), 'dd/MM/yyyy'),
            pFechaFin: kendo.toString(dpFFin.value(), 'dd/MM/yyyy')
            },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridOTEquiposPendientes").html(data);
            MostrarModalOTGenerar();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTEquipoActividades(ParamUrl1, ParamCodiEqui) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pCodiEqui:ParamCodiEqui},
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridOTEquiposActividades").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTEquipoCheck(ParamUrl1, ParamCodiEqui, ParamNumSoli, ParamCheckbox) {
   
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pCodiEqui:ParamCodiEqui, pNumSoli:ParamNumSoli, pCheck:$("#"+ParamCheckbox).is(':checked')},
        cache: false,
        success: function (data, textStatus, jqXHR) {},
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTActividadCheck(ParamUrl1, ParamIdActi,ParamCodiEqui, ParamCheckbox) {
   
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: {pIdActi:ParamIdActi,pCodiEqui:ParamCodiEqui, pCheck:$("#"+ParamCheckbox).is(':checked')},
        cache: false,
        success: function (data, textStatus, jqXHR) {},
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTAsignarResponsable(ParamUrl1) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divAsignacionReponsable").html(data);
            MostrarModalOTAsignaResponsable();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTActividadesResumen(ParamUrl1, ParamCodiEqui) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodiEqui: ParamCodiEqui },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divActividadesResumen").html(data);
            MostrarModalOTActividadesResumen();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTListarActividadResponsables(ParamUrl1,ParamUrl2,ParamUrl3, ParamCodiEqui, ParamCodiResp) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodiEqui: ParamCodiEqui },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divActividadesResponsable").html(data);
            MostrarModalOTActividadesResponsable();
            OTObtenerActividadesEquipo(ParamUrl2, ParamCodiEqui);
            OTObtenerEspecialidadResponsable(ParamUrl3, ParamCodiResp);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTObtenerActividadesEquipo(ParamUrl1, ParamCodiEqui) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodiEqui: ParamCodiEqui },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridOTEquipoActividades").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTObtenerEspecialidadResponsable(ParamUrl1, ParamCodiResp) {

    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodiPers: ParamCodiResp },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            $("#divGridOTResponsableActividades").html(data);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTAsignaResponsableEquipoCheck(ParamUrl1,ParamUrl2, ParamCodiEqui) {
    var codiPers = $("#txtCodiResp_LAR").val();
    var nombPers = $("#txtNombResp_LAR").val();
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: { pCodiEqui: ParamCodiEqui, pCodiPers: codiPers, pNombPers: nombPers },
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalOTActividadesResponsable();
            OTAsignarResponsable(ParamUrl2);
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}

function OTGenerarConfirma(ParamUrl1) {

    if (!confirm('¿Está seguro de generar las Órdenes?')) {
        return;
    }
    $.ajax({
        type: "post",
        url: ParamUrl1,
        data: "",
        cache: false,
        success: function (data, textStatus, jqXHR) {
            CerrarModalOTAsignaResponsable();
            CerrarModalOTGenerar();
        },
        error: function (req, status, error) {
            alert("fail: " + req + " " + status + " " + error);
        },
        complete: function () {
        }
    });
}


