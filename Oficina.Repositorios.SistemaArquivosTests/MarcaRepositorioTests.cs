using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MarcaRepositorioTests
    {
        private MarcaRepositorio marcaRepositorio = new MarcaRepositorio();

        [TestMethod()]
        public void ObterTest()
        {
            var marcas = marcaRepositorio.Obter();

            foreach (var marca in marcas)
            {
                Console.WriteLine($"{marca.Id} - {marca.Nome}");
            }
        }

        [TestMethod()]
        public void ObterPorIdTest()
        {
            var marca = marcaRepositorio.Obter(1);
            Assert.AreEqual(marca.Nome, "Ford");

            marca = marcaRepositorio.Obter(8);
            Assert.IsNull(marca);
        }
    }
}