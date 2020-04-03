CREATE TYPE UT_EditRevision
AS TABLE
(
Id      BIGINT,
ClientId BIGINT,
CarId BIGINT, 
Title VARCHAR(255), 
ProblemDetails VARCHAR(255)
)
