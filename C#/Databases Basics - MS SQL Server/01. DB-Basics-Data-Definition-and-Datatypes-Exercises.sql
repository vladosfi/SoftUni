-- Problem 1.	Create Database
-- You now know how to create database using the GUI of the SSMS. Now it’s time to create it using SQL queries. In that task (and the several following it) you will be required to create the database from the previous exercise using only SQL queries. Firstly, just create new database named Minions.
CREATE DATABASE Minions
GO
USE Minions

-- Problem 2.	Create Tables
-- In the newly created database Minions add table Minions (Id, Name, Age). Then add new table Towns (Id, Name). Set Id columns of both tables to be primary key as constraint.
CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL
)
GO

-- Problem 3.	Alter Minions Table
-- Change the structure of the Minions table to have new column TownId that would be of the same type as the Id column of Towns table. Add new constraint that makes TownId foreign key and references to Id column of Towns table.

ALTER TABLE Minions
	ADD TownId INT 


-- Problem 4.	Insert Records in Both Tables
-- Populate both tables with sample records given in the table below.

SET IDENTITY_INSERT MINIONS ON 


INSERT INTO Towns(Id, [Name])
     VALUES(1,'Sofia'),
	 (2,'Plovdiv'),
	 (3,'Varna')

INSERT INTO Minions(Id, [Name],Age,TownId)
     VALUES(1,'Kevin', 22, 1),
	 (2,'Bob', 15, 3),
	 (3,'Steward', NULL, 2)

-- Problem 5.	Truncate Table Minions
-- Delete all the data from the Minions table using SQL query.

TRUNCATE TABLE Minions

-- Problem 6.	Drop All Tables
-- Delete all tables from the Minions database using SQL query.
DROP TABLE Towns
DROP TABLE Minions

/*
Problem 7.	Create Table People
Using SQL query create table People with columns:
•	Id – unique number for every person there will be no more than 231-1 people. (Auto incremented)
•	Name – full name of the person will be no more than 200 Unicode characters. (Not null)
•	Picture – image with size up to 2 MB. (Allow nulls)
•	Height –  In meters. Real number precise up to 2 digits after floating point. (Allow nulls)
•	Weight –  In kilograms. Real number precise up to 2 digits after floating point. (Allow nulls)
•	Gender – Possible states are m or f. (Not null)
•	Birthdate – (Not null)
•	Biography – detailed biography of the person it can contain max allowed Unicode characters. (Allow nulls)
Make Id primary key. Populate the table with only 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.
*/

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(5,2),
[Weight] DECIMAL(5,2),
Gender CHAR NOT NULL,
Birthdate SMALLDATETIME NOT NULL,
Biography NTEXT 
)

ALTER TABLE People
ADD CONSTRAINT CH_PictureSize CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024)
ALTER TABLE People
ADD CONSTRAINT CH_Gender CHECK(Gender IN ('f','m'))

INSERT INTO People([Name],Picture,Height,[Weight],Gender ,Birthdate,Biography)
	VALUES('Pesho', 11001111,8.5,2, 'm','2000/10/19','Biography'),
	('Gosho', 11001111,1,6, 'm','2000/09/19','Biography'),
	('Sasho', 11001111,4,5, 'm','2000/08/19','Biography'),
	('Misho', 11001111,2,4, 'f','2000/07/19','Biography'),
	('Aaa', 11001111,7,3, 'f','2000/01/19','Biography')


/*
Problem 8.	Create Table Users
Using SQL query create table Users with columns:
•	Id – unique number for every user. There will be no more than 263-1 users. (Auto incremented)
•	Username – unique identifier of the user will be no more than 30 characters (non Unicode). (Required)
•	Password – password will be no longer than 26 characters (non Unicode). (Required)
•	ProfilePicture – image with size up to 900 KB. 
•	LastLoginTime
•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
Make Id primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.
*/

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(26) NOT NULL,
ProfilePicture VARBINARY (MAX),
LastLoginTime DATETIME ,
IsDeleted BIT
) 

ALTER TABLE Users
ADD CONSTRAINT CH_ProfilePicture CHECK(DATALENGTH(Picture) <= 900 * 1024)

INSERT INTO Users(Username,[Password],ProfilePicture, LastLoginTime, IsDeleted)
	VALUES('Pesho','12443',12121212,DEFAULT,0),
	('Pesho2','12323',101010,DEFAULT,0),
	('Pesho3','112343',10101110,DEFAULT,0),
	('Pesho4','123423',11101010001,DEFAULT,0),
	('Pesho5','123423',1101011110,DEFAULT,0)



/*
Problem 9.	Change Primary Key
Using SQL queries modify table Users from the previous task. First remove current primary key then create new primary key that would be the combination of fields Id and Username.
*/
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC078B6AA355

ALTER TABLE Users
ADD CONSTRAINT PK_Id_Username
PRIMARY KEY (Id,Username)

/*
Problem 10.	Add Check Constraint
Using SQL queries modify table Users. Add check constraint to ensure that the values in the Password field are at least 5 symbols long. 
*/
TRUNCATE TABLE USERS

ALTER TABLE Users
ADD CONSTRAINT CH_PasLen 
CHECK (LEN(Password) >= 5);


/*
Problem 11.	Set Default Value of a Field
Using SQL queries modify table Users. Make the default value of LastLoginTime field to be the current time.
*/
UPDATE Users
SET LastLoginTime = GETDATE()
SELECT LastLoginTime FROM USERS


/*
Problem 12.	Set Unique Field
Using SQL queries modify table Users. Remove Username field from the primary key so only the field Id would be primary key. Now add unique constraint to the Username field to ensure that the values there are at least 3 symbols long.
*/

ALTER TABLE Users
DROP CONSTRAINT PK_Id_Username

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username
UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CH_Username_Len CHECK(LEN(Username) >= 3)


/*
Problem 13.	Movies Database
Using SQL queries create Movies database with the following entities:
•	Directors (Id, DirectorName, Notes)
•	Genres (Id, GenreName, Notes)
•	Categories (Id, CategoryName, Notes)
•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with exactly 5 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
*/

CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY, 
DirectorName NVARCHAR(30) NOT NULL, 
Notes NTEXT
) 

INSERT INTO Directors(DirectorName,Notes)
	VALUES('Steven Spielberg', 'Steven'),
	('Martin Scorsese', 'Steven'),
	('Ridley Scott', 'Steven'),
	('John Woo', 'Steven'),
	('Christopher Nolan', 'Steven')

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY, 
GenreName NVARCHAR(30) NOT NULL, 
Notes NTEXT
) 

INSERT INTO Genres(GenreName,Notes)
	VALUES('Action', 'Action'),
	('Adventure ', 'Action'),
	('Comedy ', 'Action'),
	('Crime ', 'Action'),
	('Drama ', 'Action')

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY, 
CategoryName NVARCHAR(30) NOT NULL, 
Notes NTEXT
) 

INSERT INTO Categories(CategoryName,Notes)
	VALUES('Thriller', 'Action'),
	('Adventure ', 'Action'),
	('Horrror ', 'Action'),
	('Romance ', 'Action'),
	('Fantasy ', 'Action')

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY, 
Title NVARCHAR(30) NOT NULL, 
DirectorId INT NOT NULL, 
CopyrightYear DATETIME NOT NULL,  
[Length] DECIMAL(5,2) NOT NULL, 
GenreId INT NOT NULL, 
CategoryId INT NOT NULL, 
Rating INT,
Notes NTEXT
) 


INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES('Movie1', 1,'2018/01/01',2.34,1,1,5,'Note'),
	('Movie2', 1,'2010/01/01',2.34,1,1,5,'Note'),
	('Movie3', 1,'2011/01/01',2.34,1,1,5,'Note'),
	('Movie4', 1,'2012/01/01',2.34,1,1,5,'Note'),
	('Movie5', 1,'2013/01/01',2.34,1,1,5,'Note')


/*
Problem 14.	Car Rental Database
Using SQL queries create CarRental database with the following entities:
•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
*/

CREATE DATABASE CarRental 
USE CarRental

--	 Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY, 
CategoryName CHAR(30) UNIQUE, 
DailyRate INT, 
WeeklyRate INT, 
MonthlyRate INT, 
WeekendRate INT
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Sedan', 1,1,1,1),
	('Jeep', 2,2,2,2),
	('Sport', 3,3,3,3)


-- Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY, 
PlateNumber INT UNIQUE NOT NULL, 
Manufacturer NVARCHAR(30) NOT NULL, 
Model NVARCHAR(30), 
CarYear INT, 
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT, 
Picture VARBINARY(MAX), 
Condition NVARCHAR(20), 
Available BIT
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES (123,'Mitsubishi','Carisma',2002 ,1 ,4 ,101001 ,'Good',1),
	(122,'WV','GOLF III',1996 ,2 ,4 ,101001 ,'Super',0),
	(124,'BMW','MIII',19933 ,3 ,4 ,101001 ,'Poor',1)

-- Employees (Id, FirstName, LastName, Title, Notes)
CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(20) NOT NULL, 
LastName NVARCHAR(20) NOT NULL, 
Title NVARCHAR(50), 
Notes NTEXT
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Pesho', 'Peshev', 'Title', 'Notes'),
('Sasho', 'Minchev', 'Title', 'Notes'),
('Ivan', 'Ivanov', 'Title', 'Notes')

--	 Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY, 
DriverLicenceNumber INT UNIQUE NOT NULL, 
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
City NVARCHAR(30) NOT NULL,
ZIPCode NVARCHAR(30) NOT NULL,
Notes NTEXT
)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES ('123456', 'Full Name', 'Address 1', 'City', 'ZIPC123', 'Customers Notes'),
	('123453', 'Full Name', 'Address 1', 'City', 'ZIPC123', 'Customers Notes'),
	('123454', 'Full Name', 'Address 1', 'City', 'ZIPC123', 'Customers Notes')


-- RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
-- TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY, 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel INT NOT NULL, 
KilometrageStart INT NOT NULL, 
KilometrageEnd INT,
TotalKilometrage INT , 
StartDate DATE NOT NULL, 
EndDate DATE , 
TotalDays INT , 
RateApplied INT, 
TaxRate DECIMAL(6,2), 
OrderStatus NVARCHAR(20), 
Notes NTEXT
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (1, 1, 1, 50, 100234,null,null, '1988-03-13', null, null, 10, 50.30, 'Started', 'Orders Note'),
	(2, 2, 3, 50, 100234,null,null, '1988-03-13', null, null, 10, 50.30, 'Started', 'Orders Note'),
	(3, 3, 3, 50, 100234,null,null, '1988-03-13', null, null, 10, 50.30, 'Started', 'Orders Note')

/*
Problem 15.	Hotel Database
Using SQL queries create Hotel database with the following entities:
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
•	RoomStatus (RoomStatus, Notes)
•	RoomTypes (RoomType, Notes)
•	BedTypes (BedType, Notes)
•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
*/

CREATE DATABASE Hotel

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(20), 
LastName NVARCHAR(20), 
Title NVARCHAR(30), 
Notes NTEXT
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Pesho1', 'Peshev1', 'Peshos1 title', 'Note'),
	('Pesho2', 'Peshev2', 'Peshos2 title', 'Note'),
	('Pesho3', 'Peshev3', 'Peshos3 title', 'Note')

CREATE TABLE Customers (
AccountNumber INT PRIMARY KEY , 
FirstName NVARCHAR(20) NOT NULL, 
LastName NVARCHAR(20) NOT NULL, 
PhoneNumber CHAR(12) NOT NULL, 
EmergencyName NVARCHAR(30),
EmergencyNumber INT,
Notes NTEXT
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber,Notes)
VALUES (123, 'Pesho1', 'Peshev1', '0888 888 565', 'EmergencyName', 12312, 'Note'),
	(124, 'Pesho1', 'Peshev1', '0888 888 565', 'EmergencyName', 12312, 'Note'),
	(125, 'Pesho1', 'Peshev1', '0888 888 565', 'EmergencyName', 12312, 'Note')


CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(20) PRIMARY KEY,
Notes NTEXT
)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES ('Reserve', 'Note1'),
	('Free', 'Note2'),
	('Opened', 'Note3')

CREATE TABLE RoomTypes(
RoomType NVARCHAR(20) PRIMARY KEY,
Notes NTEXT
)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES ('Apartment', 'Note1'),
	('Single room', 'Note2'),
	('double room', 'Note3')


CREATE TABLE BedTypes(
BedType NVARCHAR(20) PRIMARY KEY,
Notes NTEXT
)

INSERT INTO BedTypes(BedType, Notes)
VALUES ('One', 'Note1'),
	('Two', 'Note2'),
	('One + One', 'Note3')



CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY , 
RoomType NVARCHAR(20) NOT NULL, 
BedType NVARCHAR(20) NOT NULL, 
Rate INT, 
RoomStatus NVARCHAR(20),
Notes NTEXT
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES (1, 'Apartment', 'Two',5, 'Free', 'Note'),
	(2, 'Apartment', 'Two',5, 'Free', 'Note'),
	(3, 'Apartment', 'Two',5, 'Free', 'Note')



CREATE TABLE Payments (
ID INT PRIMARY KEY IDENTITY, 
EmployeeId INT NOT NULL, 
PaymentDate DATETIME, 
AccountNumber INT, 
FirstDateOccupied DATETIME, 
LastDateOccupied DATETIME, 
TotalDays INT, 
AmountCharged DECIMAL (5,2), 
TaxRate DECIMAL (5,2), 
TaxAmount DECIMAL (5,2), 
PaymentTotal DECIMAL (5,2),
Notes NTEXT
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal)
VALUES (1, '1998/10/10', 5,'1998/10/10','1998/10/10',1,10.5,10.5,10.5,10.5),
	(2, '1998/10/10', 5,'1998/10/10','1998/10/10',1,10.5,10.5,10.5,10.5),
	(3, '1998/10/10', 5,'1998/10/10','1998/10/10',1,10.5,10.5,10.5,10.5)


CREATE TABLE Occupancies (
ID INT PRIMARY KEY IDENTITY, 
EmployeeId INT NOT NULL, 
DateOccupied DATETIME, 
AccountNumber INT, 
RoomNumber INT, 
RateApplied INT, 
PhoneCharge DECIMAL (5,2),
Notes NTEXT
)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge)
VALUES (1, '1998/10/10', 5,1, 7, 10.5),
(2, '2009/10/10', 5,1, 7, 10.5),
(3, '2008/10/10', 5,1, 7, 10.5)
	

/*
Problem 16.	Create SoftUni Database
Now create bigger database called SoftUni. You will use same database in the future tasks. It should hold information about
•	Towns (Id, Name)
•	Addresses (Id, AddressText, TownId)
•	Departments (Id, Name)
•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…). Make sure you use appropriate data types for each column. Add primary and foreign keys as constraints for each table. Use only SQL queries. Consider which fields are always required and which are optional.
*/

CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(50),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)



CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(30), 
	LastName NVARCHAR(30), 
	JobTitle NVARCHAR(30) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate SMALLDATETIME NOT NULL, 
	Salary DECIMAL(8,2) NOT NULL, 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

/*
Problem 18.	Basic Insert
Use the SoftUni database and insert some data using SQL queries.
•	Towns: Sofia, Plovdiv, Varna, Burgas
•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
•	Employees:
*/

INSERT INTO 
	Towns([Name])
VALUES ('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO
	Departments([Name])
VALUES ('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')
	

INSERT INTO Employees (FirstName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan Ivanov Ivanov' , '.NET Developer' ,4, '1988-03-13',  3500.00),
	('Petar Petrov Petrov' , 'Senior Engineer' ,1, '1988-03-13',  4000),
	('Maria Petrova Ivanova' , 'Intern' ,4, '1988-03-13',  3500.00),
	('Georgi Teziev Ivanov' , 'CEO' ,2, '1988-03-13',  3000.00),
	('Peter Pan Pan ' , 'Intern' ,3, '1988-03-13',  599.88)


/*Problem 19.	Basic Select All Fields
Use the SoftUni database and first select all records from the Towns, then from Departments and finally from Employees table. Use SQL queries and submit them to Judge at once. Submit your query statements as Prepare DB & Run queries.
*/
SELECT * FROM Towns
SELECT * FROM Departments 
SELECT * FROM Employees

/*
Modify queries from previous problem by sorting:
•	Towns - alphabetically by name
•	Departments - alphabetically by name
•	Employees - descending by salary
Submit your query statements as Prepare DB & Run queries.
*/
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY salary DESC


/*
Problem 21.	Basic Select Some Fields
Modify queries from previous problem to show only some of the columns. For table:
•	Towns – Name
•	Departments – Name
•	Employees – FirstName, LastName, JobTitle, Salary
Keep the ordering from the previous problem. Submit your query statements as Prepare DB & Run queries.
*/

SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY salary DESC


/*
Problem 22.	Increase Employees Salary
Use SoftUni database and increase the salary of all employees by 10%. Then show only Salary column for all in the Employees table. Submit your query statements as Prepare DB & Run queries.
*/

UPDATE  Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees


/*Problem 23.	Decrease Tax Rate
Use Hotel database and decrease tax rate by 3% to all payments. Then select only TaxRate column from the Payments table. Submit your query statements as Prepare DB & Run queries.
*/
UPDATE Payments
SET TaxRate = TaxRate - (TaxRate * 0.03)
SELECT TaxRate FROM Payments

/*Problem 24.	Delete All Records
Use Hotel database and delete all records from the Occupancies table. Use SQL query. Submit your query statements as Run skeleton, run queries & check DB.
*/

TRUNCATE TABLE Occupancies 