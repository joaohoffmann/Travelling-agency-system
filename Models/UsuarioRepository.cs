using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace atividade02.Models
{
    public class UsuarioRepository
    {
        private const string  endConexao = "Database=atividade02; Data source=localhost; User ID=root; Allow User Variables=true;";

        public void Insert(Usuarios novoUsuario)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();

            string sqlInsert = "insert into usuarios (nome, login, senha, dataNascimento) values(@nome, @login, @senha, NOW())";
            MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
            comando.Parameters.AddWithValue("@nome", novoUsuario.nome);
            comando.Parameters.AddWithValue("@login", novoUsuario.login);
            comando.Parameters.AddWithValue("@senha", novoUsuario.senha);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public List<Usuarios> Query()
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();
            string sqlSelect = "select * from usuarios order by nome;";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuarios> listaUsuarios = new List<Usuarios>();

            while (reader.Read())
            {
                Usuarios usr = new Usuarios();
                usr.id = reader.GetInt32("id");

                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                    usr.nome = reader.GetString("nome");
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login = reader.GetString("login");
                if(!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha = reader.GetString("senha");
                listaUsuarios.Add(usr);               
            }
            conexao.Close();
            return listaUsuarios;
        }
        public Usuarios QueryLogin(Usuarios u)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();
            string sqlLogin = "select * from usuarios where login= @login and senha= @senha";
            MySqlCommand comandoLogin = new MySqlCommand(sqlLogin, conexao);
            comandoLogin.Parameters.AddWithValue("@login", u.login);
            comandoLogin.Parameters.AddWithValue("@senha", u.senha);
            MySqlDataReader reader = comandoLogin.ExecuteReader();
            Usuarios usr = null;
            if (reader.Read())
            {
                usr = new Usuarios();
                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                    usr.nome = reader.GetString("nome");
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login = reader.GetString("login");
                if(reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha = reader.GetString("senha");
            }
            conexao.Close();
            return usr;

        }

        public void Atualizar(Usuarios u)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();

            string sqlUpdate = "update usuarios set nome=@nome, login=@login, senha= @senha where id=@id";
            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
            comando.Parameters.AddWithValue("@id", u.id);
            comando.Parameters.AddWithValue("@nome", u.nome);
            comando.Parameters.AddWithValue("@login", u.login);
            comando.Parameters.AddWithValue("@senha", u.senha);
            comando.ExecuteNonQuery();
            conexao.Close();

        }
        public void Remover(int id)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();

            string sqlDelete = "delete from usuarios where id=@id ";
            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);
            comando.Parameters.AddWithValue("@id",id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public Usuarios BuscarPorID(int id)
        {
            MySqlConnection conexao = new MySqlConnection(endConexao);
            conexao.Open();
            string sqlSelectID = "select * from usuarios where id=  @id;";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelectID, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuarios Usr = new Usuarios();

            if(reader.Read())
            {
                Usr.id = reader.GetInt32("id");
                if(!reader.IsDBNull(reader.GetOrdinal("nome")))
                    Usr.nome = reader.GetString("nome");
                if(!reader.IsDBNull(reader.GetOrdinal("login")))
                    Usr.login = reader.GetString("login");
                if(reader.IsDBNull(reader.GetOrdinal("senha")))
                    Usr.senha = reader.GetString("senha");               
            }
            conexao.Close();
            return Usr;

        }

    }
}
