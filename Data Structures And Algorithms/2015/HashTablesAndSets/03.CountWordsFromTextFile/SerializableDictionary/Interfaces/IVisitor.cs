namespace _03.CountWordsFromTextFile.SerializableDictionary.Interfaces
{
    public interface IVisitor<T>
    {
        void Visit(ILibraryItem libraryItem);
    }
}
