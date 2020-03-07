CREATE OR ALTER PROCEDURE usp_DeleteRevisionsByClientId @ClientId BIGINT AS 
BEGIN
    Delete
    FROM dbo.Revisions
    Where ClientId=@ClientId
END