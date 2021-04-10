namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Linq;
    using System.Text;
    using Events;

    public class Program
    {
        public static void Main(string[] args)
        {
            // 01.
            Console.WriteLine("01.");
            Console.WriteLine("=======================");
            StringBuilder strB = new StringBuilder("0123456789");
            Console.WriteLine(strB);

            StringBuilder sb = strB.Substring(0, 0);
            Console.WriteLine(sb.ToString());
            sb = strB.Substring(0, 1);
            Console.WriteLine(sb.ToString());
            sb = strB.Substring(0, 9);
            Console.WriteLine(sb.ToString());
            sb = strB.Substring(0, 10);
            Console.WriteLine(sb.ToString());

            // sb = strB.Substring(0, 11); // exception
            // Console.WriteLine(sb.ToString());
            sb = strB.Substring(1, 0);
            Console.WriteLine(sb.ToString());
            sb = strB.Substring(1, 1);
            Console.WriteLine(sb.ToString());

            // 02. 
            Console.WriteLine("\n02.");
            Console.WriteLine("=======================");
            int[] numbers = new int[] { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("Max: {0}", numbers.Max<int>());
            Console.WriteLine("Min: {0}", numbers.Min<int>());
            Console.WriteLine("Sum: {0}", numbers.Sum<int>());
            Console.WriteLine("Product: {0}", numbers.Product<int>());
            Console.WriteLine("Count: {0}", numbers.Count<int>());
            Console.WriteLine("Average: {0}", numbers.Average<int>());

            // 03.  
            Console.WriteLine("\n03.");
            Console.WriteLine("=======================");
            Student[] students = 
                                {
                                     new Student { FirstName = "Ivan", LastName = "Vasilev", Age = 21 }, 
                                     new Student { FirstName = "Ivan", LastName = "Ivanov", Age = 31 }, 
                                     new Student { FirstName = "Stanimir", LastName = "Ivanov", Age = 20 }, 
                                     new Student { FirstName = "George", LastName = "Johnson", Age = 10 },
                                 };
            StudentsNamesDemo.StudentsWithFirstNameBeforeLast(students);

            // 04. 
            Console.WriteLine("\n04.");
            Console.WriteLine("=======================");
            FindStrudentsByAge.FindStudentsByAgeRange(students, 18, 21);

            // 05. 
            Console.WriteLine("\n05. Lambda");
            Console.WriteLine("=======================");
            SortStudents.PrintSortedStudentsUsingLambda(students);
 
            Console.WriteLine("\n05. LINQ");
            Console.WriteLine("=======================");
            SortStudents.PrintSortedStudentsUsingLinq(students);

            // 06. 
            int[] array = { 1, 3, 231, 7, 21, 42, 56, 73, 63, 210 };
            Console.WriteLine("\n06. Lambda");
            Console.WriteLine("=======================");
            PrintFromArray.PrintNumberDivisibleByUseLambda(array, 3, 7);

            Console.WriteLine("\n06. LINQ");
            Console.WriteLine("=======================");
            PrintFromArray.PrintNumberDivisibleByUseLinq(array, 3, 7);

            Console.WriteLine("\n07. Delegates");
            Console.WriteLine("=======================");
            Timer.RepeatSomeMethod(Timer.Print, 1, 3);

            Console.WriteLine("\n08. Events");
            Console.WriteLine("=======================");
            TimerWithHandler timer = new TimerWithHandler();
            Printer firstPrinter = new Printer(timer);
            Printer secondPrinter = new Printer(timer);
            timer.RepeatMessage(1, 3);
        }
    }
}
