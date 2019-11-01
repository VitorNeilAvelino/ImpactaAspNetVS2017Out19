using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        ModeloRepositorio repositorio = new ModeloRepositorio();

        [TestMethod()]
        public void ObterTest()
        {
            var modelos = repositorio.ObterPorMarca(2);

            foreach (var modelo in modelos)
            {
                Console.WriteLine($"{modelo.Id} - {modelo.Nome} - {modelo.Marca.Nome}");
            }

            modelos = repositorio.ObterPorMarca(9);

            Assert.IsTrue(modelos.Count == 0);
        }

        [TestMethod()]
        public void ObterPorIdTest()
        {
            var modelo = repositorio.Obter(4);

            Assert.AreEqual(modelo.Nome, "Polo");

            modelo = repositorio.Obter(28);

            Assert.IsNull(modelo);
        }
    }
}