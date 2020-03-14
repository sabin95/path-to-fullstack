CREATE TABLE dbo.Revisions
(
    Id                  BIGINT PRIMARY KEY,
    ClientId            BIGINT FOREIGN KEY REFERENCES [dbo].Clients(Id),
    ProblemDetails      VARCHAR(255)
)
