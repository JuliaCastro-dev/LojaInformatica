using LojaInfo.Acoes;
using LojaInfo.Login;
using LojaInfo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LojaInfo.Controllers
{
    public class SistemaController : Controller
    {
        Produto produto = new Produto();
        ClienteAcoes cliA = new ClienteAcoes();
        AcoesSistema acS = new AcoesSistema();
        // GET: Sistema
        public static string QT;
        public static int id;
        public void carregaProdutos()
        {
            List<SelectListItem> prod = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=dbInfo;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_produto order by nm_produto;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    prod.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.Produto = new SelectList(prod, "Value", "Text");
        }



        public void carregaClientes()
        {
            List<SelectListItem> cli = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=dbInfo;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente order by nm_cliente;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cli.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.cliente = new SelectList(cli, "Value", "Text");
        }




        public ActionResult DashboardGerente()
        {
            ModelState.Clear();
           
         
           
            return View(acS.ContaVendas());
        }

        public ActionResult Vendas()
        {
            ModelState.Clear();
            return View(acS.MostraVendas());
        }

        public ActionResult Funcionarios()
        {
            
            ModelState.Clear();
            return View(acS.BuscarFunc());
            try
            {
                
                if (acS.excluirFuncionario(id))
                {
                    ViewBag.AlertMsg = "Cliente excluído com sucesso";
                }
                return RedirectToAction("Funcionarios");
            }
            catch
            {
                return View();
            }

    

        }


        public ActionResult Clientes()
        {
            ModelState.Clear();
            return View(acS.BuscarClientes());
          
        }

    
        public ActionResult Produtos(string btn)
        {
            ModelState.Clear();
          
                return View(acS.BuscarProdutos());
         
        }

        public ActionResult EditarProduto(string btn, FormCollection frm)
        {
          

            if (btn == "Buscar")
            {
                produto.produto = frm["produto"];
                acS.BuscarAtualizaProduto(produto);
                ViewBag.prod = produto.produto;
                ViewBag.valor = produto.valor_prod;
                ViewBag.marca = produto.marca_produto;


                return View();

            }

            else if (btn == "Atualizar")
            {
                produto.produto = frm["produto"];
                produto.desc_produto = frm["Descição"];
                produto.marca_produto = frm["Marca"];
                produto.setor_produto= frm["Setor"];
                produto.valor_prod = Convert.ToDecimal(frm["valor"]);

                acS.atualizaProduto(produto);
                return View();
            }

            else if (btn == "Excluir")
            {
                produto.produto = frm["produto"];
               
                acS.excluirProduto(produto);
                return View();
            }

            else
            {
                return View();
            }


        }

        public ActionResult ProdutosGamer()
        {
            ModelState.Clear();
            return View(acS.BuscarGamer());

        }

        public ActionResult ProdutosPerifericos()
        {
            ModelState.Clear();
            return View(acS.BuscarPeriféricos());

        }

        public static string nome;


        public ActionResult buscaClientes()
        {
            ModelState.Clear();
            return View(acS.BuscarClientes());
            
        }
        public ActionResult CadastrarFuncionario()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarFuncionario(Funcionario func)
        {
            acS.cadastrarFuncionario(func);



            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }

        public ActionResult CadastrarVenda()
        {
            carregaProdutos();
            carregaClientes();
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarVenda(Venda vend, Produto prod)
        {
            carregaProdutos();
            carregaClientes();
            vend.nm_cliente = Request["cliente"];
            vend.nm_produto =  Request["produto"];
            ViewBag.ValorTotal = prod.valor_prod * vend.qt_produto;
            acS.cadastrarVenda(vend);

            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }

       
        public ActionResult cadastroLoginFunc()

        {

            return View();

        }

        [HttpPost]

        public ActionResult cadastroLoginFunc(login user)

        {
            acS.cadastrarLoginFuncionario(user);


            ViewBag.confCadastro = "Cadastro Realizado com sucesso";

            return View();

        }
        public static string cod;

      
       

        public ActionResult CadastrarProduto()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto prod)
        {
          
            
            acS.cadastrarProduto(prod);
            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();

        }
      
     

    }

}
