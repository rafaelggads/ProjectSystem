<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Equipamento_Cadastro.aspx.cs" Inherits="Apresentacao.Paginas.Equipamento_Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .auto-style3 {
            height: 21px;
            width: 330px;
        }
        .auto-style1 {
            height: 21px;
        }
        .auto-style5 {
            height: 26px;
        }
    .auto-style6 {
        height: 28px;
    }
        .auto-style7 {
            height: 29px;
        }
        .auto-style8 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td align="center" class="auto-style2" colspan="2" dir="rtl" style="font-family: 'Britannic Bold'; font-size: xx-large">Cadastro de Equipamento </td>
    </tr>
    <tr>
        <td class="auto-style3" dir="rtl">
            <asp:Label ID="Label1" runat="server" Text="Identificador"></asp:Label>
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtIdentificadorEquipamento" runat="server" Width="60px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">
            <asp:Label ID="Label2" runat="server" Text="Referencia"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtReferencia" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReferencia" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarCliente"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">
            <asp:Label ID="Label9" runat="server" Text="Descrição"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescricao" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarCliente"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">
            <asp:Label ID="Label3" runat="server" Text="Grupo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtGrupo" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">
            <asp:Label ID="Label5" runat="server" Text="Quantidade de Estoque"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtQuantidadeEstoque" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">
            <asp:Label ID="Label12" runat="server" Text="Data de Fabricação"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDataFabricacao" runat="server" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" dir="rtl">
            <asp:Label ID="Label10" runat="server" Text="Ultima Data de Revião"></asp:Label>
        </td>
        <td class="auto-style7">
            <asp:TextBox ID="txtUltimaDatadeRevisao" runat="server" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style8" dir="rtl">
            <asp:Label ID="Label11" runat="server" Text="Limite de Tempo para Manutenção"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="txtTempoManutencao" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5" dir="rtl">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="auto-style6" colspan="2" dir="rtl">
            <asp:Button ID="btnFechar" runat="server" Text="Fechar" Width="90px" OnClick="btnFechar_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="90px" OnClick="btnExcluir_Click" />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="90px" OnClick="btnSalvar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
