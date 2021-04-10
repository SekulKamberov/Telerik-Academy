--## 05. Advanced SQL
--### _Homework_

USE TelerikAcademy

--1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--	*	Use a nested `SELECT` statement.

SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM Employees
WHERE Salary = 
	(
		SELECT MIN(Salary) 
		FROM Employees
	)

--2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM Employees
WHERE Salary <= 
	(
		SELECT MIN(Salary) * 1.1
		FROM Employees
	)

--3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--	*	Use a nested `SELECT` statement.

SELECT d.Name, e.Salary AS MaxSalary, e.FirstName + ' ' + e.LastName AS Employee, e.EmployeeID
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(
		SELECT MIN(Salary)
		FROM Employees emp
		WHERE emp.DepartmentID = e.DepartmentID
	)
ORDER BY d.Name, Employee

--4.	Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary)
FROM Employees
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) [Average Salary]
FROM Employees
GROUP BY DepartmentID
HAVING DepartmentID IN (1, 2, 3)

--5.	Write a SQL query to find the average salary  in the "Sales" department. (Or department name starts with 'Fin')

SELECT d.Name, AVG(Salary)
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales' OR d.Name LIKE 'Fin%'
GROUP BY d.Name

--6.	Write a SQL query to find the number of employees in the "Sales" department.

SELECT d.Name AS Department, COUNT(*) AS [Employees count]
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--7.	Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NOT NULL

--8.	Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL

--9.	Write a SQL query to find all departments and the average salary for each of them.

SELECT d.Name, AVG(e.Salary)
FROM Employees e INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--10.	Write a SQL query to find the count of all employees in each department and for each town.

SELECT t.Name AS Town, d.Name AS Department, COUNT(e.EmployeeID) Employees
FROM Employees e INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name, d.Name

--11.	Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

SELECT m.FirstName, m.LastName, m.EmployeeID AS ID --, COUNT(*) AS [COUNT]
FROM Employees m JOIN Employees e
	ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName, m.EmployeeID
HAVING COUNT(*) = 5

SELECT m.FirstName, m.LastName --,COUNT(*)
FROM Employees e INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

SELECT COUNT(*)
FROM Employees
WHERE ManagerID = 25  -- 25, 30, 64, 85, 123, 159, 182, 197, 268

--12.	Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, 'NO MANAGER') AS Manager
FROM Employees e 
	LEFT OUTER JOIN Employees m 
	ON e.ManagerID = m.EmployeeID

-- SELECT * FROM Employees ORDER BY FirstName

--13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in `LEN(str)` function.

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

--14.	Write a SQL query to display the current date and time in the following format "`day.month.year hour:minutes:seconds:milliseconds`".
--	*	Search in Google to find how to format dates in SQL Server.

SELECT CONVERT(nvarchar(12), GETDATE(), 104) + CONVERT(nvarchar(12), GETDATE(), 114)

--15.	Write a SQL statement to create a table `Users`. Users should have username, password, full name and last login time.
--	*	Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--	*	Define the primary key column as identity to facilitate inserting records.
--	*	Define unique constraint to avoid repeating usernames.
--	*	Define a check constraint to ensure the password is at least 5 characters long.
GO
CREATE TABLE Users
(
	Id int IDENTITY PRIMARY KEY,
	Username nvarchar(50) NOT NULL UNIQUE,
	[Password] nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLogin datetime NOT NULL,
	CHECK (LEN([Password]) > 5)
);

--16.	Write a SQL statement to create a view that displays the users from the `Users` table that have been in the system today.
--	*	Test if the view works correctly.
GO

CREATE VIEW UsersView AS
SELECT *
FROM Users
WHERE LastLogin BETWEEN CONVERT(datetime, CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2)), 102) AND DATEADD(MILLISECOND, -2, DATEADD(day, 1,  CONVERT(datetime, CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2)), 102)))
--WHERE CONVERT(varchar(10),LastLogin,120) = CONVERT(varchar(10),GETDATE(),120)
--WHERE LastLogin BETWEEN 
--   CAST(GETDATE() AS DATE) AND DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
GO

-- SELECT CONVERT(datetime, YEAR(GETDATE()) + '-' + MONTH(GETDATE()) + '-' + DAY(GETDATE()), 102)

-- tomorrow start
SELECT DATEADD(day, 1,  CONVERT(datetime, CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2)), 102)) AS [TOMORROW START] 
-- yesterday end
SELECT DATEADD(millisecond, -2,  CONVERT(datetime, CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2)), 102)) AS [YESTERDAY END]
-- today start
SELECT CONVERT(datetime, CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2)), 102) AS [TODAY START]
--today end 
SELECT DATEADD(MILLISECOND, -2, DATEADD(day, 1,  CONVERT(datetime, CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2)), 102))) AS [TODAY END]


--SELECT CAST(YEAR(GETDATE()) AS varchar(4)) + '-' + CAST(MONTH(GETDATE()) AS varchar(2)) + '-' + CAST(DAY(GETDATE()) AS varchar(2))
--SELECT CAST(YEAR(GETDATE()) AS varchar(4)) + '-'

SELECT * 
FROM UsersView

--17.	Write a SQL statement to create a table `Groups`. Groups should have unique name (use unique constraint).
--	*	Define primary key and identity column.
GO

CREATE TABLE Groups
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(50) NOT NULL UNIQUE
)

--18.	Write a SQL statement to add a column `GroupID` to the table `Users`.
--	*	Fill some data in this new column and as well in the `Groups table.
--	*	Write a SQL statement to add a foreign key constraint between tables `Users` and `Groups` tables.
GO
ALTER TABLE Users
ADD GroupID int not null

GO 
ALTER TABLE Users
ADD FOREIGN KEY (GroupID) REFERENCES Groups(Id)

--19.	Write SQL statements to insert several records in the `Users` and `Groups` tables.

GO
INSERT INTO Groups (Name)
VALUES('DBO'),
('Java'),
('Script'),
('MVC')
INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
VALUES('IVAN', 'g4545g', 'User1', GETDATE(), 1),
('Pesho', 'rtbbtb', 'User1', GETDATE(), 2),
('Tosho', 'g4545g', 'User1', GETDATE(), 1),
('Gosho', 'g4545g', 'User1', GETDATE(), 3),
('Losho', 'g4545g', 'User1', GETDATE(), 4)

--20.	Write SQL statements to update some of the records in the `Users` and `Groups` tables.
GO

UPDATE Users
SET FullName = FullName + '.', LastLogin = GETDATE()
WHERE FullName LIKE '%U%' 

UPDATE Groups
SET Name = Name + '.'
WHERE Name LIKE '%D%' 

--21.	Write SQL statements to delete some of the records from the `Users` and `Groups` tables.
GO

DELETE FROM Users
WHERE GroupID = 4

GO
DELETE FROM Groups
WHERE Id = 4

--22.	Write SQL statements to insert in the `Users` table the names of all employees from the `Employees` table.
--	*	Combine the first and last names as a full name.
--	*	For username use the first letter of the first name + the last name (in lowercase).
--	*	Use the same for the password, and `NULL` for last login time.

INSERT INTO Users(Username, Password, FullName, LastLogin, GroupID)
SELECT	SUBSTRING(FirstName, 0, 5) + LOWER(Employees.LastName), -- took more from FirstName cause the unique contraint
		SUBSTRING(FirstName, 0, 1) + LOWER(LastName) + 'longpass',
		FirstName + LastName,
		GETDATE(),
		1
FROM TelerikAcademy.dbo.Employees

--23.	Write a SQL statement that changes the password to `NULL` for all users that have not been in the system since 10.03.2010.
GO
UPDATE Users
SET Password = 'six chars NULL'
WHERE LastLogin < CONVERT(datetime, '10.03.2010', 102)

SELECT CONVERT(datetime, '10.03.2010', 102)

--24.	Write a SQL statement that deletes all users without passwords (`NULL` password).

GO

DELETE FROM Users
WHERE Password = 'six chars NULL'

--25.	Write a SQL query to display the average employee salary by department and job title.

SELECT DepartmentID, JobTitle, AVG(Salary)
FROM Employees
GROUP BY DepartmentID, JobTitle

--26.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

SELECT e.DepartmentID, e.JobTitle, e.Salary, e.EmployeeID
FROM Employees e
WHERE Salary = 
	(
		SELECT MIN(Salary)
		FROM Employees emp
		WHERE emp.DepartmentID = e.DepartmentID
	)
GROUP BY e.DepartmentID, e.JobTitle, e.Salary, e.EmployeeID
ORDER BY e.DepartmentID, e.JobTitle

--27.	Write a SQL query to display the town where maximal number of employees work.

SELECT TOP(1) t.Name , COUNT(*) AS [Employees Worked In Town]
FROM Towns t INNER JOIN Addresses a
	ON t.TownID = a.TownID
	INNER JOIN Employees e
	ON e.AddressID = a.AddressID
GROUP BY t.Name
ORDER BY [Employees Worked In Town] DESC

-- check
SELECT COUNT(*) AS [Worked in]
FROM Employees e INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID
WHERE t.Name = 'Seattle'

--28.	Write a SQL query to display the number of managers from each town.

SELECT COUNT(TownName) AS [Managers from town], TownName AS Town -- THIRD: COUNT TOWNS
FROM (SELECT t.Name AS TownName --, e.EmployeeID -- SECOND: SELECT MANAGER'S TOWNS
		FROM Employees e INNER JOIN Addresses a
			ON e.AddressID = a.AddressID
			INNER JOIN Towns t
			ON a.TownID = t.TownID
		WHERE e.EmployeeID IN 
			(
				SELECT ManagerID --FIRST: SELECT ONLY MANAGERS ID's
				FROM Employees
				GROUP BY ManagerID
				HAVING ManagerID IS NOT NULL
			)
	) TownName
GROUP BY TownName
ORDER BY [Managers from town] DESC

--29.	Write a SQL to create table `WorkHours` to store work reports for each employee (employee id, date, task, hours, comments).
--	*	Don't forget to define  identity, primary key and appropriate foreign key. 
--	*	Issue few SQL statements to insert, update and delete of some data in the table.
--	*	Define a table `WorkHoursLogs` to track all changes in the `WorkHours` table with triggers.
--		*	For each change keep the old record data, the new record data and the command (insert / update / delete).

GO
CREATE TABLE WorkHours
(
	ID int IDENTITY PRIMARY KEY,
	EmployeeID int NOT NULL,
	CONSTRAINT FK_EmpID FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
	DateWorked datetime NULL,
	Task nvarchar(50) NULL,
	Hours int NULL,
	Comments nvarchar(50) NULL
)
GO
INSERT INTO WorkHours(EmployeeID, DateWorked, Task, Hours, Comments)
VALUES(1, GETDATE(), 'JOB', 8, 'COMMENTS OF THE JOB DONE'),
(2, GETDATE(), 'JOB', 14, 'COMMENTS OF THE JOB DONE'),
(3, GETDATE(), 'JOB', 4, 'COMMENTS OF THE JOB DONE'),
(1, GETDATE(), 'JOB', 11, 'COMMENTS OF THE JOB DONE'),
(2, GETDATE(), 'JOB', 6, 'COMMENTS OF THE JOB DONE')

GO
UPDATE WorkHours
SET Hours = 8
WHERE Hours > 8

GO
DELETE FROM WorkHours
WHERE Hours <= 4

GO
CREATE TABLE WorkHoursLogs
(
	WorkHoursLogsID int IDENTITY PRIMARY KEY,
	OldWorkHoursID int,
	--CONSTRAINT FK_OldWorkHoursID FOREIGN KEY (OldWorkHoursID) REFERENCES WorkHours(ID),
	OldEmployeeID int,
	CONSTRAINT FK_OldEmployeeID FOREIGN KEY (OldEmployeeID) REFERENCES Employees(EmployeeID),
	OldDateWorked date,
	OldTask nvarchar(50),
	OldHours int,
	OldComments nvarchar(50),
	NewWorkHoursID int,
	--CONSTRAINT FK_NewWorkHoursID FOREIGN KEY (NewWorkHoursID) REFERENCES WorkHours(ID),
	NewEmployeeID int,
	CONSTRAINT FK_NewEmployeeID FOREIGN KEY (NewEmployeeID) REFERENCES Employees(EmployeeID),
	NewDateWorked date,
	NewTask nvarchar(50),
	NewHours int,
	NewComments nvarchar(50),
	Command nvarchar(50)
)

GO
CREATE TRIGGER Trg_Insert ON WorkHours
AFTER INSERT
AS
BEGIN
    INSERT INTO WorkHoursLogs ( NewWorkHoursID, NewEmployeeID, NewDateWorked, NewTask, NewHours, NewComments, Command)
	SELECT Id, EmployeeID, DateWorked, Task, Hours, Comments, 'INSERT'
	FROM INSERTED
END
GO

GO
CREATE TRIGGER Trg_Delete ON WorkHours
AFTER DELETE
AS
BEGIN
    INSERT INTO WorkHoursLogs ( OldWorkHoursID, OldEmployeeID, OldDateWorked, OldTask, OldHours, OldComments, Command)
	SELECT Id, EmployeeID, DateWorked, Task, Hours, Comments, 'DELETE'
	FROM DELETED
END
GO

--GO
--CREATE TRIGGER Trg_Update ON WorkHours
--AFTER UPDATE
--AS
--BEGIN
--	INSERT INTO WorkHoursLogs ( NewWorkHoursID, NewEmployeeID, NewDateWorked, NewTask, NewHours, NewComments, Command)
--	SELECT INSERTED.Id, INSERTED.EmployeeID, INSERTED.DateWorked, INSERTED.Task, INSERTED.Hours, INSERTED.Comments, 'UPDATE'
--	FROM INSERTED

--	UPDATE WorkHoursLogs 
--	SET OldWorkHoursID = (SELECT Id FROM DELETED), OldEmployeeID = (SELECT EmployeeID FROM DELETED), OldDateWorked = (SELECT DateWorked FROM DELETED), OldTask = (SELECT Task FROM DELETED), OldHours = (SELECT Hours FROM DELETED), OldComments = (SELECT Comments FROM DELETED) 
--	WHERE WorkHoursLogsID = (SELECT SCOPE_IDENTITY())
--END
--GO


GO
DROP TRIGGER Trg_Update
GO
CREATE TRIGGER Trg_Update ON WorkHours
AFTER UPDATE
AS
BEGIN
	INSERT INTO WorkHoursLogs ( NewWorkHoursID, NewEmployeeID, NewDateWorked, NewTask, NewHours, NewComments, OldWorkHoursID, OldEmployeeID, OldDateWorked, OldTask, OldHours, OldComments, Command)
	SELECT INSERTED.Id, INSERTED.EmployeeID, INSERTED.DateWorked, INSERTED.Task, INSERTED.Hours, INSERTED.Comments, DELETED.Id, DELETED.EmployeeID, DELETED.DateWorked, DELETED.Task, DELETED.Hours, DELETED.Comments, 'UPDATE'
	FROM INSERTED, DELETED
END
GO

--30.	Start a database transaction, delete all employees from the '`Sales`' department along with all dependent records from the pother tables.
--	*	At the end rollback the transaction.

--DELETE FROM EmployeesProjects WHERE EmployeeID = 99
--DELETE FROM Employees WHERE EmployeeID = 99

BEGIN TRAN Delete_Sales

/*
GO
ALTER TABLE Employees
   DROP CONSTRAINT FK_Employees_Departments

GO
ALTER TABLE Employees
   ADD CONSTRAINT FK_Employees_Departments
   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE

GO
ALTER TABLE Departments
   DROP CONSTRAINT FK_Departments_Employees

GO
ALTER TABLE Departments
   ADD CONSTRAINT FK_Departments_Employees
   FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE NO ACTION

GO
ALTER TABLE Employees
   DROP CONSTRAINT FK_Employees_Employees

GO
ALTER TABLE Employees
   ADD CONSTRAINT FK_Employees_Employees
   FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE NO ACTION
*/

/*GO
ALTER TABLE Employees
ALTER COLUMN ManagerID int NOT NULL

GO
ALTER TABLE Departments
ALTER COLUMN ManagerID int NOT NULL
*/

DELETE 
FROM Employees
WHERE DepartmentID IN (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

ROLLBACK TRAN Delete_Sales

--31.	Start a database transaction and drop the table `EmployeesProjects`.
--	*	Now how you could restore back the lost table data?

BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN

--32.	Find how to use temporary tables in SQL Server.
--	*	Using temporary tables backup all records from `EmployeesProjects` and restore them back after dropping and re-creating the table.

--BEGIN TRAN

IF object_id('tempdb..#TEMPTABLE') IS NOT NULL
BEGIN
    DROP TABLE #TEMPTABLE
END

SELECT *
INTO #TEMPTABLE -- need to start woth '#' will delete after connection is closed
FROM EmployeesProjects

---- if exists
--INSERT
--INTO #TEMPTABLE
--SELECT * FROM EmployeesProjects

DELETE FROM EmployeesProjects

INSERT INTO EmployeesProjects
SELECT *
FROM #TEMPTABLE

--current global tables
SELECT * FROM tempdb..sysobjects 

--ROLLBACK TRAN
