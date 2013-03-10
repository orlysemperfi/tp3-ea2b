<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubirArchivoSolicitudCambio.ascx.cs" Inherits="TMD.CF.Site.Controles.SubirArchivoSolicitudCambio" %>


<p>
    Subir Archivo Solicitud Cambio</p>
<p>
    Archivo</p>
<p>
    <asp:FileUpload ID="fileUpArchivo" runat="server" />
</p>
<p>
        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" 
            ValidationGroup="GrabarValidationGroup" 
            OnClientClick="javascript: return grabar();" onclick="btnGrabar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />&nbsp;</p>
&nbsp;<asp:HiddenField ID="hidIdSolicitud" runat="server" />
</p>
<script type="text/javascript" language="javascript">
    function grabar() {
        if (Page_ClientValidate('GrabarValidationGroup')) {
            Page_BlockSubmit = false;
            return confirm('Desea grabar los datos ingresados?');
        }
        Page_BlockSubmit = false;
        return false;
    }
</script>


