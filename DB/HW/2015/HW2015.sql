CREATE DATABASE Performance
GO

USE Performance

CREATE TABLE Logs
(
	ID int not null identity,
	TimeOfLog datetime not null,
	Info nvarchar(50) not null,
	CONSTRAINT PK_Logs PRIMARY KEY (ID)
)
GO

INSERT INTO Logs(TimeOfLog, Info)
VALUES (GETDATE(), 'Text 0'),
(GETDATE(), 'Text 1'),
(GETDATE(), 'Text 2'),
(GETDATE(), 'Text 3'),
(GETDATE(), 'Text 4'),
(GETDATE(), 'Text 5'),
(GETDATE(), 'Text 6'),
(GETDATE(), 'Text 7'),
(GETDATE(), 'Text 8'),
(GETDATE(), 'Text 9')
GO

DECLARE
	@counter int = 1
BEGIN
	WHILE(SELECT COUNT(*) FROM Logs) < 1000000
	BEGIN
		INSERT INTO Logs(TimeOfLog, Info)
		SELECT DATEADD(day, @counter, TimeOfLog), Info FROM Logs
		SET @counter = @counter + 1
	END
END
GO

--for 1310720 records
SELECT COUNT(*) FROM Logs
SELECT TOP(1000) * FROM Logs

CHECKPOINT; DBCC DROPCLEANBUFFERS;
-- NO INDEX 21 secconds for 1163470 rows found
SELECT * FROM Logs WHERE TimeOfLog > DATEADD(day, 50, GETDATE())

CREATE INDEX IDX_Logs_Time
ON Logs(TimeOfLog)
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS;
-- WITH INDEX only 19 seconds
SELECT * FROM Logs WHERE TimeOfLog > DATEADD(day, 50, GETDATE())


CHECKPOINT; DBCC DROPCLEANBUFFERS;
-- 7 seconds 131072 records
SELECT COUNT(*) FROM Logs WHERE Info LIKE '%Text%'

--DROP FULLTEXT INDEX ON Logs
--DROP FULLTEXT CATALOG LogsFullTextCatalog

CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(Info)
KEY INDEX PK_Logs
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS;
-- 4 seconds
SELECT COUNT(*) FROM Logs WHERE CONTAINS(Info, 'Text')


-- NEED ENTERPRISE EDITION

USE Performance;
GO
-- Adds four new filegroups to the AdventureWorks2012 database
ALTER DATABASE Performance
ADD FILEGROUP partition1;
GO
ALTER DATABASE Performance
ADD FILEGROUP partition2;
GO

-- Adds one file for each filegroup.
ALTER DATABASE Performance 
ADD FILE 
(
    NAME = partition1,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\partition1.ndf',
    SIZE = 5MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 5MB
)
TO FILEGROUP partition1;
ALTER DATABASE Performance 
ADD FILE 
(
    NAME = partition2,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\partition2.ndf',
    SIZE = 5MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 5MB
)
TO FILEGROUP partition2;
GO
-- Creates a partition function called myRangePF1 that will partition a table into four partitions
CREATE PARTITION FUNCTION myRangePF1 (datetime)
    AS RANGE LEFT FOR VALUES (DATEADD(day, 20, GETDATE());
GO
-- Creates a partition scheme called myRangePS1 that applies myRangePF1 to the four filegroups created above
CREATE PARTITION SCHEME myRangePS1
    AS PARTITION myRangePF1
    TO (partition1, partition2) ;
GO
-- Creates a partitioned table called PartitionTable that uses myRangePS1 to partition col1
CREATE TABLE PartitionTable (col1 int PRIMARY KEY, col2 char(10))
    ON myRangePS1 (col1) ;
GO