CREATE OR ALTER PROCEDURE usp_GetRevisionById @Id BIGINT AS 
BEGIN
    SELECT r.Id,r.ClientId,r.ProblemDetails,c.BrandName,c.ModelName,c.PlateNumber,c.RegistrationId
    FROM dbo.Revisions r
    JOIN dbo.Cars  c
    ON c.Id = r.CarId
    Where r.Id=@Id
END