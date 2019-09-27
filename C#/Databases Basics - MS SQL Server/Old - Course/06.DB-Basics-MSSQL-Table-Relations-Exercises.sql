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

	

