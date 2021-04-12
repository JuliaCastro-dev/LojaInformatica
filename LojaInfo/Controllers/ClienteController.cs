using LojaInfo.Acoes;
using LojaInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaInfo.Login;

namespace LojaInfo.Controllers
{
    public class ClienteController : Controller
    {
        ClienteAcoes cliA = new ClienteAcoes();
        LoginAcoes Log = new LoginAcoes();
        Cliente cad = new Cliente();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult cadastroCliente()

        {

            return View();

        }





        [HttpPost]

        public ActionResult cadastroCliente(Cliente cli)

        {

            cliA.InserirCliente(cli);



            ViewBag.confCadastro = "Cadastro Realizado com sucesso";

            return View();

        }

        

        


    }
}