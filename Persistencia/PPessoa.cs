using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Entidade;


namespace Persistencia
{
    public class PPessoa
    {
        ConexaoSingleton cnnPessoa = null;
        //MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
        MySqlCommand cmd = new MySqlCommand();

       public PPessoa()
       {
           cnnPessoa = ConexaoSingleton.getInstancia();
           cmd.Connection = cnnPessoa.conexaoMysql();

          // cnn.ConnectionString = Persistencia.Conexao.Caminho;
          // cmd.Connection = cnn;
       }

        public void Incluir(EPessoa parametro)
        {

            cmd.CommandText = @"INSERT INTO PESSOA(Nome, Sobrenome, Login, Email, Logradouro, Cep, Bairro, Cidade, DataDeNascimento, IDTipoUsuario, Senha, Telefone)
                               VALUES(@nome,@sobrenome, @login,@email, @logradouro, @cep, @bairro, @cidade,@dataDeNascimento , @IDTipoUsuario,@senha, @telefone) 
                                ";

            cmd.Parameters.Add("@Nome", parametro.nome);
            cmd.Parameters.Add("@Sobrenome", parametro.sobrenome);
            cmd.Parameters.Add("@DataDeNascimento", parametro.dataDeNascimento);
            cmd.Parameters.Add("@Email", parametro.email);
            cmd.Parameters.Add("@Telefone", parametro.telefone);
            cmd.Parameters.Add("@Logradouro", parametro.logradouro);
            cmd.Parameters.Add("@Cep", parametro.cep);
            cmd.Parameters.Add("@bairro", parametro.bairro);
            cmd.Parameters.Add("@Cidade", parametro.cidade);
            cmd.Parameters.Add("@IDTipoUsuario", parametro.TipoUsuario.Identificador);
            cmd.Parameters.Add("@Login", parametro.login);
            cmd.Parameters.Add("@Senha", parametro.senha);
            
            cnnPessoa.abrirConexao();                
            cmd.ExecuteNonQuery();            
            cnnPessoa.fecharConexao();
        
        }        
        public void Alterar(EPessoa parametro)
        {
            cmd.CommandText = @"UPDATE PESSOA SET                                  
                                Nome                 = @nome, 
                                Sobrenome            = @sobrenome,
                                Login                = @login, 
                                Email                = @email, 
                                Logradouro           = @logradouro, 
                                DataDeNascimento     = @dataDeNascimento,
                                Telefone             = @telefone,
                                Cep                  = @cep,
                                Bairro               = @bairro,
                                Cidade               = @cidade,
                                IDTipoUsuario        = @IDTipoUsuario,
                                Senha                = @senha
                                WHERE Identificador  = @id";

            cmd.Parameters.Add("@Nome", parametro.nome);
            cmd.Parameters.Add("@Sobrenome", parametro.sobrenome);
            cmd.Parameters.Add("@Login", parametro.login);
            cmd.Parameters.Add("@Email", parametro.email);
            cmd.Parameters.Add("@Logradouro", parametro.logradouro);
            cmd.Parameters.Add("@DataDeNascimento", parametro.dataDeNascimento);
            cmd.Parameters.Add("@Telefone", parametro.telefone);
            cmd.Parameters.Add("@Cep", parametro.cep);
            cmd.Parameters.Add("@bairro", parametro.bairro);
            cmd.Parameters.Add("@Cidade", parametro.cidade);
            cmd.Parameters.Add("@IDTipoUsuario", parametro.TipoUsuario.Identificador);
            cmd.Parameters.Add("@Senha", parametro.senha);
            cmd.Parameters.Add("@id", parametro.Identificador);
            
            cnnPessoa.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnPessoa.fecharConexao();                               
        }

        public EPessoa Consultar(int identificador)
        {
            cmd.CommandText = @"SELECT * FROM PESSOA
                                WHERE Identificador = @id";

            cmd.Parameters.Add("@id", identificador);

            cnnPessoa.abrirConexao();
            MySqlDataReader rdr = cmd.ExecuteReader();
            EPessoa retorno = new EPessoa();

            if (rdr.Read())
            {               
                PreencherObjeto(rdr, retorno);
            }
            cnnPessoa.fecharConexao();
            return retorno;
        }
       
        public void Excluir(int identificador)
        {
            cmd.CommandText = @"DELETE FROM PESSOA
                              WHERE Identificador = @id";

            cmd.Parameters.Add("@id", identificador);
            
            cnnPessoa.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnPessoa.fecharConexao();
        }

        public List<EPessoa> Listar(EPessoa parametro)
        {

            //MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
            //MySqlCommand cmd = new MySqlCommand();
            //cnn.ConnectionString = Persistencia.Conexao.Caminho;
            //cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM PESSOA WHERE 1 = 1";

            if (parametro != null)
            {

                if (!string.IsNullOrEmpty(parametro.nome))
                {
                    cmd.CommandText += " AND Nome Like @nome";
                    cmd.Parameters.Add("@nome", "%" + parametro.nome + "%");
                }

                if (!string.IsNullOrEmpty(parametro.sobrenome))
                {
                    cmd.CommandText += " AND Sobrenome Like @sobrenome";
                    cmd.Parameters.Add("@sobrenome", "%" + parametro.sobrenome + "%");
                }
                if (!string.IsNullOrEmpty(parametro.login))
                {
                    cmd.CommandText += " AND Login Like @login";
                    cmd.Parameters.Add("@login", "%" + parametro.login + "%");
                } 
                if (!string.IsNullOrEmpty(parametro.email))
                {
                    cmd.CommandText += " AND Email Like @email";
                    cmd.Parameters.Add("@email", "%" + parametro.email + "%");
                }
            }
           
            cnnPessoa.abrirConexao();
            MySqlDataReader retorno = cmd.ExecuteReader();
            List<EPessoa> lstRetorno = new List<EPessoa>();

            while (retorno.Read())
            {
                EPessoa obj = new EPessoa();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnnPessoa.fecharConexao();
            return lstRetorno;
        }
        private static void PreencherObjeto(MySqlDataReader rdr, EPessoa retorno)
        {
            PTipoUsuario pTipo = new PTipoUsuario();
            retorno.Identificador   = Convert.ToInt32(rdr["Identificador"]);
            retorno.login           = rdr["Login"].ToString();
            retorno.nome            = rdr["Nome"].ToString();
            retorno.sobrenome       = rdr["Sobrenome"].ToString();
            retorno.email           = rdr["Email"].ToString();
            retorno.logradouro      = rdr["logradouro"].ToString();
            retorno.cep             = rdr["Cep"].ToString();
            retorno.bairro          = rdr["Bairro"].ToString();
            retorno.cidade          = rdr["Cidade"].ToString();
            retorno.TipoUsuario =
                pTipo.Consultar(Convert.ToInt32(rdr["IDTipoUsuario"]));
            retorno.dataDeNascimento  = Convert.ToDateTime(rdr["DataDeNascimento"]);
            retorno.senha           = rdr["Senha"].ToString();
            retorno.telefone    = rdr["Telefone"].ToString();
        }
        public List<EPessoa> ListarFiltro()
        {
            //MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
            //MySqlCommand cmd = new MySqlCommand();
            //cnn.ConnectionString = Persistencia.Conexao.Caminho;
            //cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM PESSOA  WHERE 1 = 1";

            cnnPessoa.abrirConexao();
            MySqlDataReader retorno = cmd.ExecuteReader();
            List<EPessoa> lstRetorno = new List<EPessoa>();
            //Se, e enquanto, existerem registros, percorre o datareader
            while (retorno.Read())
            {
                EPessoa obj = new EPessoa();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnnPessoa.fecharConexao();
            return lstRetorno;
        }

        public List<EPessoa> MontaCombo()
        {
            MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
            MySqlCommand cmd = new MySqlCommand();
            cnn.ConnectionString = Persistencia.Conexao.Caminho;
            cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM Pessoa  WHERE 1 = 1";

            cnn.Open();
            MySqlDataReader retorno = cmd.ExecuteReader();
            List<EPessoa> lstRetorno = new List<EPessoa>();
            //Se, e enquanto, existerem registros, percorre o datareader
            while (retorno.Read())
            {
                EPessoa obj = new EPessoa();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnn.Close();
            return lstRetorno;
        }
    }
}
