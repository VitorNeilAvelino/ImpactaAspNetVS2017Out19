using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void GravarTest()
        {
            var veiculo = new Veiculo();

            veiculo.Ano = 2014;
            veiculo.Cambio = Cambio.Manual;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cor = new CorRepositorio().Obter(1);
            veiculo.Modelo = new ModeloRepositorio().Obter(1);
            veiculo.Observacao = "Obs";
            veiculo.Placa = "ABC1234";

            new VeiculoRepositorio().Gravar(veiculo);
        }
    }
}