<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reserva_Cadastro.aspx.cs" Inherits="Apresentacao.Paginas.Reserva_Cadastro1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #Text1 {
            width: 183px;
        }
        .auto-style1 {
        }
        .auto-style2 {
        }
        .auto-style4 {
            width: 326px;
        }

        .auto-style5 {
            width: 326px;
            height: 25px;
        }
        .auto-style6 {
            width: 348px;
            height: 25px;
        }
        .auto-style7 {
            height: 25px;
        }

    .auto-style8 {
        width: 326px;
        height: 21px;
    }
    .auto-style9 {
        width: 348px;
        height: 21px;
    }
    .auto-style10 {
        height: 21px;
    }

        .auto-style11 {
            width: 326px;
            height: 29px;
        }
        .auto-style12 {
            width: 348px;
            height: 29px;
        }
        .auto-style13 {
            height: 29px;
        }

        .auto-style14 {
            width: 348px;
            margin-left: 80px;
        }

        .auto-style15 {
            width: 326px;
            height: 26px;
        }
        .auto-style16 {
            width: 348px;
            height: 26px;
            margin-left: 80px;
        }
        .auto-style17 {
            height: 26px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td align="center" colspan="3" style="font-family: 'Britannic Bold'; font-size: xx-large">
                Reservas </td>
        </tr>
        <tr>
            <td align="right" class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Identificador"></asp:Label>
            </td>
            <td align="left" class="auto-style6">
            <asp:TextBox ID="txtIdentificadorReserva" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
            </td>
            <td align="right" class="auto-style7"></td>
        </tr>
        <tr>
            <td align="right" class="auto-style5">
                <asp:Label ID="Label3" runat="server" Text="Reservar para"></asp:Label>
            </td>
            <td class="auto-style14" >



                <asp:TextBox ID="txtDatadaReserva" runat="server" ViewStateMode="Enabled" Height="16px" TextMode="Date" Width="150px" TabIndex="1"  ></asp:TextBox>
                

                </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td align="right" class="auto-style15">
                <asp:Label ID="Label9" runat="server" Text="Cliente"></asp:Label>
            </td>
            <td class="auto-style16">
                <asp:DropDownList ID="ddlCliente" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataTextField="Nome" DataValueField="Identificador" Height="25px" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" Width="336px" TabIndex="2">
                </asp:DropDownList>

                
            </td>
            <td class="auto-style17"></td>
        </tr>
        <tr>
            <td align="right" class="auto-style5">
                <asp:Label ID="Label10" runat="server" Text="Campo"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddlCampo" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataTextField="Descricao" DataValueField="Identificador" Height="20px" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" Width="336px" TabIndex="3">
                </asp:DropDownList>
                </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td align="right" class="auto-style11">
                <asp:Label ID="Label5" runat="server" Text="Quantidade de Horas"></asp:Label>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="txtQuantidadeHoras" runat="server" Width="49px" OnTextChanged="txtQuantidadeHoras_TextChanged" TabIndex="4"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Text="Valor da Hora"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txtValorHora" runat="server" Width="88px" TabIndex="5"></asp:TextBox>
            </td>
            <td class="auto-style13"></td>
        </tr>
        <tr>
            <td align="right" class="auto-style4">
                <asp:Label ID="Label2" runat="server" Text="Valor Total"></asp:Label>
            </td>
            <td class="auto-style14">
                <asp:TextBox ID="txtValorTotal" runat="server" Width="69px" OnUnload="txtValorTotal_Unload" TabIndex="6"></asp:TextBox>
            &nbsp;<asp:Label ID="Label11" runat="server" Text="Data de Cadastro"></asp:Label>
            &nbsp;<asp:TextBox ID="txtData" runat="server" Height="16px" Width="142px" TextMode="Date" TabIndex="7"></asp:TextBox>
            &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style9"></td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td align="center" class="auto-style1" colspan="3">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="90px" OnClick="btnSalvar_Click" Height="26px" style="margin-bottom: 0px" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="90px" OnClick="btnExcluir_Click" Height="26px" />
                <asp:Button ID="btnFechar" runat="server" Text="Fechar" Width="90px" OnClick="btnFechar_Click" Height="26px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="3">
        
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
