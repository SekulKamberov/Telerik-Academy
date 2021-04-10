namespace _01.MobilePhoneDeviceClasses
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        private const string DefaultModel = "Nokia 1100";
        private const string DefaultManufacturer = "Nokia"; 
        private static GSM iPhone4S = new GSM("IPhone4S", "Apple", 1999, "Me", new Battery(), new Display());
        private string model;
        private string manufacturer;
        private int price;
        private string owner;
        private Battery battery;
        private Display display;
        private IList<Call> callHistory;

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.BatteryInfo = battery;
            this.DisplayInfo = display;
            this.CallHistory = new List<Call>();
        }

        public GSM()
            : this(DefaultModel, DefaultManufacturer, 0, null, null, null)
        {
            this.CallHistory = new List<Call>();
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }

            set
            {
                iPhone4S = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(string.Empty);
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Model too short! It should be at least 2 letters");
                }

                if (value.Length >= 50)
                {
                    throw new ArgumentException("Model too long! It should be less than 50 letters");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be empty!");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Model too short! It should be at least 2 letters");
                }

                if (value.Length >= 50)
                {
                    throw new ArgumentException("Model too long! It should be less than 50 letters");
                }

                foreach (char ch in value)
                {
                    if (!this.IsLetterAllowedInNames(ch))
                    {
                        throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
                    }
                }

                this.manufacturer = value;
            }
        }

        public int Price
        {
            get 
            {
                return this.price; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value must be greater than 0");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Owner cannot be empty!");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("Owner too short! It should be at least 2 letters");
                }

                if (value.Length >= 50)
                {
                    throw new ArgumentException("Owner too long! It should be less than 50 letters");
                }

                foreach (char ch in value)
                {
                    if (!this.IsLetterAllowedInNames(ch))
                    {
                        throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
                    }
                }

                this.owner = value;
            }
        }

        public Battery BatteryInfo
        {
            get
            {
                return this.battery;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Baterry is null.");
                }

                this.battery = value;
            }
        }

        public Display DisplayInfo
        {
            get
            {
                return this.display;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Display is null.");
                }

                this.display = value;
            }
        }

        public IList<Call> CallHistory 
        {
            get
            {
                return this.callHistory;
            }

            set
            {
                this.callHistory = value;
            }
        }

        public override string ToString()
        {
            return string.Format("===GSM===\nModel: {0}\nManufacturer: {1}\nOwner: {2}\nPrice: {3}\n{4}\n{5}", this.Model, this.Manufacturer, this.Owner, this.Price, this.BatteryInfo.ToString(), this.DisplayInfo.ToString());
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public bool RemoveCall(Call call)
        {
            return this.CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public double CalculateCallsPrice(double priceOfOneMinuteCall)
        {
            double price = 0;

            foreach (var call in this.callHistory)
            {
                price += priceOfOneMinuteCall * call.Duration / 60;
            }

            return price;
        }

        private bool IsLetterAllowedInNames(char ch)
        {
            bool isAllowed =
                char.IsLetter(ch) || ch == '-' || ch == ' ';
            return isAllowed;
        }
    }
}
