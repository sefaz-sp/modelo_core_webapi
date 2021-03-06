CREATE PROCEDURE [dbo].[USP_PROJETOS_UPD]
    @cd_projeto bigint,
	@nm_projeto nvarchar(50),
	@ds_projeto nvarchar(4000)
AS
	UPDATE [dbo].[PROJETOS]
	SET    [nm_projeto] = @nm_projeto,
	       [ds_projeto] = @ds_projeto
	WHERE  cd_projeto = @cd_projeto
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[USP_PROJETOS_UPD] TO [db_usuario]
    AS [dbo];

