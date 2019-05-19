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
    public partial class Campo_Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NCampo nCampo = new NCampo();
            try
            {
                string controleTela = string.Empty;
                if (!Page.IsPostBack)
                {
                    
                    controleTela = "inserir";

                    if (Page.Request.QueryString["Id"] != null)
                    {
                        CarregarTelaCampo();
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
                ECampo campo = new ECampo();
                
                if (!string.IsNullOrEmpty(txtIdentificadorCampo.Text))
                    campo.Identificador = int.Parse(txtIdentificadorCampo.Text);

                campo.descricao = txtDescricao.Text;
                campo.comprimento = Double.Parse( txtComprimento.Text);
                campo.largura = Double.Parse(txtLargura.Text);
                campo.qtdObstaculos = int.Parse(txtQtdObstaculos.Text);
                campo.valorHora = Decimal.Parse(txtValorHora.Text);
             
                NCampo nCampo = new NCampo();
                nCampo.Salvar(campo);
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Cadastro de Campo",
                    "alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Cadastro de Associados"
                    , "alert('" + mensagem + "')", true);
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
            Response.Redirect(@"~\Paginas\Campo_Listar.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                NCampo nCampo = new NCampo();
                nCampo.Excluir(int.Parse(txtIdentificadorCampo.Text));
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Exclusão de Campo",
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

        protected void CarregarTelaCampo()
        {
            NCampo nCampo = new NCampo();
            ECampo eCampo = new ECampo();

            int idCampo = Convert.ToInt32(Page.Request.QueryString["Id"].ToString());

            eCampo = nCampo.Consultar(idCampo);

            txtIdentificadorCampo.Text = eCampo.Identificador.ToString();
            txtDescricao.Text = eCampo.descricao;
            txtComprimento.Text = eCampo.comprimento.ToString();
            txtLargura.Text = eCampo.largura.ToString();
            txtQtdObstaculos.Text = eCampo.qtdObstaculos.ToString();
            txtValorHora.Text = eCampo.valorHora.ToString();
            

        }
    }
}