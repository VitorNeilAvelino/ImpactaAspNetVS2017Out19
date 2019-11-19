using Microsoft.Data.SqlClient;
using Pessoal.Dominio.Entidades;
using Pessoal.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pessoal.Repositorios.SqlServer
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private string stringConexao;

        public TarefaRepositorio(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public void Atualizar(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaInserir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddRange(Mapear(tarefa).ToArray());

                    return (int)comando.ExecuteScalar();
                }
            }
        }

        private List<SqlParameter> Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Nome", tarefa.Nome));
            parametros.Add(new SqlParameter("@Prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@Concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@Observacao", tarefa.Observacao));

            return parametros;
        }

        public List<Tarefa> Selecionar()
        {
            throw new NotImplementedException();
        }

        public Tarefa Selecionar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
