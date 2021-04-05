using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaInfo.Login;


namespace LojaInfo.Acoes
{
    public class LoginAcoes
    {

        conexao con = new conexao();
        public void TestarUsuario(login user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_login where nome_usu = @usuario and senha_usu = @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.usuario = Convert.ToString(leitor["nome_usu"]);
                    user.senha = Convert.ToString(leitor["senha_usu"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }

            else
            {
                user.usuario = null;
                user.senha = null;
                user.tipo = null;
            }

            con.MyDesconectarBD();
        }

        public void cadastrarLogin(login user )
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbl_login(nome_usu, senha_usu,tipo) values(@usuario,@senha,@tipo)", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = user.tipo;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }
    }
}