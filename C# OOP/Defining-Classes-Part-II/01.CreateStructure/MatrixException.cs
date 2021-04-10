namespace _01.CreateStructure
{
    using System;

    public class MatrixException : SystemException
    {
        public MatrixException() 
        {
        }

        public MatrixException(string message) : base(message) 
        {
        }

        public MatrixException(string message, Exception innerException) : base(message, innerException) 
        {
        }
    }
}
