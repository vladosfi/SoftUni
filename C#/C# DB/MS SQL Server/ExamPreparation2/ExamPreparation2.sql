--Section 1. DDL (30 pts)
CREATE DATABASE School
GO
USE School

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age	INT CHECK (Age > 0) NOT NULL,
Address	NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(20) NOT NULL,
Lessons	INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id	INT PRIMARY KEY IDENTITY,
StudentId INT NOT NULL,
SubjectId INT NOT NULL,
Grade DECIMAL(15,2)	CHECK(Grade >= 2 AND Grade <= 6) NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT NOT NULL)

CREATE TABLE StudentsExams(
StudentId INT NOT NULL,
ExamId INT NOT NULL,
Grade DECIMAL(15,2)	CHECK(Grade >= 2 AND Grade <= 6) NOT NULL,
CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId,ExamId))

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Address	NVARCHAR(20) NOT NULL,
Phone NCHAR(10),
SubjectId INT NOT NULL)

CREATE TABLE StudentsTeachers(
StudentId INT NOT NULL,
TeacherId INT NOT NULL,
CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId,TeacherId))


ALTER TABLE StudentsSubjects
ADD FOREIGN KEY (StudentId) REFERENCES Students(Id)
ALTER TABLE StudentsSubjects
ADD FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)

ALTER TABLE Exams
ADD FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)

ALTER TABLE Teachers
ADD FOREIGN KEY (SubjectId) REFERENCES Subjects(Id)

ALTER TABLE StudentsTeachers
ADD FOREIGN KEY (StudentId) REFERENCES Students(Id)
ALTER TABLE StudentsTeachers
ADD FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)

ALTER TABLE StudentsExams
ADD FOREIGN KEY (StudentId) REFERENCES Students(Id)
ALTER TABLE StudentsExams
ADD FOREIGN KEY (ExamId) REFERENCES Exams(Id)


--2. Insert
--Insert some sample data into the database. Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.
INSERT INTO Subjects(Name,Lessons)
VALUES('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId)
VALUES('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)


--3. Update
--Make all grades 6.00, where the subject id is 1 or 2, if the grade is above or equal to 5.50
UPDATE StudentsSubjects
	SET Grade = 6
	WHERE Grade >= 5.5 AND SubjectId IN (1,2)


--4. Delete
--Delete all teachers, whose phone number contains ‘72’.
SELECT * 
	FROM Teachers
	WHERE Phone LIKE '%72%'

DELETE FROM StudentsTeachers
	WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers 
	WHERE Phone LIKE '%72%'


--5. Teen Students
--Select all students who are teenagers (their age is above or equal to 12). Order them by first name (alphabetically), then by last name (alphabetically). Select their first name, last name and their age.
SELECT FirstName, LastName , Age
	FROM Students
	WHERE Age >= 12
ORDER BY FirstName, LastName

--6. Students Teachers
--Select all students and the count of teachers each one has. 
SELECT s.FirstName, s.LastName, COUNT(t.Id) AS TeachersCount
	FROM Students AS s
	JOIN StudentsTeachers AS st
	ON st.StudentId = s.Id
	JOIN Teachers AS t
	ON t.Id = st.TeacherId
GROUP BY s.FirstName, s.LastName

--7. Students to Go
--Find all students, who have not attended an exam. Select their full name (first name + last name).
--Order the results by full name (ascending).
SELECT DISTINCT CONCAT(s.FirstName,' ', s.LastName) AS [Full Name]
	FROM Students AS s
	LEFT JOIN StudentsExams AS se
	ON s.Id = se.StudentId
	WHERE se.Grade IS NULL
ORDER BY [Full Name]


--8. Top Students
--Find top 10 students, who have highest average grades from the exams.
--Format the grade, two symbols after the decimal point.
--Order them by grade (descending), then by first name (ascending), then by last name (ascending)
SELECT TOP 10 FirstName, LastName, CAST(AVG(se.Grade) AS DECIMAL(16,2)) AS Grade
	FROM Students AS s
	JOIN StudentsExams AS se
	ON se.StudentId = s.Id
GROUP BY FirstName, LastName
ORDER BY AVG(se.Grade) DESC, FirstName, LastName

--9. Not So In The Studying
--Find all students who don’t have any subjects. Select their full name. The full name is combination of first name, middle name and last name. Order the result by full name
--NOTE: If the middle name is null you have to concatenate the first name and last name separated with single space.
SELECT DISTINCT CONCAT(FirstName,' ',COALESCE(MiddleName + ' ',''), LastName) AS [Full Name]
	FROM Students AS s
	LEFT JOIN StudentsSubjects AS ss
	ON ss.StudentId = s.Id
	WHERE ss.SubjectId IS NULL 
ORDER BY [Full Name]

--10. Average Grade per Subject
--Find the average grade for each subject. Select the subject name and the average grade. 
--Sort them by subject id (ascending).
SELECT s.[Name], AVG(Grade) AS Grade
	FROM Subjects AS s
	JOIN StudentsSubjects AS ss
	ON ss.SubjectId = s.Id 
GROUP BY s.Id, s.[Name]
ORDER BY s.Id

--11. Exam Grades
--Create a user defined function, named udf_ExamGradesToUpdate(@studentId, @grade), that receives a student id and grade.
--The function should return the count of grades, for the student with the given id, which are above the received grade and under the received grade with 0.50 added (example: you are given grade 3.50 and you have to find all grades for the provided student which are between 3.50 and 4.00 inclusive):
--If the condition is true, you must return following message in the format:
--•	 “You have to update {count} grades for the student {student first name}”
--If the provided student id is not in the database the function should return “The student with provided id does not exist in the school!”
--If the provided grade is above 6.00 the function should return “Grade cannot be above 6.00!”
--Note: Do not update any records in the database!
GO
CREATE OR ALTER FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,2))
RETURNS VARCHAR(100)
AS
BEGIN
DECLARE @studentIdExistance INT = (SELECT TOP 1 Id  FROM Students WHERE Id = @studentId)

IF(@studentIdExistance IS NULL)
BEGIN
	RETURN 'The student with provided id does not exist in the school!';
END

IF(@grade > 6)
BEGIN
	RETURN 'Grade cannot be above 6.00!'
END

DECLARE @gradeCount INT = (SELECT TOP 1 COUNT(se.Grade) 
		FROM Students AS s
		JOIN StudentsExams AS se
		ON se.StudentId = s.Id
		WHERE se.StudentId = @studentId AND se.Grade >= @grade AND se.Grade <= @grade + 0.5)

DECLARE @studentFirstName VARCHAR(30) = (SELECT TOP 1 FirstName FROM Students Where Id = @studentId)

RETURN CONCAT('You have to update ', @gradeCount , ' grades for the student ', @studentFirstName)
END  

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)


--12. Exclude from school
--Create a user defined stored procedure, named usp_ExcludeFromSchool(@StudentId), that receives a student id and attempts to delete the current student. A student will only be deleted if all of these conditions pass:
--•	If the student doesn’t exist, then it cannot be deleted. Raise an error with the message “This school has no student with the provided id!”
--If all the above conditions pass, delete the student and ALL OF HIS REFERENCES!
CREATE OR ALTER PROC usp_ExcludeFromSchool(@StudentId INT)
AS
DECLARE @studentExistance INT = (SELECT TOP 1 Id FROM Students WHERE Id = @StudentId)
IF(@studentExistance IS NULL)
BEGIN
	RAISERROR('This school has no student with the provided id!', 16, 1)
	RETURN
END
DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId
DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId
DELETE FROM StudentsExams
	WHERE StudentId = @StudentId
DELETE FROM Students
	WHERE Id = @StudentId

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301