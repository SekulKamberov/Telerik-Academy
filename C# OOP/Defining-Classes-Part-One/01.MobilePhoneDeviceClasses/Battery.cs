namespace _01.MobilePhoneDeviceClasses
{
    using System;

    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType type;

        public Battery() 
            : this(null, 0, 0, BatteryType.UNKNOWN)
        {
        }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Model is empty.");
                }

                this.model = value;
            }
        }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative idle hours!");
                }

                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative talk hours!");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            return string.Format("===Battery===\nModel: {0}\nIdle: {1}\nTalk: {2}\nType: {3}", this.Model, this.HoursIdle, this.HoursTalk, this.Type);
        }
    }
}
