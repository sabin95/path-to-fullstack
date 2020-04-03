CREATE OR ALTER PROCEDURE usp_DeleteClient
(@DeleteClient [UT_BIGINT] READONLY)
AS
BEGIN
    UPDATE [dbo].[Clients]
    SET IsDeleted = 1
    FROM [dbo].[Clients] c
    JOIN @DeleteClient d
    ON c.Id=d.Id
END