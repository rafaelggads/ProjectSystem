<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario_View.aspx.cs" Inherits="Apresentacao.Paginas.Usuario_View" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1344px">
        </rsweb:ReportViewer>
    
    </div>
        <asp:ObjectDataSource ID="dtsUsuarioInstance" runat="server" SelectMethod="Listar" TypeName="Negocio.NUsuario">
            <SelectParameters>
                <asp:Parameter Name="parametro" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
