CREATE PROCEDURE [dbo].[USP_PROJETOS_INS]
	@Nome nvarchar(50),
	@Descricao nvarchar(max)
AS
	declare @id bigint

	INSERT INTO [dbo].[PROJETOS]([Nome],[Descricao])
	OUTPUT INSERTED.Id
    VALUES (@Nome, @Descricao)

	select @id
GO
