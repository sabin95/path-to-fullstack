CREATE OR ALTER PROCEDURE usp_EditRevisionById @Id BIGINT,@ClientId BIGINT, @Title VARCHAR(255), @ProblemDetails VARCHAR(255)  AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [Title] = @Title,
    [ProblemDetails] = @ProblemDetails    
    WHERE Id=@Id and ClientId=@ClientId
END