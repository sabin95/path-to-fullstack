CREATE OR ALTER PROCEDURE usp_InsertRevision @ProblemDetails VARCHAR(255) AS 
BEGIN
    INSERT INTO [dbo].[Revisions]
    ( 
     [Id], [ProblemDetails]
    )
    VALUES
    ( 
     (Select MAX(Id)
     From [dbo].[Revisions]) + 1, @ProblemDetails
    )
END