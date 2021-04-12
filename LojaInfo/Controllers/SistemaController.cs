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
        public static string QT;
        public static int id;

        public static string nome;
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
                MySqlCommand cmd = new MySqlCommand("select * from tbl_cliente order by cd_cliente", con);
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

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Site");
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

        //EXCLUIR
        public ActionResult excluirFuncionario(int id)
        {
            try
            {
                AcoesSistema sdb = new AcoesSistema();
                if (sdb.excluirFuncionario(id))
                {
                    ViewBag.AlertMsg = "Funcionário excluído com sucesso";
                }
                return RedirectToAction("Funcionarios");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult excluirCliente(int id)
        {
            try
            {
                ClienteAcoes sdb = new ClienteAcoes();
                if (sdb.excluirCliente(id))
                {
                    ViewBag.AlertMsg = "Cliente excluído com sucesso";
                }
                return RedirectToAction("Clientes");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult excluirProduto(string id)
        {
            try
            {
                AcoesSistema sdb = new AcoesSistema();
                if (sdb.excluirProduto(id))
                {
                    ViewBag.AlertMsg = "Produto excluído com sucesso";
                }
                return RedirectToAction("~Views/Sistema/Produtos.cshtml");
            }
            catch
            {
                return View();
            }
        }

        // EDITAR

        public ActionResult editarCliente(string id)
        {




            ClienteAcoes sdb = new ClienteAcoes();
            return View(sdb.listarCliente().Find(smodel => smodel.cd_cliente == id));


        }

        // Ação ao clicar no botão de editar Cliente
        [HttpPost]
        public ActionResult editarCliente(int id, Cliente smodel)
        {
            try
            {
                ClienteAcoes sdb = new ClienteAcoes();
                sdb.atualizarCliente(smodel);
                return RedirectToAction("Clientes");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult editarProduto(string id)
        {
            AcoesSistema sdb = new AcoesSistema();
            return View(sdb.BuscarProdutos().Find(smodel => smodel.produto == id));

        }

        // Ação ao clicar no botão de editar Cliente
        [HttpPost]
        public ActionResult editarProduto(int id, Produto prod)
        {
            try
            {
                AcoesSistema sdb = new AcoesSistema();
                sdb.atualizarProduto(prod);
                return RedirectToAction("Produtos");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult editarFuncionario(string id)
        {

            AcoesSistema sdb = new AcoesSistema();
            return View(sdb.BuscarFunc().Find(func => func.cd_func == id));


        }

        [HttpPost]
        public ActionResult editarFuncionario(int id, Funcionario func)
        {
            try
            {
                AcoesSistema sdb = new AcoesSistema();
                sdb.atualizarFuncionario(func);
                return RedirectToAction("Funcionarios");
            }
            catch
            {
                return View();
            }
        }

        // BUSCA
        public ActionResult buscaClientes()
        {
            ModelState.Clear();
            return View(acS.BuscarClientes());
            
        }

        //CADASTRA
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
            GridView dgv = new GridView();

            dgv.DataSource = acS.consultaProdutos();

            dgv.DataBind(); //Confirmação do Grid 

            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela 

            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela 

            dgv.RenderControl(htw); //Comando para construção do Grid na tela 

            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela 


            carregaClientes();
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarVenda(Venda vend, Produto prod)
        {
         
            carregaClientes();
            vend.cd_cliente = Request["cliente"];
            vend.nm_produto =  Request["produto"];
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
