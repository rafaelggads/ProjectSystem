using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade;
using Negocio;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.ComponentModel;
using System.Text;

namespace Apresentacao
{
    public partial class TelaLogin : System.Web.UI.MasterPage
    {
        MySqlConnection conn = new MySqlConnection(@"server=localhost;database=dbprojectsystem;Uid=root;Pwd=123456;");
        private DialogResult DialogResult;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (ValidaLogin(TxtLogin.Text))
                {
                    if (ValidaSenha(TxtSenha.Text))
                    {
                        if (ValidaUsuario(TxtLogin.Text, TxtSenha.Text,ddlTipoUsuario.Text))
                        {
                                if (ddlTipoUsuario.Text == "1")
                                {
                                    //retorno o diálogo ok
                                    Response.Redirect(@"~\Default.aspx");
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                    Response.Redirect(@"~\TelaLoginCliente.aspx");
                                this.DialogResult = DialogResult.OK;
                          
                        }
                        else
                        {
                            //Se o tipo da permissão for diferente exibirá essas mensagem
                            MessageBox.Show("Tipo de Permissão Inválida! \nCertifique-se sua permissão está correta!", "Project System",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.DialogResult = DialogResult.Cancel;
                            ddlTipoUsuario.Text = "0";
                        }
                    }
                    else
                    {
                        //Se a senha for diferente exibirá essa mensagem
                        MessageBox.Show("Senha Inválida! \nCertifique-se se está digitando a Senha correto!", "Project System",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.DialogResult = DialogResult.Cancel;
                    }  
                }
                else
                {
                    //Se o Login for diferente exibirá essa mensagem
                    MessageBox.Show("Login Inválido! \nCertifique-se se está digitando Login correto!", "Project System",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.Cancel;
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public bool ValidaUsuario(string login, string senha, string IDTipoUsuario)
        {
            EPessoa parametro = new EPessoa();

            //informar o retorno
            int retorno = -1;
            ////instância da cocexão
            MySqlConnection conn = new MySqlConnection(@"server=localhost;database=dbprojectsystem;Uid=root;Pwd=123456;");
            //comando sql que dá um count 
            //na tabela se existirem usuario e senha
            //com os dados informados
            string comando = "SELECT * FROM PESSOA WHERE login=@login AND senha=@senha AND IDTipoUsuario=@IDTipoUsuario ";
            //instância do comando
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            //preenchimento dos parâmetros
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@IDTipoUsuario", IDTipoUsuario);
            //abro conexão
            conn.Open();
            //retorno recebe o resultado do execute scalar
            retorno = Convert.ToInt32(cmd.ExecuteScalar());
            //fecho conexão
            //retorno true se retorno for maior que zero
            return retorno > 0;
            
        }
        public bool ValidaLogin(string login)
        {
            //informar o retorno
            int retorno = -1;
            ////instância da cocexão
            MySqlConnection conn = new MySqlConnection(@"server=localhost;database=dbprojectsystem;Uid=root;Pwd=123456;");
            //comando sql que dá um count 
            //na tabela se existirem usuario e senha
            //com os dados informados
            string comando = "SELECT * FROM PESSOA WHERE login=@login";
            //instância do comando
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            //preenchimento dos parâmetros
            cmd.Parameters.AddWithValue("@login", login);
            //abro conexão
            conn.Open();
            //retorno recebe o resultado do execute scalar
            retorno = Convert.ToInt32(cmd.ExecuteScalar());
            //fecho conexão
            conn.Close();
            //retorno true se retorno for maior que zero
            return retorno > 0;
        }
        public bool ValidaSenha(string senha)
        {
            //informar o retorno
            int retorno = -1;
            ////instância da cocexão
            MySqlConnection conn = new MySqlConnection(@"server=localhost;database=dbprojectsystem;Uid=root;Pwd=123456;");
            //comando sql que dá um count 
            //na tabela se existirem usuario e senha
            //com os dados informados
            string comando = "SELECT * FROM PESSOA WHERE senha=@senha";
            //instância do comando
            MySqlCommand cmd = new MySqlCommand(comando, conn);
            //preenchimento dos parâmetros
            cmd.Parameters.AddWithValue("@senha", senha);
            //abro conexão
            conn.Open();
            //retorno recebe o resultado do execute scalar
            retorno = Convert.ToInt32(cmd.ExecuteScalar());
            //fecho conexão
            conn.Close();
            //retorno true se retorno for maior que zero
            return retorno > 0;
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Paginas\Cliente_Cadastro.aspx");

        }

        
    }
}
    

    
