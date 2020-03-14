CREATE OR ALTER PROCEDURE usp_DeleteCarsByClientId @ClientId BIGINT AS
BEGIN
    DELETE
    FROM dbo.Cars
    WHERE ClientId=@ClientId
END