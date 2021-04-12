using LojaInfo.Login;
using LojaInfo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaInfo.Acoes
{
    public class ClienteAcoes
    {
        conexao con = new conexao();

        public void InserirCliente(Cliente cli)
        {
            conexao con = new conexao();
            
            MySqlCommand cmd = new MySqlCommand(" insert into tbl_cliente(nm_cliente, cpf_cliente, end_cliente, email_cliente) values(@nomeCli , @cpfCli, @endCli, @emailCli )", con.MyConectarBD());
         
            cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cli.nm_cliente;

            cmd.Parameters.Add("@cpfCli", MySqlDbType.VarChar).Value = cli.CPF_cliente;

            cmd.Parameters.Add("@endCli", MySqlDbType.VarChar).Value = cli.end_cliente;
            cmd.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = cli.email_cliente;



            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }
        //public void cadastrarLoginCliente(login user)
        //{

        //    MySqlCommand cmd = new MySqlCommand("insert into tbl_login(nome_usu, senha_usu,tipo) values(@usuario,@senha,3)", con.MyConectarBD());

        //    cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
        //    cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;


        //    cmd.ExecuteNonQuery();

        //    con.MyDesconectarBD();
        //}
        public DataTable consultaCliente()

        {

            MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable Clientes = new DataTable();

            da.Fill(Clientes);

            con.MyDesconectarBD();

            return Clientes;

        }



      

    

     


        //MySqlDataReader dr;
        //public void BuscaCliente(Cliente cli)
        //{
        //    MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente where nm_cliente like %@nome%", con.MyConectarBD());
        //    cmd.Parameters.AddWithValue("@nome", cli.nm_cliente);
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {

        //        cli.cd_cliente = dr[0].ToString();
        //        cli.nm_cliente = dr[1].ToString();
        //        cli.CPF_cliente = dr[2].ToString();
        //        cli.tel_cliente = dr[3].ToString();
        //        cli.end_cliente = dr[4].ToString();



        //    }
        //    con.MyDesconectarBD();
        //}


        public bool atualizarCliente(Cliente cli)

        {



            MySqlCommand cmd = new MySqlCommand("update tbl_cliente set nm_cliente=@nomeCli, cpf_cliente=@cpfCli, End_cliente=@endCli, email_cliente=@emailCli where cd_cliente=@codCli", con.MyConectarBD());



            cmd.Parameters.Add("@codCli", MySqlDbType.VarChar).Value = cli.cd_cliente;

            cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cli.nm_cliente;


            cmd.Parameters.Add("@cpfCli", MySqlDbType.VarChar).Value = cli.CPF_cliente;

            cmd.Parameters.Add("@endCli", MySqlDbType.VarChar).Value = cli.end_cliente;

            cmd.Parameters.Add("@emailCli", MySqlDbType.VarChar).Value = cli.email_cliente;

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }


        public bool excluirCliente(int id)
        {



            MySqlCommand cmd = new MySqlCommand("delete from tbl_cliente where cd_cliente=@codCli", con.MyConectarBD());



            cmd.Parameters.AddWithValue("@codCli", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }
        public List<Cliente> listarCliente()
        {
            List<Cliente> ClienteList = new List<Cliente>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente "
                , con.MyConectarBD());

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();
            foreach (DataRow dr in dt.Rows)
            {
                ClienteList.Add(
                    new Cliente
                    {
                        cd_cliente = Convert.ToString(dr["cd_cliente"]),
                        nm_cliente = Convert.ToString(dr["nm_cliente"]),
                       
                        CPF_cliente = Convert.ToString(dr["CPF_cliente"]),
                        end_cliente = Convert.ToString(dr["end_cliente"]),
                        email_cliente = Convert.ToString(dr["email_cliente"])
                    });
            }
            return ClienteList;
        }
    }
}
