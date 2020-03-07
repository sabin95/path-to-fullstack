CREATE OR ALTER PROCEDURE usp_EditRevisionById @Id BIGINT, @ProblemDetails VARCHAR(255), @ClientId BIGINT AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [ProblemDetails] = @ProblemDetails,
    [ClientId] = @ClientId
    WHERE Id=@Id
END