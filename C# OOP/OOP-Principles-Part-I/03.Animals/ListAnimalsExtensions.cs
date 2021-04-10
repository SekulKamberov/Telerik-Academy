namespace _03.Animals
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ListAnimalsExtensions
    {
        public static IList<Animal> SortAnimals(this IList<Animal> animals)
        {
            return animals.OrderBy(animal => animal.Age).ToList();
        }

        public static double AverageAge(this IList<Animal> animals)
        {
            return animals.Average(anima => anima.Age);
        }
    }
}
