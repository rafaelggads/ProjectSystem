<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario_Lista.aspx.cs" Inherits="Apresentacao.Paginas.Usuario_Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
    }
    .auto-style2 {
        width: 187px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
    <tr>
        <td align="right" class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNome" runat="server" Width="250px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Width="120px" />
            <asp:Button ID="btnAdicionar" runat="server" OnClick="btnAdicionar_Click" Text="Adicionar" Width="120px" />
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="center" class="auto-style1" colspan="2">
            <asp:GridView ID="grdListaUsuario" runat="server" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="Nenhum usuário encontrado para os parâmetros informados." ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdListaUsuario_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Identificador" DataNavigateUrlFormatString="~\Paginas\Usuario_Cadastro.aspx?Id={0}" DataTextField="Identificador" HeaderText="Identificador" />
                    <asp:BoundField DataField="nome" HeaderText="Nome do Usuário" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                    <asp:BoundField DataField="login" HeaderText="Login" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
