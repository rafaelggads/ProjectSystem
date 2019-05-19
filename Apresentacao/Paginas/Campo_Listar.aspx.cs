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
    public partial class Campo_Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NCampo nCampo = new NCampo();
                ECampo eCampo = new ECampo();
                List<ECampo> lstResultado = new List<ECampo>();

                eCampo.descricao = txtBusca.Text;

                lstResultado = nCampo.Listar(eCampo);

                grdListaCampo.DataSource = lstResultado;
                grdListaCampo.DataBind();


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
                Response.Redirect(@"~\Paginas\Campo_Cadastro.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}