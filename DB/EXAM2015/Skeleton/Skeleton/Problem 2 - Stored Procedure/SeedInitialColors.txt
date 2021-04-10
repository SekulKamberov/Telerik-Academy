USE PetStore
GO

CREATE PROC pr_seedColors
AS
	BEGIN
	DECLARE @colorsCount int
	SET @colorsCount = (SELECT COUNT(*) FROM Colors)
	IF(@colorsCount = 0)
		BEGIN
			INSERT INTO Colors(ColorType)
			VALUES('black'),
			('white'),
			('red'),
			('mixed')
		END

	END


EXEC pr_seedColors