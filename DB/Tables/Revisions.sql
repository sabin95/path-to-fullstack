CREATE TABLE dbo.Revisions
(
    Id                  BIGINT PRIMARY KEY,
    ClientId            BIGINT FOREIGN KEY REFERENCES [dbo].Clients(Id),
    CarId               BIGINT FOREIGN KEY REFERENCES [dbo].Cars(Id),
    ProblemDetails      VARCHAR(255)
)
