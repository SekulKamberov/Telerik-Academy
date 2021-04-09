/*
 * Task 11: Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods 
        and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class 
        and display its version at runtime.
*/
namespace _11.VersionAttribute
{
    using System;

    [VersionAttribute("2.10")]
    class TestProgram
    {
        static void Main()
        {
            Type type = typeof(TestProgram);

            var attribute = type.GetCustomAttributes(false);

            foreach (VersionAttribute item in attribute)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine("Version[{0}.{1}]", item.Major, item.Minor);
            }
        }
    }
}
