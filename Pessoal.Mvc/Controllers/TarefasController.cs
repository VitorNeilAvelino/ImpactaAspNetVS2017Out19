using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pessoal.Dominio.Entidades;
using Pessoal.Repositorios.SqlServer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pessoal.Mvc.Controllers
{
    public class TarefasController : Controller
    {
        private readonly TarefaRepositorio repositorio;

        public TarefasController(IConfiguration configuration)
        {
            repositorio = new TarefaRepositorio(
                configuration.GetConnectionString("pessoalSqlServer"));
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(repositorio.Selecionar());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            try
            {
                repositorio.Inserir(tarefa);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Não foi possível inserir.");

                return View(tarefa);
            }            
        }
    }
}
