namespace Profiler
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            UserProfile profile = new UserProfile();
            profile.FirstName = "Ivailo";
            profile.LastName = "Kenov";
            profile.DateOfBirth = new DateTime(2001, 1, 1);
            profile.Age = 25;
            profile.Description = "'using_atributes'";

            Save(profile);
            UserProfile loadedProfiele = Load();
        }

        public static void Save(UserProfile profile)
        {
            StreamWriter writer = new StreamWriter("data.txt");

            using (writer)
            {
                Type profileType = typeof(UserProfile);
                var profileProperties = profileType.GetProperties();

                foreach (var property in profileProperties)
                {
                    var attribute = property.GetCustomAttributes(typeof(Save), false);

                    if (attribute.Length >= 1)
                    {
                        writer.WriteLine(property.Name + " " + property.GetValue(profile)); 
                    }
                }
            }
        }

        public static UserProfile Load()
        {
            StreamReader reader = new StreamReader("data.txt");

            UserProfile profile = new UserProfile();

            using (reader)
            {
                Type profileType = typeof(UserProfile);
                string currentData = reader.ReadLine();

                while (!string.IsNullOrEmpty(currentData))
                {
                    string[] values = currentData.Split(' ');

                    string propertieName = values[0];
                    string propertyValue = values[1];

                    var property = profileType.GetProperty(propertieName);
                    object convert = Convert.ChangeType(propertyValue, property.PropertyType);
                    property.SetValue(profile, convert);

                    // int propertyValueInt;
                    // DateTime peopertyValueDate;
                    // if (int.TryParse(propertyValue, out propertyValueInt))
                    // {
                    // property.SetValue(profile, propertyValueInt);
                    // }
                    // else if (DateTime.TryParse(propertyValue, out peopertyValueDate))
                    // {
                    // property.SetValue(profile, peopertyValueDate);
                    // }
                    // else
                    // {
                    // property.SetValue(profile, propertyValue);
                    // }
                    currentData = reader.ReadLine();
                    Console.WriteLine(propertieName + " " + propertyValue);
                }
            }

            return profile;
        }
    }
}
