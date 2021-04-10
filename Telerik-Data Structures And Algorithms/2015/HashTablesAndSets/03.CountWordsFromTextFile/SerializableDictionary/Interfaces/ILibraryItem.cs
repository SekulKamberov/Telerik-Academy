namespace _03.CountWordsFromTextFile.SerializableDictionary.Interfaces
{
    public interface ILibraryItem
    {
        // T Id { get; set; }
        string FirstName { get; set; }

        string LastName { get; set; }

        PhoneType PhoneType { get; set; }

        string PhoneNumber { get; set; }

        // void Accept(IVisitor<T> visitor);
    }
}
