namespace _08.EventsTimer
{
    using System;
    using System.Threading;

    public class Handler
    {
        public Handler(Publisher pub)
        {
            pub.RaiseTimerEvent += HandleTimerEvent;
        }

        //When event is raised this method is called
        public static void HandleTimerEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Event Raised: {0}", DateTime.Now);
        }
    }
}
