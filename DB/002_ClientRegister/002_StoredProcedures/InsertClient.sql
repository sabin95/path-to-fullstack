CREATE OR ALTER PROCEDURE usp_InsertClient
    @FirstName VARCHAR(255), 
    @LastName VARCHAR(255), 
    @PhoneNumber VARCHAR(255),
    @Mail VARCHAR(255),
    @Password VARCHAR(255)
AS 
BEGIN
    INSERT INTO [dbo].[Clients]
    ( 
     [Id], [FirstName],[LastName],[PhoneNumber],[Mail],[Password]
    )
    VALUES
    ( 
     (Select ISNULL(MAX(Id),0)
     From [dbo].[Clients]) + 1, @FirstName,@LastName,@PhoneNumber,@Mail,@Password
    )
END