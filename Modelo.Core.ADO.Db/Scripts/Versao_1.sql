IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'PROJETOS'))
BEGIN
    CREATE TABLE [dbo].[PROJETOS]
    (
		[cd_projeto] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
		[nm_projeto] NVARCHAR(50) NOT NULL, 
		[ds_projeto] NVARCHAR(MAX) NULL
    )

END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.USP_PROJETOS_SEL'))
BEGIN
   drop procedure dbo.USP_PROJETOS_SEL   
END
GO

CREATE PROCEDURE [dbo].[USP_PROJETOS_SEL]
    @cd_projeto bigint = null
AS
BEGIN
	SELECT cd_projeto, nm_projeto, ds_projeto
	FROM   [dbo].[PROJETOS]
	WHERE  cd_projeto = ISNULL(@cd_projeto, cd_projeto)
END
GO

GRANT execute on [dbo].[USP_PROJETOS_SEL] to modelo_user
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.USP_PROJETOS_UPD'))
BEGIN
   drop procedure dbo.USP_PROJETOS_UPD
END
GO

CREATE PROCEDURE [dbo].[USP_PROJETOS_UPD]
    @cd_projeto bigint,
	@nm_projeto nvarchar(50),
	@ds_projeto nvarchar(max)
AS
BEGIN
	UPDATE [dbo].[PROJETOS]
	SET    [nm_projeto] = @nm_projeto,
	       [ds_projeto] = @ds_projeto
	WHERE  cd_projeto = @cd_projeto
END
GO

GRANT execute on [dbo].[USP_PROJETOS_UPD] to modelo_user
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.USP_PROJETOS_INS'))
BEGIN
   drop procedure dbo.USP_PROJETOS_INS
END
GO

CREATE PROCEDURE [dbo].[USP_PROJETOS_INS]
	@nm_projeto nvarchar(50),
	@ds_projeto nvarchar(max)
AS
BEGIN
	declare @id bigint

	INSERT INTO [dbo].[PROJETOS]([nm_projeto],[ds_projeto])
	OUTPUT INSERTED.cd_projeto
    VALUES (@nm_projeto, @ds_projeto)

	select @id
END
GO

GRANT execute on [dbo].[USP_PROJETOS_INS] to modelo_user
GO

IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'VERSAO'))
BEGIN
	CREATE TABLE [dbo].[VERSAO]
	(
		[cd_versao] BIGINT NOT NULL PRIMARY KEY, 
		[ds_versao] NVARCHAR(MAX) NOT NULL
	)


	INSERT INTO dbo.VERSAO(cd_versao,ds_versao)
	VALUES (1, N'CRIACAO DA ENTIDADE PROJETOS')
END
GO
