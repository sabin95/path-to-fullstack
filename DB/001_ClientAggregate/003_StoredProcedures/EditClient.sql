CREATE OR ALTER PROCEDURE usp_EditClient
    (@EditClient [UT_EditClient] READONLY)
AS
BEGIN
    UPDATE [dbo].[Clients]     
    SET [FirstName] = e.FirstName,
    [LastName] = e.LastName,
    [PhoneNumber] = e.PhoneNumber,
    [Email] = e.Email,
    [Password] = e.[Password]
    from [dbo].[Clients] c 
    join @EditClient e
    on c.Id=e.Id
END