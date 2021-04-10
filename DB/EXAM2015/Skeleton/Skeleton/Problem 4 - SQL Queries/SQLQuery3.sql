USE PetStore
GO

SELECT TOP(5) p.Price, p.Breed, DATEPART(yyyy, p.DateOfBirth) AS [BirthYear]
FROM Pets p
WHERE DATEPART(yyyy, p.DateOfBirth) >= 2012
ORDER BY p.Price DESC

