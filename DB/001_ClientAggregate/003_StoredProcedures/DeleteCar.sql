CREATE OR ALTER PROCEDURE usp_DeleteCar
(@DeleteClient [UT_BIGINT] READONLY)
AS
BEGIN
    UPDATE [dbo].[Cars]     
    SET [IsDeleted] = 1     
    FROM [dbo].[Cars] c
    JOIN @DeleteClient d
    ON c.Id=d.Id
END