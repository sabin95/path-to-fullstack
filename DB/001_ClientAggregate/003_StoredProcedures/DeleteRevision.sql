CREATE OR ALTER PROCEDURE usp_DeleteRevision
(@DeleteRevision [UT_BIGINT] READONLY)
AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [IsDeleted] = 1 
    FROM [dbo].[Revisions] r
    JOIN @DeleteRevision d
    ON r.Id=d.Id
END