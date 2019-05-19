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
    public partial class Equipamento_Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NEquipamento nEquipamento = new NEquipamento();
                EEquipamento eEquipamento = new EEquipamento();
                List<EEquipamento> lstResultado = new List<EEquipamento>();

                eEquipamento.descricao = txtBusca.Text;

                lstResultado = nEquipamento.Listar(eEquipamento);

                grdListaEquipamento.DataSource = lstResultado;
                grdListaEquipamento.DataBind();


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
                Response.Redirect(@"~\Paginas\Equipamento_Cadastro.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    
}