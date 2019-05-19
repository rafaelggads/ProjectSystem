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
    public partial class Usuario_Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NPessoa nUsuario = new NPessoa();
                EPessoa eUsuario = new EPessoa();
                List<EPessoa> lstResultado = new List<EPessoa>();

                eUsuario.nome = txtNome.Text;

                lstResultado = nUsuario.Listar(eUsuario);

                grdListaUsuario.DataSource = lstResultado;
                grdListaUsuario.DataBind();


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(@"~\Paginas\Usuario_Cadastro.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdListaUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}