CREATE OR ALTER PROCEDURE usp_GetAllRevisions AS 
BEGIN
    SELECT r.Id,r.ClientId,r.Title,r.ProblemDetails,c.BrandName,c.ModelName,c.PlateNumber,c.RegistrationId
    FROM dbo.Revisions r
    JOIN dbo.Cars  c
    ON c.Id = r.CarId
END