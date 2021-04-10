namespace CodeFormatting
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    internal class Program
    {
        private static StringBuilder stringBuilder = new StringBuilder();
        private static EventHolder events = new EventHolder();

        public static void Main(string[] args)
        {
            while (ExecuteNextCommand()) 
            {
            }

            Console.WriteLine(stringBuilder);
        }

        private static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            if (command[0].Equals('A'))
            {
                AddEvent(command);

                return true;
            }

            if (command[0].Equals('D'))
            {
                DeleteEvents(command);

                return true;
            }

            if (command[0].Equals('L'))
            {
                ListEvents(command);
                
                return true;
            }

            if (command[0].Equals('E'))
            {
                return false;
            }

            return false;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            events.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            events.Delete(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);
            events.Add(date, title, location);
        }

        private static void GetParameters(string command, string type, out DateTime date, out string title, out string location)
        {
            date = GetDate(command, type);
            int firstPipeIndex = command.IndexOf('|');
            int lastPipeIndex = command.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                title = command.Substring(firstPipeIndex + 1).Trim();
                location = string.Empty;
            }
            else
            {
                title = command.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                location = command.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private static DateTime GetDate(string command, string type)
        {
            DateTime date = DateTime.Parse(command.Substring(type.Length + 1, 20));

            return date;
        }

        internal static class Messages
        {
            public static void Add()
            {
                stringBuilder.Append("Event added\n");
            }

            public static void Delete(int count)
            {
                if (count == 0)
                {
                    NoEventsFound();
                }
                else
                {
                    stringBuilder.AppendFormat("{0} events deleted\n", count);
                }
            }

            public static void NoEventsFound()
            {
                stringBuilder.Append("No events found\n");
            }

            public static void Print(Event eventToPrint)
            {
                if (eventToPrint != null)
                {
                    stringBuilder.Append(eventToPrint + "\n");
                }
            }
        }

        internal class EventHolder
        {
            private MultiDictionary<string, Event> eventsByTitleDictionary = new MultiDictionary<string, Event>(true);
            private OrderedBag<Event> eventsOrderedByDate = new OrderedBag<Event>();

            public void Add(DateTime date, string title, string location)
            {
                Event newEvent = new Event(date, title, location);
                this.eventsByTitleDictionary.Add(title.ToLower(), newEvent);
                this.eventsOrderedByDate.Add(newEvent);
                Messages.Add();
            }

            public void Delete(string eventTitle)
            {
                string titleToLower = eventTitle.ToLower();
                int eventsRemoved = 0;

                foreach (var eventToRemove in this.eventsByTitleDictionary[titleToLower])
                {
                    this.eventsOrderedByDate.Remove(eventToRemove);
                    eventsRemoved++;
                }

                this.eventsByTitleDictionary.Remove(titleToLower);
                Messages.Delete(eventsRemoved);
            }

            public void ListEvents(DateTime date, int count)
            {
                OrderedBag<Event>.View eventsToShow = this.eventsOrderedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
                int eventsShowed = 0;

                foreach (var eventToShow in eventsToShow)
                {
                    if (eventsShowed == count)
                    {
                        break;
                    }

                    Messages.Print(eventToShow);
                    eventsShowed++;
                }

                if (eventsShowed == 0)
                {
                    Messages.NoEventsFound();
                }
            }
        }
    }
}