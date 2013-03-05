<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="TMD.ACP.Site.UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="color: #003399; font-family: Arial">
        <strong>Documentos Adjuntos</strong></span><br />
        <asp:FileUpload ID="fUpload" runat="server" />
        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Subir" /> <br />        
        <asp:RequiredFieldValidator ID="rvf" runat="server" ControlToValidate="fUpload" ErrorMessage="Por favor, Seleccione un archivo para la Carga!"></asp:RequiredFieldValidator>
        <br /> <br />
        <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" DataSourceID="odsArchivedFiles"
            OnRowCommand="gvFiles_RowCommand" PageSize="5" PagerSettings-Position="TopAndBottom"
            AllowPaging="True"
            CssClass="Grid" onrowdatabound="gvFiles_RowDataBound">
        <RowStyle CssClass ="RowStyle"/>
        <HeaderStyle CssClass ="GridCab"/>
        <PagerStyle CssClass ="GridPage" />
        <SelectedRowStyle  CssClass ="SelectedRow" />
            <Columns>
                <asp:BoundField DataField="idArchivo" HeaderText="N°" 
                    SortExpression="idArchivo" />
                <asp:BoundField DataField="nombreArchivo" HeaderText="Documento" 
                    SortExpression="nombreArchivo" />
                <asp:BoundField DataField="fechaCarga" HeaderText="Fec. Carga" 
                    SortExpression="fechaCarga" Visible="false" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDescarga" runat="server" CausesValidation="false" CommandName="Download" Text="Descargar"
                            CommandArgument='<%# Eval("idArchivo") %>'></asp:LinkButton>
                        <asp:LinkButton ID="lnkQuitar" runat="server" CausesValidation="false" CommandName="Quitar" Text="Quitar" OnClientClick="return confirm('¿Esta seguro de eliminar el documento adjunto?')"
                            CommandArgument='<%# Eval("idArchivo") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
            Registros No encontrados
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:Label ID="lblAuditoria" runat="server" Font-Names="Arial" Font-Size="10pt" Visible="false"></asp:Label>
        <asp:ObjectDataSource ID="odsArchivedFiles" runat="server" SelectMethod="SelectAll"
            TypeName="TMD.ACP.LogicaNegocios.Implementacion.ArchivoLogica">
            <SelectParameters>
                <asp:QueryStringParameter Name="idOrigen" QueryStringField="IdOrigen" DefaultValue="1"
                    Type="Int32" />
                <asp:QueryStringParameter Name="tipoOrigen" QueryStringField="TipoOrigen" DefaultValue="H"
                    Type="Char" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
  <%--  <p>
        Volver a <a id="lnkabc" runat="server" title="Hallazgos">Hallazgos Auditoria</a>.
    </p>--%>
    </form>
</body>
</html>
