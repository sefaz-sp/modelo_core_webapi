CREATE PROCEDURE [dbo].[USP_PROJETOS_INS]
	@nm_projeto nvarchar(50),
	@ds_projeto nvarchar(max)
AS
	declare @id bigint

	INSERT INTO [dbo].[PROJETOS]([nm_projeto],[ds_projeto])
	OUTPUT INSERTED.cd_projeto
    VALUES (@nm_projeto, @ds_projeto)

	select @id
GO
