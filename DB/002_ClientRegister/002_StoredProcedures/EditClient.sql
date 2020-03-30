CREATE OR ALTER PROCEDURE usp_EditClient
    @Id BIGINT,
    @FirstName VARCHAR(255), 
    @LastName VARCHAR(255), 
    @PhoneNumber VARCHAR(255),
    @Email VARCHAR(255),
    @Password VARCHAR(255)
AS
BEGIN
    UPDATE [dbo].[Clients]     
    SET [FirstName] = @FirstName,
    [LastName] = @LastName,
    [PhoneNumber] = @PhoneNumber,
    [Email] = @Email,
    [Password] = @Password
    where Id=@Id
END