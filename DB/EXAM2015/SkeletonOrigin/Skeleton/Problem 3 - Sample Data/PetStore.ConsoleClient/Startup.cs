namespace PetStore.ConsoleClient
{
    using System;

    using PetStore.Importer;

    public class Startup
    {
        public static void Main()
        {
            Importer.ImportCountries(20);
            Importer.ImportSpecies(100);
            Importer.ImportPets(5000);
            Importer.ImportCategories(50);
            Importer.ImportProducts(20000);
        }
    }
}
