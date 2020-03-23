CREATE TABLE dbo.Revisions
(
    Id                  BIGINT PRIMARY KEY,
    ClientId            BIGINT FOREIGN KEY REFERENCES [dbo].Clients(Id),
    CarId               BIGINT FOREIGN KEY REFERENCES [dbo].Cars(Id),
    Title               VARCHAR(255),
    ProblemDetails      VARCHAR(255),
    IsDeleted           BIT NOT NULL DEFAULT (0)
)
