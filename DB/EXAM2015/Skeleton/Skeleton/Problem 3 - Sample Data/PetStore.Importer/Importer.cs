namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PetStore.Data;

    public static class Importer
    {
        private static readonly Random RandomInstance = new Random();

        public static void ImportCountries(int count)
        {
            Console.WriteLine("ImportCountries");
            var countriesNames = new HashSet<string>();

            do
            {
                countriesNames.Add(RandomGenerator.RandomString(5, 50));
            }
            while (countriesNames.Count < count);

            var data = new PetStoreEntities();
            var counter = 0;
            foreach (var coutry in countriesNames)
            {
                var newCountry = new Country()
                {
                    Name = coutry
                };

                data.Countries.Add(newCountry);
                counter++;

                if (counter % 100 == 0)
                {
                    data.SaveChanges();
                    data.Dispose();
                    data = new PetStoreEntities();
                    Console.Write(".");
                }
            }

            data.SaveChanges();
            data.Dispose();
        }

        public static void ImportSpecies(int count)
        {
            Console.WriteLine("ImportSpecies");
            var data = new PetStoreEntities();

            var coutriesIds = data.Countries.Select(c => c.Id).ToList();
            var countriesCount = coutriesIds.Count;
            
            // generate 100 ids list
            var countriesRandomCountryIds = new List<int>();

            // add the unique 20
            countriesRandomCountryIds.AddRange(coutriesIds);

            // add the rest to count
            for (int i = 0; i < count - countriesCount; i++)
            {
                var randomCountryIndex = RandomInstance.Next(0, countriesCount);
                var randomId = coutriesIds[randomCountryIndex];
                countriesRandomCountryIds.Add(randomId);
            }

            // randomize
            var shuffledCountryIds = countriesRandomCountryIds.OrderBy(g => Guid.NewGuid()).ToList();

            var speciesNames = new HashSet<string>();
            do
            {
                speciesNames.Add(RandomGenerator.RandomString(5, 50));
            }
            while (speciesNames.Count < count);

            var counter = 0;
            foreach (var specie in speciesNames)
            {
                var id = shuffledCountryIds[0];
                shuffledCountryIds.RemoveAt(0);
                var newSpecie = new Species()
                {
                    Name = specie,
                    CountryId = id
                };

                data.Species.Add(newSpecie);
                counter++;

                if (counter % 100 == 0)
                {
                    data.SaveChanges();
                    data.Dispose();
                    data = new PetStoreEntities();
                    Console.Write(".");
                }
            }

            data.SaveChanges();
            data.Dispose();
        }

        public static void ImportPets(int count)
        {
            Console.WriteLine("ImportPets");
            var data = new PetStoreEntities();

            var speciesIds = data.Species.Select(c => c.Id).ToList();
            var speciesCount = speciesIds.Count;

            // generate 5000 ids list
            var speciesRandomIds = new List<int>();

            // add the unique
            speciesRandomIds.AddRange(speciesIds);

            // add the rest to count
            for (int i = 0; i < count - speciesCount; i++)
            {
                var randomSpecieIndex = RandomInstance.Next(0, speciesCount);
                var randomId = speciesIds[randomSpecieIndex];
                speciesRandomIds.Add(randomId);
            }

            // randomize
            var shuffledSpeciesIds = speciesRandomIds.OrderBy(g => Guid.NewGuid()).ToList();

            var colorsId = data.Colors.Select(c => c.Id).ToList();
            var colorsCount = colorsId.Count;

            var counter = 0;
            foreach (var specieId in shuffledSpeciesIds)
            {
                var randomPrice = (decimal)((RandomInstance.NextDouble() * (2500 - 5)) + 5);
                var randomColorIndex = RandomInstance.Next(0, colorsCount);
                var randomColorId = colorsId[randomColorIndex];
                var randomDate = RandomGenerator.RandomDate(new DateTime(2010, 1, 1), DateTime.Now.AddDays(-60));
                var randomBreed = RandomGenerator.RandomString(0, 30);

                var newPet = new Pet()
                {
                    SpecieId = specieId,
                    DateOfBirth = randomDate,
                    Price = randomPrice,
                    ColorId = randomColorId,
                    Breed = randomBreed
                };

                data.Pets.Add(newPet);
                counter++;

                if (counter % 100 == 0)
                {
                    data.SaveChanges();
                    data.Dispose();
                    data = new PetStoreEntities();
                    Console.Write(".");
                }
            }

            data.SaveChanges();
            data.Dispose();
        }

        public static void ImportCategories(int count)
        {
            Console.WriteLine("ImportCategories");
            var categoriesNames = new HashSet<string>();

            do
            {
                categoriesNames.Add(RandomGenerator.RandomString(5, 20));
            }
            while (categoriesNames.Count < count);

            var data = new PetStoreEntities();
            var counter = 0;
            foreach (var category in categoriesNames)
            {
                var newcategory = new Category()
                {
                    Name = category
                };

                data.Categories.Add(newcategory);
                counter++;

                if (counter % 100 == 0)
                {
                    data.SaveChanges();
                    data.Dispose();
                    data = new PetStoreEntities();
                    Console.Write(".");
                }
            }

            data.SaveChanges();
            data.Dispose();
        }

        public static void ImportProducts(int count)
        {
            Console.WriteLine("ImportProducts");
            var data = new PetStoreEntities();

            var categoriesIds = data.Categories.Select(c => c.Id).ToList();
            var categoriesCount = categoriesIds.Count;

            // generate 20000 ids list
            var categoriesRandomCountryIds = new List<int>();

            // add the unique 50
            categoriesRandomCountryIds.AddRange(categoriesIds);

            // add the rest to count
            for (int i = 0; i < count - categoriesCount; i++)
            {
                var randomCategoriesIndex = RandomInstance.Next(0, categoriesCount);
                var randomId = categoriesIds[randomCategoriesIndex];
                categoriesRandomCountryIds.Add(randomId);
            }

            // randomize
            var shuffledCategoryIds = categoriesRandomCountryIds.OrderBy(g => Guid.NewGuid()).ToList();

            var productsNames = new HashSet<string>();
            do
            {
                productsNames.Add(RandomGenerator.RandomString(5, 25));
            }
            while (productsNames.Count < count);
            var counter = 0;
            foreach (var product in productsNames)
            {
                var id = shuffledCategoryIds[0];
                shuffledCategoryIds.RemoveAt(0);
                var newProduct = new PetProduct()
                {
                    Name = product,
                    CategoryId = id,
                    Price = (decimal)((RandomInstance.NextDouble() * (1000 - 10)) + 10)
                };

                data.PetProducts.Add(newProduct);
                counter++;

                // add species match here
                var speciesCount = RandomInstance.Next(2, 11);
                var speciesToAdd = new HashSet<Species>();
                var species = data.Species.OrderBy(s => Guid.NewGuid()).Take(speciesCount).ToList();
                while (speciesToAdd.Count != speciesCount)
                {
                    var specieIdRandomIndex = RandomInstance.Next(0, species.Count);
                    var randomSpecie = species[specieIdRandomIndex];
                    speciesToAdd.Add(randomSpecie);
                }

                foreach (var specie in speciesToAdd)
                {
                    newProduct.Species.Add(specie);
                }

                if (counter % 10 == 0)
                {
                    data.SaveChanges();
                    data.Dispose();
                    data = new PetStoreEntities();
                    Console.Write(".");
                }
            }

            data.SaveChanges();
            data.Dispose();
        }
    }
}
