CREATE TYPE UT_EditCar
AS TABLE
(
Id                  BIGINT,
ClientId            BIGINT,
BrandName           VARCHAR(255),
ModelName           VARCHAR(255),
PlateNumber           VARCHAR(255),
RegistrationId           VARCHAR(255)
)