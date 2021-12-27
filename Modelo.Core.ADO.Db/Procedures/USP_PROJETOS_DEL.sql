CREATE PROCEDURE [dbo].[USP_PROJETOS_DEL]
	@cd_projeto bigint
AS
	delete [dbo].[PROJETOS]
	WHERE  cd_projeto = @cd_projeto
GO
