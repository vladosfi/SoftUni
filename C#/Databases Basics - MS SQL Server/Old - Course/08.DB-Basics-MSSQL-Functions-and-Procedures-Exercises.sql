--Problem 1.	Employees with Salary Above 35000
--Create stored procedure usp_GetEmployeesSalaryAbove35000 that returns all employees’ first and last names for whose salary is above 35000. 
USE SoftUni
GO
	CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000


--Problem 2.	Employees with Salary Above Number
--Create stored procedure usp_GetEmployeesSalaryAboveNumber that accept a number (of type DECIMAL(18,4)) as parameter and returns all employees’ first and last names whose salary is above or equal to the given number. 
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@AboveSalary DECIMAL(18,4) = 0)
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @AboveSalary 
GO


EXEC usp_GetEmployeesSalaryAboveNumber 48100


--Problem 3.	Town Names Starting With
--Write a stored procedure usp_GetTownsStartingWith that accept string as parameter and returns all town names starting with that string. 
GO
	CREATE OR ALTER PROC usp_GetTownsStartingWith(@FirstLetter NVARCHAR(MAX))
AS
	SELECT [Name] AS Town 
	FROM Towns
	WHERE [Name] LIKE CONCAT(@FirstLetter,'%')
GO

EXEC usp_GetTownsStartingWith 'b'


--Problem 4.	Employees from Town
--Write a stored procedure usp_GetEmployeesFromTown that accepts town name as parameter and return the employees’ first and last name that live in the given town. 
GO
	CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR (50))
AS
	SELECT FirstName, LastName
		FROM Employees AS e
		JOIN Addresses AS a
		ON e.AddressID = a.AddressID
		JOIN Towns AS t
		ON a.TownID = t.TownID
	WHERE t.[Name] = @TownName 
GO

EXEC usp_GetEmployeesFromTown 'Sofia'


--Problem 5.	Salary Level Function
--Write a function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) that receives salary of an employee and returns the level of the salary.
--•	If salary is < 30000 return “Low”
--•	If salary is between 30000 and 50000 (inclusive) return “Average”
--•	If salary is > 50000 return “High”


CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10) 
BEGIN
DECLARE @result AS CHAR(10)
IF (@salary < 30000 )
BEGIN
	SET @result = 'Low'
END
ELSE IF (@salary <= 50000)
BEGIN
	SET @result = 'Average'
END
ELSE
BEGIN
	SET @result = 'High'
END		
RETURN @result
END

SELECT dbo.ufn_GetSalaryLevel(60000) AS [Salary Level]


--Problem 6.	Employees by Salary Level
--Write a stored procedure usp_EmployeesBySalaryLevel that receive as parameter level of salary (low, average or high) and print the names of all employees that have given level of salary. You should use the function - “dbo.ufn_GetSalaryLevel(@Salary)”, which was part of the previous task, inside your “CREATE PROCEDURE …” query.
GO
CREATE PROC usp_EmployeesBySalaryLevel(@LevelOfSalary CHAR(10))
AS
	SELECT FirstName, LastName 
	FROM Employees e
	WHERE (SELECT dbo.ufn_GetSalaryLevel(e.Salary)) =  @LevelOfSalary
GO

EXEC usp_EmployeesBySalaryLevel 'high'

--Problem 7.	Define Function
--Define a function ufn_IsWordComprised(@setOfLetters, @word) that returns true or false depending on that if the word is a comprised of the given set of letters. 
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @Count INT = 1
	WHILE(@Count <= LEN(@word))
	BEGIN
		IF(CHARINDEX(SUBSTRING(@word, @Count, 1), @setOfLetters) = 0)
		BEGIN		
			RETURN 0
		END
		ELSE
		BEGIN
			SET @Count += 1
		END
	END
	RETURN 1
END 

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')



--Problem 8.	* Delete Employees and Departments
--Write a procedure with the name usp_DeleteEmployeesFromDepartment (@departmentId INT) which deletes all Employees from a given department. Delete these departments from the Departments table too. Finally SELECT the number of employees from the given department. If the delete statements are correct the select query should return 0.
--After completing that exercise restore your database to revert all changes.

-- alter table departments set ManagerId column null
-- delete from EmployeesProjects
-- Update department set managerId column = null
-- delete from employees where depId = dep
-- delete from departments where id = @id


CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT 

DELETE FROM EmployeesProjects 
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments 
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

DELETE FROM Employees
WHERE DepartmentID = @departmentId

DELETE FROM Departments
WHERE DepartmentID = @departmentId
SELECT COUNT(*) FROM Employees	 WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 1
	

--	Problem 9.	Find Full Name
--You are given a database schema with tables AccountHolders(Id (PK), FirstName, LastName, SSN) and Accounts(Id (PK), AccountHolderId (FK), Balance).  Write a stored procedure usp_GetHoldersFullName that selects the full names of all people. 
CREATE PROC usp_GetHoldersFullName 
AS
SELECT CONCAT(FirstName,' ', LastName) AS [Full Name]  FROM AccountHolders

EXEC usp_GetHoldersFullName 

--Problem 10.	People with Balance Higher Than
--Your task is to create a stored procedure usp_GetHoldersWithBalanceHigherThan that accepts a number as a parameter and returns all people who have more money in total of all their accounts than the supplied number. 
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@Number MONEY)
AS
SELECT s.FirstName, s.LastName FROM(
	SELECT ah.FirstName, ah.LastName, ah.Id
	FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName, ah.Id
	HAVING SUM(a.Balance) > @Number) as s
ORDER BY s.FirstName, s.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 50000


--Problem 11.	Future Value Function
--Your task is to create a function ufn_CalculateFutureValue that accepts as parameters – sum (decimal), yearly interest rate (float) and number of years(int). It should calculate and return the future value of the initial sum. Using the following formula:

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@InitialSum DECIMAL(15,4), @YearlyInterestRate FLOAT(53), @NumberOfYears INT)
RETURNS DECIMAL(15, 4)
BEGIN
	DECLARE @FV AS DECIMAL(15, 4) = @InitialSum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
	RETURN @FV
END

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)


--Problem 12.	Calculating Interest
--Your task is to create a stored procedure usp_CalculateFutureValueForAccount that uses the function from the previous problem to give an interest to a person's account for 5 years, along with information about his/her account id, first name, last name and current balance as it is shown in the example below. It should take the AccountId and the interest rate as parameters. Again you are provided with “dbo.ufn_CalculateFutureValue” function which was part of the previous task.


CREATE OR ALTER PROC usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate AS FLOAT)
AS
SELECT *, dbo.ufn_CalculateFutureValue([Current Balance], @InterestRate, 5)  AS [Balance in 5 years] FROM(
	SELECT a.AccountHolderId AS [Account Id] 
		,ah.FirstName AS [First Name]
		,ah.LastName AS [Last Name]
		, SUM(a.Balance) AS [Current Balance]
		FROM AccountHolders AS ah
		JOIN Accounts AS a
		ON ah.Id = a.AccountHolderId
		WHERE a.Id = 1 
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	) as d


EXEC usp_CalculateFutureValueForAccount 1,0.1



--Problem 13.	*Scalar Function: Cash in User Games Odd Rows
--Create a function ufn_CashInUsersGames that sums the cash of odd rows. Rows must be ordered by cash in descending order. The function should take a game name as a parameter and return the result as table. Submit only your function in.
--Execute the function over the following game names, ordered exactly like: “Lily Stargazer”, “Love in a mist”.

CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS TABLE 
RETURN
	(SELECT SUM(gs.Cash) AS [SumCash]
	FROM (SELECT g.[Name] 
				,ug.[Cash]
				,ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
			FROM [UsersGames] AS ug
			JOIN Games AS g
			ON g.Id = ug.GameID
			WHERE g.[Name] = @GameName
			) AS gs
		WHERE gs.RowNumber % 2 <> 0)


SELECT * FROM dbo.ufn_CashInUsersGames('Lily Stargazer')


-- 14. Create Table Logs
SELECT * FROM Accounts AS a JOIN AccountHolders AS ah ON a.AccountHolderID = ah.Id

CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum MONEY,
NewSum MONEY)


CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
DECLARE @NewSum MONEY = (SELECT Balance FROM inserted)
DECLARE @OldSum MONEY = (SELECT Balance FROM deleted)
DECLARE @AccountId INT = (SELECT Id FROM inserted)
INSERT INTO Logs (AccountId, NewSum, OldSum)
VALUES(@AccountId,@NewSum, @OldSum)

UPDATE Accounts SET Balance += 10 WHERE Id = 1

SELECT * FROM Logs


