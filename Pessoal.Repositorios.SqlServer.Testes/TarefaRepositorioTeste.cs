using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pessoal.Repositorios.SqlServer.Testes
{
    [TestClass]
    public class TarefaRepositorioTeste
    {
        private TarefaRepositorio repositorio;

        public TarefaRepositorioTeste()
        {
            var config = new ConfigurationBuilder()
                .Add()
                

            repositorio = new TarefaRepositorio();
        }

        [TestMethod]
        public void InserirTeste()
        {

        }
    }
}
