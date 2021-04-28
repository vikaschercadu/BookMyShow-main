CREATE VIEW TheatreShowsDetailsView
AS
SELECT 
Theatres.Id AS TheatreId,
Theatres.Name AS TheatreName,
NoOfHalls,
TheatreHalls.Id AS HallId,
TotalSeats,Shows.Id AS ShowId,
Shows.Date AS ShowDate,
StartTime,
EndTime,
CityId,
MovieId
FROM Theatres
INNER JOIN TheatreHalls ON Theatres.Id = TheatreHalls.TheatreId AND TheatreHalls.IsDeleted=0
INNER JOIN Shows ON Shows.HallId = TheatreHalls.Id AND Shows.IsDeleted=0
WHERE Theatres.IsDeleted=0