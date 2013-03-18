<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true" CodeBehind="ActualizarHallazgo.aspx.cs" Inherits="TMD.ACP.Site.ActualizarHallazgo" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
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
     
        //*****************************************************************************
        $(document).ready(function () {
         $("#trNewRowHallazgo").hide();
        });
        
        //*****************************************************************************
        function fListarCapitulos() {
             var idAuditoria = $("#MainContent___IdAuditoria").val();
             var idNorma = $("#MainContent_cboNorma").val();
             window.setTimeout(function () { DoCallBack("ListarCapitulos", idAuditoria + ":" + idNorma, End_fListarCapitulos); }, 1000)
        }
        //*****************************************************************************
        function End_fListarCapitulos(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#spanCboCap").html(mData[1]);
                $("#divPreguntas").html(mData[2]);
                $("#divHallazgos").html(mData[3]);
                $("#trNewRowHallazgo").hide();                   
            }
        }
        //*****************************************************************************
        function fListarPreguntas() {
            var idAuditoria = $("#MainContent___IdAuditoria").val();
            var idNorma = $("#MainContent_cboNorma").val();
            var idCapitulo = $("#MainContent_cboCapitulo").val();
            window.setTimeout(function () { DoCallBack("ListarPreguntas", idAuditoria + ":" + idNorma + ":" + idCapitulo, End_fListarPreguntas); }, 1000)
        }
        //*****************************************************************************
        function End_fListarPreguntas(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divPreguntas").html(mData[1]);
                $("#divHallazgos").html(mData[2]);
                $("#trNewRowHallazgo").hide();                
            }
        }
        //*****************************************************************************
        function fListarHallazgos(idPregunta) {
            var idAuditoria = $("#MainContent___IdAuditoria").val();
            $("#MainContent___TmpIdPregunta").val(idPregunta);
            window.setTimeout(function () { DoCallBack("ListarHallazgos", idAuditoria + ":" +  idPregunta, End_fListarHallazgos); }, 1000)
        }
        //*****************************************************************************
        function End_fListarHallazgos(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divHallazgos").html(mData[1]);
                $("#spanIdPregunta").html(mData[2]); 
            }
        }
        //*****************************************************************************
        function fEditarPregunta(id) {
            $("#ModoEdicion" + id).show();
            $("#ModeVista" + id).hide();            
        }

        //***************************************************************************** 
        function fCancelarPregunta(id) {
            $("#ModeVista" + id).show();
            $("#ModoEdicion" + id).hide();
        }

        //***************************************************************************** 
        function fGrabarPregunta(id) {
            var idPregunta = $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtIdPregunta_"]').val();
            var chkRpta = $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_chkRpta_"]').is(':checked');
            var sustento = $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtSustento_"]').val();
            var porcentaje = $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtPorcentaje_"]').val();

            bValida = false;

            if (sustento == "") {
                alert('Ingrese un sustento a la pregunta seleccionada');
                $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtSustento_"]').focus();
                bValida = true;
            } else if (porcentaje == "" || isNaN(porcentaje) == true || parseInt(porcentaje) < 0 || parseInt(porcentaje) > 100) {
                alert('Ingrese un valor correcto para el Porcentaje');
                $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtPorcentaje_"]').focus();
                bValida = true;
            } else if (isNaN(porcentaje) == false) {
                if (chkRpta == true && parseInt(porcentaje) <= 0) {
                    alert('El indicador de cumplimiento es SI, el valor del Porcentaje no puede ser 0. Verificar');
                    $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtPorcentaje_"]').focus();
                    bValida = true;
                }
                if (chkRpta == false && parseInt(porcentaje) != 0) {
                    alert('El indicador de cumplimiento es NO, el valor del Porcentaje no puede ser distinto a 0. Verificar');
                    $('#ModoEdicion' + id + ' input[id*="MainContent_rptPreguntas_txtPorcentaje_"]').focus();
                    bValida = true;
                }
            }

            if (bValida == false) {
                //aqui se hace un set para el registro correspondiente
                $("#MainContent___TmpIdPregunta").val(idPregunta);
                $("#MainContent___TmpChkRpta").val(chkRpta);
                $("#MainContent___TmpSustento").val(sustento);
                $("#MainContent___TmpPorcentaje").val(porcentaje);

                window.setTimeout(function () { DoFormCallBack("GrabarPregunta", null, End_fGrabarPregunta); }, 500)
            }
        }
        //*****************************************************************************    
        function End_fGrabarPregunta(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divPreguntas").html(mData[1]);                
            }
        }
        //*****************************************************************************                    
        function fEditarHallazgo(id) {
            $("#ModoEdicionHallazgo" + id).show();
            $("#ModoVistaHallazgo" + id).hide();
            $("#trNewRowHallazgo").hide();
        }
        //*****************************************************************************            
        function fCancelarHallazgo(id) {
            $("#ModoVistaHallazgo" + id).show();
            $("#ModoEdicionHallazgo" + id).hide();
            $("#trNewRowHallazgo").show();
        }
        //***************************************************************************** 
        function fGrabarHallazgo(id) {
            var tipoHallazgo = ""

            $("#ModoEdicionHallazgo" + id + " :input").each(function () {
                //alert($(this).attr("id"));alert($(this).val());                        
                if ($(this).attr("id").indexOf('MainContent_rptHallazgos_ddlTipoHallazgo_') >= 0) tipoHallazgo = $(this).val();
            });

            var idHallazgo = $('#ModoEdicionHallazgo' + id + ' input[id*="MainContent_rptHallazgos_txtIdHallazgo_"]').val();
            var descripcion = $('#ModoEdicionHallazgo' + id + ' input[id*="MainContent_rptHallazgos_txtDesHallazgo_"]').val();

            if (descripcion == "") {
                alert('Ingrese una descripción para el Hallazgo');
                $('#ModoEdicionHallazgo' + id + ' input[id*="MainContent_rptHallazgos_txtDesHallazgo_"]').focus();
            } else {

                $("#MainContent___TmpIdHallazgo").val(idHallazgo);
                $("#MainContent___TmpDesHallazgo").val(descripcion);
                $("#MainContent___TmpTipoHallazgo").val(tipoHallazgo);

                window.setTimeout(function () { DoFormCallBack("GrabarHallazgo", null, End_fGrabarHallazgo); }, 500)
            }     
        }
        //*****************************************************************************    
        function End_fGrabarHallazgo(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divHallazgos").html(mData[1]);                
            }
        }
        
        //*****************************************************************************
        function fAgregarHallazgo() {

            var idHallazgo = $("#MainContent_rptHallazgos_txtIdNewHallazgo").val();
            var descripcion = $("#MainContent_rptHallazgos_txtDesNewHallazgo").val();
            var tipoHallazgo = $("#MainContent_rptHallazgos_ddlNewTipoHallazgo").val();

            bValida = false;

            if (descripcion == "") {
                alert('Ingrese una descripción para el Hallazgo');
                $("#MainContent_rptHallazgos_txtDesNewHallazgo").focus();
                bValida = true;
            } else if (tipoHallazgo == "") {
                alert('Ingrese una Tipo de Hallazgo');
                $("#MainContent_rptHallazgos_ddlNewTipoHallazgo").focus();
                bValida = true;
            }
            
            if (bValida == false) {
                $("#MainContent___TmpIdHallazgo").val(idHallazgo);
                $("#MainContent___TmpDesHallazgo").val(descripcion);
                $("#MainContent___TmpTipoHallazgo").val(tipoHallazgo);

                window.setTimeout(function () { DoFormCallBack("AgregarHallazgo", null, End_fGrabarHallazgo); }, 500)
            }
        }

        //*****************************************************************************
        function fAdjuntarArchivo(idOrigen) {
            var title = 'ADJUNTAR ARCHIVO';
            var id = $("#MainContent___IdAuditoria").val();
            window.OpenMultiPopup('UploadFile.aspx?idOrigen=' + idOrigen + '&tipoOrigen=H&nIdAuditoria=' + id + '&nOpcion=2', title, 420, 320, true, null, null, "keyArchivo", "clone", false, false, false);
        }
        //*****************************************************************************
        function fVerArchivo(idOrigen) {
            var title = 'VER ARCHIVO';
            var id = $("#MainContent___IdAuditoria").val();
            window.OpenMultiPopup('UploadFile.aspx?idOrigen=' + idOrigen + '&tipoOrigen=H&nIdAuditoria=' + id + '&nOpcion=1', title, 420, 320, true, null, null, "keyArchivo", "clone", false, false, false);
        }
        
        //*****************************************************************************
        function fQuitarHallazgo(id) {

            var idaudi = $("#MainContent___IdAuditoria").val();
            var idPreg = $("#MainContent___TmpIdPregunta").val();
            
            if (window.confirm("Esta seguro de eliminar el Hallazgo: " + id + "?")) {
                window.setTimeout(function () { DoCallBack("QuitarHallazgo", id + ":" + idaudi + ":" + idPreg, End_fQuitarHallazgo); }, 1000)
            }
        }
        //*****************************************************************************
        function End_fQuitarHallazgo(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                $("#divHallazgos").html(mData[1]);
            }
        }
     </script>

     <asp:HiddenField id="__IdAuditoria" runat="server"/>

     <asp:HiddenField id="__TmpIdPregunta" runat="server"/>
     <asp:HiddenField id="__TmpChkRpta" runat="server"/>
     <asp:HiddenField id="__TmpSustento" runat="server"/>
     <asp:HiddenField id="__TmpPorcentaje" runat="server"/>     

     <asp:HiddenField id="__TmpIdHallazgo" runat="server"/>
     <asp:HiddenField id="__TmpDesHallazgo" runat="server"/>
     <asp:HiddenField id="__TmpTipoHallazgo" runat="server"/>  

     <div style="margin:0px 0px 0px;padding:0px 0px 0px 0px"><a href="#" style="color:black">Auditoría</a> / <a href="#" style="color:black">Actualizar Hallazgos de Auditoría</a></div>
     <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-bottom: 0px;">HALLAZGOS DE AUDITORÍA</div>

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

        <span style="padding:0px 10px 0px 10px">Datos de la Lista de Verificación</span><br /> <br />
        <span style="padding:0px 10px 0px 10px">Norma:</span>
        <span id="spanCboNorma" style="padding:0px 10px 0px 10px">
        <asp:DropDownList ID="cboNorma" runat="server" Width="30%" Font-Names="Arial" 
        Font-Size="10pt" onChange="fListarCapitulos()"></asp:DropDownList>
        </span>
        <span style="padding:0px 10px 0px 10px">Capítulo:</span>
        <span id="spanCboCap" style="padding:0px 10px 0px 10px">
            <asp:DropDownList ID="cboCapitulo" runat="server" Width="40%" Font-Names="Arial" 
        Font-Size="10pt" onChange="fListarPreguntas()"></asp:DropDownList>
        </span>    

    </div>
    <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;font-family:Arial;margin:10px 20px 0px 20px;">
    <span style="padding:0px 10px 0px 10px">Preguntas:</span>
        <div id="divPreguntas" style="margin:10px 0px 10px 0px;height:100%;width:100%;">
    
            <asp:Repeater ID="rptPreguntas" runat="server" OnItemDataBound="rptPreguntas_ItemDataBound">
                    <HeaderTemplate>
                      <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;" width="100%">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="litIdPregunta" runat="server" Text="Nro"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litDesPregunta" runat="server" Text="Pregunta"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:50px"><asp:Literal ID="litRpta" runat="server" Text="Cumple"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litSustento" runat="server" Text="Sustento"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="litPorcentaje" runat="server" Text="Porcentaje"></asp:Literal></td>                                            
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litEditar" runat="server" Text="Editar"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litHallazgos" runat="server" Text="Hallazgo"></asp:Literal></td>
                    </tr>     
                    </HeaderTemplate>
                    <ItemTemplate>
                    <tr class="RowStyle" id="ModeVista<%# Eval("idPreguntaVerificacion")%>">            
                    <td align="center" style="width:20px">
                        <asp:Literal ID="litIdPregunta" runat="server" Text='<%# Eval("idPreguntaVerificacion") %>' />
                    </td>
                    <td align="left" style="width:200px">                               
                         <asp:Literal ID="litDesPregunta" runat="server" Text='<%# Eval("descripcionPregunta") %>' />                      
                    </td>
                    <td align="center" style="width:50px">
                    <asp:Literal ID="litRpta" runat="server" Text='<%# Eval("respuesta") %>' />                
                    </td>
                    <td align="left" style="width:200px">
                     <asp:Literal ID="litSustento" runat="server" Text='<%# Eval("sustento") %>' />                
                    </td>
                    <td align="center" style="width:80px">
                        <asp:Literal ID="litPorcentaje" runat="server" Text='<%# Eval("porcentaje") %>' />%                                    
                    </td>                   
                    <td align="center" style="width:60px">               
                    <a id="lnkEditarPregunta" class="cLnkEditarPregunta" href="javascript:fEditarPregunta(<%# Eval("idPreguntaVerificacion")%>);">Editar</a>                
                    </td>
                    <td align="center" style="width:60px">
                    <a id="lnkListarHallazgos" class="cLnkListarHallazgos" runat="server">Hallazgos</a>                
                    </td>   
                    </tr>

                    <tr class="RowStyle" id="ModoEdicion<%# Eval("idPreguntaVerificacion")%>" style="display:none">  
                         <td align="center" style="width:20px">                                                        
                            <asp:TextBox ID="txtIdPregunta" runat="server" Text='<%# Eval("idPreguntaVerificacion") %>' Width="20" ReadOnly=true/>
                         </td>   
                         <td align="left" style="width:200px">    
                            <asp:Literal ID="litDesPregunta2" runat="server" Text='<%# Eval("descripcionPregunta") %>' />                      
                         </td> 
                         <td align="center" style="width:50px">                          
                            <asp:CheckBox ID="chkRpta" runat="server"/>
                         </td> 
                         <td align="left" style="width:200px">    
                            <asp:TextBox ID="txtSustento" runat="server" Text='<%# Eval("sustento") %>' Width="200"/>
                         </td> 
                         <td align="center" style="width:80px">    
                            <asp:TextBox ID="txtPorcentaje" runat="server" Text='<%# Eval("porcentaje") %>' Width="80"/>%
                         </td>                     
                         <td align="center" style="width:60px"> 
                            <a id="lnkGrabarPregunta" class="cLnkGrabarPregunta" href="javascript:fGrabarPregunta(<%# Eval("idPreguntaVerificacion")%>);">Grabar</a>
                         </td> 
                         <td align="center" style="width:60px">
                            <a id="lnkCancelarPregunta" class="cLnkCancelarPregunta" href="javascript:fCancelarPregunta(<%# Eval("idPreguntaVerificacion")%>);">Cancelar</a>                
                         </td>
                     </tr>
                    </ItemTemplate>
                    <FooterTemplate>                                
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>                             

        </div>
    </div>
    <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;font-family:Arial;margin:10px 20px 0px 20px"> 
        <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;margin:5px 0px 5px 0px;"><asp:Literal ID="ltrTitulo" runat="server" Text="Datos de Hallazgos de la Pregunta :  "></asp:Literal></span>
        <span style="font-weight:bold;font-size:12px;font-family:Arial;float:left;width:70px;margin:5px 0px 5px 0px;" id="spanIdPregunta"></span>
        <div id="divHallazgos" style="margin:10px 0px 0px 0px;height:100%;width:100%;">        
          <asp:Repeater ID="rptHallazgos" runat="server" OnItemDataBound="rptHallazgos_ItemDataBound">
                    <HeaderTemplate>
                      <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;" width="100%">
                    <tr class="GridCab">
                        <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="litIdHallazgo" runat="server" Text="Nro"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:250px"><asp:Literal ID="litDescripcion" runat="server" Text="Descripcion"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litTipoHallazgos" runat="server" Text="Tipo"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:50px"><asp:Literal ID="litNdoc" runat="server" Text="N doc"></asp:Literal></td>                                            
                        <td align="center" style="border-color:#E9E9E9;width:50px"><asp:Literal ID="litDocumentos" runat="server" Text="Documentos"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="litEstado" runat="server" Text="Estado"></asp:Literal></td>                                            
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litEditar" runat="server" Text="Editar"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:60px"><asp:Literal ID="litQuitar" runat="server" Text="Quitar"></asp:Literal></td>
                    </tr>     
                    </HeaderTemplate>
                    <ItemTemplate>
                    <tr class="RowStyle" id="ModoVistaHallazgo<%# Eval("idHallazgo")%>">            
                    <td align="center" style="width:20px">
                        <asp:Literal ID="litIdHallazgo" runat="server" Text='<%# Eval("idHallazgo") %>' />
                    </td>
                    <td align="left" style="width:250px">                               
                         <asp:Literal ID="litDescripcion" runat="server" Text='<%# Eval("descripcion") %>' />                      
                    </td>
                    <td align="center" style="width:130px">
                          <asp:Literal ID="litTipoHallazgo" runat="server"/>
                    </td>
                    <td align="center" style="width:50px">
                     <asp:Literal ID="litNdoc" runat="server" Text='<%# Eval("ndoc") %>' />                
                    </td>
                    <td align="center" style="width:30px">               
                    <a id="lnkVerHallazgo" class="cLnkVerDocumentos" href="javascript:fVerArchivo(<%# Eval("idHallazgo")%>);">Ver</a>                
                    </td>
                    <td align="center" style="width:80px">
                        <asp:Literal ID="litEstado" runat="server" Text='<%# Eval("estado") %>' />                                  
                    </td>                   
                    <td align="center" style="width:60px">               
                    <a id="lnkEditarHallazgo" class="cLnkEditarHallazgo" runat="server" >Editar</a>
                    </td>
                    <td align="center" style="width:60px">
                    <a id="lnkQuitarHallazgo" class="cLnkQuitarHallazgo" runat="server" >Quitar</a>
                    </td>   
                    </tr>

                    <tr class="RowStyle" id="ModoEdicionHallazgo<%# Eval("idHallazgo")%>" style="display:none">  
                         <td align="center" style="width:20px">                                                        
                            <asp:TextBox ID="txtIdHallazgo" runat="server" Text='<%# Eval("idHallazgo") %>' ReadOnly=true Width="20px"></asp:TextBox>                     
                         </td>   
                         <td align="left" style="width:200px">                                                            
                            <asp:TextBox ID="txtDesHallazgo" runat="server" Text='<%# Eval("descripcion") %>' Width="250px"></asp:TextBox>                     
                         </td> 
                         <td align="center" style="width:130px">                          
                            <asp:DropDownList ID="ddlTipoHallazgo" runat="server" Width="130">
                              <asp:ListItem Value ="OBSERVACION">OBSERVACION</asp:ListItem>
                               <asp:ListItem Value ="NOCONFORMIDAD">NO CONFORMIDAD</asp:ListItem>
                               <asp:ListItem Value ="MEJORA">MEJORA</asp:ListItem>
                            </asp:DropDownList>             
                         </td> 
                           <td align="center" style="width:50px">
                         <asp:Literal ID="litNdoc2" runat="server" Text='<%# Eval("ndoc") %>' />                
                        </td>
                         <td align="center" style="width:30px">    
                            <a id="lnkAdjuntarHallazgo" class="cLnkVerDocumentos" href="javascript:fAdjuntarArchivo(<%# Eval("idHallazgo")%>);">Adjuntar</a>                
                         </td> 
                         <td align="center" style="width:80px">                                
                            <asp:Literal ID="litEstado2" runat="server" Text='<%# Eval("estado") %>' />                                    
                         </td>                     
                         <td align="center" style="width:60px"> 
                            <a id="lnkGrabarHallazgo" class="cLnkGrabarHallazgo" href="javascript:fGrabarHallazgo(<%# Eval("idHallazgo")%>);">Grabar</a>
                         </td> 
                         <td align="center" style="width:60px">
                            <a id="lnkCancelarHallazgo" class="cLnkCancelarHallazgo" href="javascript:fCancelarHallazgo(<%# Eval("idHallazgo")%>);">Cancelar</a>                
                         </td>
                     </tr>
                    </ItemTemplate>
                    <FooterTemplate>                        
                        <tr class="RowStyle" id="trNewRowHallazgo">            
                            <td align="center" style="width:30px">                            
                            <asp:TextBox ID="txtIdNewHallazgo" runat="server" Width="30" ReadOnly=true ></asp:TextBox>                     
                        </td>
                        <td align="left" style="width:250px">
                            <asp:TextBox ID="txtDesNewHallazgo" runat="server" Width="250" ></asp:TextBox>                      
                        </td>
                        <td align="left" style="width:130px">
                         <asp:DropDownList ID="ddlNewTipoHallazgo" runat="server" Width="130">
                              <asp:ListItem Value ="OBSERVACION">OBSERVACION</asp:ListItem>
                               <asp:ListItem Value ="NOCONFORMIDAD">NO CONFORMIDAD</asp:ListItem>
                               <asp:ListItem Value ="MEJORA">MEJORA</asp:ListItem>
                            </asp:DropDownList>    
                        </td>
                        <td align="center" style="width:50px">
                        </td>
                         <td align="center" style="width:30px">    
                            <a id="lnkAdjuntarHallazgo" class="cLnkVerDocumentos" href="javascript:fAdjuntarArchivo(0);">Adjuntar</a>                
                         </td> 
                        <td align="left" style="width:80px">
                        </td>
                        <td align="left" style="width:60px"> 
                            <a id="lnkAddHallazgo" href="javascript:fAgregarHallazgo();">Agregar</a>                           
                        </td>
                        <td align="left" style="width:60px">                                        
                        </td>                                                
                        </tr>                                                                    
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>           
        </div>
    </div>
</asp:Content>
