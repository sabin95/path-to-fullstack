CREATE OR ALTER PROCEDURE usp_CreateRevision 
(@CreateRevision [UT_CreateRevision] READONLY)
AS 
BEGIN
    DECLARE @Id BIGINT
    Set @Id = (Select ISNULL(MAX(Id),0)
               From [dbo].[Revisions]) + 1
    INSERT INTO [dbo].[Revisions]
    ( 
     [Id], [ClientId],[Title],[ProblemDetails], [CarId]
    )
    SELECT 
    @Id, [ClientId],[Title],[ProblemDetails], [CarId]
    FROM @CreateRevision
END