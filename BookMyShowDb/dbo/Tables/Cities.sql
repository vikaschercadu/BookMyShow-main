CREATE TABLE [dbo].[Cities] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NOT NULL,
    [Pincode]     NVARCHAR (50) NOT NULL,
    [IsDeleted]   BIT           NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME      NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

