CREATE PROCEDURE [dbo].[USP_PROJETOS_SEL]
    @Id bigint = null
AS
	SELECT Id, Nome, Descricao
	FROM   [dbo].[PROJETOS]
	WHERE  Id = ISNULL(@Id, Id)
GO
