CREATE OR ALTER PROCEDURE usp_DeleteCarByClientId @ClientId BIGINT AS
BEGIN
    DELETE
    FROM DBO.Car
    WHERE ClientId=@ClientId
END