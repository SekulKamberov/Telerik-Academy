namespace _01.MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GSM
    {
        //Problem 1: Initialize classes Display, Battery, GSM & Problem 5: Encapsulate all data fields
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;

        public string Model
        {
            get { return model; }
            set
            {
                if (value.Length > 0)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("You must enter Model.");
                }
            }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (value.Length > 0)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("You must enter Model.");
                }
            }
        }
        public decimal? Price
        {
            get { return price; }
            set
            {
                if (value == null || value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The price must be positive number.");
                }
            }
        }
        public string Owner
        {
            get { return owner; }
            set
            {
                if (value == null || value.Length > 0)
                {
                    this.owner = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private Battery battery = new Battery(string.Empty);

        public Battery Battery
        {
            get { return battery; }
            set { this.battery = value; }
        }

        private Display display = new Display();

        public Display Display
        {
            get { return display; }
            set { this.display = value; }
        }

        //Problem 9: Create list of calls history
        private List<Call> callHistory = new List<Call>();
        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { this.callHistory = value; }
        }

        //Problem 2: Define constructors for the classes, model and manufacturer are mandatory
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = null;
            this.owner = null;
        }
        public GSM(string model, string manufacturer, decimal price)
            : this(model, manufacturer)
        {
            this.price = price;
        }
        public GSM(string model, string manufacturer, decimal price, string owner)
            : this(model, manufacturer, price)
        {
            this.owner = owner;
        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery)
            : this(model, manufacturer, price, owner)
        {
            this.battery = battery;
        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
            : this(model, manufacturer, price, owner, battery)
        {
            this.display = display;
        }
        //after task 12
        //public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display, Call callhistory)
        //    : this(model, manufacturer, price, owner, battery, display)
        //{
        //    this.callHistory = callHistory;
        //}

        //Problem 6: Add field and property IPhone4S
        public static GSM iPhone4S = new GSM("IPhone4S", "Apple", 900, "Dwayne Johnson",
            new Battery("LiIon", 20, 5), new Display(4, 160000000));

        public GSM IPhone4S
        {
            get { return GSM.iPhone4S; }
            private set { }
        }

        //Problem 4: Override the ToString() method
        public override string ToString()
        {
            StringBuilder gsmInfo = new StringBuilder();
            gsmInfo.AppendFormat("Model: {0}\n", this.model);
            gsmInfo.AppendFormat("Manufacturer: {0}\n", this.manufacturer);
            gsmInfo.AppendFormat("Price: {0}\n", this.price);
            gsmInfo.AppendFormat("Owner: {0}\n", this.owner);
            gsmInfo.AppendFormat("Battery Model: {0}\n", this.Battery.Model);
            gsmInfo.AppendFormat("Battery Idle Hours: {0}\n", this.Battery.HoursIdle);
            gsmInfo.AppendFormat("Battery Idle Talk: {0}\n", this.Battery.HoursTalk);
            gsmInfo.AppendFormat("Display Size: {0}\n", this.Display.Size);
            gsmInfo.AppendFormat("Display colors: {0}\n", this.Display.Colors);

            return gsmInfo.ToString();
        }

        //Problem 10: Add, delete, clear calls history & Problem 11: Calculating price of calls

        public void AddCall(Call currentCall)
        {
            this.callHistory.Add(currentCall);
        }
        public void RemoveCall()
        {
            decimal bestDuration = decimal.MinValue;
            decimal currentDuration = 0;
            int index = 0;
            int searchedIndex = 0;
            for (int i = 0; i < callHistory.Count; i++)
            {
                currentDuration = 0;
                for (int j = 0; j < callHistory.Count; j++)
                {
                    if (callHistory[i].DurationCall > callHistory[j].DurationCall)
                    {
                        currentDuration = callHistory[i].DurationCall.Value;
                        index = i;
                    }
                }
                if (currentDuration > bestDuration)
                {
                    bestDuration = currentDuration;
                    searchedIndex = index;
                }
            }
            callHistory.RemoveAt(searchedIndex);
        }
        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }
        public decimal PriceCalc(decimal pricePerMinute)
        {
            decimal totalMinutes = 0;
            decimal totalPrice = 0m;
            foreach (var seconds in callHistory)
            {
                totalMinutes += (decimal)(seconds.DurationCall) / 60;
            }
            return totalPrice = totalMinutes * pricePerMinute;
        }
    }
}
