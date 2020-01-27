CREATE TABLE dbo.Revisions
(
    Id                  UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid(),
    ProblemDetails      VARCHAR(255),
    Status              TINYINT DEFAULT 0
)
