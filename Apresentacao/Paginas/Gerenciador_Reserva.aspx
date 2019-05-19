<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gerenciador_Reserva.aspx.cs" Inherits="Apresentacao.Paginas.Gerenciador_Reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="67px" Width="437px">
                    <Columns>
                        <asp:BoundField DataField="identificador" HeaderText="Codigo" />
                        <asp:BoundField HeaderText="Data da Reserva" />
                        <asp:BoundField HeaderText="Cliente" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
