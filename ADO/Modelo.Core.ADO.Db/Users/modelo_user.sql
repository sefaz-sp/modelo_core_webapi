CREATE LOGIN modelo_login   
    WITH PASSWORD = 'modelo_pwd';  
GO  

CREATE USER modelo_user FOR LOGIN modelo_login;  
GO  
