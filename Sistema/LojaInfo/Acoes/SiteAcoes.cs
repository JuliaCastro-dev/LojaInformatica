using LojaInfo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInfo.Acoes
{
    public class SiteAcoes
    {
        conexao con = new conexao();
        MySqlDataReader dr;
        public void consultaBuscaProduto(Produto prod)

        {

            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto where nm_produto like '%@prod%'", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@prod", prod.produto);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            dr = cmd.ExecuteReader();



            while (dr.Read())

            {



                prod.img = dr[0].ToString();



                prod.produto = dr[1].ToString();



                prod.valor_prod = Convert.ToDecimal(dr[2].ToString());



            }

            con.MyDesconectarBD();

        }
    }
}