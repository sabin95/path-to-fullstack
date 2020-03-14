CREATE OR ALTER PROCEDURE usp_GetAllRevisionsByClientId @ClientId BIGINT AS 
BEGIN
    SELECT Id,ClientId,ProblemDetails,CarId
    FROM dbo.Revisions
    Where ClientId=@ClientId
END