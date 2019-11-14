using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InsertTeste()
        {
            var destino = new Destino();
            destino.Cidade = "Dublin";
            destino.Nome = "Conheça a terra da Guiness";
            destino.NomeImagem = "dublin.jpg";
            destino.Pais = "Irlanda";

            db.Destinos.Add(destino);

            db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            //db.Destinos.Where();
            var destino = db.Destinos.Find(1);

            destino.NomeImagem = "guinness.png";

            db.SaveChanges();

            //destino = db.Destinos.Where(d => d.Id == 1).SingleOrDefault();
            destino = db.Destinos.SingleOrDefault(d => d.Id == 1);

            Assert.AreEqual(destino.NomeImagem, "guinness.png");
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            var destino = db.Destinos.Find(1);

            db.Destinos.Remove(destino);

            db.SaveChanges();

            destino = db.Destinos.Find(1);

            Assert.IsNull(destino);
        }
    }
}