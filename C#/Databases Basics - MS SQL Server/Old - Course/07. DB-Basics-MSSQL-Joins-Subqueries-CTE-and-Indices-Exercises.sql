--Problem 1.	Employee Address
--Write a query that selects:
--•	EmployeeId
--•	JobTitle
--•	AddressId
--•	AddressText
--Return the first 5 rows sorted by AddressId in ascending order.
SELECT TOP 5 EmployeeID, JobTitle, e.AddressID , AddressText
FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
ORDER BY e.AddressID
	

--Problem 2.	Addresses with Towns
--Write a query that selects:
--•	FirstName
--•	LastName
--•	Town
--•	AddressText
--Sorted by FirstName in ascending order then by LastName. Select first 50 employees.
SELECT TOP 50 FirstName, LastName, t.Name, a.AddressText
FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON a.TownID = t.TownID
ORDER BY FirstName,LastName


--Problem 3.	Sales Employee
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	LastName
--•	DepartmentName
--Sorted by EmployeeID in ascending order. Select only employees from “Sales” department.
SELECT EmployeeID, FirstName, LastName, d.[Name]
FROM Employees AS e
	INNER JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID


--Problem 4.	Employee Departments
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	Salary
--•	DepartmentName
--Filter only employees with salary higher than 15000. Return the first 5 rows sorted by DepartmentID in ascending order.
SELECT TOP 5 EmployeeID,FirstName, Salary, d.[Name]
FROM Employees AS e
	INNER JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

