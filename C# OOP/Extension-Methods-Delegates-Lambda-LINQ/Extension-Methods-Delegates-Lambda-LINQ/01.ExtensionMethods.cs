namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Text;

    public static class ExtensionSubstring
    {
        // 01. Implement an extension method Substring(int index, int length) for the class StringBuilder 
        //     that returns new StringBuilder and has the same functionality as Substring in the class String.
        public static StringBuilder Substring(this StringBuilder stringBuilder, int startIndex, int length = 0)
        {
            if (length < 0 || stringBuilder.Length < length)
            {
                throw new ArgumentOutOfRangeException("Length is out of range!");
            }

            if (startIndex < 0 || stringBuilder.Length <= startIndex)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }

            if (stringBuilder.Length < startIndex + length)
            {
                throw new IndexOutOfRangeException("The length of the substring exceeds the characters of the StringBuilder after the start index.");
            }

            StringBuilder sb = new StringBuilder(length);

            for (int i = startIndex; i < startIndex + length; i++)
            {
                sb.Append(stringBuilder[i]);
            }

            return sb;
        }
    }
}
