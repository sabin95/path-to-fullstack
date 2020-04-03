CREATE  TABLE dbo.Cars
(
    Id                  BIGINT PRIMARY KEY,
    ClientId              BIGINT FOREIGN KEY REFERENCES [dbo].Clients(Id),
    BrandName           VARCHAR(255),
    ModelName           VARCHAR(255),
    PlateNumber           VARCHAR(255),
    RegistrationId           VARCHAR(255),
    IsDeleted               BIT NOT NULL DEFAULT (0)
)