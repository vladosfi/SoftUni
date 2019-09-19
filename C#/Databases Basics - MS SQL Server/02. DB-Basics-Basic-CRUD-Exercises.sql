-- 2.	Find All Information About Departments
-- Write a SQL query to find all available information about the Departments.
USE SoftUni

SELECT * FROM Departments

--3.	Find all Department Names
-- Write SQL query to find all Department names.
SELECT [Name] FROM Departments	


-- 4.	Find Salary of Each Employee
-- Write SQL query to find the first name, last name and salary of each employee.
SELECT FirstName, LastName, Salary FROM Employees


--5.	Find Full Name of Each Employee
--Write SQL query to find the first, middle and last name of each employee. 

SELECT FirstName,MiddleName, LastName FROM Employees 

-- 6.	Find Email Address of Each Employee
-- Write a SQL query to find the email address of each employee. (By his first and last name). Consider that the email domain is softuni.bg. Emails should look like “John.Doe@softuni.bg". The produced column should be named "Full Email Address". 

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address] FROM Employees

-- 7.	Find All Different Employee’s Salaries
-- Write a SQL query to find all different employee’s salaries. Show only the salaries.

SELECT DISTINCT Salary FROM Employees

-- 8.	Find all Information About Employees
-- Write a SQL query to find all information about the employees whose job title is “Sales Representative”. 
