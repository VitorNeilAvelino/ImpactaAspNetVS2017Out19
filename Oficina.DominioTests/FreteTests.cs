using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio.Tests
{
    [TestClass()]
    public class FreteTests
    {
        [TestMethod()]
        public void CalcularTest()
        {
            var frete = new Frete(UF.MG, 20.2M);
            frete.Cliente = new Cliente { Nome = "Vítor" };
            //frete.UF = UF.MG;
            //frete.ValorFrete = 200;
            //frete.ValorProduto = 20.2m;

            //frete.Calcular();

            Assert.AreEqual(frete.ValorFrete, 0.35m);
            Assert.AreEqual(frete.ValorTotal, 27.27m);
        }
    }
}