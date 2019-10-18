CREATE DATABASE ColonialJourney

--Section 1. DDL (30 pts)
--You have been tasked to create the tables in the database by the following models:
CREATE TABLE Planets(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL)

CREATE TABLE Spaceports(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id))

CREATE TABLE Spaceships(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) NOT NULL UNIQUE,
BirthDate DATE NOT NULL)

CREATE TABLE Journeys(
Id INT PRIMARY KEY IDENTITY,
JourneyStart DateTime NOT NULL,
JourneyEnd DateTime NOT NULL,
Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards(
Id INT PRIMARY KEY IDENTITY,
CardNumber CHAR(10) NOT NULL UNIQUE,
JobDuringJourney VARCHAR(8) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)

--2.	Insert
--Insert sample data into the database. Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.
--Planets
INSERT INTO Planets(Name)
	VALUES('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO Spaceships(Name,	Manufacturer,	LightSpeedRate)
VALUES('Golf','VW',	3),
	('WakaWaka','Wakanda',	4),
	('Falcon9','SpaceX',	1),
	('Bed','Vidolov',	6)

--	3.	Update
--Update all spaceships light speed rate with 1 where the Id is between 8 and 12.
UPDATE Spaceships
	SET LightSpeedRate += 1
	WHERE Id BETWEEN 8 AND 12

--	4.	Delete
--Delete first three inserted Journeys (be careful with the relationships).
DELETE FROM TravelCards WHERE JourneyId IN (SELECT TOP 3 Id FROM Journeys ORDER BY Id)
DELETE FROM Journeys WHERE Id IN (SELECT TOP 3 Id FROM Journeys ORDER BY Id)

--5.	Select all travel cards
--Extract from the database, all travel cards. Sort the results by card number ascending.
--Required Columns
--•	CardNumber
--•	JobDuringJourney
SELECT CardNumber, JobDuringJourney
	FROM TravelCards
	ORDER BY CardNumber


--6.	Select all colonists
--Extract from the database, all colonists. Sort the results by first name, them by last name, and finally by id in ascending order.
--Required Columns
--•	Id
--•	FullName
--•	Ucn

SELECT Id, CONCAT(FirstName, ' ' , LastName) AS [Full Name], Ucn
	FROM Colonists
	ORDER BY FirstName, LastName, Id	


--7.	Select all military journeys
--Extract from the database, all Military journeys. Sort the results ascending by journey start.
--Required Columns
--•	Id
--•	JourneyStart
--•	JourneyEnd

SELECT Id,FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,FORMAT (JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys
	WHERE Purpose = 'Military'
	ORDER BY JourneyStart


--8.	Select all pilots
--Extract from the database all colonists, which have a pilot job. Sort the result by id, ascending.
--`Required Columns
--•	Id
--•	FullName
SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS [full_name]
	FROM Colonists AS c
	JOIN TravelCards AS t
	ON t.ColonistId = c.Id
	WHERE t.JobDuringJourney = 'pilot'
ORDER BY c.Id


--9.	Count colonists
--Count all colonists that are on technical journey. 
--Required Columns
--•	Count
SELECT COUNT(*) AS Count
	FROM Colonists AS c
	JOIN TravelCards AS tc
	ON tc.ColonistId = c.Id
	JOIN Journeys AS j
	ON j.Id = tc.JourneyId
	WHERE j.Purpose = 'technical'


--10.	Select the fastest spaceship
--Extract from the database the fastest spaceship and its destination spaceport name. In other words, the ship with the highest light speed rate.
--Required Columns
--•	SpaceshipName
--•	SpaceportName
SELECT TOP 1 s.Name AS [SpaceshipName], sp.Name AS SpaceportName 
	FROM Spaceships AS s
	JOIN Journeys AS j
	ON j.SpaceshipId = s.Id
	JOIN Spaceports AS sp
	ON sp.Id = j.DestinationSpaceportId
	ORDER BY s.LightSpeedRate DESC


--	11.	Select spaceships with pilots younger than 30 years
--Extract from the database those spaceships, which have pilots, younger than 30 years old. In other words, 30 years from 01/01/2019. Sort the results alphabetically by spaceship name.
--Required Columns
--•	Name
--•	Manufacturer
SELECT s.Name, s.Manufacturer  
	FROM Spaceships AS s
	JOIN Journeys AS j
	ON j.SpaceshipId = s.Id
	JOIN TravelCards AS tc
	ON tc.JourneyId = j.Id
	JOIN Colonists AS c
	ON c.Id = tc.ColonistId
	WHERE DATEDIFF(YEAR,c.BirthDate,'01/01/2019') < 30 AND tc.JobDuringJourney = 'pilot'
	GROUP BY s.Name, s.Manufacturer 
	ORDER BY s.Name


--12.	Select all educational mission planets and spaceports
--Extract from the database names of all planets and their spaceports, which have educational missions. Sort the results by spaceport name in descending order.
--Required Columns
--•	PlanetName
--•	SpaceportName
SELECT p.Name AS PlanetName, sp.Name AS SpaceportName
	FROM Planets AS p
	JOIN Spaceports AS sp
	ON sp.PlanetId = p.Id
	JOIN Journeys AS j
	ON j.DestinationSpaceportId = sp.Id
	WHERE j.Purpose = 'Educational'
	ORDER BY SpaceportName DESC


--13.	Select all planets and their journey count
--Extract from the database all planets’ names and their journeys count. Order the results by journeys count, descending and by planet name ascending.
--Required Columns
--•	PlanetName
--•	JourneysCount
SELECT p.Name AS PlanetName, COUNT(j.Id) AS JourneysCount
	FROM Planets AS p
	JOIN Spaceports AS sp
	ON sp.PlanetId = p.Id
	JOIN Journeys AS j
	ON j.DestinationSpaceportId = sp.Id
	GROUP BY p.Name
	ORDER BY JourneysCount DESC, p.Name


--14.	Select the shortest journey
--Extract from the database the shortest journey, its destination spaceport name, planet name and purpose.
--Required Columns
--•	Id
--•	PlanetName
--•	SpaceportName
--•	JourneyPurpose

SELECT TOP 1 j.Id, p.Name, sp.Name, j.Purpose
	FROM Journeys AS j
	JOIN Spaceports AS sp
	ON sp.Id = j.DestinationSpaceportId
	JOIN Planets AS p
	ON p.Id = sp.PlanetId
	ORDER BY DATEDIFF(SECOND,j.JourneyStart,j.JourneyEnd)

--	15.	Select the less popular job
--Extract from the database the less popular job in the longest journey. In other words, the job with less assign colonists.
--Required Columns
--•	JourneyId
--•	JobName

SELECT TOP 1 ss.Id AS JourneyId, ss.JobDuringJourney AS JobName FROM
	(SELECT j.Id, tc.JobDuringJourney, DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY tc.Id) AS Rank
	FROM Journeys AS j
	JOIN TravelCards AS tc
	ON tc.JourneyId = j.Id
	JOIN Colonists AS c
	ON c.Id = tc.ColonistId
	WHERE j.Id = (SELECT TOP 1 j.Id
		FROM Colonists AS c
		JOIN TravelCards AS tc
		ON tc.ColonistId = c.Id
		JOIN Journeys AS j
		ON j.Id = tc.JourneyId
		ORDER BY DATEDIFF(SECOND,j.JourneyStart,j.JourneyEnd) DESC))AS ss
GROUP BY ss.Id, ss.JobDuringJourney
ORDER BY COUNT(ss.Rank)


SELECT TOP 1 j.Id AS JourneyId, tc.JobDuringJourney AS JobName
	FROM Journeys AS j
	JOIN TravelCards AS tc
	ON tc.JourneyId = j.Id
	JOIN Colonists AS c
	ON c.Id = tc.ColonistId
	WHERE j.Id = (SELECT TOP 1 j.Id
		FROM Colonists AS c
		JOIN TravelCards AS tc
		ON tc.ColonistId = c.Id
		JOIN Journeys AS j
		ON j.Id = tc.JourneyId
		ORDER BY DATEDIFF(SECOND,j.JourneyStart,j.JourneyEnd) DESC)
GROUP BY j.Id, tc.JobDuringJourney
ORDER BY COUNT(tc.JobDuringJourney)

