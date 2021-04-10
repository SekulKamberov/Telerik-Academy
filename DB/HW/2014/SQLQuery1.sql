SELECT *
FROM TelerikAcademy.dbo.Employees

/* 1. Write a SQL query to find the names and salaries of the employees that take the 
	minimal salary in the company. Use a nested SELECT statement.*/
SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM TelerikAcademy.dbo.Employees
WHERE Salary = (SELECT MIN(SALARY) FROM TelerikAcademy.dbo.Employees)

/* 2. Write a SQL query to find the names and salaries of the employees that have a salary 
	that is up to 10% higher than the minimal salary for the company.*/
SELECT FirstName + ' ' + LastName AS Employee, Salary
FROM TelerikAcademy.dbo.Employees
WHERE Salary <= (SELECT MIN(SALARY)*1.1 FROM TelerikAcademy.dbo.Employees)

/* 3. Write a SQL query to find the full name, salary and department of the employees 
	that take the minimal salary in their department. 
	Use a nested SELECT statement.*/
SELECT e.FirstName + ' ' + e.LastName AS Employee, e.Salary, d.Name AS 'Department Name'
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = (SELECT MIN(Salary) FROM Employees
	WHERE DepartmentID = e.DepartmentID)
ORDER BY e.DepartmentID

/* 4. Write a SQL query to find the average salary in the department #1.*/
SELECT AVG(Salary) AS 'Department #1 Average Salary' 
FROM TelerikAcademy.dbo.Employees
WHERE DepartmentID = 1

/* 5. Write a SQL query to find the average salary  in the "Sales" department.*/
SELECT AVG(Salary) AS 'Average Salary', d.Name AS 'Department'
FROM TelerikAcademy.dbo.Employees e 
	INNER JOIN
	TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN (SELECT d.Name FROM Departments)
GROUP BY d.Name
ORDER BY d.Name DESC

/* check */
Select avg(salary)
from Employees
where DepartmentID = 3

/* 6. Write a SQL query to find the number of employees in the "Sales" department.*/
SELECT COUNT(*) 'Number of Employees in Department', d.Name AS 'Department'
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN 
	TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN (SELECT d.Name FROM Departments)
GROUP BY d.Name

/* 7. Write a SQL query to find the number of all employees that have manager.*/
SELECT COUNT(*) AS 'Number of all employees that have manager'
FROM TelerikAcademy.dbo.Employees
WHERE ManagerID IS NOT NULL

/* 8. Write a SQL query to find the number of all employees that have no manager.*/
SELECT COUNT(*) AS 'Number of all employees that have no manager'
FROM TelerikAcademy.dbo.Employees
WHERE ManagerID IS NULL

/* 9. Write a SQL query to find all departments and the average salary for each of them.*/
SELECT AVG(Salary) AS 'Average Salary', d.Name AS 'Department'
FROM TelerikAcademy.dbo.Employees e 
	INNER JOIN
	TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN (SELECT d.Name FROM Departments)
GROUP BY d.Name

/* 10. Write a SQL query to find the count of all employees in each department and for each town.*/
SELECT COUNT(*) 'Number of Employees in Department', d.Name AS 'Department', t.Name AS 'Town'
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN 
	TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
	INNER JOIN TelerikAcademy.dbo.Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN TelerikAcademy.dbo.Towns t
	ON a.TownID = t.TownID
WHERE d.Name IN (SELECT d.Name FROM Departments)
GROUP BY d.Name, t.Name
ORDER BY d.Name

/* 11. Write a SQL query to find all managers that have exactly 5 employees. 
	Display their first name and last name.*/
SELECT COUNT(e.ManagerID) AS 'Manager''s employees', 
	(m.FirstName + ' ' + m.LastName) AS Manager, m.EmployeeID AS 'Manager ID'
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName, m.EmployeeID
HAVING COUNT(e.ManagerID) = 5

/*check manager*/
select * 
from Employees
where EmployeeID = 25
/*check employees with this manager*/
select * 
from Employees
where ManagerID = 25

/* 12. Write a SQL query to find all employees along with their managers. 
	For employees that do not have manager display the value "(no manager)".*/
SELECT (e.FirstName + ' ' + e.LastName) AS Employee , ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS Manager
FROM TelerikAcademy.dbo.Employees e
	LEFT JOIN
		TelerikAcademy.dbo.Employees m
		ON e.ManagerID = m.EmployeeID

/* 13. Write a SQL query to find the names of all employees 
	whose last name is exactly 5 characters long.
	Use the built-in LEN(str) function.*/
SELECT e.FirstName + ' ' + e.LastName AS Employee
FROM TelerikAcademy.dbo.Employees e
WHERE LEN(e.LastName) = 5

/* 14. Write a SQL query to display the current date and time in 
	the following format "day.month.year hour:minutes:seconds:milliseconds". 
	Search in  Google to find how to format dates in SQL Server.*/
SELECT CONVERT(nvarchar(8), GETDATE(), 4) + ' ' + CONVERT(nvarchar(12), GETDATE(), 114) AS 'Date and Time'

/* 15. Write a SQL statement to create a table Users. Users should have username, 
	password, full name and last login time. Choose appropriate data types for the table fields. 
	Define a primary key column with a primary key constraint. 
	Define the primary key column as identity to facilitate inserting records. 
	Define unique constraint to avoid repeating usernames. 
	Define a check constraint to ensure the password is at least 5 characters long.*/
USE TelerikAcademy
GO
DROP TABLE Users
GO
CREATE TABLE Users (
	ID int IDENTITY PRIMARY KEY,
	Username nvarchar(50) UNIQUE NOT NULL,
	Password nvarchar(50) NOT NULL CHECK (LEN(password) > 4),
	FullName nvarchar(100) NOT NULL,
	LastLoginTime datetime default getdate()
)

DELETE FROM Users

INSERT INTO Users(username, password, fullname) VALUES
('qwe', '54321', 'Ime'),
('abc', '45j2e', 'Name'),
('abcde', '343d11', 'Name');
GO

/* 16. Write a SQL statement to create a view that displays the users 
	from the Users table that have been in the system today. 
	Test if the view works correctly.*/
DROP VIEW DISPLAY_USERS
GO

CREATE VIEW DISPLAY_USERS AS
SELECT * FROM Users
WHERE DAY(LastLoginTime) = DAY(GETDATE()) 
	AND MONTH(LastLoginTime) = MONTH(GETDATE()) 
	AND YEAR(LastLoginTime) = YEAR(GETDATE())
	/*AND DATEPART(hour, LastLoginTime) = DATEPART(hour,GETDATE())
	AND DATEPART(MINUTE, LastLoginTime) = DATEPART(MINUTE,GETDATE());*/
GO

SELECT *
FROM DISPLAY_USERS

/* 17. Write a SQL statement to create a table Groups. 
	Groups should have unique name (use unique constraint). 
	Define primary key and identity column.*/
CREATE TABLE GROUPS
(
	GroupID int IDENTITY PRIMARY KEY,
	Name nvarchar(50) UNIQUE NOT NULL
)
GO

/* 18. Write a SQL statement to add a column GroupID to the table Users. 
	Fill some data in this new column and as well in the Groups table. 
	Write a SQL statement to add a foreign key constraint between 
	tables Users and Groups tables.*/
ALTER TABLE Users
ADD GroupID int
GO

INSERT INTO Users(username, password, fullname, GroupID) VALUES
('1qwe', '54321', 'Ime', 3),
('2abc', '45j2e', 'Name', 2),
('3abcde', '343d11', 'Name', 1);
GO

INSERT INTO Groups(Name) VALUES
('PHP'),
('Java'),
('C#');
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)

INSERT INTO Users(username, password, fullname, GroupID) VALUES
('12Jaja', '54321', 'Ime', 3),
('23C#PHP', '45j2e', 'Name', 2),
('34JavaScript', '343d11', 'Name', 1);
GO

/* 19. Write SQL statements to insert several records in the Users and Groups tables.*/
INSERT INTO Groups(Name) VALUES
('PHP 5'),
('Java 7'),
('C# 6'),
('XML 1.0');
GO

INSERT INTO Users(username, password, fullname, GroupID) VALUES
('JavaScript2', '43234', 'Me', 3),
('PHP sucks', '34435', 'Nakov', 2),
('HQC is real', '56656', 'NotNakov', 1);
GO

/* 20. Write SQL statements to update some of the records in the Users and Groups tables.*/
UPDATE Users
SET FullName = 'I am in group 3'
WHERE GroupID = 3;

UPDATE GROUPS
SET Name = 'lqlqlq'
WHERE GroupID = 3;

/* 21. Write SQL statements to delete some of the records from the Users and Groups tables.*/
DELETE FROM Users
WHERE FullName = 'I am in group 3'

DELETE FROM Users
WHERE ID >= 20

DELETE FROM GROUPS
WHERE Name = 'Java 713'

DELETE FROM GROUPS
WHERE GROUPID > 5
GO
/* 22. Write SQL statements to insert in the Users table the names of 
	all employees from the Employees table. Combine the first and last names as a full name. 
	For username use the first letter of the first name + the last name (in lowercase). 
	Use the same for the password, and NULL for last login time.*/
INSERT INTO Users(username, password, fullname, GroupID)
SELECT SUBSTRING ( FirstName ,0 , 5 ) + LOWER(LastName), SUBSTRING ( FirstName ,0 , 5 ) + LOWER(LastName), FirstName + ' ' + LastName, 3 FROM Employees
GO

/* we take 5 letters from FirstName and 5 letters from LastName, because of the password minimum length constraint */

/* 23. Write a SQL statement that changes the password to NULL for all 
	users that have not been in the system since 10.03.2010.*/
UPDATE Users
SET Password = 'PASSWORD CHANGED'
WHERE LastLoginTime < '2014-08-23 17:14:09.633'

/*
	password cant set to NULL, so i just change it to some random text
*/

/* 24. Write a SQL statement that deletes all users without passwords (NULL password).*/
DELETE FROM Users
WHERE Password = 'PASSWORD CHANGED'

/*
the corect statement should be

DELETE FROM Users
WHERE Password IS NULL

*/

/* 25. Write a SQL query to display the average employee salary by department and job title.*/
SELECT AVG(Salary), d.Name AS Department, JobTitle
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN 
	TelerikAcademy.dbo.Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, JobTitle
ORDER BY Department

/*check*/
SELECT AVG(Salary) AS 'Control Specialist''s Salary' FROM Employees WHERE DepartmentID = 12 AND JobTitle = 'Control Specialist'

/* 26. Write a SQL query to display the minimal employee salary by 
	department and job title along with the name of some of the employees that take it.*/
SELECT d.Name AS Department, JobTitle, Salary AS 'Min Salary', FirstName + ' ' + LastName AS Employee
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT Min(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY d.Name

/*most of the employees show, because most of them have min salary for the their job title, 
	if you reduce salary to some of them the list will reduce witch prooves that it works */

/*	check */
SELECT Salary, JobTitle FROM Employees WHERE DepartmentID = 1


/* 27. Write a SQL query to display the town where maximal number of employees work.*/
SELECT COUNT(*) 'Number of Employees in Town', t.Name AS 'Town'
FROM TelerikAcademy.dbo.Employees e
	INNER JOIN TelerikAcademy.dbo.Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN TelerikAcademy.dbo.Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name

/* 28. Write a SQL query to display the number of managers from each town.*/
SELECT COUNT(TownName) AS [Managers from town], TownName AS Town 
FROM (SELECT t.Name AS TownName
		FROM Employees e
			INNER JOIN 
			Addresses a
			ON e.AddressID = a.AddressID
			INNER JOIN 
			Towns t
			ON a.TownID = t.TownID
		WHERE e.EmployeeID IN (SELECT ManagerID FROM Employees
			GROUP BY ManagerID
			HAVING ManagerID IS NOT NULL)) TownName
GROUP BY TownName

/* 29. Write a SQL to create table WorkHours to store work reports for 
	each employee (employee id, date, task, hours, comments). 
	Don't forget to define  identity, primary key and appropriate foreign key. 
	Issue few SQL statements to insert, update and delete of some data in the table.
	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
	For each change keep the old record data, the new record data 
	and the command (insert / update / delete).*/
CREATE TABLE WorkHours
(
	WorkHoursID int IDENTITY PRIMARY KEY,
	EmployeeID int not null,
	CONSTRAINT FK_EmpID FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
	dateWorked date,
	task nvarchar(50),
	hours int,
	comments nvarchar(50)
)

CREATE TABLE WorkHoursLogs
(
	WorkHoursLogsID INT IDENTITY PRIMARY KEY
	OldWorkHoursID int,
	OldEmployeeID int,
	OldDateWorked date,
	OldTask nvarchar(50),
	OldHours int,
	OldComments nvarchar(50),
	NewWorkHoursID int,
	NewEmployeeID int,
	NewDateWorked date,
	NewTask nvarchar(50),
	NewHours int,
	NewComments nvarchar(50),
	Command nvarchar(50)
)

INSERT INTO WorkHours(EmployeeID, dateWorked) VALUES
(3, getdate()), 
(7, getdate()), 
(9, getdate()), 
(1, getdate())

UPDATE WorkHours
SET comments = 'COMMENT'
WHERE EmployeeID > 5

DELETE FROM WorkHours
WHERE EmployeeID = 9

/* 30. Start a database transaction, delete all employees from the 'Sales' department 
	along with all dependent records from the pother tables. At the end rollback the transaction.*/
BEGIN TRAN
	DELETE FROM Employees
	WHERE DepartmentID IN 
		(SELECT DepartmentID 
		FROM Departments
		WHERE Name = 'SALES')
ROLLBACK TRAN

/* 31. Start a database transaction and drop the table EmployeesProjects. 
	Now how you could restore back the lost table data?*/
BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN

/* 32. Find how to use temporary tables in SQL Server. 
	Using temporary tables backup all records from EmployeesProjects 
	and restore them back after dropping and re-creating the table.*/



/*unique managers*/
SELECT *
FROM Employees e
WHERE EmployeeID IN (SELECT m.ManagerID FROM Employees m where EmployeeID = m.EmployeeID)

/*unique managers ID*/
SELECT ManagerID FROM Employees
GROUP BY ManagerID
HAVING ManagerID IS NOT NULL

/*towns of all managers*/
SELECT t.Name
FROM Employees e
	INNER JOIN 
	Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN 
	Towns t
	ON a.TownID = t.TownID
WHERE e.EmployeeID IN (SELECT ManagerID FROM Employees
	GROUP BY ManagerID
	HAVING ManagerID IS NOT NULL)
	
SELECT DepartmentID, SUM(Salary) as SalariesCost
FROM Employees
GROUP BY DepartmentID


/*28*/
SELECT COUNT(t.Name) AS 'Number of managers from town', t.Name AS Town
	FROM Employees e
		JOIN 
		Addresses a
		ON e.AddressID = a.AddressID
		JOIN 
		Towns t
		ON a.TownID = t.TownID
	WHERE e.EmployeeID IN (SELECT ManagerID FROM Employees
		GROUP BY ManagerID
		HAVING ManagerID IS NOT NULL)
GROUP BY t.Name