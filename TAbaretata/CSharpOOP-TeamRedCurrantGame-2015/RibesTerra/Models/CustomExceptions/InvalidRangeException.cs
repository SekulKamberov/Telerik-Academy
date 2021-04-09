namespace Models.CustomExceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        private T endRange;

        public InvalidRangeException(string msg)
            : base(msg)
        {
        }

        public InvalidRangeException(string msg, T end, Exception innerEx)
            : base(msg, innerEx)
        {
            this.EndRange = end;
        }

        public InvalidRangeException(string msg, T end)
            : this(msg, end, null)
        {
            this.EndRange = end;
        }

        public T EndRange
        {
            get { return this.endRange; }
            private set { this.endRange = value; }
        }
    }
}
