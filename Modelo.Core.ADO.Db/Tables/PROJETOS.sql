CREATE TABLE [dbo].[PROJETOS]
(
	[cd_projeto] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [nm_projeto] NVARCHAR(50) NOT NULL, 
    [ds_projeto] NVARCHAR(MAX) NULL
)
