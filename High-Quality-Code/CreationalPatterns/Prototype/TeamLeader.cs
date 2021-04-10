namespace Prototype
{
    using System.Collections.Generic;
    using System.Text;

    public class TeamLeader : Employee
    {
        public TeamLeader(string name, int age)
            : base(name, age)
        {
            this.Team = new List<Employee>();
        }

        public List<Employee> Team { get; set; }

        public override Employee Clone()
        {
            var clone = new TeamLeader(this.Name, this.Age);

            for (int i = 0; i < this.Team.Count; i++)
            {
                clone.Team.Add(this.Team[i].Clone());
            }
            
            return clone;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Leader: ");
            sb.AppendLine(base.ToString());
            sb.AppendLine("Team: ");
            foreach (var employee in this.Team)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString();
        }
    }
}
