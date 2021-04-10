namespace _01.CourseStudents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * 01. A text file students.txt holds information about students and their courses in the following format:
                    
             * Kiril  | Ivanov   | C#
             * Stefka | Nikolova | SQL
             * Stela  | Mineva   | Java
             * Milena | Petrova  | C#
             * Ivan   | Grigorov | C#
             * Ivan   | Kolev    | SQL
            
             * Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them 
             * prints the students ordered by family and then by name:
               
             * C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova               
             * Java: Stela Mineva 
             * SQL: Ivan Kolev, Stefka Nikolova
             */

            string[] text = File.ReadAllLines(@"..\..\text.txt");

            IDictionary<string, SortedDictionary<string, SortedSet<string>>> outerDict = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            char [] separator = new char[]{' ', '|'};
            string[] data;
            string firstName;
            string lastName;
            string courseName;
            foreach (var line in text)
            {
                data = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                firstName = data[0];
                lastName = data[1];
                courseName = data[2];

                if(!(outerDict.ContainsKey(courseName)))
                {
                    outerDict[courseName] = new SortedDictionary<string, SortedSet<string>>();
                    outerDict[courseName].Add(lastName, new SortedSet<string>());
                    outerDict[courseName][lastName].Add(firstName);
                }
                else
                {
                    //outerDict[courseName].Add(lastName, new SortedSet<string>());
                    if (!(outerDict[courseName].ContainsKey(lastName)))
                    {
                        outerDict[courseName].Add(lastName, new SortedSet<string>());
                        outerDict[courseName][lastName].Add(firstName);
                    }
                    outerDict[courseName][lastName].Add(firstName);
                }
            }

            foreach (var item in outerDict)
            {
                var course = item.Key;
                Console.Write(course + ": ");

                SortedDictionary<string, SortedSet<string>> innerDict = item.Value;

                foreach (var innerDictItem in innerDict)
                {
                    var lName = innerDictItem.Key;
                    var fNames = innerDictItem.Value;

                    foreach (var name in fNames)
                    {
                        Console.Write(name + " " + lName + ", ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
