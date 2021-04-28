CREATE TABLE [dbo].[Movies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50)  NOT NULL,
    [Language]    NVARCHAR (50)  NOT NULL,
    [Genre]       NVARCHAR (50)  NOT NULL,
    [RunningTime] NVARCHAR (50)  NOT NULL,
    [ReleaseDate] DATETIME       NOT NULL,
    [ImageUrl]    NVARCHAR (MAX) NOT NULL,
    [IsDeleted]   BIT            NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME       NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

