namespace _01.MobilePhoneDeviceClasses
{
    using System;

    public class GsmTest
    {
        public static void Main(string[] args)
        {
            Battery batteryInformation = new Battery("lithium", 240, 24, BatteryType.LiIon);
            Display displayInformation = new Display(5, 256);

            GSM gsm = new GSM("Nokia-1100", "NOKIA", 299, "Nakov", batteryInformation, displayInformation);
            Console.WriteLine(" Model: {0}\n Manufacturer: {1}\n Price: {2}\n Owner: {3}\n Battery model: {4}\n Hours idle: {5}\n Hours talk: {6}\n Display size: {7}\n Display colors: {8}\n", gsm.Model, gsm.Manufacturer, gsm.Price, gsm.Owner, gsm.BatteryInfo.Model, gsm.BatteryInfo.HoursIdle, gsm.BatteryInfo.HoursTalk, gsm.DisplayInfo.Size, gsm.DisplayInfo.NumberOfColors);

            GSM nokia1000 = new GSM("N1000", "NOKIA", 399, "Svetlin", new Battery("Varta", 320, 35, BatteryType.NiMH), new Display(6, 1024));

            Console.WriteLine(" Model: {0}\n Manufacturer: {1}\n Price: {2}\n Owner: {3}\n Battery model: {4}\n Hours idle: {5}\n Hours talk: {6}\n Display size: {7}\n Display colors: {8}", nokia1000.Model, nokia1000.Manufacturer, nokia1000.Price, nokia1000.Owner, nokia1000.BatteryInfo.Model, nokia1000.BatteryInfo.HoursIdle, nokia1000.BatteryInfo.HoursTalk, nokia1000.DisplayInfo.Size, nokia1000.DisplayInfo.NumberOfColors);

            Console.WriteLine(nokia1000);

            Console.WriteLine(GSM.IPhone4S);

            Call firstCall = new Call(DateTime.Now, "08989892222", 120);
            Call secondCall = new Call(DateTime.Now, "0898983333", 240);
            Call thirdCall = new Call(DateTime.Now, "08989894444", 420);
            GSM.IPhone4S.AddCall(firstCall);
            GSM.IPhone4S.AddCall(secondCall);
            GSM.IPhone4S.AddCall(thirdCall);
            Console.WriteLine("===CALL HISTORY===");
            foreach (var call in GSM.IPhone4S.CallHistory)
            {
                Console.WriteLine(string.Format("DateTime: {0}\nDialed number: {1}\nDuration: {2}\n", call.DateTimeOfCall, call.DialedNumber, call.Duration));
            }

            double callPricePerMinute = 0.37;
            double callsTotalPrice = GSM.IPhone4S.CalculateCallsPrice(callPricePerMinute);
            Console.WriteLine("Total price: {0:C}", callsTotalPrice);
            GSM.IPhone4S.RemoveCall(secondCall);
            Console.WriteLine("===CALL HISTORY===");
            foreach (var call in GSM.IPhone4S.CallHistory)
            {
                Console.WriteLine(string.Format("DateTime: {0}\nDialed number: {1}\nDuration: {2}\n", call.DateTimeOfCall, call.DialedNumber, call.Duration));
            }

            double callsTotalPriceAfterRemove = GSM.IPhone4S.CalculateCallsPrice(callPricePerMinute);
            Console.WriteLine("Total price: {0:C}", callsTotalPriceAfterRemove);
        }
    }
}
