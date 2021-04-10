/*
	Create a table in SQL Server with 10 000 000 log entries (date + text). 
	Search in the table by date range. Check the speed (without caching).
*/

USE TelerikAcademy
GO

DROP TABLE LogEntries
GO

CREATE TABLE LogEntries 
(
	TimeOfLog DATETIME not null,
	Comment NVARCHAR(50) not null
)
GO

DECLARE 
    @counter INT,
    @days INT,
	@TimeOfLog DATETIME
SET @counter = 0;
SET @days = 10;
WHILE @counter <= 2000
BEGIN
	SET @counter = @counter + 1;
	SET @TimeOfLog = GETDATE() - @days;
	SET @days = @days + 10;

    INSERT INTO LogEntries VALUES(@TimeOfLog, 'Comment: ' + CAST( @counter AS NVARCHAR) )
END;
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT TimeOfLog, Comment FROM LogEntries
WHERE YEAR(TimeOfLog) < 2013 AND Comment LIKE 'Com%'
GO

-- COST 0.01364

/*
	Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
*/

CREATE INDEX Date_Index
ON LogEntries(TimeOfLog)
GO

DROP INDEX Date_Index ON LogEntries

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT TimeOfLog FROM LogEntries
WHERE YEAR(TimeOfLog) < 2013

-- COST 0.0092

/*
	Add a full text index for the text column. 
	Try to search with and without the full-text index and compare the speed.
*/

CREATE INDEX Text_Index
ON LogEntries(Comment)

DROP INDEX Text_Index ON LogEntries

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT Comment FROM LogEntries
WHERE Comment LIKE 'Com%'

-- no index: COST 0.0136
-- with index COST 0.0121
