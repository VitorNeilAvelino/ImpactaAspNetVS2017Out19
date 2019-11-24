using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Areas.Vendas.Models;
using Loja.Mvc.Mapeamento;
using Loja.Repositorios.SqlServer;

namespace Loja.Mvc.Areas.Vendas.Controllers
{
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();
        private ProdutoMapeamento produtoMap = new ProdutoMapeamento();

        public ActionResult Index()
        {
            return View(produtoMap.Mapear(db.Produtos.ToList()));
        }

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

        public ActionResult Create()
        {
            return View(produtoMap.Mapear(new Produto(), db.Categorias.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtoMap.Mapear(viewModel, db));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

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
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

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
            return View(produto);
        }

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