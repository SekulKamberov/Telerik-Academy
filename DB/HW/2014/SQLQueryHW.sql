/* 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
	 Insert few records for testing. Write a stored procedure that selects the full names of all persons.
*/

CREATE DATABASE PERSONS_ACCOUNTS
GO

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) DEFAULT('Svetlio'),
	LastName NVARCHAR(50) DEFAULT('Vitkov'),
	SSN NVARCHAR(10)
)
GO

INSERT INTO Persons VALUES
('Ivan', 'Ivanov', '555-34-32'),
('Ivan', 'Todorov', '525-34-32'),
('Mitko', 'Ivanov', '155-34-32'),
('Dragan', 'Ivanov', '555-34-32')
GO

CREATE TABLE ACCOUNTS
(
	AccountID INT IDENTITY PRIMARY KEY,
	PersonID INT,
	CONSTRAINT FK_PERSONS_ACCOUNTS FOREIGN KEY(PersonID) REFERENCES Persons(PersonID),
	Balance INT DEFAULT (0)
)
GO

INSERT INTO ACCOUNTS VALUES
(1, 200),
(2, 100),
(3, 1200),
(4, 2000)
GO

CREATE PROCEDURE dbo.usp_SelectFullNames
AS
	SELECT FirstName + ' ' + LastName AS 'Full Name'
	FROM PERSONS_ACCOUNTS.dbo.Persons
GO

EXEC usp_SelectFullNames
GO

/* 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money 
	in their accounts than the supplied number.*/

CREATE PROC dbo.usp_ListOfRitchPeople (@MinBalance INT = 0)
AS
SELECT p.*, a.AccountID, a.Balance
FROM PERSONS_ACCOUNTS.dbo.Persons p
	JOIN
	PERSONS_ACCOUNTS.dbo.ACCOUNTS a
	ON p.PersonID = a.PersonID
WHERE a.Balance > @MinBalance
GO

EXEC usp_ListOfRitchPeople
GO
EXEC usp_ListOfRitchPeople 500
GO

/* 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
	It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
*/

CREATE FUNCTION ufn_SumEarned (@sumOfMoney MONEY, @yearlyInterest INT, @months INT)
	RETURNS MONEY
AS
BEGIN
	RETURN @sumOfMoney + (@sumOfMoney * @yearlyInterest/100 * @months / 12)
END
GO

SELECT dbo.ufn_SumEarned(1000, 5, 6) AS [Function Result], 1000 + (1000 * 5/100 * 6 / 12) AS [Test Result]
GO

/* 04. Create a stored procedure that uses the function from the previous example to give an interest to a person's 
	for one month. It should take the AccountId and the interest rate as parameters.*/

CREATE PROC dbo.usp_PersonInterestForOneMonth (@AccountID INT , @InterestRate INT)
AS
SELECT p.FirstName + ' ' + p.LastName AS Person, dbo.ufn_SumEarned(Balance, @InterestRate, 1) - Balance AS [Interest For 1 month($USD)]
FROM ACCOUNTS a 
	JOIN Persons p
	ON a.PersonID = p.PersonID
WHERE AccountID = @AccountID
GO

EXEC dbo.usp_PersonInterestForOneMonth 4, 5
GO

/* 05. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) 
	that operate in transactions. */
CREATE PROCEDURE dbo.usp_WithdrawMoney(@AccountID INT, @Amount money)
AS
BEGIN TRAN
IF ((SELECT Balance FROM ACCOUNTS WHERE AccountID = @AccountID) < @Amount) 
	BEGIN	
		ROLLBACK TRAN
	END
ELSE
	BEGIN
		UPDATE ACCOUNTS
		SET Balance = Balance - @Amount
		WHERE AccountID = @AccountID
		COMMIT TRAN
	END
GO

EXEC dbo.usp_WithdrawMoney 2, 200
GO

CREATE PROCEDURE dbo.usp_DepositMoney(@AccountID INT, @Amount money)
AS
BEGIN TRAN
IF (@Amount < 0) 
	BEGIN	
		ROLLBACK TRAN
	END
ELSE
	BEGIN
		UPDATE ACCOUNTS
		SET Balance = Balance + @Amount
		WHERE AccountID = @AccountID
		COMMIT TRAN
	END
GO

EXEC dbo.usp_DepositMoney 2, 1000
GO

/* 06. Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
	Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
*/
CREATE TABLE Logs
(
	LogID INT IDENTITY PRIMARY KEY,
	AccountID INT,
	CONSTRAINT FK_LOGS_ACCOUNTS FOREIGN KEY(AccountID) REFERENCES ACCOUNTS(AccountID),
	OldSum INT,
	NewSum INT 
)
GO

ALTER TRIGGER tr_InsertBalanceChangeLogs ON ACCOUNTS FOR UPDATE
AS
BEGIN
	INSERT INTO Logs VALUES((SELECT AccountID FROM DELETED), (SELECT Balance FROM DELETED), (SELECT Balance FROM INSERTED))
END
GO

EXEC dbo.usp_DepositMoney 2, 1000
GO
EXEC dbo.usp_WithdrawMoney 2, 200
GO
EXEC dbo.usp_WithdrawMoney 2, 2000
GO

/* 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
	 and all town's names that are comprised of given set of letters. 
	 Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'. */

/* 8. Using database cursor write a T-SQL script that scans all employees and their addresses 
	and prints all pairs of employees that live in the same town.*/
DECLARE cursor_emp_from_same_town CURSOR FOR
SELECT e.FirstName + ' ' + e.LastName AS Employee, t.Name AS Town FROM TelerikAcademy.dbo.Employees e
	JOIN TelerikAcademy.dbo.Addresses a
	ON e.AddressID = a.AddressID
	JOIN TelerikAcademy.dbo.Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name, e.FirstName + ' ' + e.LastName

OPEN cursor_emp_from_same_town
DECLARE @Name nvarchar(50), @Town nvarchar(50), @OldTown nvarchar(50)
FETCH NEXT FROM cursor_emp_from_same_town INTO @Name, @Town
SET @OldTown = @Town
IF @@FETCH_STATUS = 0
BEGIN 
	PRINT '===== Town - ' + @Town + ' ====='
END
WHILE @@FETCH_STATUS = 0
  BEGIN
	IF @OldTown <> @Town
	BEGIN 
		PRINT '===== Town - ' + @Town + ' ====='
	END
    PRINT @Name
	SET @OldTown = @Town
    FETCH NEXT FROM cursor_emp_from_same_town 
    INTO @Name, @Town
  END

CLOSE cursor_emp_from_same_town
DEALLOCATE cursor_emp_from_same_town
GO

/* 9. * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
	Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
	Ottawa -> Jose Saraiva
*/

/* 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings 
	and return a single string that consists of the input strings separated by ','. 
	For example the following SQL statement should return a single string: 
	SELECT StrConcat(FirstName + ' ' + LastName)
	FROM Employees
*/