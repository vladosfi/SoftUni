--Section 1. DDL (30 pts)
CREATE DATABASE Bitbucket

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)


CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(18,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)


--2.	Insert
--Insert some sample data into the database. Write a query to add the following records into the corresponding tables. All Ids should be auto-generated.
INSERT INTO Files(Name,	Size,	ParentId,	CommitId)
	VALUES('Trade.idk',2598.0,	1,	1),
('menu.net',9238.31,	2,	2),
('Administrate.soshy',1246.93,	3,	3),
('Controller.php',7353.15,	4,	4),
('Find.java',9957.86,5,	5),
('Controller.json',14034.87,	3,	6),
('Operate.xix',	7662.92,7,	7)


INSERT INTO Issues (Title,	IssueStatus	,RepositoryId,	AssigneeId)
VALUES ('Critical Problem with HomeController.cs file','open',1,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open',9,8)


--3.	Update
--Make issue status 'closed' where Assignee Id is 6.
UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId = 6


--4.	Delete
--Delete repository "Softuni-Teamwork" in repository contributors and issues.
DELETE FROM RepositoriesContributors WHERE RepositoryId IN (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')

DELETE FROM Issues WHERE RepositoryId IN (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')


--5.	Commits
--Select all commits from the database. Order them by id (ascending), message (ascending), repository id (ascending) and contributor id (ascending).
SELECT Id,Message, RepositoryId, ContributorId 
	FROM Commits
	ORDER BY Id,Message,RepositoryId,ContributorId


--	6.	Heavy HTML
--Select all of the files, which have size, greater than 1000, and their name contains "html". Order them by size (descending), id (ascending) and by file name (ascending)
SELECT Id,Name,Size 
	FROM Files
	WHERE Size > 1000 AND Name LIKE '%html%'
	ORDER BY Size DESC, Id, Name


--	7.	Issues and Users
--Select all of the issues, and the users that are assigned to them, so that they end up in the following format: {username} : {issueTitle}. Order them by issue id (descending) and issue assignee (ascending).
SELECT i.Id, CONCAT(u.Username, ' : ', Title) AS [IssueAssignee]
	FROM Issues AS i
	JOIN Users AS u
	ON u.Id = i.AssigneeId
	ORDER BY i.Id DESC, i.AssigneeId


--8.	Non-Directory Files
--Examples
--Select all of the files, which are NOT a parent to any other file. Select their size of the file and add "KB" to the end of it. Order them file id (ascending), file name (ascending) and file size (descending).

SELECT f.Id, f.Name, CONCAT(f.Size,'KB') AS Size
	FROM Files AS f
	LEFT JOIN Files AS fl
	ON fl.ParentId = f.Id
	WHERE fl.Id IS NULL
ORDER BY f.Id,f.Name,f.Size DESC


--9.	Most Contributed Repositories
--Select the top 5 repositories in terms of count of commits. Order them by commits count (descending), repository id (ascending) then by repository name (ascending).
SELECT TOP 5 r.Id,r.Name, COUNT(c.Id) AS Commits
	FROM Repositories AS r
	JOIN Commits AS c
	ON c.RepositoryId = r.Id
	JOIN RepositoriesContributors AS cr
	ON cr.RepositoryId = r.Id
GROUP BY r.Id,r.Name
ORDER BY Commits DESC, r.Id, r.Name



SELECT *
	FROM Repositories AS r
	JOIN Commits AS c
	ON c.RepositoryId = r.Id
	JOIN RepositoriesContributors AS cr
	ON cr.RepositoryId = r.Id
	join Users as u
	on u.Id = cr.ContributorId
	order by c.Id

--	10.	User and Files
--Select all users which have commits. Select their username and average size of the file, which were uploaded by them. Order the results by average upload size (descending) and by username (ascending).
SELECT Username, AVG(f.Size) AS Size
	FROM Users AS u
	JOIN Commits AS c
	ON c.ContributorId = u.Id
	JOIN Files AS f	
	ON f.CommitId = c.Id
GROUP BY Username
ORDER BY AVG(f.Size) DESC, Username


--11.	 User Total Commits
--Create a user defined function, named udf_UserTotalCommits(@username) that receives a username.
--The function must return count of all commits for the user:
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
RETURNS INT
AS 
BEGIN 
	DECLARE @userId INT = (SELECT TOP 1 Id FROM Users WHERE Username = @username);
	DECLARE @commitsCount INT = (SELECT COUNT(*) FROM Commits 
		WHERE ContributorId = @userId)
	RETURN @commitsCount
END 

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')


--12.	 Find by Extensions
--Create a user defined stored procedure, named usp_FindByExtension(@extension), that receives a files extensions.
--The procedure must print the id, name and size of the file. Add "KB" in the end of the size. Order them by id (ascending), file name (ascending) and file size (descending)
CREATE OR ALTER PROC usp_FindByExtension(@extension VARCHAR(5))
AS
SELECT Id, [Name], CONCAT(Size,'KB') AS Size
	FROM Files 
	WHERE [Name] LIKE CONCAT('%',@extension)
	ORDER BY Id, [Name], Size DESC

EXEC usp_FindByExtension 'txt'