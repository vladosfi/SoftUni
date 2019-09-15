SELECT * FROM Departments

SELECT [Name] FROM Departments

SELECT FirstName, MiddleName, LastName 
	FROM Employees


SELECT FirstName + '.' + ISNULL(LastName,'') + '@softuni.bg' AS [Full Email Address]
	FROM Employees 


SELECT DISTINCT Salary
	FROM Employees

SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative'

SELECT FirstName, LastName, JobTitle 
	FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000
	


SELECT FirstName + ' ' + ISNULL(MiddleName,'')  + ' ' + LastName AS [Full Name]
	FROM Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)


SELECT FirstName, LastName
	FROM Employees
	WHERE ManagerID IS NULL

--Write a SQL query to find first name, last name and salary of those employees who has salary more than 50000.
--Order them in decreasing order by salary.

SELECT FirstName, LastName, Salary
	FROM Employees
	WHERE Salary >= 50000
	ORDER BY Salary DESC


--Write SQL query to find first and last names about 5 best paid Employees ordered descending by their salary.
SELECT TOP (5) FirstName, LastName
	FROM Employees
	ORDER BY Salary DESC
	

--Write a SQL query to find the first and last names of all employees whose department ID is different from 4.
SELECT FirstName, LastName
	FROM Employees
	WHERE NOT (DepartmentID = 4)

-- Write a SQL query to sort all records in the Employees table by the following criteria:
--   First by salary in decreasing order
--   Then by first name alphabetically
--   Then by last name descending
--   Then by middle name alphabetically

SELECT * FROM Employees
	ORDER BY 
	Salary DESC,
	FirstName, 
	LastName DESC,
	MiddleName 

-- Write a SQL query to create a view V_EmployeesSalaries with 
-- first name, last name and salary for each employee.

CREATE VIEW V_EmployeesSalaries AS
	SELECT FirstName, LastName,	Salary
	FROM Employees

SELECT * FROM V_EmployeesSalaries


--Write a SQL query to create view V_EmployeeNameJobTitle with full employee name and job title. When middle
--name is NULL replace it with empty string (‘’).
CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT FirstName + ' ' + ISNULL(MiddleName,'')  + ' ' + ISNULL(LastName,'') AS [Full Name],
	JobTitle
	FROM Employees

SELECT * FROM V_EmployeeNameJobTitle

-- Write a SQL query to find all distinct job titles.

SELECT DISTINCT JobTitle 
	FROM Employees
	
-- 19. Find First 10 Started Projects
-- Write a SQL query to find first 10 started projects. 
-- Select all information about them and sort them by start date, then by name.

SELECT TOP (10) *
	FROM Projects
	ORDER BY StartDate, [Name]

-- 20. Last 7 Hired Employees
-- Write a SQL query to find last 7 hired employees. Select their first, last name and their hire date.

SELECT TOP(7) FirstName, LastName, HireDate
	FROM Employees
	ORDER BY HireDate DESC


-- 21. Increase Salaries
-- Write a SQL query to increase salaries of all employees that are in the Engineering, Tool Design, Marketing or
-- Information Services department by 12%. Then select Salaries column from the Employees table. After that
-- exercise restore your database to revert those changes.

UPDATE Employees 
	SET Salary = Salary * 1.12
	WHERE DepartmentId IN (1,2,4,11)
	SELECT Salary FROM Employees
-- WHERE DepartmentId IN (SELECT DepartmentID FROM Departments WHERE Name IN (Engineering, Tool Design, Marketing ,Information))

-- 22. All Mountain Peaks
-- Display all mountain peaks in alphabetical order.

USE Geographi
SELECT PeakName
	FROM Peaks
	ORDER BY PeakName

-- 23. Biggest Countries by Population
-- Find the 30 biggest countries by population from Europe. Display the country name and population. 
-- Sort the results by population (from biggest to smallest), then by country alphabetically.

SELECT TOP(30) CountryName, [Population] 
	FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY 
		[Population] DESC,
		CountryName


-- 24. *Countries and Currency (Euro / Not Euro)
-- Find all countries along with information about their currency. Display the country name, country code and
-- information about its currency: either &quot;Euro&quot; or &quot;Not Euro&quot;. 
-- Sort the results by country name alphabetically.
-- *Hint: Use CASE … WHEN.

SELECT CountryName, CountryCode,
	CASE 
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
    ELSE 'Not Euro'
	END AS Currency
FROM Countries
ORDER BY CountryName


-- 25. All Diablo Characters
-- Display all characters in alphabetical order.

SELECT [Name]
	FROM Diablo
	ORDER BY [Name]
	