using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Areas.Vendas.Models;
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

        [Authorize(Users = "avelino.vitor@gmail.com")]
        public ActionResult Create()
        {            
            return View(produtoMap.Mapear(new Produto(), db.Categorias.ToList()));
        }

        [HttpPost]
        [Authorize(Users = "avelino.vitor@gmail.com")]
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
            ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType", produto.Id);
            return View(produto);
        }

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

        [Authorize(Roles = "Master, Gerente")]
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
