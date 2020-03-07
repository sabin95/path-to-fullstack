CREATE OR ALTER PROCEDURE usp_GetRevisionById @Id BIGINT AS 
BEGIN
    SELECT Id,ProblemDetails,ClientId
    FROM dbo.Revisions
    Where Id=@Id
END