<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Campo_Listar.aspx.cs" Inherits="Apresentacao.Paginas.Campo_Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

    .auto-style2 {
        width: 187px;
    }
        .auto-style3 {
            width: 187px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
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
        <td align="right" class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="Filtro :"></asp:Label>
        </td>
        <td class="auto-style4">
            <asp:TextBox ID="txtBusca" runat="server" Width="250px"></asp:TextBox>
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
            <asp:GridView ID="grdListaCampo" runat="server" AutoGenerateColumns="False" CellPadding="4" EmptyDataText="Nenhum Campo encontrado para os parâmetros informados." GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="Identificador" DataNavigateUrlFormatString="~\Paginas\Campo_Cadastro.aspx?Id={0}" DataTextField="Identificador" HeaderText="Identificador" />
                    <asp:BoundField DataField="descricao" HeaderText="Descricao" />
                    <asp:BoundField DataField="comprimento" HeaderText="Comprimento" />
                    <asp:BoundField DataField="largura" HeaderText="Largura" />
                    <asp:BoundField DataField="qtdObstaculos" HeaderText="Quatidade de Obstaculos" />
                    <asp:BoundField DataField="valorHora" HeaderText="Valor da Hora" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="right" class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
