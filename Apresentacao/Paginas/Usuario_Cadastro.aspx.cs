using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade;
using Negocio;

namespace Apresentacao.Paginas
{
    public partial class Cadastro_Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NPessoa nUsuario = new NPessoa();
       
            try
            {
                string controleTela = string.Empty;
                if (!Page.IsPostBack)
                {
                    CarregarTipoUsuario();
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
                usuario.TipoUsuario.Identificador = int.Parse(ddlTipoUsuario.SelectedValue);
                usuario.login = txtLogin.Text;
                usuario.senha = txtSenha.Text;

                NPessoa nUsuario = new NPessoa();
                nUsuario.Salvar(usuario);
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Cadastro de Usuário",
                    "alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Cadastro de Usuário"
                    , "alert('" + mensagem + "')", true);
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

        protected void CarregarTipoUsuario()
        {
            NTipoUsuario nTipoAssociado = new NTipoUsuario();
            List<ETipoUsuario> lstRetorno = new List<ETipoUsuario>();

            lstRetorno = nTipoAssociado.Listar();
            //Limpar a dropdownlist
            ddlTipoUsuario.Items.Clear();

            //Cria o item do "Selecionar..."
            ListItem Selecionar = new ListItem();
            Selecionar.Value = "0";
            Selecionar.Text = "Selecione...";
            ddlTipoUsuario.Items.Add(Selecionar);

            //Preenche a dropdownlist
            ddlTipoUsuario.DataSource = lstRetorno;
            ddlTipoUsuario.DataBind();

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
            ddlTipoUsuario.SelectedValue = eUsuario.TipoUsuario.Identificador.ToString();
            txtLogradouro.Text = eUsuario.logradouro;
            txtDataNascimento.Text = Convert.ToDateTime(eUsuario.dataDeNascimento).ToString();
            txtEmail.Text = eUsuario.email;
            txtTelefone.Text = eUsuario.telefone;
            txtLogin.Text = eUsuario.login;
            txtSenha.Text = eUsuario.senha;

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                NPessoa nUsuario = new NPessoa();
                nUsuario.Excluir(int.Parse(txtIdentificador.Text));
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Exclusão de Usuário",
                    "alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();
                
            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Exclusão de Usuário"
                    , "alert('" + mensagem + "')", true); ;
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
        private void VoltarParaPaginaAnterior()
        {
            Response.Redirect(@"~\Default.aspx");
        }

    }

}