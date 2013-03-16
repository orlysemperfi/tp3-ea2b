<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarEntidadAuditada.aspx.cs" Inherits="TMD.ACP.Site.ConsultarEntidadAuditada" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />        
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript">

        //*****************************************************************************
        //Enviar entidad auditada seleccionada al formulario padre y refrescar informacion
        //*****************************************************************************

        function fSaveData() {
            var sList = '';
            $('input[type=radio]').each(function () {
                if ($(this).val()!=''){
                    if (this.checked) sList = (sList == "" ? $(this).val() : sList + "," + $(this).val());
                }
            });
            if (sList == '') {
                alert('Seleccionar un proceso o proyecto a auditar');
            }
            else
            {
                try { parent.arrRefFunctions["entidadauditada.refresh"](sList); } catch (e) { }
                window.parent.CloseMultiPopup("keyConsultarEntidadAuditada");
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">    
    <div style="margin:0px 10px 0px 10px">    

        <asp:Repeater ID="rptEntidadAuditada" runat="server" 
            onitemdatabound="rptEntidadAuditada_ItemDataBound" > 
            <HeaderTemplate >
            <table width="100%" border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;">
                <tr class="GridCab">                                      
                    <td align="center" style="border-color:#E9E9E9;width:5%"><asp:Literal ID="ltNroEntAud" runat="server" Text="Nro"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:25%"><asp:Literal ID="ltEntiAud" runat="server" Text="Proceso/Proyecto"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:25%"><asp:Literal ID="ltArea" runat="server" Text="Area"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltCriticidad" runat="server" Text="Criticidad"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltRiesgo" runat="server" Text="Riesgo"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltAlcance" runat="server" Text="Alcance"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltNroSeguimiento" runat="server" Text="NroSeguimiento"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltNroAuditorias" runat="server" Text="NroAuditorias"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltPuntaje" runat="server" Text="Puntaje"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:6%"><asp:Literal ID="ltSeleccionar" runat="server" Text="Seleccionar"></asp:Literal></td>
                </tr>
             </HeaderTemplate>
            <ItemTemplate>
                <tr class="RowStyle">        
                    <td align="left"><asp:Label ID="lblNroEntAud" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblEntiAud" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblArea" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblCriticidad" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblRiesgo" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblAlcance" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblNroSeguimiento" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblNroAuditorias" runat="server"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblPuntaje" runat="server"></asp:Label></td>
                    <td align="center"><input type="radio" name="seleccionar" id="chk<%# Eval("IdEntidadAuditada")%>" value="<%# Eval("IdEntidadAuditada")%>"  /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
        </asp:Repeater>     
    </div>
    </form>
</body>
</html>
