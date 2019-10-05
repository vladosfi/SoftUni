--Problem 1.	Employee Address
--Write a query that selects:
--•	EmployeeId
--•	JobTitle
--•	AddressId
--•	AddressText
--Return the first 5 rows sorted by AddressId in ascending order.
SELECT TOP 5 EmployeeID, JobTitle,e.AddressID,AddressText 
FROM Employees AS e
JOIN  Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY AddressID


--Problem 2.	Addresses with Towns
--Write a query that selects:
--•	FirstName
--•	LastName
--•	Town
--•	AddressText
--Sorted by FirstName in ascending order then by LastName. Select first 50 employees.
SELECT TOP 50 FirstName, LastName, t.Name, a.AddressText
FROM Employees AS e
JOIN Addresses as a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Problem 3.	Sales Employee
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	LastName
--•	DepartmentName
--Sorted by EmployeeID in ascending order. Select only employees from “Sales” department.
SELECT EmployeeID, FirstName, LastName, d.Name
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID


--Problem 4.	Employee Departments
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	Salary
--•	DepartmentName
--Filter only employees with salary higher than 15000. Return the first 5 rows sorted by DepartmentID in ascending order.
SELECT TOP 5 EmployeeID, FirstName, Salary, d.Name
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000 
ORDER BY d.DepartmentID 


--Problem 5.	Employees Without Project
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--Filter only employees without a project. Return the first 3 rows sorted by EmployeeID in ascending order.

SELECT TOP 3 e.EmployeeID, FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
LEFT JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.Name IS NULL
ORDER BY e.EmployeeID


--Problem 6.	Employees Hired After
--Write a query that selects:
--•	FirstName
--•	LastName
--•	HireDate
--•	DeptName
--Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" departments, sorted by HireDate (ascending).
SELECT FirstName, LastName, HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate >= '1.1.1999' AND  d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate


--Problem 7.	Employees with Project
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	ProjectName
--Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). Return the first 5 rows sorted by EmployeeID in ascending order.
SELECT TOP 5 e.EmployeeID, FirstName, p.[Name]
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > CONVERT(smalldatetime, '13.08.2002', 103) AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem 8.	Employee 24
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	ProjectName
--Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.
SELECT e.EmployeeID, FirstName, 
     CASE 
     WHEN DATEPART(YEAR,p.StartDate) >= 2005 THEN NULL
     ELSE p.[Name]
     END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24


--Problem 9.	Employee Manager
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	ManagerID
--•	ManagerName
--Filter all employees with a manager who has ID equals to 3 or 7. Return all the rows, sorted by EmployeeID in ascending order.
SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName
FROM Employees AS e
JOIN Employees AS em
ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY EmployeeID


--Problem 10.	Employee Summary
--Write a query that selects:
--•	EmployeeID
--•	EmployeeName
--•	ManagerName
--•	DepartmentName
--Show first 50 employees with their managers and the departments they are in (show the departments of the employees). Order by EmployeeID.
SELECT TOP 50 
	e.EmployeeID, 
	CONCAT(e.FirstName,' ', e.LastName) AS EmployeeName, 
	CONCAT(em.FirstName,' ', em.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS em
ON e.ManagerID = em.EmployeeID
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID


--Problem 11.	Min Average Salary
--Write a query that returns the value of the lowest average salary of all departments.
SELECT MIN(e.AvgSalary) AS MinAverageSalary FROM 
(SELECT DepartmentID, AVG(Salary) AS AvgSalary
FROM Employees
GROUP BY DepartmentID
) AS e

--Problem 12.	Highest Peaks in Bulgaria
--Write a query that selects:
--•	CountryCode
--•	MountainRange
--•	PeakName
--•	Elevation
--Filter all peaks in Bulgaria with elevation over 2835. Return all the rows sorted by elevation in descending order
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON m.Id = mc.MountainId
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Problem 13.	Count Mountain Ranges
--Write a query that selects:
--•	CountryCode
--•	MountainRanges
--Filter the count of the mountain ranges in the United States, Russia and Bulgaria.
SELECT c.CountryCode, COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE c.CountryName IN ('United States', 'Russia','Bulgaria')
GROUP BY c.CountryCode


--Problem 14.	Countries with Rivers
--Write a query that selects:
--•	CountryName
--•	RiverName
--Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
SELECT TOP 5 c.CountryName, r.RiverName
FROM Countries AS c
JOIN Continents AS co
ON c.ContinentCode = co.ContinentCode 
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName


--Problem 15.	*Continents and Currencies
--Write a query that selects:
--•	ContinentCode
--•	CurrencyCode
--•	CurrencyUsage
--Find all continents and their most used currency. Filter any currency that is used in only one country. Sort your results by ContinentCode.

SELECT r.ContinentCode,r.CurrencyCode,r.CurrencyUsage FROM
(SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS CurrencyUsage
	,DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) >= 2) AS r
WHERE [Rank] = 1
ORDER BY r.ContinentCode


--Problem 16.	Countries without any Mountains
--Find all the count of all countries, which don’t have a mountain.
SELECT COUNT(*) AS [Count]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL


--Problem 17.	Highest Peak and Longest River by Country
--For each country, find the elevation of the highest peak and the length of the longest river, sorted by the highest peak elevation (from highest to lowest), then by the longest river length (from longest to smallest), then by country name (alphabetically). Display NULL when no data is available in some of the columns. Limit only the first 5 rows.
SELECT 
	TOP 5 
	c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.[Length]) AS LongestRiverLength
FROM Countries As c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p
ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

--Problem 18.	* Highest Peak Name and Elevation by Country
--For each country, find the name and elevation of the highest peak, along with its mountain. When no peaks are available in some country, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name. When multiple peaks in some country have the same elevation, display all of them. Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.
SELECT c.CountryName
	,CASE 
		 WHEN p.PeakName IS NULL THEN '(no highest peak)'
		 ELSE p.PeakName
		 END AS [Highest Peak Name]
	,CASE 
		 WHEN p.Elevation IS NULL THEN '0'
		 ELSE p.Elevation
		 END AS [Highest Peak Elevation]
	,CASE 
		 WHEN m.MountainRange IS NULL THEN '(no mountain)'
		 ELSE m.MountainRange
		 END AS [Mountain]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p	
ON m.Id = p.MountainId
ORDER BY c.CountryName, [Highest Peak Elevation]