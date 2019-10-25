CREATE TABLE [dbo].[Applied] (
    [StudentID] NUMERIC (18) NOT NULL,
    [OfferID]   NUMERIC (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentID],[OfferID])
);

