namespace _01.MobilePhoneDeviceClasses
{
    using System;

    public class Call
    {
        private DateTime dateTimeOfCall;
        private string dialedNumber;
        private int duration;

        public Call(DateTime dateTimeOfCall, string dialedNumber, int duration)
        {
            this.DateTimeOfCall = dateTimeOfCall;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public DateTime DateTimeOfCall
        {
            get
            {
                return this.dateTimeOfCall;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null datetime");
                }

                this.dateTimeOfCall = value;
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Dialed number null ot empty!");
                }

                this.dialedNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid duration!");
                }

                this.duration = value;
            }
        }
    }
}
