CREATE OR ALTER PROCEDURE usp_GetAllRevisions AS 
BEGIN
    SELECT Id,ProblemDetails,Status
    FROM dbo.Revisions
END