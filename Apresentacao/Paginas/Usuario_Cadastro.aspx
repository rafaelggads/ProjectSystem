<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario_Cadastro.aspx.cs" Inherits="Apresentacao.Paginas.Cadastro_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
    }
    .auto-style2 {
    }
    .auto-style3 {
        width: 322px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
    <tr>
        <td align="center" class="auto-style1" colspan="2" style="font-family: 'Britannic Bold'; font-size: xx-large">Cadastro de Usuário</td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="Identificador"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtIdentificador" runat="server" ReadOnly="True" Width="60px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNome" runat="server" Width="120px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label13" runat="server" Text="Sobrenome"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtSobrenome" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtSobrenome" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label5" runat="server" Text="Data de Nascimento"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDataNascimento" runat="server" TextMode="DateTime" Width="140px" MaxLength="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDataNascimento" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label4" runat="server" Text="Logradouro"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLogradouro" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLogradouro" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label9" runat="server" Text="CEP"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtCep" runat="server" MaxLength="8"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtCep" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label10" runat="server" Text="Bairro"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtBairro" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtBairro" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label11" runat="server" Text="Cidade"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtCidade" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtCidade" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label6" runat="server" Text="Telefone"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTelefone" runat="server" Width="120px" MaxLength="10" TextMode="Phone"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelefone" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label12" runat="server" Text="Perfil do Usuário"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlTipoUsuario" runat="server" Height="20px" Width="150px" DataTextField="Descricao" DataValueField="Identificador">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTipoUsuario" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label7" runat="server" Text="Login"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLogin" runat="server" Width="120px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLogin" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">
            <asp:Label ID="Label8" runat="server" Text="Senha"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtSenha" runat="server" Width="120px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSenha" ErrorMessage="* CAMPO OBRIGATÓRIO!" ForeColor="Red" ValidationGroup="SalvarUsuario"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="auto-style2" colspan="2">
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" ValidationGroup="SalvarUsuario" Width="90px" />
            <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir" Width="90px" />
            <asp:Button ID="btnFechar" runat="server" OnClick="btnFechar_Click" Text="Fechar" Width="90px" />
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
