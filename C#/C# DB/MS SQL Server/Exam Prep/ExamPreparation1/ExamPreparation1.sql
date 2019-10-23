--1
CREATE DATABASE Airport

--2.	Insert
--Insert some sample data into the database. Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.

INSERT INTO Planes (Name, Seats, Range) 
	VALUES('Airbus 336',112	,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)

INSERT INTO LuggageTypes (Type)
VALUES('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')


--3.	Update
--Make all flights to "Carlsbad" 13% more expensive.
UPDATE Tickets
	SET Price += Price * 0.13
	WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Carlsbad')



--4.	Delete
--Delete all flights to "Ayn Halagim".
DELETE 
	FROM Tickets 
	WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE 
	FROM Flights 
	WHERE Destination = 'Ayn Halagim'


--5.	The "Tr" Planes
--Select all of the planes, which name contains "tr". Order them by id (ascending), name (ascending), seats (ascending) and range (ascending).
SELECT * FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id, [Name], Seats, [Range]

--6.	Flight Profits
--Select the total profit for each flight from database. Order them by total price (descending), flight id (ascending).
SELECT p.FlightId, p.Price 
FROM
	(SELECT FlightId, SUM(Price) AS Price
	FROM Tickets
	GROUP BY FlightId) AS p
	ORDER BY p.Price DESC, p.FlightId


--7.	Passenger Trips
--Select the full name of the passengers with their trips (origin - destination). Order them by full name (ascending), origin (ascending) and destination (ascending).
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name]
	,f.Origin
	,f.Destination
FROM Passengers as p
	JOIN Tickets as t
	ON t.PassengerId = p.Id
	JOIN Flights AS f
	ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination


--8.	Non Adventures People
--Select all people who don't have tickets. Select their first name, last name and age .Order them by age (descending), first name (ascending) and last name (ascending).
SELECT FirstName, LastName, Age 
	FROM Passengers AS p
	LEFT JOIN Tickets AS t
	ON p.Id = t.PassengerId
	WHERE t.PassengerId IS NULL
	ORDER BY Age DESC, FirstName, LastName


--	9.	Full Info
--Select all passengers who have trips. Select their full name (first name – last name), plane name, trip (in format {origin} - {destination}) and luggage type. Order the results by full name (ascending), name (ascending), origin (ascending), destination (ascending) and luggage type (ascending).
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name]
	,pl.[Name] AS [Plane Name]
	,CONCAT(f.Origin, ' - ', f.Destination) AS Trip
	,lt.[Type] AS [Luggage Type]
	FROM Passengers AS p
	JOIN Tickets AS t
	ON t.PassengerId = p.Id
	JOIN Flights AS f
	ON f.Id = t.FlightId
	JOIN Planes AS pl
	ON pl.Id = f.PlaneId
	JOIN Luggages AS l
	ON l.Id = t.LuggageId
	JOIN LuggageTypes AS lt
	ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name],[Plane Name],f.Origin,f.Destination,[Luggage Type]


--10.	PSP
--Select all planes with their name, seats count and passengers count. Order the results by passengers count (descending), plane name (ascending) and seats (ascending) 
SELECT pl.Name
	, pl.Seats
	, COUNT(p.Id) AS [Passengers Count]
FROM Passengers AS p
RIGHT JOIN Tickets AS t
ON t.PassengerId = p.Id
RIGHT JOIN Flights AS f
ON f.Id = t.FlightId
RIGHT JOIN Planes AS pl
ON pl.Id = f.PlaneId
GROUP BY pl.Name, pl.Seats
ORDER BY COUNT(p.Id) DESC, pl.Name, pl.Seats


--11.	Vacation
--Create a user defined function, named udf_CalculateTickets(@origin, @destination, @peopleCount) that receives an origin (town name), destination (town name) and people count.
--The function must return the total price in format "Total price {price}"
--•	If people count is less or equal to zero return – "Invalid people count!"
--•	If flight is invalid return – "Invalid flight!"

CREATE OR ALTER FUNCTION udf_CalculateTickets (@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
	IF(@peopleCount <= 0)
	BEGIN
		RETURN 'Invalid people count!';
	END 

	DECLARE @flihtId INT = (SELECT TOP 1 Id FROM Flights 
		WHERE Origin = @origin AND Destination = @destination);

	IF(@flihtId IS NULL)
	BEGIN
		RETURN 'Invalid flight!';
	END

	DECLARE @ticketPrice decimal(18, 2) = (SELECT TOP 1 Price FROM Tickets 
											WHERE FlightId = @flihtId);
	DECLARE @totalPrice DECIMAL(24,2) = @ticketPrice * @peopleCount;

DECLARE @result VARCHAR(50);
SET @result = CONCAT('Total price ', @totalPrice);
RETURN @result;
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)


--12.	Wrong Data
--Create a user defined stored procedure, named usp_CancelFlights
--The procedure must cancel all flights on which the arrival time is before the departure time. Cancel means you need to leave the departure and arrival time empty.
CREATE OR ALTER PROC usp_CancelFlights 
AS
UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE DepartureTime < ArrivalTime


EXEC usp_CancelFlights