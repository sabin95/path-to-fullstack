CREATE OR ALTER PROCEDURE usp_InsertCar 
    @ClientId BIGINT, 
    @BrandName VARCHAR(255), 
    @ModelName VARCHAR(255) , 
    @PlateNumber VARCHAR(255), 
    @RegistrationId VARCHAR(255) 
AS 
BEGIN
    INSERT INTO [dbo].[Cars]
    ( 
     [Id], [ClientId],[BrandName],[ModelName],[PlateNumber],[RegistrationId]
    )
    VALUES
    ( 
     (Select ISNULL(MAX(Id),0)
     From [dbo].[Cars]) + 1, @ClientId,@BrandName,@ModelName,@PlateNumber,@RegistrationId
    )
END