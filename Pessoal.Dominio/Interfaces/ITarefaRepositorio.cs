using Pessoal.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pessoal.Dominio.Interfaces
{
    public interface ITarefaRepositorio
    {
        int Inserir(Tarefa tarefa);
        Tarefa Selecionar(int id);
        List<Tarefa> Selecionar();
        void Atualizar(Tarefa tarefa);
        void Excluir(int id);
    }
}
