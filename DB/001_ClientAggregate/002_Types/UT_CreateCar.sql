CREATE TYPE UT_CreateCar  
AS TABLE
(
    ClientId            BIGINT,
    BrandName           VARCHAR(255),
    ModelName           VARCHAR(255),
    PlateNumber           VARCHAR(255),
    RegistrationId           VARCHAR(255)
)