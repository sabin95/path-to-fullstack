CREATE OR ALTER PROCEDURE usp_DeleteCarById @Id BIGINT AS
BEGIN
    DELETE
    FROM DBO.Car
    WHERE Id=@Id
END