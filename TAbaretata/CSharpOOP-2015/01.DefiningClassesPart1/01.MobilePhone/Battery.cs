using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobilePhone
{

    class Battery
    {
        //Problem 3: Set enum BatteryType
        public enum BatteryType
        { LiIon, NiMH, NiCd, }

        //Problem 1: Initialize classes Display, Battery, GSM & Problem 5: Encapsulate all data fields
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;

        public string Model
        {
            get { return model; }
            set
            {
                if (value == null || value.Length > 0)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("You must enter battery model.");
                }
            }
        }
        public double? HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value == null || value > 0)
                {
                    this.hoursIdle = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The hours value must be positive number.");
                }
            }
        }
        public double? HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value == null || value > 0)
                {
                    this.hoursTalk = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The hours value must be positive number.");
                }
            }
        }

        //Problem 2: Define constructors for the classes, model and manufacturer are mandatory
        public Battery(string model)
        {
            this.model = model;
            this.hoursIdle = null;
            this.hoursTalk = null;
        }
        public Battery(string model, double hoursIdle, double hoursTalk)
            : this(model)
        {
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }
    }
}
