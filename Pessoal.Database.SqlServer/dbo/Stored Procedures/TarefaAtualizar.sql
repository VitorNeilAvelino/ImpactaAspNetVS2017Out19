Create procedure TarefaAtualizar
	@id int,
	@nome			nvarchar(200),
	@prioridade		tinyint,
	@concluida		bit,
	@observacoes	nvarchar(1000)
as
Update [dbo].[Tarefa]
Set			[Nome] = @nome
           ,[Prioridade] = @prioridade
           ,[Concluida] = @concluida
           ,[Observacoes] = @observacoes
where Id = @id