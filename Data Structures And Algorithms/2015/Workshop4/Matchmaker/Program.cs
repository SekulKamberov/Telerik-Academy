namespace Matchmaker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static List<Player> males = new List<Player>();
        private static List<Player> females = new List<Player>();
        private static int maxInterestMatchCounter = 0;
        private static Player topMale;
        private static Player topFemale;
        private static HashSet<string> maxCommonInterests;

        public static void Main(string[] args)
        {
            ReadInput();
            ComparePlayers();
            Console.WriteLine("{0} and {1} have {2} common {3}!", topMale.Name, topFemale.Name, maxInterestMatchCounter, maxInterestMatchCounter > 1 ? "interests" : "interest");
        }

        private static void ComparePlayers()
        {
            topMale = males[0];
            topFemale = females[0];

            foreach (var male in males)
            {
                if (male.Interests.Length < maxInterestMatchCounter)
                {
                    continue;
                }

                foreach (var female in females)
                {
                    if (female.Interests.Length < maxInterestMatchCounter)
                    {
                        continue;
                    }

                    var tempCounter = 0;
                    HashSet<string> commonInterests = new HashSet<string>();
                    foreach (var maleInterest in male.Interests)
                    {
                        foreach (var femaleInterest in female.Interests)
                        {
                            if (maleInterest.Equals(femaleInterest) && 
                                !commonInterests.Contains(maleInterest))
                            {
                                tempCounter++;
                                commonInterests.Add(maleInterest);
                            }
                        }
                    }

                    if (tempCounter > maxInterestMatchCounter)
                    {
                        topMale = male;
                        topFemale = female;
                        maxInterestMatchCounter = tempCounter;
                        maxCommonInterests = commonInterests;
                    }
                    else if (tempCounter == maxInterestMatchCounter && male.Name.CompareTo(topMale.Name) < 1)
                    {
                        topMale = male;
                        topFemale = female;
                        maxInterestMatchCounter = tempCounter;
                        maxCommonInterests = commonInterests;
                    }
                }
            }
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var sexString = Console.ReadLine();
                var sex = sexString == "m" ? true : false;
                var m = int.Parse(Console.ReadLine());
                var interests = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var player = new Player()
                {
                    Name = name,
                    Sex = sex,
                    InterestCount = m,
                    Interests = interests,
                };

                if (sex)
                {
                    males.Add(player);
                }
                else
                {
                    females.Add(player);
                }
            }
        }
    }
}
