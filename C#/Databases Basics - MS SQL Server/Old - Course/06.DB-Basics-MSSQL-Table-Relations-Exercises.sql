--Problem 1.	One-To-One Relationship

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
Salary DECIMAL(15,2),
PassportID INT NOT NULL
)

CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber VARCHAR(8) NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports 
FOREIGN KEY (PassportID) 
REFERENCES Passports(PassportID)

INSERT INTO Passports(PassportID,PassportNumber)
	VALUES(101,'N34FG21B'),
	(102,'K65LO4R7'),
	(103,'ZE657QP2')


INSERT INTO Persons(FirstName,Salary,PassportID)
	VALUES('Roberto',43300.00,102),
	('Tom',56100.00,103),
	('Yana',60200.0,101)



--Problem 2.	One-To-Many Relationship
--Create two tables as follows. Use appropriate data types.

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY,
[Name] VARCHAR(20) UNIQUE,	
EstablishedOn SMALLDATETIME
)

CREATE TABLE Models(
ModelID	INT PRIMARY KEY,
[Name] VARCHAR(20) UNIQUE,	
ManufacturerID INT
CONSTRAINT FK_Peaks_Mountains
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(ManufacturerID,[Name],EstablishedOn)
	VALUES(1,'BMW','07/03/1916'),
	(2,'Tesla','01/01/2003'),
	(3,'Lada','01/05/1966')

INSERT INTO Models(ModelID,[Name],ManufacturerID)
	VALUES(101,'X1',1),
	(102,'i6',1),
	(103,'Model S',2),
	(104,'Model X',2),
	(105,'Model 3',2),
	(106,'Nova',3)


--Problem 3.	Many-To-Many Relationship
--Create three tables as follows. Use appropriate data types.

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL
)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID,ExamID)


ALTER TABLE StudentsExams
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)


INSERT INTO Students(StudentID,[Name])
	VALUES(1,'Mila'),
	(2,'Toni'),
	(3,'Ron')


INSERT INTO Exams(ExamID,[Name])
	VALUES(101,'SpringMVC'),
	(102,'Neo4j'),
	(103,'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES(1,101),
	(1,102),
	(2,101),
	(3,103),
	(2,102),
	(2,103)

	
--	Problem 4.	Self-Referencing 
--Create a single table as follows. Use appropriate data types.
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY,
[Name] VARCHAR (20) NOT NULL,
ManagerID INT
)

ALTER TABLE Teachers
ADD FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)


--Problem 5.	Online Store Database
--Create a new database and design the following structure:

CREATE DATABASE OnlineStore 
GO
USE OnlineStore

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT)

CREATE TABLE Cities(
CityID INT PRIMARY KEY,
[Name] VARCHAR(50))


CREATE TABLE OrderItems(
OrderID INT NOT NULL,
ItemID INT NOT NULL,
CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID,ItemID)
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] VARCHAR(50),
ItemTypeID INT)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
[Name] VARCHAR(50))

ALTER TABLE Items
ADD FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)


ALTER TABLE OrderItems
ADD FOREIGN KEY (ItemID) REFERENCES Items(ItemID)


ALTER TABLE OrderItems
ADD FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)


ALTER TABLE Orders
ADD FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)

ALTER TABLE Customers
ADD FOREIGN KEY (CityID) REFERENCES Cities(CityID)


--Problem 6.	University Database
--Create a new database and design the following structure:
CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
[Name] VARCHAR(50))

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber INT,
StudentName VARCHAR(50),
MajorID INT)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount DECIMAL(18,2),
StudentID INT)

CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL,
CONSTRAINT PK_Agenda PRIMARY KEY (StudentID,SubjectID))

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName VARCHAR(50)
)

ALTER TABLE Agenda
ADD FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)


ALTER TABLE Agenda
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)


ALTER TABLE Students
ADD FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)

ALTER TABLE Payments
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

--Problem 9.	*Peaks in Rila
--Display all peaks for "Rila" mountain. Include:
--•	MountainRange
--•	PeakName
--•	Elevation
--Peaks should be sorted by elevation descending.

SELECT MountainRange, PeakName, Elevation 
FROM Mountains AS m
	JOIN Peaks AS p  ON m.id = p.MountainId
	WHERE MountainRange = 'Rila'
	ORDER BY Elevation DESC

