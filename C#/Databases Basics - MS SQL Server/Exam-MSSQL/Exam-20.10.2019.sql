CREATE DATABASE Service
USE Service
--Section 1. DDL (30 pts)
--You have been tasked to create the tables in the database by the following models:
CREATE TABLE Users (
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL UNIQUE,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATETIME,
Age SMALLINT CHECK(Age >= 14 AND Age <= 110),
Email VARCHAR(50) NOT NULL)


CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME,
Age SMALLINT CHECK(Age >= 18 AND Age <= 110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status] (
Id INT PRIMARY KEY IDENTITY,
Label VARCHAR(30) NOT NULL
)


CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2.	Insert
--Let's insert some sample data into the database. Write a query to add the following records into the corresponding tables. All Id's should be auto-generated.
INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId)
VALUES('Marlo','O''Malley','1958-9-21',1),
('Niki','Stanaghan','1969-11-26',4),
('Ayrton','Senna','1960-03-21',9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)


INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId)
VALUES(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)


--3.	Update
--Update the CloseDate with the current date of all reports, which don't have CloseDate. 
UPDATE Reports
     SET CloseDate = GETDATE()
     WHERE CloseDate IS NULL

	 SELECT CloseDate FROM Reports 

--4.	Delete
--Delete all reports who have a Status 4.
 DELETE FROM Reports WHERE StatusId = 4


-- 5.	Unassigned Reports
--Find all reports that don't have an assigned employee. Order the results by OpenDate in ascending order, then by description ascending. OpenDate must be in format - 'dd-MM-yyyy'
SELECT Description, FORMAT(OpenDate,'dd-MM-yyyy')
	FROM Reports 
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate ASC, [Description] ASC


--6.	Reports & Categories
--Select all descriptions from reports, which have category. Order them by description (ascending) then by category name (ascending).
SELECT Description, c.Name
	FROM Reports AS r
	JOIN Categories AS c
	ON c.Id = r.CategoryId
	WHERE CategoryId IS NOT NULL
ORDER BY Description, c.Name


--7.	Most Reported Category
--Select the top 5 most reported categories and order them by the number of reports per category in descending order and then alphabetically by name.
SELECT TOP 5 c.Name, COUNT(r.CategoryId) AS ReportsNumber
	FROM Categories AS c
	JOIN Reports AS r
	ON r.CategoryId = c.Id
	GROUP BY c.Name
ORDER BY ReportsNumber DESC, c.Name


--8.	Birthday Report
--Select the user's username and category name in all reports in which users have submitted a report on their birthday. Order them by username (ascending) and then by category name (ascending).
SELECT Username, c.Name
	FROM Users AS u
	JOIN Reports AS r
	ON r.UserId = u.Id
	JOIN Categories AS c
	ON c.Id = r.CategoryId
	WHERE DATEPART(MONTH,u.Birthdate) = DATEPART(MONTH,r.OpenDate) 
		AND DATEPART(DAY,u.Birthdate) = DATEPART(DAY,r.OpenDate) 
ORDER BY Username, c.Name



--9.	Users per Employee 
--Select all employees and show how many unique users each of them has served to.
--Order by users count  (descending) and then by full name (ascending).
SELECT CONCAT(e.FirstName,' ', e.LastName) AS FullName, COUNT(r.UserId) AS UsersCount
	FROM Employees AS e
	LEFT JOIN Reports AS r
	ON r.EmployeeId = e.Id
	GROUP BY CONCAT(e.FirstName,' ', e.LastName) 
ORDER BY UsersCount DESC, FullName







--10.	Full Info
--Select all info for reports along with employee first name and last name (concataned with space), department name, category name, report description, open date, status label and name of the user. Order them by first name (descending), last name (descending), department (ascending), category (ascending), description (ascending), open date (ascending), status (ascending) and user (ascending).
--Date should be in format - dd.MM.yyyy
--If there are empty records, replace them with 'None'.



SELECT
	ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
	ISNULL(d.Name, 'None') AS Department,
	ISNULL(c.Name, 'None') AS Category,
	ISNULL(r.Description, 'None') AS Description,
	ISNULL(FORMAT(r.OpenDate,'dd.MM.yyyy'), 'None') AS OpenDate,
	ISNULL(s.Label, 'None') AS Status,
	ISNULL(u.Name, 'None') AS [User]
	FROM Reports AS r
	LEFT JOIN Employees AS e
	ON e.Id = r.EmployeeId
	LEFT JOIN Categories AS c
	ON c.DepartmentId = r.CategoryId
	LEFT JOIN [Status] AS s
	ON s.Id = r.StatusId	
	LEFT JOIN Users AS u
	ON u.Id = r.UserId	
	JOIN Departments AS d
	ON d.Id = e.DepartmentId
ORDER BY 
	FirstName DESC,
	LastName DESC,
	Department ASC,
	Category ASC,
	[Description] ASC,
	OpenDate ASC,
	[Status] ASC,
	[User] ASC


--	11.	Hours to Complete
--Create a user defined function with the name udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) that receives a start date and end date and must returns the total hours which has been taken for this task. If start date is null or end is null return 0.
CREATE FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
DECLARE @totalHours INT;

IF(@StartDate IS NULL OR @EndDate IS NULL)
BEGIN
	RETURN 0;
END

SET @totalHours = DATEDIFF(HOUR,@StartDate,@EndDate)
RETURN @totalHours;
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours FROM Reports

--12.	Assign Employee
--Create a stored procedure with the name usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) that receives an employee's Id and a report's Id and assigns the employee to the report only if the department of the employee and the department of the report's category are the same. Otherwise throw an exception with message: "Employee doesn't belong to the appropriate department!". 
GO                   
CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @departmentId INT = (SELECT TOP 1 DepartmentId FROM Employees WHERE Id = @EmployeeId)
DECLARE @reportDepartmentId INT = (
		SELECT TOP 1 c.DepartmentId 
			FROM Reports AS r
			JOIN Categories AS c
			ON c.Id = r.CategoryId
			WHERE r.Id = @ReportId AND @departmentId = c.DepartmentId)

IF(@reportDepartmentId = @departmentId)
BEGIN
	UPDATE Reports SET EmployeeId = @EmployeeId WHERE Id = @ReportId
	RETURN
END 
RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
RETURN
	

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2


SELECT *
			FROM Reports AS r
			JOIN Categories AS c
			ON c.Id = r.CategoryId
			WHERE c.Id = 7