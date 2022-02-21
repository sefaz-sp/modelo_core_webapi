CREATE PROCEDURE [dbo].[USP_PROJETOS_DEL]
	@cd_projeto bigint
AS
	delete [dbo].[PROJETOS]
	WHERE  cd_projeto = @cd_projeto
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[USP_PROJETOS_DEL] TO [db_usuario]
    AS [dbo];

