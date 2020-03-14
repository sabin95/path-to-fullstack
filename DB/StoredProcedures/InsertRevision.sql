CREATE OR ALTER PROCEDURE usp_InsertRevision @ProblemDetails VARCHAR(255), @CarId BIGINT, @ClientId BIGINT AS 
BEGIN
    INSERT INTO [dbo].[Revisions]
    ( 
     [Id], [ClientId],[ProblemDetails], [CarId]
    )
    VALUES
    ( 
     (Select MAX(Id)
     From [dbo].[Revisions]) + 1, @ClientId, @ProblemDetails, @CarId
    )
END