CREATE OR ALTER PROCEDURE usp_PopulateStatusTable AS 
BEGIN
    INSERT INTO dbo.[Status]
    FROM dbo.Revisions
END