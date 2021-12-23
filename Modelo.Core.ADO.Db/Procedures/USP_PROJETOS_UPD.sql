CREATE PROCEDURE [dbo].[USP_PROJETOS_UPD]
    @Id bigint,
	@Nome nvarchar(50),
	@Descricao nvarchar(max)
AS
	UPDATE [dbo].[PROJETOS]
	SET    [Nome] = @Nome,
	       [Descricao] = @Descricao
	WHERE  Id = @Id
GO
