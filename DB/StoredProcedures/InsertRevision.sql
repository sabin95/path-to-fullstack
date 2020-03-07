CREATE OR ALTER PROCEDURE usp_InsertRevision @ProblemDetails VARCHAR(255), @ClientId BIGINT AS 
BEGIN
    INSERT INTO [dbo].[Revisions]
    ( 
     [Id], [ProblemDetails],[ClientId]
    )
    VALUES
    ( 
     (Select MAX(Id)
     From [dbo].[Revisions]) + 1, @ProblemDetails , @ClientId
    )
END