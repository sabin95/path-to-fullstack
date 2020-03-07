CREATE OR ALTER PROCEDURE usp_EditCarById @Id BIGINT, @ClientId BIGINT,@ModelName VARCHAR(255), @BrandName VARCHAR(255),
                                                        @PlateNumber VARCHAR(255), @RegistrationId VARCHAR(255) AS 
BEGIN
    UPDATE [dbo].[car]     
    SET [ClientId] = @ClientId,
    [BrandName] = @BrandName,
    [ModelName] = @ModelName,
    [PlateNumber] = @PlateNumber,
    [RegistrationId] = @RegistrationId
    where Id=@Id
END