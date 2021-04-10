namespace _03.CountWordsFromTextFile.SerializableDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Serializable]
    public class SerializebleSortedDictionary<K, V> : SortedDictionary<K, V> where V : ISerializable
    {
    }
}
