CREATE OR ALTER PROCEDURE usp_PopulateStatusTable AS 
BEGIN
    INSERT INTO dbo.[Status] (ID,[Description])
    VALUES (0,'Submitted'),
           (1,'WaitingForOffers'),
           (2,'OfferReceived')
    
END