namespace ProcessingJSONin.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;

    public class Computer
    {
        public Computer(string model, string vendor, int ram)
        {
            this.Model = model;
            this.RAM = ram;
            this.Vendor = vendor;
        }

        public string Model { get; set; }

        public int? RAM { get; set; }

        public string Vendor { get; set; }

        public Computer InnerComputer { get; set; }

        [JsonProperty("y")]
        public int Year { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
    }

    public class School
    {
        public List<Student> Students { get; set; }

        public School()
        {
            this.Students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                this.Students.Add(new Student() { Name = "NAME" + i });
            }
        }
    }

    public class Person
    {
        public Name Name { get; set; }

        public int Age { get; set; }

        public Person Parent { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    // Install-Package Newtonsoft.Json
    public class Program
    {
        public static void Main(string[] args)
        {
            var computer = new Computer("Apple", "IBM", 24);
            computer.InnerComputer = new Computer("Apple2", "IBM2", 12);
            var serializer = new JavaScriptSerializer();
            //var jsonFromComputer = serializer.Serialize(computer);
            //Console.WriteLine(jsonFromComputer);

            //            var computerJson = @"
            //                            {
            //                                ""Vendor"" : ""MS"", 
            //                                ""Model"" : ""S2"", 
            //                            }";
            //var computerFromJson = serializer.Deserialize<Computer>(computerJson);
            //Console.WriteLine("Model: {0} Vendor: {1} RAM: {2}", computerFromJson.Model, computerFromJson.Vendor, computerFromJson.RAM);

            var jsonFromComputer = JsonConvert.SerializeObject(computer, Formatting.Indented);
            Console.WriteLine(jsonFromComputer);
            Console.WriteLine();

            var computerJson = @"
                            {
                                ""vendor"" : ""case insensitive"", 
                                ""Model"" : ""S2"",
                                ""Password"" : ""WILL NOT SHOW"", 
                                ""y"" : 2001,
                                ""NOTinCOMPUTER"" : ""NO ERROR""     
                            }";
            var computerFromJson = JsonConvert.DeserializeObject<Computer>(computerJson);
            Console.WriteLine("Model: {0} Vendor: {1} RAM: {2} Pass: {3} Year: {4}",
                computerFromJson.Model, computerFromJson.Vendor, computerFromJson.RAM, computerFromJson.Password, computerFromJson.Year);

            Console.WriteLine();
            var anonymous = @"{""Name"" : ""Pesho"", ""NOTinTEMPLATE"" : ""NO ERROR""}";
            var template = new
            {
                Name = ""
            };
            var obj = JsonConvert.DeserializeAnonymousType(anonymous, template);
            Console.WriteLine(obj.Name);

            // LINQ
            var schools = new School[3] { new School(), new School(), new School() };
            var schoolsObj = new { Schools = schools };
            var studentsJson = JsonConvert.SerializeObject(schoolsObj, Formatting.Indented);

            var jObj = JObject.Parse(studentsJson);

            var studentsPerSchool = jObj["Schools"]
                .Select(sc => sc["Students"].Count());
            //.Select(sc => sc["Students"][1]["Name"]);
            Console.WriteLine(studentsPerSchool);
            foreach (var count in studentsPerSchool)
            {
                Console.WriteLine(count);
            }

            // JSON TO XML TO JSON
            //var xml = JsonConvert.DeserializeXmlNode(studentsJson);


            // READ JSON FROM FILE
            using (StreamReader file = File.OpenText(@"..\..\json1.json"))
            {
                JsonSerializer jsonSer = new JsonSerializer();
                List<Person> persons = (List<Person>)jsonSer.Deserialize(file, typeof(List<Person>));
            }
        }
    }
}
