CREATE OR ALTER PROCEDURE usp_GetAllStatus AS 
BEGIN
    SELECT 
        Id,
        [Description]
    FROM dbo.[Status]
END