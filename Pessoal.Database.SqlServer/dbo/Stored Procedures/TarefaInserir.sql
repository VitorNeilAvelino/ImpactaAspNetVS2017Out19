

CREATE PROCEDURE [dbo].[TarefaInserir] 
	@Nome nvarchar(200)
    ,@Prioridade int
    ,@Concluida bit
    ,@Observacao nvarchar(1000)
AS
BEGIN
INSERT INTO [dbo].[Tarefa]
           ([Nome]
           ,[Prioridade]
           ,[Concluida]
           ,[Observacao])
		output inserted.Id
     VALUES
           (@Nome
           ,@Prioridade
           ,@Concluida
           ,@Observacao)
END

