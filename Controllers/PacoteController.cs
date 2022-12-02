using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using atividade02.Models;

namespace atividade02.Controllers
{
    public class PacoteController : Controller
    {
        public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(pacoteTurismo novoPct)
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            pacoteTurismoRepository pctR = new pacoteTurismoRepository();
            pctR.Insert(novoPct);
            ViewBag.Mensagem = "Pacote cadastrado com sucesso!";
            return View("Listar");
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            pacoteTurismoRepository pct = new pacoteTurismoRepository();
            List<pacoteTurismo> listaPacotes = pct.Query();
            return View(listaPacotes);
        }
        public IActionResult Atualizar(int id)
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            pacoteTurismoRepository pctR = new pacoteTurismoRepository();
            pacoteTurismo pct = pctR.BuscarPorID(id);
            return View(pct);
        }
        [HttpPost]
        public IActionResult Atualizar(pacoteTurismo pct)
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            pacoteTurismoRepository pctR = new pacoteTurismoRepository();
            pctR.Atualizar(pct);
            ViewBag.Mensagem = "Pacote Atulizado com sucesso!";
            return RedirectToAction("Index", "Home");  
        }
        public IActionResult Remover(int id)
        {            
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login","Usuario");
            pacoteTurismoRepository pctR = new pacoteTurismoRepository();
            pctR.Remover(id);
            return RedirectToAction("Listar");

        }
        public IActionResult Logout()
        {
            if(HttpContext.Session != null)
            {
             HttpContext.Session.Clear();
             return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
        }
    }
}