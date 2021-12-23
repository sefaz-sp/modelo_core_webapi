CREATE PROCEDURE [dbo].[USP_PROJETOS_SEL]
    @cd_projeto bigint = null
AS
	SELECT cd_projeto, nm_projeto, ds_projeto
	FROM   [dbo].[PROJETOS]
	WHERE  cd_projeto = ISNULL(@cd_projeto, cd_projeto)
GO
