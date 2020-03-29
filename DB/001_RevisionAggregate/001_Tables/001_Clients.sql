CREATE TABLE dbo.Clients
(
    Id                  BIGINT PRIMARY KEY,
    FirstName           VARCHAR(255),
    LastName            VARCHAR(255),
    PhoneNumber         VARCHAR(255),
    Mail                VARCHAR(255) NOT NULL UNIQUE,
    Password            VARCHAR(255)
)
