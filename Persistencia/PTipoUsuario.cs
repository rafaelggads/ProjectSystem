using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Persistencia
{
    public class PTipoUsuario
    {
            //ConexaoSingleton cnnTipoUsuario = null;
            MySqlCommand cmd = new MySqlCommand();

            public PTipoUsuario() {
                
            }
            public ETipoUsuario Consultar(int identificador)
            {
                MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
                MySqlCommand cmd = new MySqlCommand();

                cnn.ConnectionString = Conexao.Caminho;
                cmd.Connection = cnn;
                //cnnTipoUsuario = ConexaoSingleton.getInstancia();
                //cmd.Connection = cnnTipoUsuario.conexaoMysql();

                cmd.CommandText = @"SELECT * FROM TipoUsuario
                                WHERE Identificador = @id";
                cmd.Parameters.Add("@id", identificador);

                
                cnn.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                ETipoUsuario retorno = new ETipoUsuario();
                if (rdr.Read())
                {
                    PreencherObjeto(rdr, retorno);
                }
                cnn.Close();
                return retorno;
            }

            public List<ETipoUsuario> Listar()
            {
                MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
                MySqlCommand cmd = new MySqlCommand();
                cnn.ConnectionString = Conexao.Caminho;
                cmd.Connection = cnn;
                //cnnTipoUsuario = ConexaoSingleton.getInstancia();
                //cmd.Connection = cnnTipoUsuario.conexaoMysql();

                cmd.CommandText = "SELECT * FROM TipoUsuario ";

                cnn.Open();
                MySqlDataReader retorno = cmd.ExecuteReader();
                List<ETipoUsuario> lstRetorno = new List<ETipoUsuario>();
                //Se, e enquanto, existerem registros, percorre o datareader
                while (retorno.Read())
                {
                    ETipoUsuario obj = new ETipoUsuario();
                    PreencherObjeto(retorno, obj);
                    lstRetorno.Add(obj);
                }
                cnn.Close();
                return lstRetorno;
            }

            private static void PreencherObjeto(MySqlDataReader rdr, ETipoUsuario retorno)
            {
                retorno.Identificador = Convert.ToInt32(rdr["identificador"]);
                retorno.Descricao = rdr["Descricao"].ToString();
                
            }
        }
    }

