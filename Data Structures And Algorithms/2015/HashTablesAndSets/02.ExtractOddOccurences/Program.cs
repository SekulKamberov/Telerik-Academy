namespace _02.ExtractOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            var courses = new string[] { "SQL", "PHP", "CSS", "PHP", "CSS", "JAVA", "'Враца Софтуер'", "JAVA", "SQL", "PHP", "CSS" };
            var oddCourses = new HashSet<string>();

            for (int i = 0; i < courses.Length; i++)
            {
                var course = courses[i];
                if (!oddCourses.Contains(course))
                {
                    oddCourses.Add(course);
                } 
                else 
                {
                    oddCourses.Remove(course);
                }
            }

            foreach (var course in oddCourses)
            {
                Console.WriteLine("{0}", course);
            }
        }
    }
}
