CREATE OR ALTER PROCEDURE usp_DeleteCarById 
    @Id BIGINT, 
    @ClientId BIGINT
AS
BEGIN
    UPDATE [dbo].[Cars]     
    SET [IsDeleted] = 1 
    WHERE Id=@Id 
    and ClientId=@ClientId
END