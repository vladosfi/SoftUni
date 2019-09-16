-- Problem 1. Find Names of All Employees by First Name
-- Write a SQL query to find first and last names of all employees whose first name starts with “SA”.
SELECT FirstName, LastName 
	FROM Employees
WHERE FirstName LIKE 'sa%'

-- Problem 2. Find Names of All employees by Last Name
-- Write a SQL query to find first and last names of all employees whose last name contains “ei”.
SELECT	FirstName, LastName
	FROM Employees
WHERE LastName LIKE '%ei%'

-- Problem 3. Find First Names of All Employees
-- Write a SQL query to find the first names of all employees in the departments with ID 3 or 10 and whose hire year is
-- between 1995 and 2005 inclusive.
SELECT FirstName
	FROM Employees
	WHERE DepartmentId IN (3,10) AND DATEPART(YEAR, HireDate) BETWEEN 1975 AND 2005


-- Problem 4. Find All Employees Except Engineers
-- Write a SQL query to find the first and last names of all employees whose job titles does not contain “engineer”.
SELECT FirstName,LastName
	FROM Employees
WHERE JobTitle NOT LIKE('%engineer%')

-- Problem 5. Find Towns with Name Length
-- Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name.
SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) BETWEEN 5 AND 6
	ORDER BY [Name]

-- Problem 6. Find Towns Starting With
-- Write a SQL query to find all towns that start with letters M, K, B or E. Order them alphabetically by town name.
SELECT TownID, [Name]
	FROM Towns
	WHERE [Name] LIKE '[mkbe]%'
	ORDER BY [Name] ASC

-- Problem 7. Find Towns Not Starting With
-- Write a SQL query to find all towns that does not start with letters R, B or D. Order them alphabetically by name.
SELECT *
	FROM Towns
	WHERE [Name] LIKE '[^rbd]%'
	ORDER BY [Name]

-- Problem 8. Create View Employees Hired After 2000 Year
-- Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year.

CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE DATEPART(YEAR, HireDate) > 2000 

SELECT * FROM V_EmployeesHiredAfter2000

-- Problem 9. Length of Last Name
-- Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
SELECT FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5

-- Problem 10. Rank Employees by Salary
-- Write a query that ranks all employees using DENSE_RANK. In the DENSE_RANK function, employees need to be
-- partitioned by Salary and ordered by EmployeeID. You need to find only the employees whose Salary is between
-- 10000 and 50000 and order them by Salary in descending order.

SELECT 
	EmployeeID, FirstName,LastName, Salary, 
	 DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM
	Employees 
WHERE 
	Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC


-- Problem 11. Find All Employees with Rank 2 *
-- Use the query from the previous problem and upgrade it, so that it finds only the employees whose Rank is 2 and
-- again, order them by Salary (descending).
SELECT *
	FROM (
	SELECT EmployeeID, FirstName,LastName, Salary, 
		 DENSE_RANK() OVER   
		(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM
		Employees 
	WHERE 
		Salary BETWEEN 10000 AND 50000
	) AS SubTable
	WHERE SubTable.Rank = 2 
	ORDER BY Salary DESC

-- Problem 12. Countries Holding ‘A’ 3 or More Times
-- Find all countries that holds the letter &#39;A&#39; in their name at least 3 times (case insensitively), sorted by ISO code. Display the country name and ISO code.

SELECT CountryName, ISOCode
	FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY ISOCode


-- Problem 13. Mix of Peak and River Names
-- Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name. 
-- Display the peak names, river names, and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.

--SELECT PeakName , RiverName
--	FROM (
--		SELECT PeakName + ' ' + RiverName	
--		FROM Countries
--		WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
--		) AS mix
--	ORDER BY mix

SELECT PeakName, RiverName, LOWER(SUBSTRING(PeakName,1,LEN(PeakName)-1) + RiverName) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
	ORDER BY Mix

-- Problem 14. Games from 2011 and 2012 year
-- Find the top 50 games ordered by start date, then by name of the game. Display only games from 2011 and 2012 year. Display start date in the format “yyyy-MM-dd”.

SELECT TOP(50) [Name], FORMAT ([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE YEAR([Start]) IN (2011,2012)
	ORDER BY [Start], [Name]