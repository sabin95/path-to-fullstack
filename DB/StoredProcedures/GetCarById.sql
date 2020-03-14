CREATE OR ALTER PROCEDURE usp_GetCarById @Id BIGINT, @ClientId BIGINT AS 
BEGIN
    SELECT Id,ClientId,BrandName,ModelName,PlateNumber,RegistrationId
    FROM dbo.Car
    Where Id=@Id and ClientId=@ClientId
END