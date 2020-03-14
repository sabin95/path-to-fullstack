CREATE OR ALTER PROCEDURE usp_GetRevisionById @Id BIGINT AS 
BEGIN
    SELECT Id,ClientId,ProblemDetails,CarId
    FROM dbo.Revisions
    Where Id=@Id
END