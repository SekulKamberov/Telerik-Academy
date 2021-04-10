namespace _05.Set
{
    using System;
    using ImplementHashTable;
    /* 05. Implement the data structure "set" in a class HashedSet<T> 
     * using your class HashTable<K,T> to hold the elements. 
     * Implement all standard set operations like Add(T), Find(T), 
     * Remove(T), Count, Clear(), union and intersect.*/
    public class Set<T>
    {
        public HashDictionary<T, bool> values { get; set; }

        public Set()
        {
            this.values = new HashDictionary<T, bool>();
        }

        public void Add(T value)
        {
            if (!(this.values.ContainsKey(value)))
            {
                this.values.Add(value, true);
            }
        }

        public bool Find(T value)
        {
            return this.values.ContainsKey(value);
        }

        public void Remove(T value)
        {
            if(this.Find(value))
            {
                this.values.Remove(value);
            }
            else
            {
                throw new ArgumentException("No such value.");
            }
        }

        public int Count()
        {
            return this.values.Count;
        }

        public void Clear()
        {
            this.values = new HashDictionary<T, bool>();
        }

        public Set<T> Union(Set<T> set2)
        {
            var newSet = new Set<T>();
            foreach (var pair in this.values)
            {
                newSet.Add(pair.Key);
            }

            foreach (var item in set2.values)
            {
                var value = item.Key;
                if (!(newSet.values.ContainsKey(value)))
                {
                    newSet.Add(value);
                }
            }

            return newSet;
        }

        public Set<T> Intersects(Set<T> set)
        {
            var newSet = new Set<T>();
            foreach (var pair in this.values)
            {
                var value = pair.Key;
                if (set.values.ContainsKey(value))
                {
                    newSet.Add(value);
                }
            }

            return newSet;
        }

    }
}
