CREATE TABLE dbo.Clients
(
    Id                  BIGINT PRIMARY KEY,
    FirstName           VARCHAR(255),
    LastName            VARCHAR(255),
    PhoneNumber         VARCHAR(255),
    Email                VARCHAR(255) NOT NULL UNIQUE,
    Password            VARCHAR(255),
    IsDeleted           BIT NOT NULL DEFAULT (0)
)
