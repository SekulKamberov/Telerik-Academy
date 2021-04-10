--## 06. Transact SQL
--### _Homework_

--01.	Create a database with two tables: `Persons(Id(PK), FirstName, LastName, SSN)` and `Accounts(Id(PK), PersonId(FK), Balance)`.
--	*	Insert few records for testing.
--	*	Write a stored procedure that selects the full names of all persons.

BEGIN TRAN

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES('Pesho', 'Peshov', '12345'),
('Gosho', 'Goshov', '12346'),
('Pesho', 'Peshov', '12347')
GO

INSERT INTO Accounts(PersonId, Balance)
VALUES(1, 10),
(2, 100),
(3, 1000)
GO

CREATE PROCEDURE proc_persons_fullnames
AS
SELECT FirstName + ' ' + LastName AS FullName
FROM Persons
GO

CREATE PROCEDURE proc_persons_SSN
AS
SELECT FirstName + ' ' + LastName AS FullName, SSN
FROM Persons
GO

EXEC proc_persons_fullnames

EXEC proc_persons_SSN

COMMIT TRAN
--ROLLBACK TRAN
GO
--02.	Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.

BEGIN TRAN

--DROP PROC proc_rich_customers
CREATE PROCEDURE proc_rich_customers (@minBalance money = 0)
AS
BEGIN
	SELECT p.Id, FirstName, LastName, SSN
	FROM Persons p INNER JOIN Accounts a
		ON p.Id = a.PersonId
	WHERE a.Balance > @minBalance
END

EXEC proc_rich_customers @minBalance = 100

ROLLBACK TRAN
GO
--03.	Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--	*	It should calculate and return the new sum.
--	*	Write a `SELECT` to test whether the function works as expected.

CREATE FUNCTION ufn_CalculateInterest(@sum money, @yearlyInterestRate decimal, @months int)
  RETURNS money
AS
BEGIN
	DECLARE @newSum money
	IF (@sum <= 0)
		RETURN 0
	ELSE IF (@yearlyInterestRate <= 0 OR @months <= 0)
		RETURN @sum
	ELSE
		SET @newSum = @sum + @sum * ( @yearlyInterestRate / 100 ) * @months
		RETURN @newSum
END
GO

SELECT dbo.ufn_CalculateInterest (1000, 6, 5) AS [New Ballance]
--04.	Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--	*	It should take the `AccountId` and the interest rate as parameters.

CREATE PROC up_calculate_one_month_interest
(@accountId int,
@interestRate int,
@months int = 1)
AS
BEGIN
	SELECT dbo.ufn_CalculateInterest (a.Balance, @interestRate, @months) AS [Customer Interest]
	FROM Accounts a
	WHERE a.Id = @accountId
END
GO

EXEC dbo.up_calculate_one_month_interest @accountId = 2, @interestRate = 10, @months = 1

--SELECT dbo.ufn_CalculateInterest (100, 10, 1) AS [Customer Interest]
--FROM Accounts
--WHERE Id =1

--05.	Add two more stored procedures `WithdrawMoney(AccountId, money)` and `DepositMoney(AccountId, money)` that operate in transactions.

CREATE PROC up_withdraw_money
(@accountId int,
@money money)
AS
BEGIN
	DECLARE @balance money

	BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance - @money, @balance = Balance - @money
	WHERE Id = @accountId

	IF @balance < 0
		ROLLBACK TRAN
	ELSE
		COMMIT TRAN

	SELECT p.FirstName + ' ' + p.LastName, a.Balance
	FROM Accounts a INNER JOIN Persons p
		ON a.PersonId = p.Id
	WHERE a.Id = @accountId
END
GO

EXEC dbo.up_withdraw_money 1, 10
GO

CREATE PROC up_deposit_money
(@accountId int,
@money money)
AS
BEGIN
	DECLARE @balance money

	BEGIN TRAN
	UPDATE Accounts
	SET Balance = Balance + @money, @balance = Balance + @money
	WHERE Id = @accountId

	IF @balance > 10000000
		ROLLBACK TRAN
	ELSE
		COMMIT TRAN

	SELECT p.FirstName + ' ' + p.LastName, a.Balance
	FROM Accounts a INNER JOIN Persons p
		ON a.PersonId = p.Id
	WHERE a.Id = @accountId
END
GO

EXEC dbo.up_deposit_money 1, 5000000
GO

--06.	Create another table – `Logs(LogID, AccountID, OldSum, NewSum)`.
--	*	Add a trigger to the `Accounts` table that enters a new entry into the `Logs` table every time the sum on an account changes.

CREATE TRIGGER tr_AccountUpdate ON Accounts AFTER UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM INSERTED i INNER JOIN DELETED d 
		ON i.Id = d.Id
GO

UPDATE Accounts
SET Balance = Balance + 10
WHERE Id = 1
GO

SELECT * FROM Logs
GO

--07.	Define a function in the database `TelerikAcademy` that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters.
--	*	_Example_: '`oistmiahf`' will return '`Sofia`', '`Smith`', … but not '`Rob`' and '`Guy`'.

--DECLARE 
--	@str1 nvarchar(50),
--	@len int,
--	@c nvarchar(50),
--	@left nvarchar(50),
--	@clen int
--	BEGIN
--	SET @str1 = 'abcdef'
--	SET @len = LEN(@str1)
--	SET @c = SUBSTRING(@str1, 1, 1)
--	SET @clen = LEN(@c)
--	SET @left = SUBSTRING(@str1, 2, @len - 1)
--		SELECT @str1, @len, @c, @clen, @left

--	END
--GO

--DECLARE
--	@firstChar char(1) = 'c',
--	@string nvarchar(50) = 'abcdef',
--	@stringLength int,
--	@firstCharIndex int,
--	@stringLeft nvarchar(50)
--	BEGIN
--		SET @stringLength = LEN(@string)
--		SET @firstCharIndex = CHARINDEX(@firstChar, @string)
--		IF(@firstCharIndex = 1)
--			SET @stringLeft = SUBSTRING(@string, 2, @stringLength - 1)
--		ELSE
--			SELECT SUBSTRING(@string, 1, @firstCharIndex - 1)
--			SELECT SUBSTRING(@string, @firstCharIndex + 1, @stringLength)
--			SET @stringLeft = SUBSTRING(@string, 1, @firstCharIndex - 1) + SUBSTRING(@string, @firstCharIndex + 1, @stringLength)
--		SELECT @firstCharIndex
--		SELECT @stringLeft
--	END
--GO

USE TelerikAcademy
GO

--ALTER FUNCTION dbo.uf_check_if_string_containes_string(@string nvarchar(50), @value nvarchar(50))
CREATE FUNCTION dbo.uf_check_if_string_containes_string(@string nvarchar(50), @value nvarchar(50))
RETURNS BIT
AS 
BEGIN
	IF(LEN(@value) = 0)
		RETURN 1
	ELSE IF(LEN(@value) = 1)
		BEGIN
			IF (@value LIKE ('%[' + @string + ']%'))
				RETURN 1
			ELSE 
				RETURN 0
		END
	ELSE	
		DECLARE -- 'somename'
			@firstChar char(1) = SUBSTRING(@value, 1, 1),
			@valueLength int = LEN(@value),
			@stringLength int,
			@firstCharIndex int,
			@stringLeft nvarchar(50),
			@valueLeft nvarchar(50),
			@temp nvarchar(52) = '%[' + @string + ']%'
		BEGIN
			IF (@firstChar LIKE @temp)
				BEGIN
					SET @valueLeft = SUBSTRING(@value, 2, @valueLength - 1)
					SET @stringLength = LEN(@string)
					SET @firstCharIndex = CHARINDEX(@firstChar, @string)
					IF(@firstCharIndex = 1)
						BEGIN
							SET @stringLeft = SUBSTRING(@string, 2, @stringLength - 1)
							RETURN dbo.uf_check_if_string_containes_string(@stringLeft, @valueLeft)
						END
					ELSE
						BEGIN
							SET @stringLeft = SUBSTRING(@string, 1, @firstCharIndex - 1) + SUBSTRING(@string, @firstCharIndex + 1, @stringLength)
							RETURN dbo.uf_check_if_string_containes_string(@stringLeft, @valueLeft)
						END
				END
		END
		RETURN 0
END
GO

--ALTER FUNCTION dbo.uf_checkForSubstring(@string nvarchar(50), @value nvarchar(50))
CREATE FUNCTION dbo.uf_checkForSubstring(@string nvarchar(50), @value nvarchar(50))
RETURNS BIT
AS 
BEGIN
	IF(LEN(@value) = 0)
		RETURN 1
	IF (LEN(@string) = 0)
		RETURN 0
	IF (LEN(@string) < LEN(@value))
		RETURN 0
	RETURN dbo.uf_check_if_string_containes_string(@string, @value)
END
GO

--ALTER FUNCTION uf_FirstMiddleLastTownNameComprised(@content nvarchar(50))
CREATE FUNCTION uf_FirstMiddleLastTownNameComprised(@content nvarchar(50))
  RETURNS @CoincidentsResult TABLE  (Word nvarchar(50) NOT NULL)
AS
BEGIN
	INSERT INTO @CoincidentsResult
	SELECT FirstName AS Result
	FROM TelerikAcademy.dbo.Employees
	WHERE FirstName IS NOT NULL AND dbo.uf_checkForSubstring(@content, FirstName) = 1
	UNION ALL
	SELECT MiddleName
	FROM TelerikAcademy.dbo.Employees
	WHERE MiddleName IS NOT NULL AND dbo.uf_checkForSubstring(@content, MiddleName) = 1
	UNION ALL
	SELECT LastName
	FROM TelerikAcademy.dbo.Employees
	WHERE LastName IS NOT NULL AND dbo.uf_checkForSubstring(@content, LastName) = 1
	UNION ALL
	SELECT Name
	FROM TelerikAcademy.dbo.Towns
	WHERE Name IS NOT NULL AND dbo.uf_checkForSubstring(@content, Name) = 1
	RETURN
END
GO

SELECT * FROM uf_FirstMiddleLastTownNameComprised('oistmiahf')
GO
--08.	Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.

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

--09.	*Write a T-SQL script that shows for each town a list of all employees that live in it.
--	*	_Sample output_:	
--```sql
--Sofia -> Martin Kulov, George Denchev
--Ottawa -> Jose Saraiva
--…
--```

DECLARE cursor_emp_from_same_town CURSOR FOR
SELECT e.FirstName + ' ' + e.LastName AS Employee, t.Name AS Town FROM TelerikAcademy.dbo.Employees e
	JOIN TelerikAcademy.dbo.Addresses a
	ON e.AddressID = a.AddressID
	JOIN TelerikAcademy.dbo.Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name, e.FirstName + ' ' + e.LastName
OPEN cursor_emp_from_same_town
DECLARE @Name nvarchar(50), @Town nvarchar(50), @OldTown nvarchar(50), @list nvarchar(MAX)
FETCH NEXT FROM cursor_emp_from_same_town INTO @Name, @Town
SET @OldTown = @Town
SET @list = @Town + ' -> '
WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @OldTown <> @Town
			BEGIN
				PRINT @list
				SET @OldTown = @Town
				SET @list = @Town + ' -> ' + @Name
			END
		ELSE 
			BEGIN
				SET @list = @list + @Name + ', '
			END
		FETCH NEXT FROM cursor_emp_from_same_town 
		INTO @Name, @Town
	END
  PRINT @list
CLOSE cursor_emp_from_same_town
DEALLOCATE cursor_emp_from_same_town

GO

--10.	Define a .NET aggregate function `StrConcat` that takes as input a sequence of strings and return a single string that consists of the input strings separated by '`,`'.
--	*	For example the following SQL statement should return a single string:

--```sql
--SELECT StrConcat(FirstName + ' ' + LastName)
--FROM Employees
--```

--ALTER FUNCTION StrConcat(@firstString nvarchar(50), @secondString nvarchar(50))
CREATE FUNCTION StrConcat(@firstString nvarchar(50), @secondString nvarchar(50))
RETURNS nvarchar(101)
AS
BEGIN
	DECLARE @result nvarchar(101)
	SET @result = @firstString + ' ' + @secondString
	RETURN @result
END
GO

SELECT dbo.StrConcat(FirstName, LastName) AS Employee
FROM Employees
GO