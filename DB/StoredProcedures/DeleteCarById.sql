CREATE OR ALTER PROCEDURE usp_DeleteCarById @Id BIGINT, @ClientId BIGINT AS
BEGIN
    DELETE
    FROM dbo.Car
    WHERE Id=@Id and ClientId=@ClientId
END