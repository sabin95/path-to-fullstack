CREATE OR ALTER PROCEDURE usp_DeleteRevisionById 
    @Id BIGINT,
    @ClientId BIGINT,
    @CarId BIGINT
AS 
BEGIN
    UPDATE [dbo].[Revisions]     
    SET [IsDeleted] = 1 
    Where Id=@Id
    and ClientId=@ClientId
    and CarId=@CarId
END