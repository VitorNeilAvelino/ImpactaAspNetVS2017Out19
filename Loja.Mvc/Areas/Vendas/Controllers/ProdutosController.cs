using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Areas.Vendas.Models;
using Loja.Mvc.Helpers;
using Loja.Mvc.Mapeamentos;
using Loja.Repositorios.SqlServer;

namespace Loja.Mvc.Areas.Vendas.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();
        private readonly ProdutoMapeamento produtoMap = new ProdutoMapeamento();

        [AllowAnonymous]
        public ActionResult Index()
        {
            //var produtoes = db.Produtos.Include(p => p.Imagem);
            return View(produtoMap.Mapear(db.Produtos.ToList()));
        }

        // GET: Vendas/Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [Authorize(Users = "avelino.vitor@gmail.com")]
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType");
            return View(produtoMap.Mapear(new Produto(), db.Categorias.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "avelino.vitor@gmail.com")]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtoMap.Mapear(produto, db));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(produto);
        }

        // GET: Vendas/Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType", produto.Id);
            return View(produto);
        }

        // POST: Vendas/Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,Estoque")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType", produto.Id);
            return View(produto);
        }

        //[Authorize(Roles = "Master, Premium, Gerente, Odin")]
        [AuthorizeRole(PerfilUsuario.Master, PerfilUsuario.Gerente)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produtoMap.Mapear(produto));
        }

        //[Authorize(Roles = "Zeus")]
        [Authorize(Roles = "Master, Premium, Gerente, Odin")]
        //[Authorize(Roles = Perfil.Master.ToString())]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
