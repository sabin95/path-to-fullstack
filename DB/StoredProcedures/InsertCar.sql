CREATE OR ALTER PROCEDURE usp_InsertCar @ClientId BIGINT, @BrandName VARCHAR(255), 
                                            @ModelName VARCHAR(255) , @PlateNumber VARCHAR(255), @RegistrationId VARCHAR(255) AS 
BEGIN
    INSERT INTO [dbo].[Car]
    ( 
     [Id], [ClientId],[BrandName],[ModelName],[PlateNumber],[RegistrationId]
    )
    VALUES
    ( 
     (Select MAX(Id)
     From [dbo].[Revisions]) + 1, @ClientId,@BrandName,@ModelName,@PlateNumber,@RegistrationId
    )
END