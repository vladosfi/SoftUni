-- Problem 1. Create Database
-- You now know how to create database using the GUI of the SSMS. Now it’s time to create it using SQL queries. In
-- that task (and the several following it) you will be required to create the database from the previous exercise using
-- only SQL queries. Firstly, just create new database named Minions.

CREATE DATABASE Minions

-- Problem 2. Create Tables
-- In the newly created database Minions add table Minions (Id, Name, Age). Then add new table Towns (Id, Name).
-- Set Id columns of both tables to be primary key as constraint.
USE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL
)

-- Problem 3. Alter Minions Table
-- Change the structure of the Minions table to have new column TownId that would be of the same type as the Id
-- column of Towns table. Add new constraint that makes TownId foreign key and references to Id column of Towns table.

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

-- Problem 4. Insert Records in Both Tables
-- Populate both tables with sample records given in the table below.

--SET IDENTITY_INSERT Towns OFF

INSERT INTO Towns(Id, [Name])
VALUES (1, 'Sofia'), 
	   (2, 'Plovdiv'),
	   (3, 'Varna')

SET IDENTITY_INSERT Minions ON 
INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES (1,'Kevin',22,1), 
	   (2,'Bob', 15,2),
	   (3,'Steward', NULL,3)


-- Problem 5. Truncate Table Minions
-- Delete all the data from the Minions table using SQL query.

TRUNCATE TABLE Minions

-- Problem 6. Drop All Tables
-- Delete all tables from the Minions database using SQL query.

DROP TABLE Minions, Towns

-- Problem 7. Create Table People
-- Using SQL query create table People with columns:
-- Id – unique number for every person there will be no more than 2^31 -1 people. (Auto incremented)
-- Name – full name of the person will be no more than 200 Unicode characters. (Not null)
-- Picture – image with size up to 2 MB. (Allow nulls)
-- Height – In meters. Real number precise up to 2 digits after floating point. (Allow nulls)
-- Weight – In kilograms. Real number precise up to 2 digits after floating point. (Allow nulls)
-- Gender – Possible states are m or f. (Not null)
-- Birthdate – (Not null)
-- Biography – detailed biography of the person it can contain max allowed Unicode characters. (Allow nulls)
-- Make Id primary key. Populate the table with only 5 records. 
-- Submit your CREATE and INSERT statements as Run queries &amp; 
-- check DB.

USE Minions

CREATE TABLE People (
Id INT NOT NULL PRIMARY KEY IDENTITY,
[Name] NVARCHAR (200) NOT NULL,
Picture VARBINARY,
Height decimal(5,2),
[Weight] decimal(5,2),
Gender CHAR NOT NULL,
Birthdate DATE,
Biography NTEXT
)

ALTER TABLE People
ADD CONSTRAINT CH_PictureSize CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024)

ALTER TABLE People
ADD CONSTRAINT CH_Gender CHECK(Gender = 'm' or Gender = 'f')


SET IDENTITY_INSERT People ON 

INSERT INTO People(Id, [Name], Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES (1,'Kevin',110101001,2.12,3.14,'f', '1988-03-03', 'sadfsdfsdfsdfsdf'),
(2,'2Kevin',110101001,2.12,3.14,'f', '1988-03-23', 'sadfsdfsdfsdfsdf'),
(3,'3Kevin',110101001,2.12,3.14,'f', '1988-03-13', 'sadfsdfsdfsdfsdf'),
(4,'4Kevin',110101001,2.12,3.14,'f', '1988-03-30', 'sadfsdfsdfsdfsdf'),
(5,'5Kevin',110101001,2.12,3.14,'f', '1988-03-03', 'sadfsdfsdfsdfsdf')

-- Problem 8. Create Table Users
-- Using SQL query create table Users with columns:
--	 Id – unique number for every user. There will be no more than 2^63 -1 users. (Auto incremented)
--	 Username – unique identifier of the user will be no more than 30 characters (non Unicode). (Required)
--	 Password – password will be no longer than 26 characters (non Unicode). (Required)
--	 ProfilePicture – image with size up to 900 KB.
--	 LastLoginTime
--	 IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
-- Make Id primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run
-- queries &amp; check DB.

CREATE TABLE Users(
Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
Username CHAR(30) NOT NULL UNIQUE,
Password CHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT CH_ProfilePicture CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024)


INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES('1Pesho', '1234561', 12345678, '2008-11-11 13:23:44', 0),
	('2Pesho', '1234562', 12345678, '2008-11-11 13:23:44', 0),
	('3Pesho', '1234563', 12345678, '2008-11-11 13:23:44', 0),
	('4Pesho', '1234564', 12345678, '2008-11-11 13:23:44', 0),
	('5Pesho', '1234565', 12345678, '2008-11-11 13:23:44', 0)


-- Problem 9. Change Primary Key
-- Using SQL queries modify table Users from the previous task. First remove current primary key then create new
-- primary key that would be the combination of fields Id and Username.

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07AD8DD30C

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY (Id,Username);

-- Problem 10. Add Check Constraint
-- Using SQL queries modify table Users. Add check constraint to ensure that the values in the Password field are at
-- least 5 symbols long.

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordLen 
CHECK (LEN(Password) >= 5);


-- Problem 11. Set Default Value of a Field
-- Using SQL queries modify table Users. Make the default value of LastLoginTime field to be the current time.
ALTER TABLE Users 
ADD DEFAULT GETDATE()
FOR LastLoginTime


-- Problem 12. Set Unique Field
-- Using SQL queries modify table Users. Remove Username field from the primary key so only the field Id would be
-- primary key. Now add unique constraint to the Username field to ensure that the values there are at least 3
-- symbols long.

ALTER TABLE Users
DROP CONSTRAINT UQ__Users__536C85E46AE2AABA

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLen 
CHECK (LEN(Username) >= 3);

-- Problem 13. Movies Database
-- Using SQL queries create Movies database with the following entities:
--	 Directors (Id, DirectorName, Notes)
--	 Genres (Id, GenreName, Notes)
--	 Categories (Id, CategoryName, Notes)
--	 Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
-- Set most appropriate data types for each column. Set primary key to each table. Populate each table with exactly 5
-- records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields
-- are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries &amp;
-- check DB.

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT NOT NULL PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(30) UNIQUE,
Notes NTEXT
)

INSERT INTO Directors( DirectorName, Notes)
VALUES ('Pesho1', 'Directors notes text!'),
('Pesho2', 'Directors notes text!'),
('Pesho3', 'Directors notes text!'),
('Pesho4', 'Directors notes text!'),
('Pesho5', 'Directors notes text!')

CREATE TABLE Genres(
Id INT NOT NULL PRIMARY KEY IDENTITY,
GenreName NVARCHAR(30) UNIQUE,
Notes NTEXT
)

INSERT INTO Genres( GenreName, Notes)
VALUES ('GenreName1', 'Genre notes text!'),
('GenreName2', 'Genre notes text!'),
('GenreName3', 'Genre notes text!'),
('GenreName4', 'Genre notes text!'),
('GenreName5', 'Genre notes text!')

CREATE TABLE Categories(
Id INT NOT NULL PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) UNIQUE,
Notes NTEXT
)

INSERT INTO Categories(CategoryName, Notes)
VALUES ('CategoryName1', 'Category notes text!'),
('CategoryName2', 'Category notes text!'),
('CategoryName3', 'Category notes text!'),
('CategoryName4', 'Category notes text!'),
('CategoryName5', 'Category notes text!')


CREATE TABLE Movies(
Id INT NOT NULL PRIMARY KEY IDENTITY,
Title NVARCHAR(30) UNIQUE,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT,
[Length] DECIMAL(3,2),
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT, 
Notes NTEXT
)

INSERT INTO Movies(Title, DirectorId,CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES ('Star Wars 1', 1, 2008, 2.3, 1, 1, 4, 'Movie note text!'),
('Star Wars 2', 1, 2009, 2.3, 2, 2, 6, 'Movie note text!'),
('Star Wars 3', 1, 2010, 2.3, 3, 3, 8, 'Movie note text!'),
('Star Wars 4', 1, 2011, 2.3, 4, 4, 4, 'Movie note text!'),
('Star Wars 5', 1, 2008, 2.3, 5, 5, 9, 'Movie note text!')


-- Problem 14. Car Rental Database
-- Using SQL queries create CarRental database with the following entities:
--	 Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--	 Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--	 Employees (Id, FirstName, LastName, Title, Notes)
--	 Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--	 RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
-- TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
-- Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3
-- records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields
-- are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries &amp;
-- check DB.

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




-- Problem 15. Hotel Database
-- Using SQL queries create Hotel database with the following entities:
--	 Employees (Id, FirstName, LastName, Title, Notes)
--	 Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber,Notes)
--	 RoomStatus (RoomStatus, Notes)
--	 RoomTypes (RoomType, Notes)
--	 BedTypes (BedType, Notes)
--	 Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--	 Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied,
--	TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
--	 Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge,Notes)
-- Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3
-- records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields
-- are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries &amp;
-- check DB.

CREATE DATABASE Hotel

USE Hotel


--	 Employees (Id, FirstName, LastName, Title, Notes)

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

--	 Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber,Notes)

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


--	 RoomStatus (RoomStatus, Notes)
CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(20),
Notes NTEXT
)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES ('Reserve', 'Note1'),
	('Reserve', 'Note2'),
	('Reserve', 'Note3')

--  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

-- Problem 16. Create SoftUni Database
-- Now create bigger database called SoftUni. You will use same database in the future tasks. It should hold information about
--	 Towns (Id, Name)
--	 Addresses (Id, AddressText, TownId)
--	 Departments (Id, Name)
--	 Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
-- Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…). Make sure you use appropriate
-- data types for each column. Add primary and foreign keys as constraints for each table. Use only SQL queries.
-- Consider which fields are always required and which are optional.

CREATE DATABASE SoftUni
USE SoftUni

--	 Towns (Id, Name)
CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL
)

--	 Addresses (Id, AddressText, TownId)
CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(30) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--	 Departments (Id, Name)
CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
)

--	 Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30),
MiddleName NVARCHAR(30),
LastName NVARCHAR(30),
JobTitle NVARCHAR(30),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATETIME NOT NULL,
Salary DECIMAL(15,2) NOT NULL, 
AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
)


-- Problem 17. Backup Database
-- Backup the database SoftUni from the previous tasks into a file named “softuni-backup.bak”. Delete your database
-- from SQL Server Management Studio. Then restore the database from the created backup.
-- Hint: https://support.microsoft.com/en-gb/help/2019698/how-to-schedule-and-automate-backups-of-sql-server-databases-in-sql-se


-- Problem 18. Basic Insert
-- Use the SoftUni database and insert some data using SQL queries.
--	 Towns: Sofia, Plovdiv, Varna, Burgas
--	 Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
--	 Employees:
-- | Name |Job Title | Department | Hire Date | Salary |
-- |Ivan Ivanov Ivanov | .NET Developer | Software Development | 01/02/2013 | 3500.00
-- |Petar Petrov Petrov | Senior Engineer | Engineering | 02/03/2004 | 4000.00
-- |Maria Petrova Ivanova | Intern | Quality Assurance | 28/08/2016 | 525.25
-- |Georgi Teziev Ivanov | CEO | Sales | 09/12/2007 | 3000.00
-- |Peter Pan Pan | Intern | Marketing | 28/08/2016 | 599.88

INSERT INTO Towns (Name)
VALUES ('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments (Name)
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