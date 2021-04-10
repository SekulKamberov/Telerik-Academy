namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private Dictionary<K1, Guid> key1Identifiers;
        private Dictionary<K2, Guid> key2Identifiers;
        private MultiDictionary<Guid, V> values;

        public BiDictionary()
        {
            this.key1Identifiers = new Dictionary<K1, Guid>();
            this.key2Identifiers = new Dictionary<K2, Guid>();
            this.values = new MultiDictionary<Guid, V>(true);
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            var id = this.GenerateId();
            if (this.key1Identifiers.ContainsKey(key1) && this.key2Identifiers.ContainsKey(key2))
            {
                var id1 = this.key1Identifiers[key1];
                var id2 = this.key2Identifiers[key2];
                if (id1 == id2)
                {
                    id = id1;
                    this.values.Add(id, value);
                }
            }
            else
            {
                this.key1Identifiers.Add(key1, id);
                this.key2Identifiers.Add(key2, id);
                this.values.Add(id, value);
            }
        }

        public ICollection<V> Find(K1 key)
        {
            if (this.key1Identifiers.ContainsKey(key))
            {
                var id = this.key1Identifiers[key];

                return this.values[id];
            }
            else 
            {
                return null;
            }
        }

        public ICollection<V> Find(K2 key)
        {
            if (this.key2Identifiers.ContainsKey(key))
            {
                var id = this.key2Identifiers[key];

                return this.values[id];
            }
            else
            {
                return null;
            }
        }

        public ICollection<V> Find(K1 key1, K2 key2)
        {
            if (this.key1Identifiers.ContainsKey(key1) && this.key2Identifiers.ContainsKey(key2))
            {
                var id1 = this.key1Identifiers[key1];
                var id2 = this.key2Identifiers[key2];
                if (id1 == id2)
                {
                    return this.values[id1];
                }
            }

            return null;
        }

        private Guid GenerateId()
        {
            var guid = Guid.NewGuid();
            while (this.values.ContainsKey(guid))
            {
                guid = Guid.NewGuid();
            }

            return guid;
        }
    }
}
