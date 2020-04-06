CREATE TYPE UT_CreateRevision
AS TABLE
(
ClientId BIGINT,
CarId BIGINT, 
Title VARCHAR(255), 
ProblemDetails VARCHAR(255)
)