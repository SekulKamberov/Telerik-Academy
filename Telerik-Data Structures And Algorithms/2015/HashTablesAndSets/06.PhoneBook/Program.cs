namespace _06.PhoneBook
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var textReader = new TextReader();
            var phoneBookItems = textReader.ReadPhoneBook(@"..\..\phones.txt");
            Console.WriteLine("=====ALL=====");
            foreach (var person in phoneBookItems)
            {
                Console.WriteLine(person.Name + "\n" + person.Town + "\n" + person.PhoneNumber);
                Console.WriteLine("-----------------------------------------------------------");
            }

            Console.WriteLine("=====COMMANDS=====");
            var commands = textReader.ReadCommands(@"..\..\commands.txt");
            foreach (var command in commands)
            {
                Console.WriteLine("Parrams: {0} {1}", command.Parrams[0], command.Parrams[1]); 
                Console.WriteLine("=====" + command.CommandAsString + "=====");
                var mathingItems = phoneBookItems.Where(p => p.Name.Contains(command.Parrams[0]) && p.Town.Contains(command.Parrams[1]));
                foreach (var phoneContact in mathingItems)
                {
                    Console.WriteLine("{0}\t|{1}\t|{2}", phoneContact.Name, phoneContact.Town, phoneContact.PhoneNumber);
                }

                Console.WriteLine("============");
            }
        }
    }
}
