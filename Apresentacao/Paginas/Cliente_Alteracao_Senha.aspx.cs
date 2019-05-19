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
    public partial class Cliente_Alteracao_Senha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.Request.QueryString["Id"] != null)
            {
                CarregarTelaUsuario();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(Page.Request.QueryString["Id"].ToString());
            NPessoa nUsuario = new NPessoa();
            EPessoa eUsuario = new EPessoa();
            eUsuario = nUsuario.Consultar(idUsuario);

            txtCodigo.Text = eUsuario.Identificador.ToString();
            txtLogin.Text = eUsuario.login;
            txtSenha.Text = eUsuario.senha;
            
        }
        protected void CarregarTelaUsuario()
        {
            NPessoa nUsuario = new NPessoa();
            EPessoa eUsuario = new EPessoa();
            int idUsuario = Convert.ToInt32(Page.Request.QueryString["Id"].ToString());

            eUsuario = nUsuario.Consultar(idUsuario);

            txtCodigo.Text = eUsuario.Identificador.ToString();
            txtLogin.Text = eUsuario.login;
            txtSenha.Text = eUsuario.senha;
        }
    }
}