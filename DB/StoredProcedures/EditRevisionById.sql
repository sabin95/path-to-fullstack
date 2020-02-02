CREATE OR ALTER PROCEDURE usp_EditRevisionById @Id BIGINT, @ProblemDetails VARCHAR(255) AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [ProblemDetails] = @ProblemDetails    
    WHERE Id=@Id
END