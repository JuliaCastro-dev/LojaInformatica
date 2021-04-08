using LojaInfo.Login;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaInfo.Models;
using System.Data;

namespace LojaInfo.Acoes
{
    public class AcoesSistema
    {
        conexao con = new conexao();
        // ******************* FUNCIONARIO ACOES
        public void cadastrarLoginFuncionario(login user)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbl_login(nome_usu, senha_usu,tipo) values(@usuario,@senha,2)", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }

        public void cadastrarFuncionario(Funcionario func)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbl_funcionario(nm_func,end_func,cargo_func,tel_func) values(@nome,@end,@cargo,@tel)", con.MyConectarBD());

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = func.nm_func;
            cmd.Parameters.Add("@end", MySqlDbType.VarChar).Value = func.end_func;
            cmd.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = func.cargo_func;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = func.tel_func ;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }
        public DataTable consultaFuncionario()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_funcionario", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable func = new DataTable();
            da.Fill(func);
            con.MyDesconectarBD();
            return func;
        }
        MySqlDataReader dr;

        public void consultaBuscaFunc(Funcionario func)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_funcionario where cd_func=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@cod",func.cd_func);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                func.cd_func= dr[0].ToString();
                func.nm_func = dr[1].ToString();
                func.cargo_func = dr[2].ToString();

            }
            con.MyDesconectarBD();
        }

        public List<Funcionario> BuscarFunc()
        {
            List<Funcionario> Funclist = new List<Funcionario>();

            MySqlCommand cmd = new MySqlCommand("select cd_func as cd_func, nm_func as nm_func, end_func as end_func, cargo_func as cargo_func, tel_func as tel_func from tbl_funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Funclist.Add(

                    new Funcionario
                    {
                        cd_func = Convert.ToString(dr["cd_func"]),
                        nm_func = Convert.ToString(dr["nm_func"]),
                        end_func = Convert.ToString(dr["end_func"]),
                        cargo_func = Convert.ToString(dr["cargo_func"]),
                        tel_func = Convert.ToString(dr["tel_func"]),
                    });


            }
            return Funclist;
        }


        public bool excluirFuncionario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_funcionario where cd_func = @cd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ***************VENDA ACOES
        public void cadastrarVenda(Venda vend)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbl_venda(nm_cliente,dt_venda,tp_pagamento,end_cliente,vl_total, nm_produto, qt_produto) values(@nome,@dt, @tipo, @end, @vl, @produto,@qt)", con.MyConectarBD());

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = vend.nm_cliente;
            cmd.Parameters.Add("@dt", MySqlDbType.VarChar).Value = vend.dt_venda;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = vend.tp_pagamento;
            cmd.Parameters.Add("@end", MySqlDbType.VarChar).Value = vend.end_cliente;
            cmd.Parameters.Add("@vl", MySqlDbType.Decimal).Value = vend.vl_total;
            cmd.Parameters.Add("@produto", MySqlDbType.VarChar).Value = vend.nm_produto;
            cmd.Parameters.Add("@qt", MySqlDbType.Int16).Value = vend.qt_produto;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }


        public List<Vendas> ContaVendas()
        {
            List<Vendas> Funclist = new List<Vendas>();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS QuatidadeVendas FROM tbl_venda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();


            return Funclist;
        }
        public List<Vendas> MostraVendas()
        {
            List<Vendas> Vendalist = new List<Vendas>();

            MySqlCommand cmd = new MySqlCommand("select * from vw_MostraVendas;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            sd.Fill(dt);
            con.MyDesconectarBD();



            foreach (DataRow dr in dt.Rows)
            {
                Vendalist.Add(
                    new Vendas
                    {
                        cd_venda = Convert.ToString(dr["cd_venda"]),
                        cd_cliente = Convert.ToString(dr["cd_cliente"]),
                        tp_pagamento = Convert.ToString(dr["tp_pagamento"]),
                        vl_total = Convert.ToString(dr["vl_total"]),
                        dt_venda = Convert.ToDateTime(dr["dt_venda"])

                    });
            }
            return Vendalist;
        }

        // ****************PRODUTO ACOES
        public void cadastrarProduto(Produto prod)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tbl_produto(nm_produto,qt_estoque,vl_produto,desc_produto,setor_produto,marca_produto,img) values(@produto,@estoque,@valor,@desc,@setor,@marca,@img)", con.MyConectarBD());

            cmd.Parameters.Add("@produto", MySqlDbType.VarChar).Value = prod.produto;
            cmd.Parameters.Add("@estoque", MySqlDbType.VarChar).Value = prod.qt_estoque;
            cmd.Parameters.Add("@valor", MySqlDbType.Decimal).Value = prod.valor_prod;
            cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = prod.desc_produto;
            cmd.Parameters.Add("@setor", MySqlDbType.VarChar).Value = prod.setor_produto;
            cmd.Parameters.Add("@marca", MySqlDbType.VarChar).Value = prod.marca_produto;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = prod.img;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }
        public DataTable consultaProduto()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable produtos = new DataTable();
            da.Fill(produtos);
            con.MyDesconectarBD();
            return produtos;
        }

        MySqlDataReader drProd;
        public void BuscarAtualizaProduto(Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_produto where produto=@prod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@prod", prod.produto);
            drProd = cmd.ExecuteReader();

            while (drProd.Read())
            {
                prod.produto = drProd[1].ToString();
                prod.valor_prod = Convert.ToDecimal(drProd[2].ToString());
                prod.marca_produto = drProd[3].ToString();

            }



        }

        public void excluirProduto(Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_produto where produto = @cd", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = prod.produto;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

        }

        public void atualizaProduto(Produto prod)

        {

            MySqlCommand cmd = new MySqlCommand("update tbl_produto set qt_estoque=@qt , vl_produto=@vl , desc_produto=@desc, setor_produto=@setor, marca_produto=@marca, img=@img where nm_produto=@prod", con.MyConectarBD());



            cmd.Parameters.Add("@prod", MySqlDbType.VarChar).Value = prod.produto;

            cmd.Parameters.Add("@qt", MySqlDbType.VarChar).Value = prod.qt_estoque;

            cmd.Parameters.Add("@vl", MySqlDbType.VarChar).Value = prod.valor_prod;
            cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = prod.desc_produto;
            cmd.Parameters.Add("@setor", MySqlDbType.VarChar).Value = prod.setor_produto;
            cmd.Parameters.Add("@marca", MySqlDbType.VarChar).Value = prod.marca_produto;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = prod.img;




            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }

        public List<Produto> BuscarGamer()
        {
            List<Produto> Gamerlist = new List<Produto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto where setor_produto = 'Gamer'", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Gamerlist.Add(

                    new Produto
                    {
                        produto = Convert.ToString(dr["nm_produto"]),
                        marca_produto = Convert.ToString(dr["marca_produto"]),
                        valor_prod = Convert.ToDecimal(dr["vl_produto"]),
                        img = Convert.ToString(dr["img"])

                    });


            }
            return Gamerlist;
        }

        public List<Produto> BuscarPeriféricos()
        {
            List<Produto> Perilist = new List<Produto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto where setor_produto = 'Periféricos'", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Perilist.Add(

                    new Produto
                    {
                        produto = Convert.ToString(dr["nm_produto"]),
                        marca_produto = Convert.ToString(dr["marca_produto"]),
                        valor_prod = Convert.ToDecimal(dr["vl_produto"]),
                        img = Convert.ToString(dr["img"])

                    });


            }
            return Perilist;
        }



        public List<Produto> BuscarProdutos()
        {
            List<Produto> Prodlist = new List<Produto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Prodlist.Add(
                    new Produto
                    {

                        produto = Convert.ToString(dr["nm_produto"]),
                        qt_estoque = Convert.ToString(dr["qt_estoque"]),
                        desc_produto = Convert.ToString(dr["desc_produto"]),
                        valor_prod = Convert.ToDecimal(dr["vl_produto"]),
                        img = Convert.ToString(dr["img"])
                    });
            }
            return Prodlist;
        }


        //************* CLIENTE ACOES

        public DataTable consultaClientes()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable clientes = new DataTable();
            da.Fill(clientes);
            con.MyDesconectarBD();
            return clientes;
        }
       

        public List<Cliente> BuscarClientes()
        {
            List<Cliente> Clilist = new List<Cliente>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Clilist.Add(
                    new Cliente
                    {

                        cd_cliente = Convert.ToString(dr["cd_cliente"]),
                        nm_cliente = Convert.ToString(dr["nm_cliente"]),
                        tel_cliente = Convert.ToString(dr["tel_cliente"]),
                        end_cliente= Convert.ToString(dr["end_cliente"]),
                        CPF_cliente = Convert.ToString(dr["CPF_cliente"]),
                        email_cliente = Convert.ToString(dr["email_cliente"])

                    });
            }
            return Clilist;
        }

        public bool excluirCliente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbl_cliente where cd_cliente = @cdCliente", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCliente", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }


      

    }
    }