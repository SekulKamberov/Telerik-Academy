namespace RandomGenerator
{
    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithrandomLength(int min, int max);

        string GetRandomStringOfNumbers(int length);
    }
}
