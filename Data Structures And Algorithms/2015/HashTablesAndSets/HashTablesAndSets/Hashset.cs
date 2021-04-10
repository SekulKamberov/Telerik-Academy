namespace HashTablesAndSets
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Hashset<K> : IEnumerable
    {
        private const int InitialCapacity = 16;
        private HashTable<K, K> data;

        public Hashset(int capacity = InitialCapacity)
        {
            this.data = new HashTable<K, K>(capacity);
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.data.Capacity;
            }
        }

        public void Add(K key)
        {
            if (!this.data.ContainesKey(key))
            {
                this.data.Add(key, key);
            }
        }

        public bool Remove(K key)
        {
            return this.data.Remove(key);
        }

        public K Find(K key)
        {
            KeyValuePair<K, K>? keyValuePair = this.data.Find(key);
            return keyValuePair.GetValueOrDefault().Key;
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public bool Containes(K key)
        {
            return this.data.ContainesKey(key);
        }

        public Hashset<K> Union(Hashset<K> secondHashSet)
        {
            var union = new Hashset<K>();
            foreach (K key in this)
            {
                union.Add(key);
            }

            foreach (K key in secondHashSet)
            {
                if (!union.Containes(key))
                {
                    union.Add(key);
                }
            }

            return union;
        }

        public Hashset<K> Intersect(Hashset<K> secondHashSet)
        {
            var intersectionSet = new Hashset<K>();
            foreach (K firstKey in this)
            {
                if (secondHashSet.Containes(firstKey))
                {
                    intersectionSet.Add(firstKey);
                }
            }

            return intersectionSet;
        }

        public IEnumerator GetEnumerator()
        {
            ICollection<K> keys = this.data.Keys();
            foreach (var item in keys)
            {
                yield return item;
            }
        }
    }
}
