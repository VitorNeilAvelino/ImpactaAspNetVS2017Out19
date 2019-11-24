Create procedure TarefaSelecionar
	@id int = null
as

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacoes]
  FROM [dbo].[Tarefa]
Where Id = ISNULL(@id, Id)
Order by Concluida, Prioridade