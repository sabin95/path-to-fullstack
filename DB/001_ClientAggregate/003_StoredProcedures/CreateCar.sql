CREATE OR ALTER PROCEDURE usp_CreateCar 
    (@CreateCar [UT_CreateCar] READONLY)
AS 
BEGIN
    DECLARE @Id BIGINT 
    SET @Id = (Select ISNULL(MAX(Id),0)
               From [dbo].[Cars]) + 1
    INSERT INTO [dbo].[Cars]
    ( 
     [Id], [ClientId],[BrandName],[ModelName],[PlateNumber],[RegistrationId]
    )
    SELECT @Id, [ClientId],[BrandName],[ModelName],[PlateNumber],[RegistrationId]
    FROM @CreateCar    
END