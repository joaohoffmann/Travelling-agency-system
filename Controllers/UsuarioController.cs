using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using atividade02.Models;

namespace atividade02.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuarios u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Insert(u);
            ViewBag.Mensagem = "Cadastrado com sucesso!";
            return View();
        }
        public IActionResult Listar()
        {
            if(HttpContext.Session.GetInt32("idUsuario")== null)
                return RedirectToAction("Login");
            UsuarioRepository ur = new UsuarioRepository();
            List<Usuarios> lista = ur.Query();
            return View(lista);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuarios u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuarios usuario = ur.QueryLogin(u);

            if(usuario != null)
            {
                ViewBag.Mensagem="Você esta logado!";
                HttpContext.Session.SetInt32("idUsuario", usuario.id);
                HttpContext.Session.SetString("nomeUsuario", usuario.nome);
                return RedirectToAction("Listar");
            }
            else
            {
                ViewBag.Mensagem="Usuário não cadastrado!";
                return View();
            }
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

        public IActionResult Atualizar(int id)
        {
            if(HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("Login");  
            UsuarioRepository usr = new UsuarioRepository();
            Usuarios u = usr.BuscarPorID(id);
            return View(u);  
        }
        [HttpPost]
        public IActionResult Atualizar(Usuarios u)
        {
            if(HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("Login");
            UsuarioRepository usr = new UsuarioRepository();
            usr.Atualizar(u);
            ViewBag.Mensagem = "Usuario atualizado com sucesso!";
            return RedirectToAction("Listar");
        }
        public IActionResult Remover(int id)
        {
            if(HttpContext.Session.GetInt32("idUsuario") == null)
                return RedirectToAction("Login");
            UsuarioRepository usr = new UsuarioRepository();
            usr.Remover(id);
            return RedirectToAction("Listar");
        }

    }
}