using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidade;

namespace Apresentacao.Paginas
{
    public partial class Cliente_Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NPessoa nUsuario = new NPessoa();

            try
            {
                string controleTela = string.Empty;
                if (!Page.IsPostBack)
                {
                    controleTela = "inserir";

                    if (Page.Request.QueryString["Id"] != null)
                    {
                        CarregarTelaUsuario();
                        controleTela = "alterar";
                    }
                }

                PrepararTela(controleTela);
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                EPessoa usuario = new EPessoa();
                if (!string.IsNullOrEmpty(txtIdentificador.Text))
                    usuario.Identificador = int.Parse(txtIdentificador.Text);

                usuario.nome = txtNome.Text;
                usuario.dataDeNascimento = DateTime.Parse(txtDataNascimento.Text);
                usuario.sobrenome = TxtSobrenome.Text;
                usuario.email = txtEmail.Text;
                usuario.telefone = txtTelefone.Text;
                usuario.logradouro = txtLogradouro.Text;
                usuario.cep = TxtCep.Text;
                usuario.bairro = TxtBairro.Text;
                usuario.cidade = TxtCidade.Text;
                usuario.TipoUsuario.Identificador = int.Parse(ddlTipoCliente.SelectedValue);
                usuario.login = txtLogin.Text;
                usuario.senha = txtSenha.Text;

                NPessoa nUsuario = new NPessoa();
                nUsuario.Salvar(usuario);
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Cadastro de Cliente",
                    "alert('Operação realizada com sucesso!')", true);

                Response.Redirect(@"~\TelaLogin.aspx");

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Cadastro de Cliente"
                    , "alert('" + mensagem + "')", true);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                NPessoa nUsuario = new NPessoa();
                nUsuario.Excluir(int.Parse(txtIdentificador.Text));
                Response.Redirect(@"~\Paginas\Usuario_Lista.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                VoltarParaPaginaAnterior();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void PrepararTela(string controle)
        {
            if (controle == "inserir")
            {
                btnExcluir.Enabled = false;
            }
            else
            {
                btnExcluir.Enabled = true;
            }
        }
        protected void CarregarTelaUsuario()
        {
            NPessoa nUsuario = new NPessoa();
            EPessoa eUsuario = new EPessoa();
            int idUsuario = Convert.ToInt32(Page.Request.QueryString["Id"].ToString());

            eUsuario = nUsuario.Consultar(idUsuario);

            txtIdentificador.Text = eUsuario.Identificador.ToString();
            txtNome.Text = eUsuario.nome;
            TxtSobrenome.Text = eUsuario.sobrenome;
            TxtCep.Text = eUsuario.cep;
            TxtCidade.Text = eUsuario.cidade;
            TxtBairro.Text = eUsuario.bairro;
            ddlTipoCliente.SelectedValue = eUsuario.TipoUsuario.Identificador.ToString();
            txtLogradouro.Text = eUsuario.logradouro;
            txtDataNascimento.Text = Convert.ToDateTime(eUsuario.dataDeNascimento).ToString();
            txtEmail.Text = eUsuario.email;
            txtTelefone.Text = eUsuario.telefone;
            txtLogin.Text = eUsuario.login;
            txtSenha.Text = eUsuario.senha;

        }
        private void VoltarParaPaginaAnterior()
        {
            Response.Redirect(@"~\TelaLoginCliente.aspx");
        }
    }
}