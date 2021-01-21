CREATE TABLE [dbo].[Tours] (
    [TourId]      INT           IDENTITY (1, 1) NOT NULL,
    [ToursName]   VARCHAR (100) NOT NULL,
    [Country]     VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (250) NOT NULL,
    [DaysCost]    FLOAT (53)    NULL,
    CONSTRAINT [PK_Tours] PRIMARY KEY CLUSTERED ([TourId] ASC)
);

