namespace Proxy
{
    public interface IStudent
    {
        bool ProgressFromYearToYear();

        int StudentCredits();

        void TakeExam();

        void Add(IStudent student);

        void Remove(IStudent student);

        void Display(int depth);
    }
}
