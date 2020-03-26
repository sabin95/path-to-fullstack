CREATE OR ALTER PROCEDURE usp_DeleteCarsByClientId
    @ClientId BIGINT
AS
BEGIN
    UPDATE [dbo].[Cars]     
    SET [IsDeleted] = 1 
    WHERE ClientId=@ClientId
END