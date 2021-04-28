CREATE TABLE [dbo].[TheatreHalls] (
    [Id]            INT         IDENTITY (1, 1) NOT NULL,
    [TotalSeats]    INT         NOT NULL,
    [TheatreId]     INT         NOT NULL,
    [IsDeleted]     BIT         NOT NULL DEFAULT 0, 
    [DateDeleted]   DATETIME    NULL,
    CONSTRAINT [PK_TheatreHalls] PRIMARY KEY CLUSTERED ([Id] ASC)
);

