using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Persistencia
{
    public class PEquipamento
    {
           /*
        * @Autor:RafaelGG
        */

        ConexaoSingleton cnnEquipamento = null;
    
        
      
        //String Conexão com o Banco de Dados Mysql
       // MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
        MySqlCommand cmd = new MySqlCommand();

        //Construtor da classe
        public PEquipamento()
        {
            // pega a instacia de conexao com o banco
            cnnEquipamento = ConexaoSingleton.getInstancia();

            // executa a conexao com o banco de dados
            cmd.Connection = cnnEquipamento.conexaoMysql();


            //cnnEquipamento.ConnectionString = Persistencia.Conexao.Caminho;
            //cmd.Connection = cnn;
        }
        
//        //Métodos

//        //Inserir Equipamento
        public void Incluir(EEquipamento parametro)
        {
          //  sql = @"INSERT INTO Equipamento(Referencia, Descricao, Grupo, QtdEstoque,DataDeFabricacao,TempoDeManutencao, UltimaDataRevisao)
            //                    VALUES(" + parametro.referencia + "," + parametro.descricao + "," + parametro.grupo + "," + parametro.qtdEstoque + "," + parametro.dataDeFabricacao + "," + parametro.tempoDeManutencao + "," + parametro.ultimaDataRevisao + ") ";
            cmd.CommandText = @"INSERT INTO Equipamento(Referencia, Descricao, Grupo, QtdEstoque,DataDeFabricacao,TempoDeManutencao, UltimaDataRevisao)
                               VALUES(@referencia,@descricao, @grupo, @qtdEstoque, @dataDeFabricacao,@tempoDeManutencao,@ultimaDataRevisao) ";

            cmd.Parameters.Add("@referencia", parametro.referencia);
            cmd.Parameters.Add("@descricao", parametro.descricao);
            cmd.Parameters.Add("@grupo", parametro.grupo);
            cmd.Parameters.Add("@qtdEstoque", parametro.qtdEstoque);
            cmd.Parameters.Add("@dataDeFabricacao", parametro.dataDeFabricacao);
            cmd.Parameters.Add("@tempoDeManutencao", parametro.tempoDeManutencao);
            cmd.Parameters.Add("@ultimaDataRevisao", parametro.ultimaDataRevisao);

            cnnEquipamento.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnEquipamento.fecharConexao();
           
          
        }

        public void Alterar(EEquipamento parametro)
        {
            cmd.CommandText = @"UPDATE Equipamento SET Referencia = @referencia, Descricao = @descricao, Grupo = @grupo, QtdEstoque = @qtdEstoque, DataDeFabricacao = @dataDeFabricacao, TempoDeManutencao = @tempoDeManutencao, ultimaDataRevisao = @ultimaDataRevisao";

            cmd.Parameters.Add("@referencia", parametro.referencia);
            cmd.Parameters.Add("@descricao", parametro.descricao);
            cmd.Parameters.Add("@grupo", parametro.grupo);
            cmd.Parameters.Add("@qtdEstoque", parametro.qtdEstoque);
            cmd.Parameters.Add("@dataFabricacao", parametro.dataDeFabricacao);
            cmd.Parameters.Add("@tempoManutencao", parametro.tempoDeManutencao);
            cmd.Parameters.Add("@ultimaDataRevisao", parametro.ultimaDataRevisao);

            cnnEquipamento.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnEquipamento.fecharConexao();
       }

        public EEquipamento Consultar(int identificador) {

            cmd.CommandText = @"SELECT * FROM Equipamento WHERE identificador=@id";

            cmd.Parameters.Add("@id", identificador);

            cnnEquipamento.abrirConexao();
            MySqlDataReader rdr = cmd.ExecuteReader();
            EEquipamento retorno = new EEquipamento();

            if (rdr.Read())
            {
                PreencherObjeto(rdr, retorno);
            }
            cnnEquipamento.fecharConexao();
           return retorno;
         }

        public void Excluir(int identificador)
        {
            cmd.CommandText = @"DELETE FROM Equipamento
                              WHERE Identificador = @id";

            cmd.Parameters.Add("@id", identificador);
            cnnEquipamento.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnEquipamento.fecharConexao();
        }

        public List<EEquipamento> Listar(EEquipamento parametro)
       {
           cmd.CommandText = "SELECT * FROM Equipamento WHERE 1 = 1";

           if (parametro != null)
           {

               if (!string.IsNullOrEmpty(parametro.descricao))
               {
                   cmd.CommandText += " AND Descricao Like @descicao";
                   cmd.Parameters.Add("@descricao", "%" + parametro.descricao + "%");
               }

               if (!String.IsNullOrEmpty(parametro.referencia))
               {
                   cmd.CommandText += " AND Referencia Like @referencia";
                   cmd.Parameters.Add("@referencia", "%" + parametro.referencia + "%");
               }

               if (!string.IsNullOrEmpty(parametro.grupo))
               {
                   cmd.CommandText += " AND Grupo Like @grupo";
                   cmd.Parameters.Add("@grupo", "%" + parametro.grupo + "%");
               }

           }

           cnnEquipamento.abrirConexao();
           MySqlDataReader retorno = cmd.ExecuteReader();
            List<EEquipamento> lstRetorno = new List<EEquipamento>();

            while (retorno.Read())
            {
                EEquipamento obj = new EEquipamento();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnnEquipamento.fecharConexao();
           return lstRetorno;
        }
       
     private static void PreencherObjeto(MySqlDataReader rdr, EEquipamento retorno){
            retorno.Identificador = Convert.ToInt32(rdr["Identificador"]);
            retorno.descricao = ( rdr["Descricao"].ToString());
            retorno.referencia = (rdr["Referencia"].ToString());
            retorno.grupo = (rdr["Grupo"].ToString());
            retorno.qtdEstoque = (Convert.ToInt32(rdr["QtdEstoque"].ToString()));
            retorno.dataDeFabricacao = (Convert.ToDateTime(rdr["DataDeFabricacao"]));
            retorno.ultimaDataRevisao = (Convert.ToDateTime(rdr["UltimaDataRevisao"]));
            retorno.tempoDeManutencao = (Convert.ToInt32(rdr["TempoDeManutencao"]));
     }

    }
}
