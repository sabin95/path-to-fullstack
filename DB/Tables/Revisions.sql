CREATE TABLE dbo.Revisions
(
    Id                  UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
    ProblemDetails      VARCHAR(255)
)
