CREATE OR ALTER PROCEDURE usp_GetAllCarsByClientId 
    @ClientId BIGINT 
AS 
BEGIN
    SELECT 
        Id,
        ClientId,
        BrandName,
        ModelName,
        PlateNumber,
        RegistrationId
    FROM dbo.Cars
    Where ClientId=@ClientId
    and IsDeleted=0
END