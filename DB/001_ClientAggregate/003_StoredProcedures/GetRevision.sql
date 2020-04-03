CREATE OR ALTER PROCEDURE usp_GetRevision
    @Id BIGINT,
    @ClientId BIGINT
AS 
BEGIN
    SELECT 
        r.Id,
        r.ClientId,
        r.CarId,
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
    and r.IsDeleted=0
END