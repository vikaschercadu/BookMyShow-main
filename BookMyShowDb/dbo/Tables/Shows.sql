CREATE TABLE [dbo].[Shows] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Date]          DATETIME      NOT NULL,
    [StartTime]     NVARCHAR (50) NOT NULL,
    [EndTime]       NVARCHAR (50) NOT NULL,
    [HallId]        INT           NOT NULL,
    [MovieId]       INT           NOT NULL,
    [IsDeleted]     BIT           NOT NULL DEFAULT 0, 
    [DateDeleted]   DATETIME      NULL,
    CONSTRAINT [PK_Shows] PRIMARY KEY CLUSTERED ([Id] ASC)
);

