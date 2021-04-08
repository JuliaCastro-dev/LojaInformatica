using LojaInfo.Acoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaInfo.Login;
using LojaInfo.Models;
using System.Web.Security;

namespace LojaInfo.Controllers
{
    public class SiteController : Controller
    {
        conexao con = new conexao();
        LoginAcoes logar = new LoginAcoes();
        login login = new login();
        AcoesSistema acS = new AcoesSistema();
        public ActionResult Index()
        {
            
            return View();

        }

        public ActionResult DashboardCliente()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( login verLogin)
        {
            logar.TestarUsuario(verLogin);
            if (verLogin.usuario != null && verLogin.senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.usuario, false);
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();



                if (verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString(); //=1 GERENTE;
                    return RedirectToAction("DashboardGerente", "Sistema");
                }
                else if (verLogin.tipo == "2")
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString();//=2 FUNCIONARIO
                    return RedirectToAction("DashboardGerente", "Sistema");
                }
                else
                {
                    Session["tipoLogado3"] = verLogin.tipo.ToString();//=3 CLIENTE
                    return RedirectToAction("DashboardCliente", "Cliente");
                }
                

               
            }

            else
            {
                Response.Write("<script> alert('Erro no login')</script >");
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();

            }

           
        }

    }
}