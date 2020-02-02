CREATE OR ALTER PROCEDURE usp_DeleteRevisionById @Id BIGINT AS 
BEGIN
    Delete
    FROM dbo.Revisions
    Where Id=@Id
END