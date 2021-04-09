using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobilePhone
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            //Problem 7: Write a class GSMTest to test the GSM class
            Console.WriteLine("Task 7: Write a class GSMTest to test the GSM class");

            Battery battery = new Battery("LiLon 2200", 20, 5);
            Display display = new Display(5, 1000000000);
            GSM tel1 = new GSM("S5mini", "Samsung");
            GSM tel2 = new GSM("Alpha 5", "Samsung", 600);
            GSM tel3 = new GSM("Xperia Z", "Sony", 700, "Dwayne Johnson", battery, display);

            GSM[] telephones = new GSM[] { tel1, tel2, tel3 };

            foreach (GSM tel in telephones)
            {
                Console.WriteLine(tel);
            }

            Console.WriteLine(GSM.iPhone4S);
            Console.WriteLine(new string('-', 15));

            //Problem 12: Test the call history functionality of the GSM class.

            Console.WriteLine("Task 12: Write a class to test the call history functionality of the GSM class.");

            GSM Lenovo = new GSM("Vibe Z", "Lenovo", 900, null, null, null);
            Call callHistory1 = new Call("0885 111 111", 20, DateTime.Now);
            
            Call callHistory2 = new Call("359 101010", 40);

            List<Call> listOfCalls = new List<Call>();
            listOfCalls.Add(callHistory1);
            listOfCalls.Add(callHistory2);

            foreach (Call call in listOfCalls)
            {
                Console.WriteLine(call);
            }

            tel1.AddCall(callHistory1);
            Console.WriteLine("Total price of calls for {0} {1} is: {2:C}",tel1.Manufacturer ,tel1.Model, tel1.PriceCalc(0.37m));

            tel1.AddCall(callHistory2);
            Console.WriteLine("Total price of calls for {0} {1} is: {2:C}", tel1.Manufacturer, tel1.Model, tel1.PriceCalc(0.37m));

            tel1.RemoveCall();
            Console.WriteLine("Total price of calls after removing a call is {0:C}", tel1.PriceCalc(0.37m));

            tel1.ClearCallHistory();
            Console.WriteLine("Total price after clearing call history is {0:C}", tel1.PriceCalc(0.37m));
        }
    }
}
