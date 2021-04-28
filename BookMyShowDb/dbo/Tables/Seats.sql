CREATE TABLE [dbo].[Seats] (
    [Id]             INT        IDENTITY (1, 1) NOT NULL,
    [Status]         SMALLINT   NOT NULL,
    [HallId]         INT        NOT NULL,
    [IsDeleted]      BIT        NOT NULL DEFAULT 0, 
    [DateDeleted]    DATETIME   NULL,
    CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED ([Id] ASC)
);

