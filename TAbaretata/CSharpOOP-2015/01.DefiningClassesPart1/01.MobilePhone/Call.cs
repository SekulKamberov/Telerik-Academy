using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobilePhone
{
    class Call
    {
        //Problem 8: Create class Call.It should contain date, time, dialed phone number and duration (in seconds).

        private DateTime? date;
        private string dialedNumber;
        private ulong? durationCall;

        public DateTime? Date
        {
            get { return date; }
            set
            {
                try
                {
                    this.date = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Date format is invalid.");
                }
            }
        }
        public string DialedNumber
        {
            get { return dialedNumber; }
            set { dialedNumber = value; }
        }
        public ulong? DurationCall
        {
            get { return durationCall; }
            set { durationCall = value; }
        }

        public Call()
        {
            this.dialedNumber = null;
            this.durationCall = null;
            this.date = null;
        }
        public Call(string dialedNumber, ulong durationCall)
            : this()
        {
            this.dialedNumber = dialedNumber;
            this.durationCall = durationCall;
        }
        public Call(string dialedNumber, ulong durationCall, DateTime date)
            : this(dialedNumber, durationCall)
        {
            this.date = date;
        }

        public override string ToString()
        {
            StringBuilder callInfo = new StringBuilder();
            callInfo.AppendFormat("Dialed number: {0}\n", this.dialedNumber);
            callInfo.AppendFormat("Duration of call: {0}\n", this.durationCall);
            callInfo.AppendFormat("Date and time of call: {0}\n", this.date);

            return callInfo.ToString();
        }
    }
}
