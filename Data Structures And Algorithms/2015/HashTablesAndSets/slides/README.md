<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionaries, Hash Tables and Sets
##  Dictionaries, Hash Tables, Hashing, Collisions, Sets
<div class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href = "http://academy.telerik.com " class="signature-link">http://academy.telerik.com </a>
</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* Dictionaries
* Hash Tables
* Dictionary<TKey, TValue> Class
* Sets: HashSet<T> and SortedSet<T>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionaries
##  Data Structures that Map Keys to Values

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# The Dictionary (Map) ADT
* The abstract data type (ADT) "`dictionary`" maps key to values
  * Also known as "`map`" or "`associative array`"
  * Contains a set of (key, value) pairs
* Dictionary ADT operations:
  * `Add(key, value)`
  * `FindByKey(key) &rarr; value`
  * `Delete(key)`
* Can be implemented in several ways
  * List, array, hash table, balanced tree, ...

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# ADT Dictionary – Example
* Example dictionary:

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Hash Tables
##  What is Hash Table? How it Works?

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Hash Table
* A hash table is an array that holds a set of(key, value) pairs
* The process of mapping a key to a positionin a table is called `hashing`
* T
* h(k)
<div class="fragment balloon">Hash table of size m</div>
<div class="fragment balloon">Hash function h: k → 0 … m-1</div>

<!-- attr: { showInPresentation:true, style:'' } -->
# Hash Functions and Hashing
* A hash table has `m` slots, indexed from `0` to `m-1`
* A hash function `h(k)` maps keys to positions:
  * `h: k → 0 … m-1`
* For any value `k` in the key range and some hash function `h` we have `h(k)` `=` `p` and `0` `≤` `p` `<` `m`
* T
* h(k)

<!-- attr: { showInPresentation:true, style:'' } -->
# Hashing Functions
* Perfect hashing function (PHF)
  * `h(k)` : one-to-one mapping of each key `k` to an integer in the range [0, m-1]
  * The PHF maps each key to a `distinct` integer within some manageable range
* Finding a perfect hashing function is in most cases `impossible`
* More realistically
  * Hash function `h(k)` that maps `most` of the keys onto unique integers, but `not all`

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Collisions in a Hash Table
* A `collision` is the situation when different keys have the same hash value
  * `	h(k1)` `=` `h(k2)` for `k1` `≠` `k2`
* When the number of collisions is sufficiently small, the hash tables work quite well (fast)
* Several `collisions resolution `strategies exist
  * Chaining in a list
  * Using the neighboring slots (linear probing)
  * Re-hashing (second hash function)
  * ...

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Collision Resolution: Chaining
* h("Pesho") = 4
* h("Kiro") = 2	 
* h("Mimi") = 1	
* h("Ivan") = 2
* h("Lili") = m-1
* Kiro
* Ivan
* null
* Mimi
* null
* Lili
* null
* Pesho
* null
* collision
<div class="fragment balloon">Chaining elements in case of collision</div>
* T

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Hash Tables and Efficiency
* Hash tables are the most efficient implementation of ADT "dictionary"
* Add / Find / Delete take just few primitive operations
  * Speed does not depend on the size of the hash-table (constant time)
    * Amortized complexity O(1)
  * Example: finding an element in a hash-table with 1 000 000 elements, takes just few steps
    * Finding an element in array of 1 000 000 elements takes average 500 000 steps

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionaries: .NET Interfaces and Implementations

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Hash Tables in C#
##  The Dictionary<TKey,TValue> Class

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Dictionary<TKey,TValue>
* Implements the ADT dictionary as hash table
  * The size is dynamically increased as needed
  * Contains a collection of key-value pairs
  * Collisions are resolved by chaining
  * Elements have almost random order
    * Ordered by the hash code of the key
* `Dictionary<TKey,TValue>` relies on
  * `Object.Equals()` – for comparing the keys
  * `Object.GetHashCode()` – for calculating the hash codes of the keys

<!-- attr: { showInPresentation:true, style:'' } -->
# Dictionary<TKey,TValue> (2)
* Major operations:
  * `Add(TKey,TValue)` – adds an element with the specified key and value
  * `Remove(TKey)` – removes the element by key
  * `this[]` – get / add / replace of element by key
  * `Clear()` – removes all elements
  * `Count` – returns the number of elements
  * `Keys` – returns a collection of the keys
  * `Values` – returns a collection of the values

<!-- attr: { showInPresentation:true, style:'' } -->
# Dictionary<TKey,TValue> (3)
* Major operations:
  * `ContainsKey(TKey)` – checks whether the dictionary contains given key
  * `ContainsValue(TValue)` – checks whether the dictionary contains given value
    * Warning: slow operation – O(n)
  * `TryGetValue(TKey,` `out` `TValue)`
    * If the key is found, returns it in the `TValue`
    * Otherwise returns `false`

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionary<TKey,TValue> – Example  

```cs
Dictionary<string, int> studentsMarks =
  new Dictionary<string, int>();
studentsMarks.Add("Ivan", 4);
studentsMarks.Add("Peter", 6);
studentsMarks.Add("Maria", 6);
studentsMarks.Add("George", 5);
int peterMark = studentsMarks["Peter"];
Console.WriteLine("Peter's mark: {0}", peterMark);
Console.WriteLine("Is Peter in the hash table: {0}",
  studentsMarks.ContainsKey("Peter"));
Console.WriteLine("Students and grades:");
foreach (var pair in studentsMarks)
{
  Console.WriteLine("{0} --> {1}", pair.Key, pair.Value);
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionary<TKey,TValue>
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Counting the Words in a Text

```cs
string text = "a text, some text, just some text";
IDictionary<string, int> wordsCount = 
  new Dictionary<string, int>(); 
string[] words = text.Split(' ', ',', '.');
foreach (string word in words)
{
  int count = 1;
  if (wordsCount.ContainsKey(word))
    count = wordsCount[word] + 1;
  wordsCount[word] = count;
}
foreach(var pair in wordsCount)
{
  Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Counting the Words in a Text
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
* Data structures can be nested, e.g. dictionary of lists: `Dictionary<string, List<int>>`
# Nested Data Structures

```cs
static Dictionary<string, List<int>> studentGrades = 
    new Dictionary<string, List<int>>();
private static void AddGrade(string name, int grade)
{
    if (! studentGrades.ContainsKey(name))
    {
        studentGrades[name] = new List<int>();
    }
    studentGrades[name].Add(grade);
}
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionary of Lists
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Balanced Tree Dictionaries
##  The SortedDictionary<TKey,TValue> Class

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# SortedDictionary<TKey,TValue>
* `SortedDictionary<TKey,TValue>` implements the ADT "dictionary" as self-balancing search tree
  * Elements are arranged in the tree ordered by key
  * Traversing the tree returns the elements in increasing order
  * Add / Find / Delete perform `log2(n)` operations
* Use `SortedDictionary<TKey,TValue>` when you need the elements sorted by key
  * Otherwise use `Dictionary<TKey,TValue>` – it has better performance

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Counting Words (Again)

```cs
string text = "a text, some text, just some text";
IDictionary<string, int> wordsCount = 
  new SortedDictionary<string, int>(); 
string[] words = text.Split(' ', ',', '.');
foreach (string word in words)
{
  int count = 1;
  if (wordsCount.ContainsKey(word))
    count = wordsCount[word] + 1;
  wordsCount[word] = count;
}
foreach(var pair in wordsCount)
{
  Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Counting the Words in a Text
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Comparing Dictionary Keys
##  Using custom key classes in Dictionary<TKey, TValue> and SortedDictionary<TKey,TValue>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# IComparable<T>
* `Dictionary<TKey,TValue>` relies on
  * `Object.Equals()` – for comparing the keys
  * `Object.GetHashCode()` – for calculating the hash codes of the keys
* `SortedDictionary<TKey,TValue>` relies on `IComparable<T>` for ordering the keys
* Built-in types like `int`, `long`, `float`, `string` and `DateTime` already implement `Equals()`, `GetHashCode()` and `IComparable<T>`
  * Other types used when used as dictionary keys should provide custom implementations

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Implementing Equals() and GetHashCode()

```cs
public struct Point
{
  public int X { get; set; }
  public int Y { get; set; }
  public override bool Equals(Object obj)
  {
    if (!(obj is Point) || (obj == null)) return false;
    Point p = (Point)obj;
    return (X == p.X) && (Y == p.Y);
  }
  public override int GetHashCode()
  {
      return (X << 16 | X >> 16) ^ Y;
  }
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Implementing IComparable<T>

```cs
public struct Point : IComparable<Point>
{
  public int X { get; set; }
  public int Y { get; set; }
  public int CompareTo(Point otherPoint)
  {
    if (X != otherPoint.X)
    {
      return this.X.CompareTo(otherPoint.X);
    }
    else
    {
      return this.Y.CompareTo(otherPoint.Y);
    }
  }
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Sets
##  Sets of Elements

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Set and Bag ADTs
* The abstract data type (ADT) "`set`" keeps a set of elements with no duplicates
* Sets with duplicates are also known as ADT "`bag`"
* Set operations:
  * `Add(element)`
  * `Contains(element) &rarr; true / false`
  * `Delete(element)`
  * `Union(set) / Intersect(set)`
* Sets can be implemented in several ways
  * List, array, hash table, balanced tree, ...

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Sets: .NET Interfacesand Implementations

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# HashSet<T>
* `HashSet<T>` implements ADT `set` by hash table
  * Elements are in no particular order
* All major operations are fast:
  * `Add(element)` – appends an element to the set
    * Does nothing if the element already exists
  * `Remove(element)` – removes given element
  * `Count` – returns the number of elements
  * `UnionWith(set)` / `IntersectWith(set)` – performs union / intersection with another set

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# HashSet<T> – Example

```cs
ISet<string> firstSet = new HashSet<string>(
   new string[] { "SQL", "Java", "C#", "PHP"  });
ISet<string> secondSet = new HashSet<string>(
   new string[] { "Oracle", "SQL", "MySQL"  });
ISet<string> union = new HashSet<string>(firstSet);
union.UnionWith(secondSet);
PrintSet(union); // SQL Java C# PHP Oracle MySQL
private static void PrintSet<T>(ISet<T> set)
{
   foreach (var element in set)
   {
      Console.Write("{0} ", element);
   }
   Console.WriteLine();
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# SortedSet<T>
* `SortedSet<T>` implements ADT `set` by balanced search tree (red-black tree)
  * Elements are sorted in increasing order
* Example:

```cs
ISet<string> firstSet = new SortedSet<string>(
   new string[] { "SQL", "Java", "C#", "PHP" });
ISet<string> secondSet = new SortedSet<string>(
   new string[] { "Oracle", "SQL", "MySQL" });
ISet<string> union = new HashSet<string>(firstSet);
union.UnionWith(secondSet);
PrintSet(union); // C# Java PHP SQL MySQL Oracle
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# HashSet<T> and SortedSet<T>
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Summary
* Dictionaries map key to value
  * Can be implemented as hash table or balanced search tree
* Hash-tables map keys to values
  * Rely on hash-functions to distribute the keys in the table
  * Collisions needs resolution algorithm (e.g. chaining)
  * Very fast add / find / delete – O(1)
* Sets hold a group of elements
  * Hash-table or balanced tree implementations

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dictionaries, Hash Tables and Sets
* http://academy.telerik.com

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises
* Write a program that counts in a given array of `double` values the number of occurrences of each value. Use `Dictionary<TKey,TValue>`.
  * Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
  * -2.5 &rarr; 2 times
  * 3 &rarr; 4 times
  * 4 &rarr; 3 times
* Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
  * {C#, SQL, PHP, PHP, SQL, SQL } &rarr; {C#, SQL}

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises (2)
* Write a program that counts how many times each word from given text file `words.txt` appears in it. The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. Example:
  * 	is &rarr; 2
  * 	the &rarr; 2
  * 	this &rarr; 3
  * 	text &rarr; 6

```cs
This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises (3)
* Implement the data structure "`hash table`" in a class `HashTable<K,T>`. Keep the data in array of lists of key-value pairs (`LinkedList<KeyValuePair<K,T>>[]`) with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties: `Add(key,` `value)`, `Find(key)&rarr;value`, `Remove( key)`, `Count`, `Clear()`, `this[]`, `Keys`. Try to make the hash table to support iterating over its elements with `foreach`.
* Implement the data structure "`set`" in a class `HashedSet<T>` using your class `HashTable<K,T>` to hold the elements. Implement all standard set operations like `Add(T)`, `Find(T)`, `Remove(T)`, `Count`, `Clear()`, union and intersect.

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises (4)
* x A text file `phones.txt` holds information about people, their town and phone number:
* 	Duplicates can occur in people names, towns and phone numbers. Write a program to read the phones file and execute a sequence of commands given in the file `commands.txt`:
  * `find(name)` – display all matching records by given name (first, middle, last or nickname)
  * `find(name,` `town)` – display all matching records by given name and town

```cs
Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
Kireto                  | Varna    | 052 23 45 67
Daniela Ivanova Petrova | Karnobat | 0899 999 888
Bat Gancho              | Sofia    | 02 946 946 946
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Free Trainings @ Telerik Academy
* C# Programming @ Telerik Academy
    * csharpfundamentals.telerik.com
  * Telerik Software Academy
    * academy.telerik.com
  * Telerik Academy @ Facebook
    * facebook.com/TelerikAcademy
  * Telerik Software Academy Forums
    * forums.academy.telerik.com

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

