<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="ActListaVerificacion.aspx.cs" Inherits="TMD.ACP.Site.ActListaVerificacion" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
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
            if ($("#MainContent___IsView").val() == "1") {
                $("#btnGrabar").hide();             
            }
        });

        //*****************************************************************************

        function fCancelar() {
            window.location.href = "ListaVerificacion.aspx";
        }

        //********************************************************************
        function fGrabar() {
            window.setTimeout(function () { DoFormCallBack("GrabarListaVerificacion", null, End_fSaveData); }, 500)
        }

        //*****************************************************************************

        function End_fSaveData(arg) {
            var mData = arg.split(":::")
            if (mData[0] == "1") {
                alert("Se grabó la lista de verificación satisfactoriamente");
                window.location.href = "ListaVerificacion.aspx";
            }
        }
       
    </script>
    <asp:HiddenField id="__IdAuditoria" runat="server"/>
    <asp:HiddenField id="__IsView" runat="server" Value="0"/>

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

    <div style="border:solid 1px #C2C2C2;padding:10px 10px 10px 10px;font-family:Arial;margin:10px 20px 0px 20px;">
    <span style="padding:0px 10px 0px 10px">Preguntas Base:</span>
        <div id="divPreguntas" style="margin:10px 0px 10px 0px;height:100%;width:100%;">
    
            <asp:Repeater ID="rptPreguntas" runat="server">
                    <HeaderTemplate>
                      <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;" width="100%">
                    <tr class="GridCab">                                                              
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="Literal1" runat="server" Text="Norma"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="Literal2" runat="server" Text="Capitulo"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litDesPregunta" runat="server" Text="Pregunta"></asp:Literal></td>                        
                    </tr>     
                    </HeaderTemplate>
                    <ItemTemplate>
                    <tr class="RowStyle" id="ModeVista<%# Eval("idPreguntaBase")%>">                              
                    <td align="left" style="width:200px">                               
                         <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("descripcionNorma") %>' />                      
                    </td>                   
                    <td align="left" style="width:200px">                               
                         <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("descripcionCapitulo") %>' />                      
                    </td>                   
                    <td align="left" style="width:200px">                               
                         <asp:Literal ID="litDesPregunta" runat="server" Text='<%# Eval("descripcionPregunta") %>' />                      
                    </td>                   
                    </tr>                    
                    </ItemTemplate>
                    <FooterTemplate>                                
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>                             

        </div>
    </div>

     <div style="margin:10px 30px 10px 30px;height:100%;float:right;">        
        <input type="button" id="btnGrabar" value="Grabar" onclick="javascript:fGrabar();" class="TButton"/>
        <input type="button" id="btnCancelar" value="Cancelar" onclick="javascript:fCancelar();" class="TButton"/>
    </div>
</asp:Content>

