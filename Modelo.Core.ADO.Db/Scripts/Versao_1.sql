IF (NOT EXISTS (SELECT * 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'PROJETOS'))
BEGIN
    CREATE TABLE [dbo].[PROJETOS]
    (
		[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
		[Nome] NVARCHAR(50) NOT NULL, 
		[Descricao] NVARCHAR(MAX) NULL
    )

END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.USP_PROJETOS_SEL'))
BEGIN
   drop procedure dbo.USP_PROJETOS_SEL   
END
GO

CREATE PROCEDURE [dbo].[USP_PROJETOS_SEL]
    @Id bigint = null
AS
BEGIN
	SELECT Id, Nome, Descricao
	FROM   [dbo].[PROJETOS]
	WHERE  Id = ISNULL(@Id, Id)
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
    @Id bigint,
	@Nome nvarchar(50),
	@Descricao nvarchar(max)
AS
BEGIN
	UPDATE [dbo].[PROJETOS]
	SET    [Nome] = @Nome,
	       [Descricao] = @Descricao
	WHERE  Id = @Id
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
	@Nome nvarchar(50),
	@Descricao nvarchar(max)
AS
BEGIN
	declare @id bigint

	INSERT INTO [dbo].[PROJETOS]([Nome],[Descricao])
	OUTPUT INSERTED.Id
    VALUES (@Nome, @Descricao)

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
