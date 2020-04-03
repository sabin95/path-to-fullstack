CREATE OR ALTER PROCEDURE usp_EditCar
    (@EditCar [UT_EditCar] READONLY)
AS 
BEGIN
    UPDATE [dbo].[Cars]     
    SET [BrandName] = e.BrandName,
    [ModelName] = e.ModelName,
    [PlateNumber] = e.PlateNumber,
    [RegistrationId] = e.RegistrationId
    FROM [dbo].[Cars] c
    JOIN @EditCar e
    on c.Id=e.Id
    WHERE IsDeleted=0
END