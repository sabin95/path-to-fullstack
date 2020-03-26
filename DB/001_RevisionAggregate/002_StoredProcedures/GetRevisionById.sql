CREATE OR ALTER PROCEDURE usp_GetRevisionById 
    @Id BIGINT,
    @ClientId BIGINT,
    @CarId BIGINT 
AS 
BEGIN
    SELECT 
        r.Id,
        r.ClientId,
        r.Title,
        r.ProblemDetails,
        c.BrandName,
        c.ModelName,
        c.PlateNumber,
        c.RegistrationId
    FROM dbo.Revisions r
    JOIN dbo.Cars  c
    ON c.Id = r.CarId
    Where r.Id=@Id
    and r.ClientId = @ClientId
    and r.CarId = @CarId
    and IsDeleted=0
END