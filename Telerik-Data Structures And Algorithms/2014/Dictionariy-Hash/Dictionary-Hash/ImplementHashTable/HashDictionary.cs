namespace ImplementHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashDictionary<K,V> : IEnumerable<KeyValuePair<K, V>>
    {
        const int InitialValueSize = 4;
        LinkedList<KeyValuePair<K, V>>[] values;

        public HashDictionary()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[InitialValueSize];
        }

        public int Count { get; private set; }

        public int Capacity 
        {
            get
            {
                return this.values.Length;
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                var hash = CalculateHash(key);
                bool isFound = false;

                var pair = this.values[hash].First;
                while (pair != null)
                {
                    if (pair.Value.Key.Equals(key))
                    {
                        LinkedListNode<KeyValuePair<K, V>> node =
                            new LinkedListNode<KeyValuePair<K, V>>(new KeyValuePair<K, V>(key, value));
                        this.values[hash].AddAfter(pair, node);
                        this.values[hash].Remove(pair);
                        isFound = true;
                        break;
                    }
                    pair = pair.Next;
                }
                if (isFound == false)
                {
                    throw new ArgumentException("No element with this key.");
                }
                
            }
        }

        public void Add(K key, V value)
        {
            var hash = CalculateHash(key);

            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }
            
            var alreadyHasKey = this.values[hash].Any(p => p.Key.Equals(key));
            if (alreadyHasKey)
            {
                throw new ArgumentException("Key already exists");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= 0.75 * this.Capacity)
            {
                this.ResizeAndReaddValues();
            }
        }

        public void Remove(K key)
        {
            int index = CalculateHash(key);
            if (this.values[index] == null)
            {
                throw new ArgumentException("There is no element with this key");
            }
            else
            {
                bool isFind = false;
                var next = this.values[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        this.values[index].Remove(next);
                        isFind = true;
                        this.Count -= 1;
                    }
                    next = next.Next;
                }
                if (isFind == false)
                {
                    throw new ArgumentException("There is no element with this key");
                }
            }
        }

        public bool ContainsKey(K key)
        {
            var hash = CalculateHash(key);

            if (this.values[hash] == null)
            {
                return false;
            }

            var pairs = this.values[hash];

            return pairs.Any(pair => pair.Key.Equals(key));
        }

        public V Find(K key)
        {
            var hash = CalculateHash(key);

            var pairs = this.values[hash];

            if (pairs != null)
            {
                var pair = pairs.First;
                while (pair != null)
                {
                    if(pair.Value.Key.Equals(key))
                    {
                        return pair.Value.Value;
                    }

                    pair = pair.Next;
                }
            }

            throw new ArgumentException("No such element with this key");

        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valueCollection in this.values)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        yield return value;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private int CalculateHash(K key)
        {
            int hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);
            return hash;
        }

        private void ResizeAndReaddValues()
        {
            // cache old values 
            var cachedValues = this.values;

            // resize
            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            this.Count = 0;

            // add values
            foreach (var valueCollection in cachedValues)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }
    }
}
