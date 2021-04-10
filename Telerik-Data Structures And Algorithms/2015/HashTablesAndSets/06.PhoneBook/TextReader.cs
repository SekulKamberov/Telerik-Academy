namespace _06.PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TextReader
    {
        private char[] phoneItemsSeparators = new char[] { '|' };
        private char[] commandsSeparators = new char[] { ',' };

        public ICollection<PhoneBookItem> ReadPhoneBook(string filePath)
        {
            var phoneBookItems = new List<PhoneBookItem>();

            using (var file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var phoneBookItemsInfo = line.Split(this.phoneItemsSeparators, StringSplitOptions.RemoveEmptyEntries);
                    var phoneBookItem = new PhoneBookItem(phoneBookItemsInfo[0], phoneBookItemsInfo[1], phoneBookItemsInfo[2]);
                    phoneBookItems.Add(phoneBookItem);
                }
            }

            return phoneBookItems;
        }

        public ICollection<Command> ReadCommands(string filePath)
        {
            var commands = new List<Command>();

            using (var file = new StreamReader(filePath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var commandEndIndex = line.IndexOf("(");
                    var parametarsEndIndex = line.IndexOf(")");
                    var commandString = line.Substring(0, commandEndIndex);
                    var parameters = line
                        .Substring(commandEndIndex + 1, parametarsEndIndex - commandEndIndex - 1)
                        .Split(this.commandsSeparators, StringSplitOptions.RemoveEmptyEntries);
                    var nameMatchSubstring = string.Empty;
                    var townMatchingSubstring = string.Empty;
                    if (parameters.Length > 0)
                    {
                        nameMatchSubstring = parameters[0];
                    }

                    if (parameters.Length > 1)
                    {
                        townMatchingSubstring = parameters[1];
                    }

                    var command = new Command(commandString, line, new[] { nameMatchSubstring, townMatchingSubstring });
                    commands.Add(command);
                }
            }

            return commands;
        }
    }
}
