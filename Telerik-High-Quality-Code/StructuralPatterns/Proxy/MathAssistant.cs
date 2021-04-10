namespace Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Decorator Pattern
    /// </summary>
    public class MathAssistant : Assistant
    {
        private readonly List<DateTime> schedule = new List<DateTime>();

        public MathAssistant(Student student)
            : base(student)
        {
        }

        public void Lecture(DateTime timeOfTheLecture)
        {
            this.schedule.Add(timeOfTheLecture);
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("SCHEDULE");
            foreach (var timeOfLecture in this.schedule)
            {
                sb.AppendLine(string.Format("DateTime: {0}", timeOfLecture));
            }

            return sb.ToString();
        }
    }
}
