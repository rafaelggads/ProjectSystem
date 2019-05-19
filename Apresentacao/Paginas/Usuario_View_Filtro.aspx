<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario_View_Filtro.aspx.cs" Inherits="Apresentacao.Paginas.Usuario_View_Filtro" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 256px;
        }
        .auto-style2 {
            width: 256px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style2" dir="rtl"></td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1" dir="rtl">
                    <asp:Label ID="Label1" runat="server" Text="Consultar Por"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipoConsulta" runat="server" Width="157px">
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="1">Nome</asp:ListItem>
                        <asp:ListItem Value="2">Login</asp:ListItem>
                        <asp:ListItem Value="3">Email</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtParametro" runat="server" Width="260px"></asp:TextBox>
                    <asp:Button ID="btnGerarRelatorio" runat="server" OnClick="btnGerarRelatorio_Click" Text="Gerar Relatório" Width="208px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1" dir="rtl">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="rptUsuario" runat="server" Height="532px" Width="1342px">
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="dtsUsuario" runat="server" SelectMethod="Listar" TypeName="Negocio.NUsuario">
            <SelectParameters>
                <asp:Parameter Name="parametro" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
