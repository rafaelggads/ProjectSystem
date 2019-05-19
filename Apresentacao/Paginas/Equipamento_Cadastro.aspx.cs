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
    public partial class Equipamento_Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                string controleTela = string.Empty;
                if (!Page.IsPostBack)
                {

                    controleTela = "inserir";

                    if (Page.Request.QueryString["Id"] != null)
                    {
                        CarregarTelaEquipamento();
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
                EEquipamento eEquipamento = new EEquipamento();

                if (!string.IsNullOrEmpty(txtIdentificadorEquipamento.Text))
                eEquipamento.Identificador = int.Parse(txtIdentificadorEquipamento.Text);       

                eEquipamento.referencia = txtReferencia.Text;
                eEquipamento.descricao = txtDescricao.Text;
                eEquipamento.grupo = txtGrupo.Text;
                eEquipamento.qtdEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
                eEquipamento.dataDeFabricacao = Convert.ToDateTime(txtDataFabricacao.Text);
                eEquipamento.ultimaDataRevisao = Convert.ToDateTime(txtUltimaDatadeRevisao.Text);
                eEquipamento.tempoDeManutencao = Convert.ToInt32(txtTempoManutencao.Text);

                NEquipamento nEquipamento = new NEquipamento();
                nEquipamento.Salvar(eEquipamento);
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Cadastro de Equipamentos",
                    "alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Cadastro de Equipamentos"
                    , "alert('" + mensagem + "')", true);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                NEquipamento nEquipamento = new NEquipamento();
                nEquipamento.Excluir(int.Parse(txtIdentificadorEquipamento.Text));
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Exclusão de Equipamento",
                    "alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Exclusão de Equipamento"
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
            Response.Redirect(@"~\Paginas\Equipamento_Listar.aspx");
        }
        
        protected void CarregarTelaEquipamento()
        {
            NEquipamento nEquipamento = new NEquipamento();
            EEquipamento eEquipamento = new EEquipamento();

            int idCampo = Convert.ToInt32(Page.Request.QueryString["Id"].ToString());

            eEquipamento = nEquipamento.Consultar(idCampo);

            txtIdentificadorEquipamento.Text = eEquipamento.Identificador.ToString();
            txtReferencia.Text = eEquipamento.referencia;
            txtDescricao.Text = eEquipamento.descricao;
            txtGrupo.Text = eEquipamento.grupo;
            txtQuantidadeEstoque.Text = eEquipamento.qtdEstoque.ToString();
            txtDataFabricacao.Text  = eEquipamento.dataDeFabricacao.Date.ToString("d");
            txtUltimaDatadeRevisao.Text = eEquipamento.ultimaDataRevisao.ToString("d");
            txtTempoManutencao.Text = eEquipamento.tempoDeManutencao.ToString();

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
    }
}