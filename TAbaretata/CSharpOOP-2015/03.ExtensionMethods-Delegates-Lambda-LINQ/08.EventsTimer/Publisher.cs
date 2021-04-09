namespace _08.EventsTimer
{
    using System;
    using System.Threading;

    public delegate void TimeElapsedEventHandler(object sender, Publisher e);

    public class Publisher : EventArgs
    {
        public event EventHandler RaiseTimerEvent;

        //After completing this method is raised an event
        public void Start(int ticks, int interval)
        {
            int start = 0;
            while (start <= interval)
            {
                Thread.Sleep(start * 1000);
                start += ticks;
                OnRaiseTimerEvent();
            }
        }

        protected void OnRaiseTimerEvent()
        {
            EventHandler e = RaiseTimerEvent;
            if (e!= null)
            {
                e(this, null);
            }
        }
    }
}
