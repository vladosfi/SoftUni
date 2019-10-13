--Problem 1.	Number of Users for Email Provider
--Find number of users for email provider from the largest to smallest, then by Email Provider in ascending order. 
SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
	,COUNT(SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))) AS [Number Of Users]
	FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER BY [Number Of Users] DESC, [Email Provider] 

--Problem 2.	All User in Games
--Find all user in games with information about them. Display the game name, game type, username, level, cash and character name. Sort the result by level in descending order, then by username and game in alphabetical order. Submit your query statement as Prepare DB & run queries in Judge.
SELECT g.Name,gt.Name ,Username , Level, ug.Cash, c.Name
	FROM Users AS u
	JOIN UsersGames AS ug
	ON ug.UserId = u.Id
	JOIN Characters AS c
	ON c.Id = ug.CharacterId
	JOIN Games AS g
	ON g.Id = ug.GameId
	JOIN GameTypes AS gt
	ON gt.Id = g.GameTypeId
ORDER BY Level DESC,Username, g.Name


--Problem 3.	Users in Games with Their Items
--Find all users in games with their items count and items price. Display the username, game name, items count and items price. Display only user in games with items count more or equal to 10. Sort the results by items count in descending order then by price in descending order and by username in ascending order. Submit your query statement as Prepare DB & run queries in Judge.
SELECT Username, g.Name, COUNT(i.Name) AS [Items Count], SUM(i.Price) AS [Items Price]
	FROM Users AS u
	JOIN UsersGames AS ug
	ON ug.UserId = u.Id
	JOIN Games AS g
	ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
	JOIN Items AS i
	ON i.Id = ugi.ItemId
GROUP BY Username, g.Name
HAVING COUNT(i.Name) >= 10
ORDER BY COUNT(i.Name) DESC, SUM(i.Price) DESC, Username


--Problem 5.	All Items with Greater than Average Statistics
--Find all items with statistics larger than average. Display only items that have Mind, Luck and Speed greater than average Items mind, luck and speed. Sort the results by item names in alphabetical order. Submit your query statement as Prepare DB & run queries in Judge.
SELECT i.Name,i.Price, i.MinLevel, s.Strength,s.Defence,s.Speed,s.Luck,s.Mind 
	FROM Items AS i
	JOIN [Statistics] AS s
	ON s.Id = i.StatisticId
	WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics])
		AND s.Luck > (SELECT AVG(Luck) FROM [Statistics])
		AND s.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY i.Name


--Problem 6.	Display All Items with Information about Forbidden Game Type
--Find all items and information whether and what forbidden game types they have. Display item name, price, min level and forbidden game type. Display all items. Sort the results by game type in descending order, then by item name in ascending order. Submit your query statement as Prepare DB & run queries in Judge.
SELECT i.Name, i.Price, i.MinLevel, gt.Name AS [Forbidden Game Type]
	FROM Items AS i 
	LEFT JOIN GameTypeForbiddenItems AS gtfi
	ON gtfi.ItemId = i.Id
	LEFT JOIN GameTypes AS gt
	ON gt.Id = gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC, i.Name


--Problem 8.	Peaks and Mountains
--Find all peaks along with their mountain sorted by elevation (from the highest to the lowest), then by peak name alphabetically. Display the peak name, mountain range name and elevation. Submit your query statement as Prepare DB & run queries in Judge.
SELECT PeakName,MountainRange AS Mountain, p.Elevation 
	FROM Mountains AS m
	JOIN Peaks AS p
	ON p.MountainId = m.Id
ORDER BY p.Elevation DESC,p.PeakName


--Problem 9.	Peaks with Their Mountain, Country and Continent
--Find all peaks along with their mountain, country and continent. When a mountain belongs to multiple countries, display them all. Sort the results by peak name alphabetically, then by country name alphabetically. Submit your query statement as Prepare DB & run queries in Judge.
SELECT PeakName,MountainRange AS Mountain, CountryName, ContinentName
	FROM Countries AS c
	JOIN Continents AS con
	ON con.ContinentCode = c.ContinentCode
	JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	JOIN Mountains AS m
	ON m.Id = mc.MountainId
	JOIN Peaks AS p
	ON p.MountainId = m.Id
ORDER BY PeakName, CountryName