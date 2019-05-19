using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Persistencia
{
    public class ConexaoSingleton
    {
        private static ConexaoSingleton instancia;
        private static MySqlConnection  cnn;
    

        private ConexaoSingleton() {

            //Intancia variavel como String de Conexão do Banco de Dados Mysql
            cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
            
            // passa o caminho do banco para conectar
            cnn.ConnectionString = Caminho; 
         
        }

        public static ConexaoSingleton getInstancia() {

            if (instancia == null)
            {
                instancia = new ConexaoSingleton();
                    
            }
            return instancia;
        }

        //metodo que retorna conexao My SQL
        public MySqlConnection conexaoMysql() {
            
           return cnn;

        }

        public void abrirConexao() {
            
            if (cnn.State.ToString() =="Closed")
            {
                cnn.Open();
            }

            

        }

        public void fecharConexao() {
            cnn.Close();
        }
        
        public static string Caminho
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                return reader.GetValue("ConexaoBanco", typeof(string)).ToString();
            }
        }
    





    }
}
