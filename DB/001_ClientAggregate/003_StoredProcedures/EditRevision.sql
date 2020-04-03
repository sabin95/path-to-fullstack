CREATE OR ALTER PROCEDURE usp_EditRevision 
   (@EditRevision [UT_EditRevision] READONLY)
AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [Title] = e.Title,
    [ProblemDetails] = e.ProblemDetails    
    From [dbo].[Revisions] r
    JOIN @EditRevision e
    ON r.Id=e.Id
    WHERE IsDeleted=0
END