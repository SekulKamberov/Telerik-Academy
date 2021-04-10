namespace _03.CountWordsFromTextFile.SerializableDictionary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using _03.CountWordsFromTextFile.SerializableDictionary.Interfaces;

    [Serializable]
    public class SerializableSortedList<K, V> : SortedList<string, V> where V : ILibraryItem, ISerializable
    {
        private SortedList<string, V> data;

        // private IVisitor<int> visitor;
        public SerializableSortedList()
        {
            this.data = new SortedList<string, V>();
        }

        // public SerializableSortedList()
        // : this(new IdentityIdVisitor())
        // {
        // }
        // public SerializableSortedList(IVisitor<int> visitor)
        // {
        // this.data = new SortedList<int, V>();
        // this.visitor = visitor;
        // }
        public void Add(V value)
        {
            // value.Accept(this.visitor);
            this.data.Add(value.PhoneNumber, value);
        }

        // public bool ContainsKey(int key)
        // {
        //   return this.data.ContainsKey(key);
        // }
        // public ICollection<int> Keys
        // {
        // get { return this.data.Keys; }
        // }
        // public bool Remove(int key)
        // {
        // return this.data.Remove(key);
        // }
        // public bool TryGetValue(int key, out V value)
        // {
        //  return this.data.TryGetValue(key, out value);
        // }
        // public ICollection<V> Values
        // {
        // get { return this.data.Values; }
        // }
        // public V this[int key]
        // {
        // get
        // {
        // return this.data[key];
        // }
        // set
        // {
        // this.data[key] = value;
        // }
        // }
        // public void Clear()
        // {
        //   this.data.Clear();
        // }
        // public int Count
        // {
        // get { return this.data.Count; }
        // }
    }
}
