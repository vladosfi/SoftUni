--Problem 1.	One-To-One Relationship
--Create two tables as follows. Use appropriate data types.
CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
Salary DECIMAL(15,2) NOT NULL,
PassportID INT UNIQUE
)

CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber NVARCHAR(8) NOT NULL
)

INSERT INTO Persons(FirstName,Salary,PassportID)
	VALUES('Roberto',43300.00,102),
	('Tom',56100.00,103),
	('Yana',60200.00,101)

INSERT INTO Passports(PassportID, PassportNumber)
	VALUES(102,'N34FG21B'),
	(103,'K65LO4R7'),
	(101,'ZE657QP2')

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID) REFERENCES Passports(PassportID);


--Problem 2.	One-To-Many Relationship
--Create two tables as follows. Use appropriate data types.
CREATE TABLE Models(
ModelID	INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20),
EstablishedOn DATETIME
)

INSERT INTO Models(ModelID, [Name], ManufacturerID)
	VALUES(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)


INSERT INTO Manufacturers([Name],EstablishedOn)
		VALUES('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')


ALTER TABLE Models
ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID);


--Problem 3.	Many-To-Many Relationship
--Create three tables as follows. Use appropriate data types.
CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(30) NOT NULL
)


CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL
)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID,ExamID);


INSERT INTO Students([Name])
VALUES('Mila'),
('Toni'),
('Ron')
 
 INSERT INTO Exams ([Name])
	VALUES('SpringMVC'),
('Neo4j'),
('Oracle 11g')


INSERT INTO StudentsExams(StudentID,ExamID)
	VALUES(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

ALTER TABLE StudentsExams
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
ALTER TABLE StudentsExams
ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)


--Problem 4.	Self-Referencing 
--Create a single table as follows. Use appropriate data types.
