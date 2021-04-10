namespace _00.PowerCollections
{
    using System;
    using Wintellect.PowerCollections;

    // https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/tree/master/05.%20Advanced-Data-Structures
    public class Program
    {
        public static void Main(string[] args)
        {
            // TestBag();
            // TestSet();
            // TestOrderedBag();
            // TestOrderedSet();
            // TestMultiDictionary();
            // TestOrderedDictionary();
            // TestOrderedMultiDictionary();
            // TestDeque();
            TestBigList();
        }

        /// <summary>
        /// Bag<T>
        /// A bag (multi-set) based on hash-table (WITH DUPLICATES) 
        /// Unordered collection
        /// Add / Find / Remove work in time O(1)
        /// T should provide Equals() and GetHashCode()
        /// </summary>
        private static void TestBag()
        {
            Bag<int> bagOfInts = new Bag<int>();
            bagOfInts.Add(1);
            bagOfInts.Add(1);
            bagOfInts.AddMany(new int[] { 1, 21 });
            bagOfInts.AddRepresentative(1);
            bagOfInts.ChangeNumberOfCopies(1, 3);
            Console.WriteLine("CountWhere > 2 : " + bagOfInts.CountWhere(x => x > 2));
            Console.WriteLine("Exists < 1 : " + bagOfInts.Exists(x => x < 1));
            Console.WriteLine("Copies of 1 : " + bagOfInts.NumberOfCopies(1));

            foreach (var item in bagOfInts)
            {
                Console.WriteLine(item);
            }

            Bag<Student> bagOfStudents = new Bag<Student>();
        }

        /// <summary>
        /// Set<T>
        /// A set based on hash-table   (NO DUPLICATES)
        /// Add / Find / Remove work in time O(1) 
        /// Like .NET’s HashSet<T>
        /// </summary>
        private static void TestSet()
        {
            Set<Student> students = new Set<Student>();
            var student1 = new Student("Pesho", 21);
            var student2 = new Student("Pesho", 21);
            var student3 = new Student("Pesho", 22);
            var student4 = new Student("Pesho", 22);
            var student5 = new Student("Pesho", 24);
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("=====FindAll(x => x.Age < 23)=====");
            var someStudents = students.FindAll(x => x.Age < 23);
            foreach (var student in someStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("=====ForEach(x => { x.Age += 1; Console.WriteLine(x); })=====");
            students.ForEach(x => { x.Age += 1; Console.WriteLine(x); });
        }

        /// <summary>
        /// OrderedBag<T>
        /// A bag (multi-set) based on balanced search tree (WITH DUPLICATES)
        /// Add / Find / Remove work in time O(log(N))
        /// T should implement IComparable<T>
        /// </summary>
        private static void TestOrderedBag()
        {
            OrderedBag<Student> orderedBagOfStudents = new OrderedBag<Student>();
            var student1 = new Student("Pesho", 21);
            var student2 = new Student("Pesho", 21);
            orderedBagOfStudents.Add(student1);
            orderedBagOfStudents.Add(student2);
            Console.WriteLine("Equals: " + student1.Equals(student2));
            Console.WriteLine("CompareTo: " + student1.CompareTo(student2));
            Console.WriteLine(student1.GetHashCode());
            Console.WriteLine(student2.GetHashCode());
            orderedBagOfStudents.Add(student1);
            var student3 = new Student("Pesho", 22);
            var student4 = new Student("Pesho", 23);
            var student5 = new Student("Pesho", 24);
            orderedBagOfStudents.Add(student3);
            orderedBagOfStudents.Add(student4);
            orderedBagOfStudents.Add(student5);
            foreach (var item in orderedBagOfStudents)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("========== Range Age >= 22 && <= 23 ============= ");
            var rangeBag = orderedBagOfStudents.Range(student3, true, student4, true);
            foreach (var item in rangeBag)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// OrderedSet<T>
        /// A set based on balanced search tree (red-black) (NO DUPLICATES)
        /// Add / Find / Remove work in time O(log(N))
        /// Like .NET’s SortedSet<T>
        /// Provides fast .Range(from, to) operation
        /// </summary>
        private static void TestOrderedSet()
        {
            OrderedSet<Student> students = new OrderedSet<Student>();
            var student1 = new Student("Pesho", 21);
            var student2 = new Student("Pesho", 21);
            students.Add(student1);
            students.Add(student2);
            Console.WriteLine("Equals: " + student1.Equals(student2));
            Console.WriteLine("CompareTo: " + student1.CompareTo(student2));
            Console.WriteLine(student1.GetHashCode());
            Console.WriteLine(student2.GetHashCode());
            students.Add(student1);
            var student3 = new Student("Pesho", 22);
            var student4 = new Student("Pesho", 23);
            var student5 = new Student("Pesho", 24);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("========== Range Age >= 22 && <= 23 ============= ");
            var rangeBag = students.Range(student3, true, student4, true);
            foreach (var item in rangeBag)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========ForEach(x => { x.Age += 1; Console.WriteLine(x); })============= ");
            students.ForEach(x => { x.Age += 1; Console.WriteLine(x); });
        }

        /// <summary>
        /// MultiDictionary<TKey,TValue>
        /// A dictionary (map) implemented by hash-table (DUPLICATES CONFIGURABLE)
        /// Allows duplicates
        /// Add / Find / Remove work in time O(1)
        /// Like Dictionary<TKey,List<TValue>>
        /// </summary>
        private static void TestMultiDictionary()
        {
            MultiDictionary<int, Student> students = new MultiDictionary<int, Student>(true);
            var student1 = new Student("First DUPLICATE", 21);
            var student2 = new Student("Second", 21);
            students.Add(1, student1);
            students.Add(1, student1);
            students.Add(2, student2);
            var student3 = new Student("Third", 22);
            var student4 = new Student("Forth", 23);
            var student5 = new Student("Fifth", 24);
            students.Add(3, student3);
            students.Add(4, student4);
            students.Add(2, student5);
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// OrderedDictionary<TKey,TValue>              (NO DUPLICATES)
        /// A dictionary based on balanced search tree
        /// Add / Find / Remove work in time O(log(N))
        /// Provides fast .Range(from,to) operation
        /// </summary>
        private static void TestOrderedDictionary()
        {
            OrderedDictionary<int, Student> students = new OrderedDictionary<int, Student>();
            var student1 = new Student("First", 21);
            var student2 = new Student("Second", 21);
            students.Add(5, student1);
            students.Add(2, student2);
            var student3 = new Student("Third", 22);
            var student4 = new Student("Forth", 23);
            var student5 = new Student("Fifth", 24);
            students.Add(3, student3);
            students.Add(4, student4);
            students.Add(1, student5);
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("========== Range Key >= 2 && <= 4 ============= ");
            var inRangeStudents = students.Range(2, true, 4, true);
            foreach (var item in inRangeStudents)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("==========ForEach(x => { x.Value.Age += 1; Console.WriteLine(x); })============= ");
            students.ForEach(x => { x.Value.Age += 1; Console.WriteLine(x); });
        }

        /// <summary>
        /// OrderedMultiDictionary<TKey,TValue>              (WITH DUPLICATES)
        /// A dictionary based on balanced search tree
        /// Add / Find / Remove work in time O(log(N))
        /// Provides fast .Range(from,to) operation
        /// </summary>
        private static void TestOrderedMultiDictionary()
        {
            OrderedMultiDictionary<int, Student> students = new OrderedMultiDictionary<int, Student>(true);
            var student1 = new Student("First DUPLICATE", 21);
            var student2 = new Student("Second", 21);
            students.Add(5, student1);
            students.Add(5, student1);
            students.Add(2, student2);
            var student3 = new Student("Third", 22);
            var student4 = new Student("Forth", 23);
            var student5 = new Student("Fifth", 24);
            students.Add(3, student3);
            students.Add(4, student4);
            students.Add(1, student5);
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("========== Range Key >= 4 && <= 5 ============= ");
            var inRangeStudents = students.Range(4, true, 5, true);
            foreach (var item in inRangeStudents)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Deque<T>
        /// Double-ended queue (deque)
        /// </summary>
        private static void TestDeque()
        {
            Deque<Student> deque = new Deque<Student>();
            var student1 = new Student("First DUPLICATE", 21);
            var student2 = new Student("Second", 21);
            var student3 = new Student("Third", 22);
            var student4 = new Student("Forth", 23);
            var student5 = new Student("Fifth", 24);
            deque.AddToBack(student1);
            deque.AddToFront(student2);
            deque.AddToBack(student3);
            deque.AddToFront(student4);
            deque.AddToBack(student5);
            deque.AddToFront(student1);

            while (deque.Count != 0)
            {
                var student = deque.RemoveFromFront();
                Console.WriteLine(student);
            }
        }

        /// <summary>
        /// BigList<T> (WITH DUPLICATES)
        /// Editable sequence of indexed items
        /// Like List<T> but provides
        /// Fast Insert / Delete operations (at any position)
        /// Fast Copy / Concat / Sub-range operations
        /// Implemented by the data structure "Rope"
        /// Special kind of balanced binary tree: http://en.wikipedia.org/wiki/Rope_(data_structure)
        /// </summary>
        private static void TestBigList()
        {
            BigList<Student> students = new BigList<Student>();
            var student1 = new Student("First DUPLICATE", 21);
            var student2 = new Student("Second", 21);
            var student3 = new Student("Third", 22);
            var student4 = new Student("Forth", 23);
            var student5 = new Student("Fifth", 24);
            Console.WriteLine();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            students.Add(student1);
            Console.WriteLine("===== BEFORE SORT =====");
            Console.WriteLine("Index of student1: " + students.BinarySearch(student1));
            Console.WriteLine("Index of student2: " + students.BinarySearch(student2));
            Console.WriteLine("Index of student3: " + students.BinarySearch(student3));
            Console.WriteLine("Index of student4: " + students.BinarySearch(student4));
            Console.WriteLine("Index of student5: " + students.BinarySearch(student5));
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            students.Sort();
            Console.WriteLine("===== AFTER SORT =====");
            Console.WriteLine("Index of student1: " + students.BinarySearch(student1));
            Console.WriteLine("Index of student2: " + students.BinarySearch(student2));
            Console.WriteLine("Index of student3: " + students.BinarySearch(student3));
            Console.WriteLine("Index of student4: " + students.BinarySearch(student4));
            Console.WriteLine("Index of student5: " + students.BinarySearch(student5));
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("===== INDEX students[3] =====");
            Console.WriteLine(students[3]);
        }
    }
}
