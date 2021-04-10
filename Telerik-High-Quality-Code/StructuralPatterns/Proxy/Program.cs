namespace Proxy
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var firstStudent = new Student("Pesho");
            var secondStudent = new Student("Gosho");
            var assistant = new MathAssistant(firstStudent);
            assistant.Lecture(new DateTime(2015, 09, 29));
            assistant.Lecture(new DateTime(2015, 09, 28));
            Console.WriteLine(assistant);

            var firstProxyStudent = new StudentProxy("ProxyPesho");
            Console.WriteLine(firstProxyStudent.ProgressFromYearToYear());
            firstProxyStudent.TakeExam();
            Console.WriteLine(firstProxyStudent.ProgressFromYearToYear());
            firstProxyStudent.TakeExam();
            firstProxyStudent.TakeExam();
            firstProxyStudent.TakeExam();
            firstProxyStudent.TakeExam();
            Console.WriteLine(firstProxyStudent.ProgressFromYearToYear());
            Console.WriteLine(firstProxyStudent.StudentCredits());

            var representingStudent = new StudentRepresentative("Ivan");
            representingStudent.Add(secondStudent);
            representingStudent.Add(assistant);
            representingStudent.Display(3);
        }
    }
}
