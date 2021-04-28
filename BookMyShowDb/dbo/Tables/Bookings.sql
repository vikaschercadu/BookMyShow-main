CREATE TABLE [dbo].[Bookings] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [NoOfSeats]   INT            NOT NULL,
    [BookingDate] DATETIME       NOT NULL,
    [TimeSlot]    NVARCHAR (50)  NOT NULL,
    [ShowId]      INT            NOT NULL,
    [UserId]      NVARCHAR (450) NOT NULL,
    [IsDeleted]   BIT            NOT NULL DEFAULT 0, 
    [DateDeleted] DATETIME       NULL, 
    CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

