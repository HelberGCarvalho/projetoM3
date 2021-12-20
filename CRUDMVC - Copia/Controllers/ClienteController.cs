using CRUDMVC.Models;
using CRUDMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace CRUDMVC.Controllers
{
    [Route("Cliente")]
    public class ClienteController : Controller
    {
        [HttpGet]
        [Route("Listar")]
        public IActionResult Index()
        {


            var dbcontext = new Contexto();
            ViewData["Clientes"] = dbcontext.Clientes.Where(p => p.Id > 0).ToList();
            return View();

        }

        [HttpPost]
        [Route("Listar")]
        public IActionResult Index(Cliente Cliente)
        {
            var dbcontext = new Contexto();
            dbcontext.Add(Cliente);
            dbcontext.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(Cliente cliente)
        {
            var dbcontext = new Contexto();

            var clienteDelete = dbcontext.Clientes.Find(cliente.Id);
            dbcontext.Remove(clienteDelete);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar(Cliente novosDadosCliente)
        {
            var dbcontext = new Contexto();

            var antigosDadosCliente = dbcontext.Clientes.Find(novosDadosCliente.Id);

            antigosDadosCliente.Nome = novosDadosCliente.Nome;
            antigosDadosCliente.CPF = novosDadosCliente.CPF;
            antigosDadosCliente.Email = novosDadosCliente.Email;
            antigosDadosCliente.Sexo = novosDadosCliente.Sexo;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");





        }


    }
}
