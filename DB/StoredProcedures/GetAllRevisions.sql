CREATE OR ALTER PROCEDURE usp_GetAllRevisions AS 
BEGIN
    SELECT Id,ProblemDetails
    FROM dbo.Revisions
END