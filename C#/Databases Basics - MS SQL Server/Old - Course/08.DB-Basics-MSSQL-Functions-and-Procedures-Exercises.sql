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
