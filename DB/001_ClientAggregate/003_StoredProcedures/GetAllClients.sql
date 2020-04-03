CREATE OR ALTER PROCEDURE usp_GetAllClients AS 
BEGIN
    SELECT 
        Id,
        FirstName,
        LastName,
        PhoneNumber,
        Email
    FROM dbo.Clients
END