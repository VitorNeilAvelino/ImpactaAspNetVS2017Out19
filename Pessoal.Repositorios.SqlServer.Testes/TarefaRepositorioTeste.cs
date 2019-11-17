using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio.Entidades;
using System;

namespace Pessoal.Repositorios.SqlServer.Testes
{
    [TestClass]
    public class TarefaRepositorioTeste
    {
        private readonly TarefaRepositorio repositorio;

        public TarefaRepositorioTeste()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            repositorio = new TarefaRepositorio(config.GetConnectionString("pessoalSqlServer"));
        }

        [TestMethod()]
        public void InserirTest()
        {
            var tarefa = new Tarefa();
            tarefa.Concluida = false;
            tarefa.Nome = "Passar roupa";
            tarefa.Observacoes = "Rápido";
            tarefa.Prioridade = Prioridade.Alta;

            tarefa.Id = repositorio.Inserir(tarefa);

            Assert.AreNotEqual(tarefa.Id, 0);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var tarefa = new Tarefa();
            tarefa.Id = 1;
            tarefa.Concluida = true;
            tarefa.Nome = "Passar roupa no sábado";
            tarefa.Observacoes = "Rápido editado";
            tarefa.Prioridade = Prioridade.Baixa;

            repositorio.Atualizar(tarefa);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            foreach (var tarefa in repositorio.Selecionar())
            {
                Console.WriteLine($"{tarefa.Id} - {tarefa.Nome} - {tarefa.Observacoes} - " +
                    $"{tarefa.Prioridade} - {tarefa.Concluida}");
            }
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            repositorio.Excluir(1);

            Assert.IsNull(repositorio.Selecionar(1));
        }
    }
}