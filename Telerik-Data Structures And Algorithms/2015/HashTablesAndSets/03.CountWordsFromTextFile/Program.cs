namespace _03.CountWordsFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    using _03.CountWordsFromTextFile.SerializableDictionary;

    public class Program
    {
        public static void Main(string[] args)
        {
            var separators = new char[] { ' ', ',', '!', '-', '.', '–', '?' };
            var dictionary = new Dictionary<string, int>();

            using (StreamReader streamReader = new StreamReader(@"..\..\words.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        var wordToLower = word.ToLower();
                        if (!dictionary.ContainsKey(wordToLower))
                        {
                            dictionary[wordToLower] = 0;
                        }

                        dictionary[wordToLower] += 1;
                    }
                }
            }

            var wordsSortedByApearence = dictionary.OrderBy(i => i.Value);
            foreach (var word in wordsSortedByApearence)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }

            // SerializableSortedList<int, LibraryItem> dict = new SerializableSortedList<int, LibraryItem>();
            // var libraryItem1 = new LibraryItem("Pesho", "Peshov", PhoneType.Home, "09999999");
            // dict.Add(libraryItem1);
            // var libraryItem2 = new LibraryItem("Peshob", "Peshov", PhoneType.Home, "08888888");
            // dict.Add(libraryItem2);
            // var libraryItem3 = new LibraryItem("Peshoc", "Peshova", PhoneType.Home, "07777777");
            // dict.Add(libraryItem3);
            // var libraryItem4 = new LibraryItem("Peshoa", "Peshovc", PhoneType.Home, "06666666");
            // dict.Add(libraryItem4);
            // var libraryItem5 = new LibraryItem("Peshob", "Peshov", PhoneType.Home, "05555555");
            // dict.Add(libraryItem5);
            // IFormatter formatter = new BinaryFormatter();
            // string fileLocation = "../../SerializableDictionary/dictionary.bin";
            // Stream stream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write, FileShare.None);
            // formatter.Serialize(stream, dict);
            // stream.Close();
            // formatter = new BinaryFormatter();
            // stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
            // var desirializedDict = (SerializableSortedList<int, LibraryItem>)formatter.Deserialize(stream);
            // stream.Close();
            // foreach (var item in desirializedDict)
            // {
            // Console.WriteLine(item);
            // }
            // Console.WriteLine();
            // var sortedByLastName = desirializedDict.OrderBy(i => i.Value.LastName);
            // foreach (var item in sortedByLastName)
            // {
            // Console.WriteLine(item);
            // }
            var library = new Library();
            library.Add(new LibraryItem("B", "A", PhoneType.Cellphone, "0999"));
            library.Add(new LibraryItem("A", "B", PhoneType.Cellphone, "0888"));
            library.Add(new LibraryItem("B", "C", PhoneType.Cellphone, "0777"));
            library.Add(new LibraryItem("A", "B", PhoneType.Cellphone, "0666"));

            IFormatter formatter = new BinaryFormatter();
            string fileLocation = "../../SerializableDictionary/library.bin";
            Stream stream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, library);
            stream.Close();

            formatter = new BinaryFormatter();
            stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.Read);
            var desirializedDict = (Library)formatter.Deserialize(stream);
            stream.Close();

            foreach (var item in desirializedDict)
            {
                Console.WriteLine(item);
            }
        }
    }
}
