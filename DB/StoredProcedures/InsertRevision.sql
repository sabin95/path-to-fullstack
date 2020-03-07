CREATE OR ALTER PROCEDURE usp_InsertRevision @ProblemDetails VARCHAR(255), @ClientId BIGINT AS 
BEGIN
    INSERT INTO [dbo].[Revisions]
    ( 
     [Id], [ClientId],[ProblemDetails]
    )
    VALUES
    ( 
     (Select MAX(Id)
     From [dbo].[Revisions]) + 1, @ClientId, @ProblemDetails
    )
END