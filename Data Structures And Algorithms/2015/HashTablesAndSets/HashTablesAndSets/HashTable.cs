namespace HashTablesAndSets
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<K, V> : IEnumerable
    {
        private const int InitialCapacity = 16;
        private const int ResizePercent = 75;
        private int capacity;
        private int count;
        private LinkedList<KeyValuePair<K, V>>[] data;

        public HashTable(int capacity = InitialCapacity)
        {
            this.capacity = capacity;
            this.count = 0;
            this.data = new LinkedList<KeyValuePair<K, V>>[this.capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public V this[K key]
        {
            get
            {
                var index = this.GetIndex(key);
                var keyValuePairList = this.data[index];
                if (keyValuePairList == null)
                {
                    throw new ArgumentException("Key not found!");
                }

                foreach (var keyValuePair in keyValuePairList)
                {
                    if (keyValuePair.Key.Equals(key))
                    {
                        return keyValuePair.Value;
                    }
                }

                throw new ArgumentException("Key not found!");
            }

            set
            {
                var keyValuePair = this.Find(key);
                if (keyValuePair != null)
                {
                    this.Remove(key);
                    this.Add(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, V>>[this.capacity];
            this.count = 0;
        }

        public ICollection<K> Keys()
        {
            var keys = new List<K>(this.count);

            foreach (var linkedList in this.data)
            {
                if (linkedList != null)
                {
                    foreach (var keyValuePair in linkedList)
                    {
                        keys.Add(keyValuePair.Key);
                    }
                }
            }

            return keys;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var linkedList in this.data)
            {
                if (linkedList != null)
                {
                    foreach (var keyValuePair in linkedList)
                    {
                        yield return keyValuePair;
                    }
                }
            }
        }

        public void Add(K key, V value)
        {
            var index = this.GetIndex(key);
            var keyValuePairList = this.data[index];
            var newKeyValuePair = new KeyValuePair<K, V>(key, value);
            if (keyValuePairList == null)
            {
                var newLinkedList = new LinkedList<KeyValuePair<K, V>>();
                newLinkedList.AddFirst(newKeyValuePair);
                this.data[index] = newLinkedList;
                this.count++;
            }
            else if (this.HasKey(keyValuePairList, key))
            {
                throw new ArgumentException("Item with the same key already has been added!");
            }
            else
            {
                keyValuePairList.AddLast(newKeyValuePair);
                this.count++;
            }

            if (this.count >= this.capacity * ResizePercent / 100)
            {
                this.ResizeTable();
            }
        }

        public bool Remove(K key)
        {
            var index = this.GetIndex(key);
            var keyValuePairList = this.data[index];

            if (keyValuePairList == null)
            {
                return false;
            }

            foreach (var keyValuePair in keyValuePairList)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    keyValuePairList.Remove(keyValuePair);
                    this.count--;
                    return true;
                }
            }

            return false;
        }

        public KeyValuePair<K, V>? Find(K key)
        {
            var index = this.GetIndex(key);
            var keyValuePairList = this.data[index];
            if (keyValuePairList == null)
            {
                return null;
            }

            foreach (var keyValuePair in keyValuePairList)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    return keyValuePair;
                }
            }

            return null;
        }

        public bool ContainesKey(K key)
        {
            var index = this.GetIndex(key);
            var keyValuePairList = this.data[index];
            if (keyValuePairList != null)
            {
                return this.HasKey(keyValuePairList, key);
            }

            return false;
        }

        private bool HasKey(LinkedList<KeyValuePair<K, V>> keyValuePairList, K key)
        {
            if (keyValuePairList == null)
            {
                return false;
            }

            foreach (var keyValuePair in keyValuePairList)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private int GetIndex(K key)
        {
            var hash = key.GetHashCode();
            var index = Math.Abs(hash % this.capacity);
            return index;
        }

        private void ResizeTable()
        {
            var newCapacity = this.capacity * 2;
            var newTable = new HashTable<K, V>();
            newTable.capacity = newCapacity;
            newTable.data = new LinkedList<KeyValuePair<K, V>>[newCapacity];
            foreach (KeyValuePair<K, V> pair in this)
            {
                newTable.Add(pair.Key, pair.Value);
            }

            this.data = newTable.data;
            this.capacity = newCapacity;
            this.count = newTable.count;
        }
    }
}
