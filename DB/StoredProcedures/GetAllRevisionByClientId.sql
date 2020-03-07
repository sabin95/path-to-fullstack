CREATE OR ALTER PROCEDURE usp_GetAllRevisionsByClientId @ClientId BIGINT AS 
BEGIN
    SELECT Id,ProblemDetails,ClientId
    FROM dbo.Revisions
    Where ClientId=@ClientId
END