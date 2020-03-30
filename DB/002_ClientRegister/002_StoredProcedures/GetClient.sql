CREATE OR ALTER PROCEDURE usp_GetClient 
    @Id BIGINT
AS
BEGIN
    SELECT
    Id,
    FirstName,
    LastName,
    PhoneNumber,
    Email
    FROM [dbo].Clients
    WHERE Id=@Id
END