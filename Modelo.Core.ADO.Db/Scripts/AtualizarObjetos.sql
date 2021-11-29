USE APLICACAO_MODELO
GO

IF (NOT EXISTS (SELECT * 
                FROM dbo.VERSAO
                WHERE cd_versao = 1))
BEGIN
	:r .\Versao_1.sql
END
GO
