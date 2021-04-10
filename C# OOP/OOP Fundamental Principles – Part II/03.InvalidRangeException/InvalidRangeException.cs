namespace _03.InvalidRangeException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T start;
        private T end;

        public InvalidRangeException(string message, T start, T end, Exception innerException) 
            : base(message, innerException)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(T start, T end)
            : this(null, start, end, null)
        {
        }

        public InvalidRangeException(string message, T start, T end)
            : this(message, start, end, null)
        {
        }

        public T End
        {
            get { return this.end; }
            set { this.end = value; }
        }

        public T Start
        {
            get { return this.start; }
            set { this.start = value; }
        }
    }
}
