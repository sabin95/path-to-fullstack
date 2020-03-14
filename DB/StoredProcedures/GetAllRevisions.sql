CREATE OR ALTER PROCEDURE usp_GetAllRevisions AS 
BEGIN
    SELECT Id,ClientId,ProblemDetails,CarId
    FROM dbo.Revisions
END