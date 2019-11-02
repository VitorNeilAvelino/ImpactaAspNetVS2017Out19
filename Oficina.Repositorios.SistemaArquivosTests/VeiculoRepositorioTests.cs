using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var veiculo = new Veiculo();
            veiculo.Ano = 2014;
            veiculo.Cambio = Cambio.Manual;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Observacao = "Observação";
            veiculo.Placa = "ABC1234";

            veiculo.Cor = new CorRepositorio().Obter(1);
            veiculo.Modelo = new ModeloRepositorio().Obter(1);

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}