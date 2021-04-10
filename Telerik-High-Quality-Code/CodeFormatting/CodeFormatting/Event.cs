namespace CodeFormatting
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event otherEvent = obj as Event;
            int compareByDate = this.Date.CompareTo(otherEvent.Date);

            if (compareByDate == 0)
            {
                int compareByTitle = this.Title.CompareTo(otherEvent.Title);

                if (compareByTitle == 0)
                {
                    int compareByLocation = this.Location.CompareTo(otherEvent.Location);

                    return compareByLocation;
                }
                else
                {
                    return compareByTitle;
                }
            }
            else
            {
                return compareByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringBuilder.Append(" | " + this.Title);
            bool isLocationValid = this.Location != null && this.Location != string.Empty;

            if (isLocationValid)
            {
                stringBuilder.Append(" | " + this.Location);
            }

            return stringBuilder.ToString();
        }
    }
}