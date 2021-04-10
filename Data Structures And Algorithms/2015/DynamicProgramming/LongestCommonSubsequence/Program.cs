namespace LongestCommonSubsequence
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var firstString = "ABCABD";
            var secondString = "ABABF";
            var lcsMatrix = LongestCommonSubsequenceCalculator.DrawLongestCommonSequenceMatrix(firstString, secondString);
            LongestCommonSubsequenceCalculator.PrintMatrix(lcsMatrix, firstString, secondString);
            Console.WriteLine();
            Console.WriteLine(LongestCommonSubsequenceCalculator.ExtractSequence(lcsMatrix, firstString, secondString));

            var thirdString = "CDAGBH";
            var matrix3D = LongestCommonSubsequenceCalculator3D.DrawLongestCommonSequenceMatrix(firstString, secondString, thirdString);
            Console.WriteLine();
            Console.WriteLine(LongestCommonSubsequenceCalculator3D.ExtractSequence(matrix3D, firstString, secondString, thirdString));
        }
    }
}
