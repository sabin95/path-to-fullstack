CREATE OR ALTER PROCEDURE usp_CreateClient
    (@CreateClient [UT_CreateClient] READONLY)
AS 
BEGIN
    DECLARE @Id BIGINT
    SET @Id = (Select ISNULL(MAX(Id),0)
               From [dbo].[Clients]) + 1
    INSERT INTO [dbo].[Clients]
    ( 
     [Id], [FirstName],[LastName],[PhoneNumber],[Email],[Password]
    )
    SELECT @Id, [FirstName],[LastName],[PhoneNumber],[Email],[Password]
    From @CreateClient    
END