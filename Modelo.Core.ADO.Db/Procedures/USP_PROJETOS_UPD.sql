CREATE PROCEDURE [dbo].[USP_PROJETOS_UPD]
    @cd_projeto bigint,
	@nm_projeto nvarchar(50),
	@ds_projeto nvarchar(max)
AS
	UPDATE [dbo].[PROJETOS]
	SET    [nm_projeto] = @nm_projeto,
	       [ds_projeto] = @ds_projeto
	WHERE  cd_projeto = @cd_projeto
GO
