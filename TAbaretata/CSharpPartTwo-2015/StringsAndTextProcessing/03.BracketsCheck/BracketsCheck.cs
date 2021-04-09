using System;

/*  Write a program to check if in a given expression the brackets are put correctly.
    Example of correct expression: ((a+b)/5-d). 
    Example of incorrect expression: )(a+b)).  
 */

class BracketsCheck
{
    static bool CheckExpression(string expression)
    {
        const char leftBracket = '(';
        const char rightBracket = ')';
        uint bracketCount = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            switch (expression[i])
            {
                case leftBracket: bracketCount++; continue;
                case rightBracket: bracketCount--; continue;
                default: continue;
            }
        }
        if (bracketCount == 0)
        {
            return true;
        }
        return false;
    }

    static void Main()
    {
        string expression = Console.ReadLine();

        Console.WriteLine(CheckExpression(expression) ? "Valid expression" : "Incorrect expression");
    }
}
