namespace _03.CountWordsFromTextFile.SerializableDictionary.Interfaces
{
    using System.Collections.Generic;

    public interface ILibrary<K, V>
    {
        void Add(V value);

        bool Remove(K key);

        void Edit(K key, V newValue);
    }
}
