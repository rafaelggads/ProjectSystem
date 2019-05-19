using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidade;
using System.Data;
using System.Reflection;

namespace Apresentacao.Paginas
{
    public partial class Usuario_View_Filtro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                NPessoa nUsuario = new NPessoa();
                EPessoa parametro = new EPessoa();

                #region filtro
                switch (ddlTipoConsulta.SelectedValue)
                {
                    case "1":
                        parametro.nome = txtParametro.Text;
                        break;
                    case "2":
                        parametro.login = txtParametro.Text;
                        break;
                    case "3":
                        parametro.email = txtParametro.Text;
                        break;
                    default:
                        break;
                }
                #endregion filtro

                DataTable result = ConverteListParaDataTable(nUsuario.Listar(parametro));

                //this.rptUsuario.LocalReport.DataSources.Clear();
                //this.rptUsuario.LocalReport.DataSources.Add(new ReportDataSource("dtsUsuario", result));
                //this.rptUsuario.Visible = true;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable ConverteListParaDataTable<TipoDoObjeto>(List<TipoDoObjeto> list)
        {
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in typeof(TipoDoObjeto).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (TipoDoObjeto t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(TipoDoObjeto).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}