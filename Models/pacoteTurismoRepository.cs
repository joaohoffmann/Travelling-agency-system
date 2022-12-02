using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace atividade02.Models
{
    public class pacoteTurismoRepository
    {
        private const string  endConexao = "Database=atividade02; Data source=localhost; User ID=root; Allow User Variables=true;";

        public void Insert(pacoteTurismo novopct)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();

            string sqlCadastro = "insert into pacotesTuristicos (nome, origem, destino, atrativos) values(@nome, @origem, @destino, @atrativos)";
            MySqlCommand comando = new MySqlCommand(sqlCadastro, conexao);
            comando.Parameters.AddWithValue("nome", novopct.nome);
            comando.Parameters.AddWithValue("origem", novopct.origem);
            comando.Parameters.AddWithValue("destino", novopct.destino);
            comando.Parameters.AddWithValue("atrativos", novopct.atrativos);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<pacoteTurismo> Query()
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();
            string sqlSelect = "select *  from pacotesTuristicos order by nome;";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<pacoteTurismo> listaPacotes = new List<pacoteTurismo>();

            while (reader.Read())
            {
                pacoteTurismo pct = new pacoteTurismo();
                pct.id = reader.GetInt32("id");

                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                    pct.nome = reader.GetString("nome");
                if(!reader.IsDBNull(reader.GetOrdinal("origem")))
                    pct.origem = reader.GetString("origem");
                if(!reader.IsDBNull(reader.GetOrdinal("destino")))
                    pct.destino = reader.GetString("destino");
                if(!reader.IsDBNull(reader.GetOrdinal("atrativos")))
                    pct.atrativos = reader.GetString("atrativos");
                listaPacotes.Add(pct);               
            }
            conexao.Close();
            return listaPacotes;
        }
        public void Remover(int id)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();

            string sqlDelete = "delete from pacotesTuristicos where id=@id";
            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public void Atualizar(pacoteTurismo pct)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();
            string sqlUpdate = "update pacotesTuristicos set nome=@nome, origem = @origem, destino=@destino, atrativos=@atrativos where id=@id";

            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
            comando.Parameters.AddWithValue("@id", pct.id);
            comando.Parameters.AddWithValue("@nome", pct.nome);
            comando.Parameters.AddWithValue("@origem", pct.origem);
            comando.Parameters.AddWithValue("@destino", pct.destino);
            comando.Parameters.AddWithValue("@atrativos", pct.atrativos);
            comando.ExecuteNonQuery();
            conexao.Close();
        } 
        public pacoteTurismo BuscarPorID(int id)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();
            string sqlSelectID = "select * from usuarios where id=  @id;";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelectID, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            pacoteTurismo pct = new pacoteTurismo();

            if(reader.Read())
            {
                pct.id = reader.GetInt32("id");
                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                    pct.nome = reader.GetString("nome");
                if(!reader.IsDBNull(reader.GetOrdinal("origem")))
                    pct.origem = reader.GetString("origem");
                if(reader.IsDBNull(reader.GetOrdinal("destino")))
                    pct.destino = reader.GetString("destino");
                if(reader.IsDBNull(reader.GetOrdinal("atrativos")))
                    pct.atrativos = reader.GetString("atrativos");                  
            }
            conexao.Close();
            return pct;

        }
        
    }
}