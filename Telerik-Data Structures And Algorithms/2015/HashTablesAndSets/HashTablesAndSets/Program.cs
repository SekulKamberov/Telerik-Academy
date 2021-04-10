namespace HashTablesAndSets
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<KeyValuePair<string, int>> list = new LinkedList<KeyValuePair<string, int>>();
            Person person1 = new Person("Pesho", "Peshov", 21);
            Person person2 = new Person("Gosho", "Peshov", 22);
            Person person3 = new Person("Tosho", "Peshov", 23);

            // Console.WriteLine(person1.GetHashCode());
            // Console.WriteLine(person2.GetHashCode());
            // Console.WriteLine(person3.GetHashCode());
            // Console.WriteLine(person1.CompareTo(person2));
            // Console.WriteLine(person1.CompareTo(person3));
            var hashTable = new HashTable<Person, int>();
            hashTable.Add(person1, 1);
            hashTable.Add(person2, 1);
            hashTable.Add(person3, 2);
            foreach (KeyValuePair<Person, int> person in hashTable)
            {
                Console.WriteLine("Key\n{0}Value: {1}", person.Key, person.Value);
                Console.WriteLine();
            }

            Console.WriteLine("=====FIND=====");
            Console.WriteLine(hashTable.Find(person1));

            Console.WriteLine("=====REMOVE=====");
            Console.WriteLine(hashTable.Remove(person1));
            Console.WriteLine(hashTable.Remove(person1));

            Console.WriteLine("=====FIND=====");
            Console.WriteLine(hashTable.Find(person1));

            var keys = hashTable.Keys();
            foreach (var item in keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=====INDEXER=====");
            Person person4 = new Person("Rosho", "Peshov", 55);

            // set
            hashTable[person4] = 777;

            // get
            Console.WriteLine(hashTable[person4]);

            Console.WriteLine("=====CLEAR=====");
            hashTable.Clear();
            Person person5 = new Person("Josh", "Goshov", 33);
            hashTable.Add(person5, 1234);
            Person person6 = new Person("Losh", "Goshov", 66);
            hashTable.Add(person6, 126);
            foreach (KeyValuePair<Person, int> person in hashTable)
            {
                Console.WriteLine("Key\n{0}Value: {1}", person.Key, person.Value);
                Console.WriteLine();
            }

            Console.WriteLine(hashTable.ContainesKey(person6));
            Console.WriteLine("=================================================");

            Console.WriteLine("=====HashSet=====");
            Hashset<Person> hashSet = new Hashset<Person>();
            hashSet.Add(person1);
            hashSet.Add(person2);
            Console.WriteLine(hashSet.Find(person1));
            Console.WriteLine(hashSet.Remove(person1));
            Console.WriteLine(hashSet.Find(person1));
            Console.WriteLine(hashSet.Find(person2));
            Console.WriteLine(hashSet.Remove(person2));

            Console.WriteLine("=====FOREACH=====");
            hashSet.Clear();
            hashSet.Add(person1);
            hashSet.Add(person2);
            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=====UNION=====");
            var secondHashSet = new Hashset<Person>();
            secondHashSet.Add(person2);
            secondHashSet.Add(person3);
            var unionHashset = hashSet.Union(secondHashSet);
            foreach (var item in unionHashset)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=====INTERSECT ====");
            var intersectionHashset = hashSet.Intersect(secondHashSet);
            foreach (var item in intersectionHashset)
            {
                Console.WriteLine(item);
            }
        }
    }
}
