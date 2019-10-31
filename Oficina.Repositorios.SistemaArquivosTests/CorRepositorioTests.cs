using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        private CorRepositorio corRepositorio = new CorRepositorio();

        [TestMethod()]
        public void ObterTest()
        {
            var cores = corRepositorio.Obter();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }
        }

        [TestMethod()]
        public void ObterPorIdTest()
        {
            var cor = corRepositorio.Obter(1);
            Assert.AreEqual(cor.Nome, "Branco");

            cor = corRepositorio.Obter(8);
            Assert.IsNull(cor);
        }
    }
}