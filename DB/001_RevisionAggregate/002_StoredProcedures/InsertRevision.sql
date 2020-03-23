CREATE OR ALTER PROCEDURE usp_InsertRevision 
    @Title VARCHAR(255), 
    @ProblemDetails VARCHAR(255), 
    @CarId BIGINT, 
    @ClientId BIGINT 
AS 
BEGIN
    INSERT INTO [dbo].[Revisions]
    ( 
     [Id], [ClientId],[Title],[ProblemDetails], [CarId]
    )
    VALUES
    ( 
     (Select ISNULL(MAX(Id),0)
     From [dbo].[Revisions]) + 1, @ClientId,@Title, @ProblemDetails, @CarId
    )
END