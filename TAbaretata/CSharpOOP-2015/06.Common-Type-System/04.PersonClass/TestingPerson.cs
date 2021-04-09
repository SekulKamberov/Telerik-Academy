/*
 * Problem 4: Create a class Person with two fields – name and age. Age can be left unspecified 
    (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so.
    Write a program to test this functionality.
 */

namespace _04.PersonClass
{
    using System;

    public class TestingPerson
    {
        public static void Main()
        {
            var person = new Person("Ivan Peshev", 12);

            Console.WriteLine(person);

            var otherPerson = new Person("Pesho Ivanov");

            Console.WriteLine(otherPerson);
        }
    }
}
