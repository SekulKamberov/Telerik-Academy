namespace ReflectionValidator
{
    using System;
    using System.Collections.Generic;

    using ObjectStateValidator;

    public class Program
    {
        public static void Main(string[] args)
        {
            var mentor = new Student()
            {
                FirstName = "Gosho",
                Age = 25,
                Marks = new List<int>() { 6, 6, 6 },
            };

            var student = new Student()
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                Age = 22,
                Marks = new List<int>() { 4, 3, 4 },
                Mentor = mentor,
            };

            var studentValidator = new Validator(student);
            studentValidator.Validate();

            if (!studentValidator.IsValid)
            {
                foreach (var error in studentValidator.Errors)
                {
                    Console.WriteLine(error.Key);
                    Console.WriteLine(error.Value);
                }
            }
        }
    }
}
