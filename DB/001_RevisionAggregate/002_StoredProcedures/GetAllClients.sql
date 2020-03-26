CREATE OR ALTER PROCEDURE usp_GetAllClients AS 
BEGIN
    SELECT 
        Id,
        FirstName,
        LastName,
        PhoneNumber
    FROM dbo.Clients
END