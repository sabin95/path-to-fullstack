CREATE OR ALTER PROCEDURE usp_GetAllCarsByClientId @ClientId BIGINT AS 
BEGIN
    SELECT Id,ClientId,BrandName,ModelName,PlateNumber,RegistrationId
    FROM dbo.Car
    Where ClientId=@ClientId
END