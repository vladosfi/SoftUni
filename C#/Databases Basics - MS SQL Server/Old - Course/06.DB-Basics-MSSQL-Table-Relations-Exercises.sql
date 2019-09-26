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


