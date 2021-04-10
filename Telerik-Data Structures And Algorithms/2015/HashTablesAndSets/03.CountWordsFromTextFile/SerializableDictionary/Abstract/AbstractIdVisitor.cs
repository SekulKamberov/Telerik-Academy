namespace _03.CountWordsFromTextFile.SerializableDictionary
{
    using _03.CountWordsFromTextFile.SerializableDictionary.Interfaces;

    public abstract class AbstractIdVisitor<T> : IVisitor<T>
    {
        public abstract void Visit(ILibraryItem libraryItem);

        // {
        // if (libraryItem.Id == 0)
        // {
        // libraryItem.Id = this.GetId();
        // }
        // }
        protected abstract T GenerateId();
    }
}
