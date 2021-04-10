USE PetStore
GO

SELECT s.Name, Count(sp.SpecieId) AS [Products Available]
FROM Species s INNER JOIN SpeciesProducts sp
ON s.Id = sp.SpecieId
GROUP BY s.Name
ORDER BY [Products Available] ASC