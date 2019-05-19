<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCliente.Master" AutoEventWireup="true" CodeBehind="Cliente_Alteracao_Senha.aspx.cs" Inherits="Apresentacao.Paginas.Cliente_Alteracao_Senha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
    }
    .auto-style2 {
        width: 313px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
    <tr>
        <td align="center" colspan="2" style="font-family: 'britannic Bold'; font-size: xx-large;">Alterar Senha Cliente</td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Codigo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="4" Width="70px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="102px" />
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="Login"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLogin" runat="server" ReadOnly="True" Width="180px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Senha"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSenha" runat="server" Width="180px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="auto-style1" colspan="2">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="120px" />
            <asp:Button ID="btnFechar" runat="server" Text="Fechar" Width="120px" />
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
