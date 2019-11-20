using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio.Entidades;

namespace Pessoal.Repositorios.SqlServer.Testes
{
    [TestClass]
    public class TarefaRepositorioTeste
    {
        private TarefaRepositorio repositorio;

        public TarefaRepositorioTeste()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
                

            repositorio = new TarefaRepositorio(
                config.GetConnectionString("pessoalSqlServer"));
        }

        [TestMethod]
        public void InserirTeste()
        {
            var tarefa = new Tarefa();
            tarefa.Nome = "Limpar a casa";
            tarefa.Observacao = "Passar pano na casa toda";
            tarefa.Prioridade = Prioridade.Alta;
            tarefa.Concluida = true;

            tarefa.Id = repositorio.Inserir(tarefa);

            Assert.IsTrue(tarefa.Id > 0);
        }

        [TestMethod]
        public void SelecionarTodosTeste()
        {
            Assert.IsTrue(repositorio.Selecionar().Count > 0);
        }

        [TestMethod]
        public void SelecionarPorIdTeste()
        {
            //var tarefa = repositorio.Selecionar(1);

            Assert.IsNotNull(repositorio.Selecionar(1));
            Assert.IsNull(repositorio.Selecionar(0));
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var tarefa = new Tarefa();
            tarefa.Id = 1;
            tarefa.Nome = "Limpar a casaaaaaa";
            tarefa.Observacao = "Passar pano na casa todaaaaa";
            tarefa.Prioridade = Prioridade.Baixa;
            tarefa.Concluida = false;
            repositorio.Atualizar(tarefa);

            tarefa = repositorio.Selecionar(1);

            Assert.IsTrue(tarefa.Id == 1);
            Assert.AreEqual(tarefa.Prioridade, Prioridade.Baixa);
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            repositorio.Excluir(1);

            Assert.IsNull(repositorio.Selecionar(1));
        }
    }
}
