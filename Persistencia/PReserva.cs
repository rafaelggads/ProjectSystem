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
    public class PReserva
    {
           /*
        * @Autor:RafaelGG
        */

        ConexaoSingleton cnnReserva = null;

        //String Conexão com o Banco de Dados Mysql
        //MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
        MySqlCommand cmd = new MySqlCommand();

        //Construtor da classe
        public PReserva() {
            
            cnnReserva = ConexaoSingleton.getInstancia();
            cmd.Connection = cnnReserva.conexaoMysql();

            //cnn.ConnectionString = Persistencia.Conexao.Caminho;
            //cmd.Connection = cnn;
        }

        //Métodos

        //Inserir Reserva
        public void Incluir(EReserva parametro) {

            MySqlConnection cnn = new MySqlConnection(ConfigurationManager.AppSettings["ConexaoBanco"]);
            MySqlCommand cmd = new MySqlCommand();
            cnn.ConnectionString = Persistencia.Conexao.Caminho;
            cmd.Connection = cnn;

            cmd.CommandText = @"INSERT INTO Reserva (DataDaReserva, QtdDeHoras, ValorTotal,FCodCliente, FCodCampo, DataDeCadastro, ValorHora)
                               VALUES(@dataDaReserva, @qtdDeHoras, @valorTotal, @fCodCliente,@fCodCampo,@dataDeCadastro,@valorHora) ";

            cmd.Parameters.Add("@dataDaReserva", parametro.dataDaReserva);
            cmd.Parameters.Add("@qtdDeHoras", parametro.qtdDeHoras);
            cmd.Parameters.Add("@valorTotal", parametro.valorTotal);
            cmd.Parameters.Add("@fCodCliente", parametro.FCodCliente.Identificador);
            cmd.Parameters.Add("@fCodCampo", parametro.FCodCampo.Identificador);
            cmd.Parameters.Add("@dataDeCadastro", parametro.data);
            cmd.Parameters.Add("@valorHora", parametro.valorHora);

            //cnnReserva.abrirConexao();
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            //cnnReserva.fecharConexao();        
        }

        public void Alterar(EReserva parametro) {
            
            cmd.CommandText = @"UPDATE Reserva SET Data = @data, DataDaReserva = @dataDaReserva, FCodCliente = @FCodCliente, FCodCampo = @FCodCampo, QtdDeHoras = @qtdDeHoras, ValorTotal = @valorTotal";

            cmd.Parameters.Add("@data", parametro.data);
            cmd.Parameters.Add("@dataReserva", parametro.dataDaReserva);
            cmd.Parameters.Add("@FCodCliente", parametro.FCodCliente.Identificador);
            cmd.Parameters.Add("@FCodCampo", parametro.FCodCampo.Identificador);
            cmd.Parameters.Add("@qtdDeHoras", parametro.qtdDeHoras);
            cmd.Parameters.Add("@valorTotal", parametro.valorTotal);
            
            cnnReserva.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnReserva.fecharConexao();
        }

        public EReserva Consultar(int identificador) {

            cmd.CommandText = @"SELECT * FROM Reserva WHERE identificador=@id";

            cmd.Parameters.Add("@id", identificador);

            cnnReserva.abrirConexao();

            MySqlDataReader rdr = cmd.ExecuteReader();
            EReserva retorno = new EReserva();
            
            if (rdr.Read())
            {
                PreencherObjeto(rdr, retorno);
            }
            cnnReserva.fecharConexao();
            return retorno;
        }

        public void Excluir(int identificador)
        {
            cmd.CommandText = @"DELETE FROM Reserva
                              WHERE Identificador = @id";

            cmd.Parameters.Add("@id", identificador);
            
            cnnReserva.abrirConexao();
            cmd.ExecuteNonQuery();
            cnnReserva.fecharConexao();
        }

        public List<EReserva> Listar(EReserva parametro)
        {
            cmd.CommandText = "SELECT * FROM Reserva WHERE 1 = 1";

            if (parametro != null)
            {

                if (parametro.data !=DateTime.Parse("01/01/0001 00:00:00"))
                {
                    cmd.CommandText += "AND data = @data ";
                    cmd.Parameters.Add("@data", parametro.data);
                }

                if (parametro.dataDaReserva != DateTime.Parse("01/01/0001 00:00:00"))
                {
                    cmd.CommandText += "AND dataDaReserva = @dataDaReserva ";
                    cmd.Parameters.Add("@dataDaReserva", parametro.dataDaReserva);
                }
                
            }

            cnnReserva.abrirConexao();
            MySqlDataReader retorno = cmd.ExecuteReader();
            List<EReserva> lstRetorno = new List<EReserva>();

            while (retorno.Read())
            {
                EReserva obj = new EReserva();
                PreencherObjeto(retorno, obj);
                lstRetorno.Add(obj);
            }
            cnnReserva.fecharConexao();
            return lstRetorno;
        }
       
     private static void PreencherObjeto(MySqlDataReader rdr, EReserva retorno){
            retorno.Identificador = Convert.ToInt32(rdr["Identificador"]);
            retorno.data = Convert.ToDateTime(rdr["data"].ToString());
            retorno.qtdDeHoras = (Convert.ToDouble(rdr["qtdDeHoras"]));
            retorno.valorTotal = (Convert.ToDecimal(rdr["valorTotal"].ToString()));
            retorno.FCodCliente.Identificador = Convert.ToInt32(rdr["FCodCliente"]);
            retorno.FCodCampo.Identificador = Convert.ToInt32(rdr["FCodCampo"]);
     }
    }
}
