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
    public partial class Reserva_Cadastro1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                
                if (!Page.IsPostBack)
                {
                      
                    CarregarDropCliente();
                    CarregarDropCampo();

                    if (Page.Request.QueryString["Id"] != null)
                    {
                        CarregarTelaReserva(int.Parse(Page.Request.QueryString["Id"].ToString()));
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                NReserva nReserva = new NReserva();
                nReserva.Excluir(int.Parse(txtIdentificadorReserva.Text));
                ScriptManager.RegisterClientScriptBlock(this,
                    GetType(), "Exclusão de Reserva",
                    "alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();

            }
            catch (Exception ex)
            {
                string mensagem = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType()
                    , "Exclusão de Reserva"
                    , "alert('" + mensagem + "')", true); ;
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
               
                EReserva eReserva = new EReserva();

                if (!string.IsNullOrEmpty(txtIdentificadorReserva.Text))
                      eReserva.Identificador = int.Parse(txtIdentificadorReserva.Text);

               eReserva.dataDaReserva = DateTime.Parse(txtDatadaReserva.Text);
               eReserva.FCodCliente.Identificador = int.Parse(ddlCliente.SelectedValue);
               if (ddlCampo.SelectedValue != "0") { eReserva.FCodCampo.Identificador = int.Parse(ddlCampo.SelectedValue); }
               if (ddlCliente.SelectedValue != "0") { eReserva.qtdDeHoras = int.Parse(txtQuantidadeHoras.Text); }
               eReserva.valorHora = decimal.Parse(txtValorHora.Text.Replace("R$", "").Trim());
               eReserva.valorTotal = Decimal.Parse(txtValorTotal.Text.Replace("R$", "").Trim());

                NReserva nReserva = new NReserva();
                nReserva.Salvar(eReserva);
                ScriptManager.RegisterClientScriptBlock(this,GetType(), "Cadastro de Reserva","alert('Operação realizada com sucesso!')", true);
                VoltarParaPaginaAnterior();

            }
            catch (Exception erro)
            {
                string mensagem = erro.Message;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Erro ao Cadastrar", "alert('" + mensagem + "')", true);
            }
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            VoltarParaPaginaAnterior();
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int identificador = int.Parse(ddlCliente.SelectedValue);

            NPessoa nPessoa = new NPessoa();
            EPessoa cliente = nPessoa.Consultar(identificador);

            
        }

        private void CarregarDropCliente()
        {
            //Cria e adiciona o item "Selecione..." na dropdown
            ListItem selecione = new ListItem();
            selecione.Value = "0";
            selecione.Text = "Selecione...";
            ddlCliente.Items.Add(selecione);

            //Preenche a dropdown com a lista de produtos
            NPessoa nPessoa = new NPessoa();
            ddlCliente.DataSource = nPessoa.MontaCombo();
            ddlCliente.DataBind();

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int identificador = int.Parse(ddlCampo.SelectedValue);

            
            NCampo nCampo = new NCampo();
            ECampo campo = nCampo.Consultar(identificador);

            txtValorHora.Text = campo.valorHora.ToString("c");
            CalcularValorTotal();
        }

        private void CarregarDropCampo() {
            //Cria e adiciona o item "Selecione..." na dropdown
            ListItem selecione = new ListItem();
            selecione.Value = "0";
            selecione.Text = "Selecione...";
            ddlCampo.Items.Add(selecione);

            //Preenche a dropdown com a lista de produtos
            NCampo nCampo = new NCampo();
            ddlCampo.DataSource = nCampo.MontarCombo();
            ddlCampo.DataBind();
        
        }

        private void CarregarTelaReserva(int identificador)
        {
            EReserva retorno = new NReserva().Consultar(identificador);

            //Preenche a tela
            txtIdentificadorReserva.Text = retorno.Identificador.ToString();
            txtDatadaReserva.Text = retorno.dataDaReserva.ToString();
            txtQuantidadeHoras.Text = retorno.qtdDeHoras.ToString();
            txtValorTotal.Text = retorno.valorTotal.ToString();
            txtData.Text = retorno.data.ToString();

        }
        
        private void VoltarParaPaginaAnterior()
        {
            Response.Redirect(@"~\Default.aspx");
        }

        private void LimpaCampos() {

            txtIdentificadorReserva.Text = "";
            txtDatadaReserva.Text = "";
            txtData.Text = "";
            txtQuantidadeHoras.Text = "";
            txtValorTotal.Text = "";
            txtValorHora.Text = "";
            ddlCliente.SelectedValue = "0";
            ddlCampo.SelectedValue = "0";
            
        }

        private void CalcularValorTotal()
        {
            if (!string.IsNullOrEmpty(txtQuantidadeHoras.Text) &&
                !string.IsNullOrEmpty(txtValorHora.Text))
            {
                //tem algum valor
                decimal qtde = decimal.Parse(txtQuantidadeHoras.Text);
                decimal valor = decimal.Parse(txtValorHora.
                    Text.Replace("R$", "").Trim());
                decimal total = qtde * valor;

                txtValorTotal.Text = total.ToString("c");
            }
        }

        protected void txtQuantidadeHoras_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularValorTotal();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void txtValorTotal_Unload(object sender, EventArgs e)
        {
            try
            {
                CalcularValorTotal();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}