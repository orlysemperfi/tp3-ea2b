<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenerHallazgo.aspx.cs" Inherits="TMD.ACP.Site._MantenerHallazgo" %>
<%--EnableViewState="false" ValidateRequest="false" EnableEventValidation="false"--%>
 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />    
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="js/global.js"></script>

    <script type="text/javascript">

        function openPopup(strOpen) {
            open(strOpen, "Info",
         "status=1, width=500, height=500, top=100, left=50");
        }

        function toogle() {

            lnk = document.getElementById("lnkAdjuntar");
//            alert(lnk);
            if (lnk.style.display == "none") {
                lnk.style.display = "block";
            }
        }

        function CheckSatus(idfila) {
            chkRpta = document.getElementById("gvPreguntaVerif_chkRpta_" + idfila);
            cboPorc = document.getElementById("gvPreguntaVerif_cboPorc_" + idfila);
            
            if (chkRpta.checked) {
                cboPorc.disabled = false;
            } else {
                cboPorc.disabled = true;
                cboPorc.value = "0";
            }

        }

        function validarPreguntas(idfila) {

            txtsustento = document.getElementById("gvPreguntaVerif_txtSustento_" + idfila);
            chkRpta = document.getElementById("gvPreguntaVerif_chkRpta_" + idfila);
            cboPorc = document.getElementById("gvPreguntaVerif_cboPorc_" + idfila);

            if (txtsustento.value == "") {
                alert('Ingrese una descripción para el Sustento');
                txtsustento.focus(); return false;
            }

            if (chkRpta.checked && cboPorc.value == "0") {
                alert('El porcentaje no puede ser 0');
                cboPorc.focus(); return false;
            } 
        }

        function validarHallazgos(opc, idfila) {
            
            txtDescrip = document.getElementById("gvHallazgo_txtDesHallazgo_" + idfila);
            if (opc==2 &&  txtDescrip.value == "") {
                alert('Ingrese una descripción para el Hallazgo');
                txtDescrip.focus();return false;
            }

            txtDescrip2 = document.getElementById("gvHallazgo_txtNewDesHallazgo");
            if (opc == 3 && txtDescrip2.value == "") {
                alert('Ingrese una descripción para el Hallazgo');
                txtDescrip2.focus(); return false;
            }

//            cboTipo = document.getElementById("cbotipo");
//            if (opc == 2 && cboTipo.value == "") {
//                alert('Seleccione un Tipo de Hallazgo');
//                txtDescrip.focus(); return false;
//            }
//            cboTipo = document.getElementById("cboNewTipo");
//            if (opc == 3 && cboTipo.value == "") {
//                alert('Seleccione un Tipo de Hallazgo');
//                txtDescrip.focus(); return false;
//            }
            return confirm('¿Está seguro de que desea realizar la transacción?')
        }

//        $(document).ready(function () {

//            ShowPopupBox();
//           
//        });

//        $('#btnClose').click(function () {
//            HidePopupBox();
//        });

//        $('#MainPage').click(function () {
//            HidePopupBox();
//        });

//        function HidePopupBox() {    // TO Hide PopupBox
//            $('#PopupDiv').fadeOut("slow");
//            $("#MainPage").css({ // this is just for style       
//                "opacity": "1"
//            });
//        }

//        function ShowPopupBox() {    // To   Show PopupBox
//            $('#PopupDiv').fadeIn("slow");
//            $("#MainPage").css({ // this is just for style
//                "opacity": "0.3"
//            });
//        }


    </script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <h1 style="text-align:center">Hallazgos de Auditoria</h1>
        <div style="border:solid 1px black;padding:10px 10px 10px 10px;height:50px;font-family:Arial;margin:10px 20px 0px 20px">
        <div style="float:left">
            <label>Proceso o Proyecto: </label><asp:Label ID="lblDescrip" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label><br />
            <label>Area: </label><asp:Label ID="lblArea" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label><br />
            <label>Jefe de Proceso: </label><asp:Label ID="lblResponsable" runat="server"  Font-Names="Arial" Font-Size="10pt"></asp:Label><br />           
        </div>
         <div style="float:right">
            Nro:<label style="font-weight:bold;"><asp:Label ID="lblAuditoria" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></label></br>      
         </div>
         </div>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="padding:10px 10px 10px 10px;height:30px;font-family:Arial;font-weight:bold">  

                    <span style="padding:0px 10px 0px 10px">Datos de la Lista de Verificación</span><br /> <br />
                    <span style="padding:0px 10px 0px 10px">Norma:</span>
                    <span id="spanCboNorma" style="padding:0px 10px 0px 10px">
                    <asp:DropDownList ID="cboNorma" runat="server" Width="30%" Font-Names="Arial" 
                    Font-Size="10pt" onselectedindexchanged="cboNorma_SelectedIndexChanged" 
                        AutoPostBack="True" ></asp:DropDownList>
                    </span>
                    <span style="padding:0px 10px 0px 10px">Capítulo:</span>
                    <span id="spanCboCap" style="padding:0px 10px 0px 10px">
                        <asp:DropDownList ID="cboCapitulo" runat="server" Width="40%" Font-Names="Arial" 
                    Font-Size="10pt" onselectedindexchanged="cboCapitulo_SelectedIndexChanged" 
                        AutoPostBack="True" ></asp:DropDownList>
                    </span>    
        </div>
        <br /> <br />

        <div id="divGvPregunta">
        <asp:GridView ID="gvPreguntaVerif" runat="server" 
        AutoGenerateColumns="false"
        Caption="Preguntas:" 
        CssClass="Grid"
        Width="100%" 
        onrowdatabound="gvPreguntaVerif_RowDataBound" 
        onrowcommand="gvPreguntaVerif_RowCommand"
        DataKeyNames="idPreguntaVerificacion" 
        onrowcancelingedit="gvPreguntaVerif_RowCancelingEdit" 
        onrowupdating="gvPreguntaVerif_RowUpdating" 
                onrowediting="gvPreguntaVerif_RowEditing" 
            >
            <RowStyle CssClass ="RowStyle"/>
            <HeaderStyle CssClass ="GridCab"/>
            <PagerStyle CssClass ="GridPage" />
            <SelectedRowStyle  CssClass ="SelectedRow" />

            <Columns>
                <asp:TemplateField HeaderText="Nro" >
                    <ItemTemplate><asp:Literal ID="ltrlIdPreg" runat="server" /></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pregunta" >
                    <ItemTemplate><asp:Literal ID="ltrlDesPreg" runat="server" /></ItemTemplate>
                    <ItemStyle Width="30%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cumple" >
                    <ItemTemplate><asp:Literal ID="ltrlRpta" runat="server" /></ItemTemplate>
                    <EditItemTemplate>
                    <asp:CheckBox ID="chkRpta" runat="server" EnableViewState="false"/>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sustento" >
                    <EditItemTemplate> 
                    <asp:TextBox ID="txtSustento" runat="server" Width="100%" ></asp:TextBox>                     
                    </EditItemTemplate> 
                    <ItemTemplate><asp:Literal ID="ltrlSustento" runat="server" /></ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Porcentaje"> 
                    <ItemTemplate> <asp:Label ID="lblPorc" runat="server"></asp:Label> </ItemTemplate> 
                    <EditItemTemplate> 
                        <asp:DropDownList ID="cboPorc" runat="server" Enabled="false"> 
                        <asp:ListItem Value ="100">100%</asp:ListItem>
                        <asp:ListItem Value ="75">75%</asp:ListItem>
                        <asp:ListItem Value ="50">50%</asp:ListItem>
                        <asp:ListItem Value ="25">25%</asp:ListItem>
                        <asp:ListItem Value ="0">0%</asp:ListItem>
                        </asp:DropDownList> 
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="" ShowHeader="False" > 
                    <EditItemTemplate> 
                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="false" CommandName="Update" Text="Guardar"></asp:LinkButton> 
                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton> 
                    </EditItemTemplate> 
                    <ItemTemplate> 
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>                     
                    </ItemTemplate> 
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField> 

                <%--<asp:ButtonField CommandName="Hallazgo" Text="Hallazgo" HeaderText="" >
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:ButtonField>--%>
                <asp:TemplateField HeaderText="" ShowHeader="False"> 
                    <ItemTemplate> 
                    <asp:LinkButton ID="lnkHallazgo" runat="server" CausesValidation="False" CommandName="Hallazgo" Text="Hallazgo" CommandArgument='<%# Eval("idPreguntaVerificacion")%>'></asp:LinkButton>                              
                    </ItemTemplate> 
                    <EditItemTemplate>                       
                    </EditItemTemplate>
                     <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        </div>

    <br />
    
    <div id="divGvHallazgo" style="margin:0px 10px 0px 10px">
    <asp:GridView ID="gvHallazgo" runat="server" 
    AutoGenerateColumns="false"  ShowFooter="True"
    CssClass="Grid" onrowdatabound="gvHallazgo_RowDataBound" 
            onrowcancelingedit="gvHallazgo_RowCancelingEdit" 
            onrowdeleting="gvHallazgo_RowDeleting" 
            onrowediting="gvHallazgo_RowEditing" onrowupdating="gvHallazgo_RowUpdating" onrowcommand="gvHallazgo_RowCommand"    
    DataKeyNames="IdHallazgo"
    > 
        <RowStyle CssClass ="RowStyle"/>
        <HeaderStyle CssClass ="GridCab"/>
        <PagerStyle CssClass ="GridPage" />
        <SelectedRowStyle  CssClass ="SelectedRow" />

        <Columns>

        <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Left"> 
            <EditItemTemplate> <asp:Literal ID="lblId" runat="server" /></EditItemTemplate> 
            <ItemTemplate> <asp:Literal ID="lblId" runat="server" /></ItemTemplate> 
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Descripción Hallazgo" HeaderStyle-HorizontalAlign="Left"> 
            <EditItemTemplate> 
                <asp:TextBox ID="txtDesHallazgo" runat="server" ></asp:TextBox> 
            </EditItemTemplate> 
            <FooterTemplate> 
                <asp:TextBox ID="txtNewDesHallazgo" runat="server" Visible="false" ></asp:TextBox> 
            </FooterTemplate> 
            <ItemTemplate> 
                <asp:Literal ID="lblDesHallazgo" runat="server" ></asp:Literal> 
            </ItemTemplate> 
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tipo" HeaderStyle-HorizontalAlign="Left"> 
            <EditItemTemplate> 
                <asp:DropDownList ID="cbotipo" runat="server"> 
                <asp:ListItem Value ="OBSERVACION">OBSERVACION</asp:ListItem>
                <asp:ListItem Value ="NOCONFORMIDAD">NO CONFORMIDAD</asp:ListItem>
                <asp:ListItem Value ="MEJORA">MEJORA</asp:ListItem>
                </asp:DropDownList> 
            </EditItemTemplate> 
            <ItemTemplate> 
                <asp:Literal ID="lblTipo" runat="server"></asp:Literal> 
            </ItemTemplate> 
            <FooterTemplate> 
                <asp:DropDownList ID="cboNewTipo" runat="server" Visible="false"> 
                <asp:ListItem Value ="OBSERVACION">OBSERVACION</asp:ListItem>
                <asp:ListItem Value ="NOCONFORMIDAD">NO CONFORMIDAD</asp:ListItem>
                <asp:ListItem Value ="MEJORA">MEJORA</asp:ListItem>
                </asp:DropDownList> 
            </FooterTemplate> 
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="N° Doc"  HeaderStyle-HorizontalAlign="Center"> 
            <ItemTemplate> <asp:Literal ID="lblCantDoc" runat="server"/></ItemTemplate> 
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Documentos" >            
            <ItemTemplate> 
                <a id="lnkVer" href="javascript:openPopup('UploadFile.aspx?idOrigen=<%# Eval("IdHallazgo") %>&tipoOrigen=H&nIdAuditoria=<%# Eval("IdAuditoria") %>&nOpcion=1')">Ver</a>
            </ItemTemplate> 
            <EditItemTemplate> 
                <a id="lnkVer" href="javascript:openPopup('UploadFile.aspx?idOrigen=<%# Eval("IdHallazgo") %>&tipoOrigen=H&nIdAuditoria=<%# Eval("IdAuditoria") %>&nOpcion=2')">Adjuntar</a>
            </EditItemTemplate> 
            <FooterTemplate> 
                <a id="lnkAdjuntar" runat="server" onclick="javascript:openPopup('UploadFile.aspx?idOrigen=0&tipoOrigen=H&nIdAuditoria=0&nOpcion=3)"  style='display:none'>Adjuntar</a>
            </FooterTemplate> 
            <ItemStyle HorizontalAlign="Center" Width="10%" />

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Estado" >
        <ItemTemplate><asp:Literal ID="lblEstado" runat="server" /></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
            <EditItemTemplate> 
                <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="false" CommandName="Update" Text="Guardar" ></asp:LinkButton> 
                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton> 
            </EditItemTemplate> 
            <FooterTemplate> 
                <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Agregar" Text="Agregar" ></asp:LinkButton>
                <asp:LinkButton ID="lnkGrabar" runat="server" CausesValidation="false" CommandName="Insert" Text="Grabar" Visible="false" ></asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" Visible="false"></asp:LinkButton> 
            </FooterTemplate> 
            <ItemTemplate> 
                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
            </ItemTemplate> 
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Center" Width="10%" />
        </asp:TemplateField> 

        <asp:CommandField HeaderText="" ShowDeleteButton="True" ShowHeader="True" 
                ItemStyle-HorizontalAlign="Center" > 
        
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        
        </Columns>

    </asp:GridView>
    
    <br /><br />
    
</ContentTemplate>
</asp:UpdatePanel>

    <asp:ObjectDataSource ID="odsAuditoria" runat="server" SelectMethod="SelectAll"
    TypeName="TMD.ACP.LogicaNegocios.Implementacion.AuditoriaLogica">
    <SelectParameters>
    <asp:QueryStringParameter Name="idAuditoria" QueryStringField="IdAuditoria" DefaultValue="1"
        Type="Int32" />
    </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="Red"
    Width="496px"></asp:Label><br />
    </div>



    
    </form>
</body>
</html>

