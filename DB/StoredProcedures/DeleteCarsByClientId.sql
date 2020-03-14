CREATE OR ALTER PROCEDURE usp_DeleteCarsByClientId @ClientId BIGINT AS
BEGIN
    DELETE
    FROM dbo.Car
    WHERE ClientId=@ClientId
END