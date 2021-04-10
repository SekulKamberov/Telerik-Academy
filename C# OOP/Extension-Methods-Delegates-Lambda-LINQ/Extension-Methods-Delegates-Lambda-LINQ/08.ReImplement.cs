namespace Events
{
    using System;
    using System.Threading;

    // 08. * Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.
    public class MessageEventArgs : EventArgs
    {
        private string message;

        public MessageEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }
    }

    public class Printer
    {
        private static int counter;

        private int id;

        public Printer(TimerWithHandler timer)
        {
            this.Id = counter;
            counter++;
            timer.RaiseMessageEvent += this.PrintEvent;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

        public void PrintEvent(object sender, MessageEventArgs args)
        {
            Console.WriteLine("Printer (ID:{0}) received message: {1}", this.Id, args.Message);
        }
    }

    public class TimerWithHandler
    {
        public event EventHandler<MessageEventArgs> RaiseMessageEvent;

        public void RepeatMessage(int stepInSeconds, long durationInSeconds)
        {
            MessageEventArgs messageEventArgs = new MessageEventArgs("Message");

            EventHandler<MessageEventArgs> handler = this.RaiseMessageEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                long start = 1;

                while (start <= durationInSeconds)
                {
                    messageEventArgs.Message = string.Format("at {0}", DateTime.Now.ToString());

                    // Use the () operator to raise the event.
                    handler(this, messageEventArgs);

                    Thread.Sleep(stepInSeconds * 1000);
                    start += stepInSeconds;
                }
            }            
        }
    }
}