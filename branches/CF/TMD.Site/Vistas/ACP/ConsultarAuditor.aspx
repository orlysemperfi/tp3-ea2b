<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarAuditor.aspx.cs" Inherits="TMD.ACP.Site.ConsultarAuditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
          
    <script type="text/javascript" src="js/jquery-1.8.3.js"></script>
    <script type="text/javascript">

    function fSaveData(){
        var sList = '';
        $('input[type=checkbox]').each(function () {
            if ($(this).val()!=''){
                if (this.checked) sList = (sList == "" ? $(this).val() : sList + "," + $(this).val());
            }
        });
        //parent.parent.setTimeout(function () { fListarAuditoresSeleccionados(sList); }, 1000)
        try { parent.parent.arrRefFunctions["auditor.refresh"](sList); } catch (e) { }
        window.parent.parent.CloseMultiPopup("keyConsultarAuditor");
    }

    </script>

</head>
<body>
    <form id="form1" runat="server">    
    <div style="margin:0px 10px 0px 10px">
        
        <div style="font-weight:bold;font-family:arial; font-size:14px; margin:5px 0px 5px 0px">LISTADO DE EMPLEADOS</div>
      
        <asp:Repeater ID="rptEmpleados" runat="server" 
            onitemdatabound="rptEmpleados_ItemDataBound" > 
            <HeaderTemplate >
            <table width="100%" border="1" style="border-bottom-color:#E9E9E9;border-collapse:collapse;">
                <tr class="GridCab">                  
                    <td align="center" style="border-color:#E9E9E9;width:10%"><asp:Literal ID="ltSeleccionar" runat="server" Text="Seleccionar"></asp:Literal>
                      
                    </td>
                    <td align="center" style="border-color:#E9E9E9;width:25%"><asp:Literal ID="ltNombres" runat="server" Text="Nombres"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:20%"><asp:Literal ID="ltApePaterno" runat="server" Text="Apellido Paterno"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:20%"><asp:Literal ID="ltApeMaterno" runat="server" Text="Apellido Materno"></asp:Literal></td>
                    <td align="center" style="border-color:#E9E9E9;width:25%;padding-right:5px"><asp:Literal ID="ltArea" runat="server" Text="Area"></asp:Literal></td>
                </tr>
             </HeaderTemplate>
            <ItemTemplate>
            <tr class="RowStyle">
            <td align="center">
                <input type="checkbox" id="chk<%# Eval("idEmpleado")%>" value="<%# Eval("idEmpleado")%>"  />               
            </td>
            <td align="left"><asp:Label ID="lblNombres" runat="server"></asp:Label></td>
            <td align="left"><asp:Label ID="lblApePaterno" runat="server"></asp:Label></td>
            <td align="left"><asp:Label ID="lblApeMaterno" runat="server"></asp:Label></td>
            <td align="left"><asp:Label ID="lblArea" runat="server"></asp:Label></td>
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
