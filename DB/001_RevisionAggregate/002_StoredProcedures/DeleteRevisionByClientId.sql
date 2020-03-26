CREATE OR ALTER PROCEDURE usp_DeleteRevisionsByClientId 
    @ClientId BIGINT 
AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [IsDeleted] = 1 
    Where ClientId=@ClientId
END