using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Dominio;
using ViagensOnline.Mvc.Mapeamentos;
using ViagensOnline.Mvc.Models;
using ViagensOnline.Repositorios.SqlServer;

namespace ViagensOnline.Mvc.Controllers
{
    public class DestinosController : Controller
    {
        private ViagensOnlineDbContext db = new ViagensOnlineDbContext();
        private string caminhoImagensDestinos = 
            ConfigurationManager.AppSettings["caminhoImagensDestinos"];
        private DestinosMapeamento mapeamento = new DestinosMapeamento();

        // GET: Destinos
        public ActionResult Index()
        {
            return View(Mapear(db.Destinos.ToList()));
        }

        private List<DestinoViewModel> Mapear(List<Destino> destinos)
        {
            var viewModels = new List<DestinoViewModel>();

            foreach (var destino in destinos)
            {
                viewModels.Add(Mapear(destino));
            }

            return viewModels;
        }

        private DestinoViewModel Mapear(Destino destino)
        {
            var viewModel = new DestinoViewModel();

            viewModel.CaminhoImagem = Path.Combine(caminhoImagensDestinos, 
                destino.NomeImagem);
            viewModel.Cidade = destino.Cidade;
            viewModel.Id = destino.Id;
            viewModel.Nome = destino.Nome;
            viewModel.Pais = destino.Pais;

            return viewModel;
        }

        // GET: Destinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // GET: Destinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DestinoViewModel viewModel)
        {
            if (viewModel.ArquivoFoto == null)
            {
                ModelState.AddModelError("", "É necessário enviar uma imagem.");
            }

            if (ModelState.IsValid)
            {
                SalvarFoto(viewModel.ArquivoFoto);

                db.Destinos.Add(Mapear(viewModel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private void SalvarFoto(HttpPostedFileBase arquivoFoto)
        {
            var caminhoVirtual = 
                Path.Combine(caminhoImagensDestinos, arquivoFoto.FileName);

            var caminhoFisico = Request.MapPath(caminhoVirtual);

            arquivoFoto.SaveAs(caminhoFisico);
            //arquivoFoto.InputStream;
        }

        private Destino Mapear(DestinoViewModel viewModel)
        {
            var destino = new Destino();

            destino.NomeImagem = viewModel.ArquivoFoto.FileName;
            destino.Cidade = viewModel.Cidade;
            destino.Id = viewModel.Id;
            destino.Nome = viewModel.Nome;
            destino.Pais = viewModel.Pais;

            return destino;
        }

        // GET: Destinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // POST: Destinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DestinoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var destino = db.Destinos.Find(viewModel.Id);

                db.Entry(destino).CurrentValues.SetValues(viewModel);
                //db.Entry(destino).State = EntityState.Modified;

                if (viewModel.ArquivoFoto != null)
                {
                    SalvarFoto(viewModel.ArquivoFoto);
                    destino.NomeImagem = viewModel.ArquivoFoto.FileName;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Destinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destinos.Find(id);
            db.Destinos.Remove(destino);
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
