<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Campo_Cadastro.aspx.cs" Inherits="Apresentacao.Paginas.Campo_Cadastro" %>
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
        height: 30px;
    }
    .auto-style7 {
        height: 29px;
    }
        .auto-style8 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td align="center" class="auto-style2" colspan="2" dir="rtl" style="font-family: 'Britannic Bold'; font-size: xx-large">Cadastro de Campo </td>
    </tr>
    <tr>
        <td class="auto-style3" dir="rtl">
            <asp:Label ID="Label1" runat="server" Text="Identificador"></asp:Label>
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtIdentificadorCampo" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style7" dir="rtl">
            <asp:Label ID="Label2" runat="server" Text="Descrição"></asp:Label>
        </td>
        <td class="auto-style7">
            <asp:TextBox ID="txtDescricao" runat="server" Width="263px" Height="18px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescricao" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarCampo"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style8" dir="rtl">
            <asp:Label ID="Label9" runat="server" Text="Comprimento"></asp:Label>
        </td>
        <td class="auto-style8">
            <asp:TextBox ID="txtComprimento" runat="server" Width="83px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5" dir="rtl">
            <asp:Label ID="Label3" runat="server" Text="Largura"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:TextBox ID="txtLargura" runat="server" Width="85px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5" dir="rtl">
            <asp:Label ID="Label5" runat="server" Text="Quantidade de Obstaculos"></asp:Label>
        </td>
        <td class="auto-style5">
            <asp:TextBox ID="txtQtdObstaculos" runat="server" Width="62px"></asp:TextBox>
        &nbsp;
            <asp:Label ID="Label10" runat="server" Text="Valor Hora"></asp:Label>
&nbsp;<asp:TextBox ID="txtValorHora" runat="server" Height="16px" Width="116px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5" dir="rtl">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="auto-style6" colspan="2" dir="rtl">
            <asp:Button ID="btnFechar" runat="server" Text="Fechar" Width="90px" OnClick="btnFechar_Click" Height="26px" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="90px" OnClick="btnExcluir_Click" Height="26px"/>
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="90px" OnClick="btnSalvar_Click" Height="26px"  />
        </td>
    </tr>
    <tr>
        <td class="auto-style4" dir="rtl">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
