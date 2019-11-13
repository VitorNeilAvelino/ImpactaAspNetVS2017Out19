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
    }
}