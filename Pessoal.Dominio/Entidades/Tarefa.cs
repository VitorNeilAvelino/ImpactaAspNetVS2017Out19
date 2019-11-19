using System;

namespace Pessoal.Dominio.Entidades
{
    public class Tarefa
    {
        //Página 61 (II)
        public int Id { get; set; }
        public string Nome { get; set; }
        public Prioridade Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Observacao { get; set; }
    }
}
