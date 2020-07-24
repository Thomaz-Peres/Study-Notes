using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SQLite.BancoDados
{
    class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = C:\\Users\\AlphaPaiN\\Documents\\dev\\Notes\\Visual Studio\\SQLite\\Banco de Dados\\Banco_academia.db");
            conexao.Open();
            return conexao;
        }

        public static DataTable ObterTodosUsuarios()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            { 
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM tb_usuarios";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Consulta(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ConexaoBanco().Close();
                throw ex;
            }
        }
        
        public static void NovoUsuario(Usuario usuario)
        {
            if(existeUsername(usuario))
            {
                MessageBox.Show("Username ja existe");
                return;
            }
            try
            {
                var cmd = ConexaoBanco().CreateCommand();
                cmd.CommandText = "INSERT INTO tb_usuarios " +
                    "(T_NOMEUSUARIO," +
                    " T_USERNAME," +
                    " T_SENHAUSUARIO," +
                    " T_STATUSUSUARIO," +
                    " N_NIVELUSUARIO)" +
                    " VALUES (@nome, @username, @senha, @status, @nivel)";
                cmd.Parameters.AddWithValue("@nome", usuario.nome);
                cmd.Parameters.AddWithValue("@username", usuario.username);
                cmd.Parameters.AddWithValue("@senha", usuario.senha);
                cmd.Parameters.AddWithValue("@status", usuario.status);
                cmd.Parameters.AddWithValue("@nivel", usuario.nivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo usuario inserido");
                ConexaoBanco().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar novo usuario");
                ConexaoBanco().Close();
            }
        }

        public static bool existeUsername(Usuario u)
        {
            bool res;

            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            var cmd = ConexaoBanco().CreateCommand();
            cmd.CommandText = "SELECT T_USERNAME FROM tb_usuarios WHERE T_USERNAME='"+u.username+"' ";
            da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            return res;
        }

    }
}
