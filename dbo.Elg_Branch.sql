CREATE TABLE [dbo].[Elg_Branch] (
    [OfferID] NUMERIC (18) NOT NULL,
    [Branch]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Branch],[OfferID])
);

