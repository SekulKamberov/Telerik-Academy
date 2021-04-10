namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        private static Dictionary<string, Unit> unitsByNames = new Dictionary<string, Unit>();
        private static OrderedBag<Unit> unitsByAttack = new OrderedBag<Unit>();
        private static Dictionary<string, Bag<Unit>> unitsByType = new Dictionary<string, Bag<Unit>>();

        private static StringBuilder output = new StringBuilder();

        public static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var hasNext = ReadCommand(command);

            while (hasNext)
            {
                command = Console.ReadLine();
                hasNext = ReadCommand(command);
            }

            Console.Write(output.ToString());
        }

        private static bool ReadCommand(string input)
        {
            if (input == "end")
            {
                return false;
            }

            var firstEmptySpaceIndex = input.IndexOf(' ');
            var command = input.Substring(0, firstEmptySpaceIndex);

            var parametars = input.Substring(firstEmptySpaceIndex + 1);
            var paramsSeparated = parametars.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (command.Equals("add"))
            {
                Add(paramsSeparated[0], paramsSeparated[1], int.Parse(paramsSeparated[2]));
                return true;
            }
            else if (command.Equals("find"))
            {
                Find(paramsSeparated[0]);
                return true;
            }
            else if (command.Equals("power"))
            {
                Power(int.Parse(paramsSeparated[0]));
                return true;
            }
            else if (command.Equals("remove"))
            {
                Remove(paramsSeparated[0]);
                return true;
            }

            return false;
        }

        private static void Add(string name, string type, int attack)
        {
            if (name.Length > 30 || type.Length > 40 || attack < 100 || attack > 1000)
            {
                return;
            }

            var unitToAdd = new Unit(name, type, attack);
            if (!unitsByNames.ContainsKey(name))
            {
                unitsByNames[name] = unitToAdd;
            }
            else
            {
                output.AppendLine(string.Format("FAIL: {0} already exists!", name));
                return;
            }

            unitsByAttack.Add(unitToAdd);

            if (!unitsByType.ContainsKey(type))
            {
                unitsByType[type] = new Bag<Unit>();
            }

            unitsByType[type].Add(unitToAdd);

            output.AppendLine(string.Format("SUCCESS: {0} added!", name));
        }

        private static void Remove(string name)
        {
            if (unitsByNames.ContainsKey(name))
            {
                var unit = unitsByNames[name];
                unitsByType[unit.Type].Remove(unit);
                unitsByAttack.Remove(unit);
                unitsByNames.Remove(name);
                output.AppendLine(string.Format("SUCCESS: {0} removed!", name));
            }
            else
            {
                output.AppendLine(string.Format("FAIL: {0} could not be found!", name));
            }
        }

        private static void Power(int numberOfUnits)
        {
            PrintUnitsByAttack(numberOfUnits);
        }

        private static void PrintUnitsByAttack(int numberOfUnits)
        {
            if (!unitsByAttack.Any())
            {
                output.AppendLine(string.Format("RESULT: "));
                return;
            }
            else
            {
                var units = unitsByAttack.Take(numberOfUnits);
                var orderedUnits = units.OrderByDescending(x => x.Attack).ThenBy(x => x.Name);
                output.AppendLine(string.Format("RESULT: {0}", string.Join(", ", orderedUnits)));
            }
        }

        private static void Find(string type)
        {
            var units = new Bag<Unit>();
            if (unitsByType.ContainsKey(type))
            {
                units = unitsByType[type];
            }

            PrintUnits(units);
        }

        private static void PrintUnits(IEnumerable<Unit> units)
        {
            if (!units.Any())
            {
                output.AppendLine(string.Format("RESULT: "));
                return;
            }
            else
            {
                var orderedUnits = units
                    .OrderByDescending(x => x.Attack)
                    .OrderByDescending(x => x.Attack)
                    .ThenBy(x => x.Name)
                    .Take(10);
                output.AppendLine(string.Format("RESULT: {0}", string.Join(", ", orderedUnits)));
            }
        }
    }

    public class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public int CompareTo(Unit other)
        {
            int compare = other.Attack.CompareTo(this.Attack);
            if (compare == 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            else
            {
                return compare;
            }
        }

        public override bool Equals(object obj)
        {
            var otherUnit = obj as Unit;
            if (otherUnit == null)
            {
                return false;
            }

            if (this.Name.Equals(otherUnit.Name)
                && this.Type.Equals(otherUnit.Type)
                && this.Attack.Equals(otherUnit.Attack))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() << 17 ^ this.Type.GetHashCode() << 3 ^ this.Attack.GetHashCode() >> 23;
        }
    }
}
