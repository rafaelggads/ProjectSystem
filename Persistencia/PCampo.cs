using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Configuration;
using Entidade;


namespace Persistencia
{
    public class PCampo
    {
        /*
        * @Autor:RafaelGG
        */

        ConexaoSingleton cnnCampo = null;
        
        //String Conexão com o Banco de Dados Mysql
        //MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
        MySqlCommand cmd = new MySqlCommand();

        //Construtor da classe
        public PCampo() {

            // pega a instacia de conexao com o banco
            cnnCampo = ConexaoSingleton.getInstancia();

            // executa a conexao com o banco de dados
            cmd.Connection = cnnCampo.conexaoMysql();

            //cnn.ConnectionString = Persistencia.Conexao.Caminho;
            //cmd.Connection = cnn;
        }

        //Métodos
        
        //Inserir Campo
        public void Incluir(ECampo parametro) {
           
            cmd.CommandText = @"INSERT INTO Campo(Descricao, Comprimento, Largura, QtdObstaculos,ValorHora)
                               VALUES(@descricao, @comprimento, @largura, @qtdObstaculos,@valorHora) ";

            cmd.Parameters.Add("@descricao", parametro.descricao);
            cmd.Parameters.Add("@comprimento", parametro.comprimento);
            cmd.Parameters.Add("@largura", parametro.largura);
            cmd.Parameters.Add("@qtdObstaculos", parametro.qtdObstaculos);
            cmd.Parameters.Add("@valorHora", parametro.valorHora);
            
            cnnCampo.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnCampo.fecharConexao();        
        }

        public void Alterar(ECampo parametro) {
            cmd.CommandText = @"UPDATE Campo SET Descricao = @descricao, Comprimento = @comprimento, Largura = @largura, QtdObstaculos = @qtdObstaculos, ValorHora = @valorHora  WHERE Identificador  = @id";

            cmd.Parameters.Add("@descricao", parametro.descricao);
            cmd.Parameters.Add("@comprimento", parametro.comprimento);
            cmd.Parameters.Add("@largura", parametro.largura);
            cmd.Parameters.Add("@qtdObstaculos", parametro.qtdObstaculos);
            cmd.Parameters.Add("@valorHora", parametro.valorHora);
            cmd.Parameters.Add("@id", parametro.Identificador);

            cnnCampo.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnCampo.fecharConexao();
        }

        public ECampo Consultar(int identificador) {
            
            cmd.CommandText = @"SELECT * FROM Campo WHERE identificador=@id";

            cmd.Parameters.Add("@id", identificador);

            cnnCampo.abrirConexao();
            MySqlDataReader rdr = cmd.ExecuteReader();
            ECampo retorno = new ECampo();
            
            if (rdr.Read())
            {
                PreencherObjeto(rdr, retorno);
            }
            cnnCampo.abrirConexao();
            return retorno;
        }

        public void Excluir(int identificador)
        {
            cmd.CommandText = @"DELETE FROM Campo
                              WHERE Identificador = @id";

            cmd.Parameters.Add("@id", identificador);
            
            cnnCampo.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnCampo.fecharConexao();
        }

        public List<ECampo> Listar(ECampo parametro)
        {

            cmd.CommandText = "SELECT * FROM CAMPO WHERE 1 = 1";

            if (parametro != null)
            {

                if (!string.IsNullOrEmpty(parametro.descricao))
                {
                    cmd.CommandText += " AND Descricao Like @descricao";
                    cmd.Parameters.Add("@descricao", "%" + parametro.descricao + "%");
                }


            }

            cnnCampo.abrirConexao();
            MySqlDataReader retorno = cmd.ExecuteReader();
            List<ECampo> lstRetorno = new List<ECampo>();

            while (retorno.Read())
            {
                ECampo obj = new ECampo();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnnCampo.fecharConexao();
            return lstRetorno;
        }
        public List<ECampo> MontaCombo() {

            MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
            MySqlCommand cmd = new MySqlCommand();
            cnn.ConnectionString = Persistencia.Conexao.Caminho;
            cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM Campo  WHERE 1 = 1";

            cnn.Open();
            MySqlDataReader retorno = cmd.ExecuteReader();
            List<ECampo> lstRetorno = new List<ECampo>();
            //Se, e enquanto, existerem registros, percorre o datareader
            while (retorno.Read())
            {
                ECampo obj = new ECampo();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnn.Close();
            return lstRetorno;

        }
     private static void PreencherObjeto(MySqlDataReader rdr, ECampo retorno){
            retorno.Identificador = Convert.ToInt32(rdr["Identificador"]);
            retorno.descricao = rdr["Descricao"].ToString();
            retorno.comprimento = (Convert.ToDouble(rdr["Comprimento"]));
            retorno.largura = ( Convert.ToDouble(rdr["Largura"].ToString()));
            retorno.qtdObstaculos = (Convert.ToInt32(rdr["QtdObstaculos"].ToString()));
            retorno.valorHora = (Decimal.Parse(rdr["ValorHora"].ToString()));
     }

    }
}
