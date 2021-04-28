CREATE TABLE [dbo].[Theatres] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX)  NOT NULL,
    [NoOfHalls]     INT             NOT NULL,
    [TicketPrice]   DECIMAL (16, 2) NULL,
    [CityId]        INT             NOT NULL,
    [IsDeleted]     BIT             NOT NULL DEFAULT 0, 
    [DateDeleted]   DATETIME        NULL,
    CONSTRAINT [PK_Theatres] PRIMARY KEY CLUSTERED ([Id] ASC)
);

