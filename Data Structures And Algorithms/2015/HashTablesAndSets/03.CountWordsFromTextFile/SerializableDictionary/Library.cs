namespace _03.CountWordsFromTextFile.SerializableDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using _03.CountWordsFromTextFile.SerializableDictionary.Interfaces;

    [Serializable]
    public class Library : ILibrary<string, ILibraryItem>, IEnumerable
    {
        private IDictionary<string, ILibraryItem> data;

        public Library()
        {
            this.data = new Dictionary<string, ILibraryItem>();
        }

        public Library(IDictionary<string, ILibraryItem> data)
        {
            this.data = data;
        }

        public void Add(ILibraryItem libraryItem)
        {
            this.data.Add(libraryItem.PhoneNumber, libraryItem);
        }

        public bool Remove(string key)
        {
            return this.data.Remove(key);
        }

        public void Edit(string key, ILibraryItem newValue)
        {
            this.data[key] = newValue;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }
    }
}
