<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaActSeguimientoHallazgo.aspx.cs" Inherits="TMD.ACP.Site.ListaActSeguimientoHallazgo" EnableViewState="false" ValidateRequest="false" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
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
        
        $(document).ready(function () {
            
        });
        
        //*****************************************************************************

        function fSeleccionar(id) {            
            window.location.href = "ActualizarSeguimientoHallazgo.aspx?idHallazgo=" + id;
        }

        //*****************************************************************************                
     </script>
     <asp:HiddenField id="__IdAuditoria" runat="server"/>
     <div style="margin:0px 0px 0px;padding:0px 0px 0px 0px"><a href="#" style="color:black">Auditoría</a> / <a href="#" style="color:black">ACTUALIZAR SEGUIMIENTO DE HALLAZGOS</a></div>
     <div style="text-align:center; font-size: 1.5em;color: #666666;font-variant: small-caps;text-transform: none;font-weight: 200;margin-top: 10px;">ACTUALIZAR SEGUIMIENTO A LOS HALLAZGOS DE AUDITORÍA</div>
   
    <div style="padding:5px 10px 5px 10px;height:15px;font-family:Arial;">
        <div style="float:left">
            <label>Periodo:</label><asp:Literal ID="litPeriodo" runat="server"></asp:Literal>
        </div>        
    </div>    
    <div style="float:left; width:100%;">
    <div id="divHallazgos" style="margin:10px 0px 10px 0px;height:100%;width:100%;">
    
            <asp:Repeater ID="rptHallazgos" runat="server" OnItemDataBound="rptHallazgos_ItemDataBound">
                    <HeaderTemplate>
                      <table border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;" width="100%">
                    <tr class="GridCab">                                      
                        <td align="center" style="border-color:#E9E9E9;width:20px"><asp:Literal ID="litIdHallazgo" runat="server" Text="Nro"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="litIdAuditoria" runat="server" Text="Auditoría"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litDescripcionPregunta" runat="server" Text="Descripción de Pregunta"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:200px"><asp:Literal ID="litDescripcion" runat="server" Text="Descripción de Hallazgo"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="litTipoHallazgo" runat="server" Text="Tipo"></asp:Literal></td>                        
                        <td align="center" style="border-color:#E9E9E9;width:120px"><asp:Literal ID="litResponsable" runat="server" Text="Responsable Seguimiento"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:110px"><asp:Literal ID="litFechaSeguimiento" runat="server" Text="Fec. Seguimiento"></asp:Literal></td>                    
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="litEstado" runat="server" Text="Estado"></asp:Literal></td>
                        <td align="center" style="border-color:#E9E9E9;width:80px"><asp:Literal ID="litSeleccionar" runat="server" Text="Seleccionar"></asp:Literal></td>                        
                    </tr>     
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="RowStyle">            
                        <td align="center" style="width:20px">
                            <asp:Literal ID="litIdHallazgo" runat="server"/>
                        </td>
                         <td align="center" style="width:80px">
                            <asp:Literal ID="litIdAuditoria" runat="server"/>
                        </td>
                        <td align="left" style="width:200px">                               
                             <asp:Literal ID="litDescripcionPregunta" runat="server"/>                      
                        </td>
                        <td align="left" style="width:200px">                               
                             <asp:Literal ID="litDescripcion" runat="server"/>                      
                        </td>
                         <td align="left" style="width:120px">                               
                             <asp:Literal ID="litTipoHallazgo" runat="server"/>                      
                        </td>                      
                        <td align="left" style="width:120px">
                         <asp:Literal ID="litResponsable" runat="server"/>                
                        </td>
                        <td align="center" style="width:110px">
                            <asp:Literal ID="litFechaSeguimiento" runat="server"/>                                    
                        </td>                   
                        <td align="center" style="width:80px">
                            <asp:Literal ID="litEstado" runat="server"/>                                    
                        </td>  
                        <td align="center" style="width:80px">
                        <a id="lnkSeleccionar" class="cLnkSeleccionar" href="javascript:fSeleccionar(<%# Eval("idHallazgo")%>);">Seleccionar</a>                
                        </td>                                           
                        </tr>            
                    </ItemTemplate>
                    <FooterTemplate>                                
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>                             
        </div>
    </div>
  </asp:Content>