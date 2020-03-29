CREATE OR ALTER PROCEDURE usp_DeleteClient
    @Id BIGINT
AS
BEGIN
    DELETE
    FROM [dbo].Clients
    WHERE Id=@Id
END