namespace InterpreterPattern
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var hexadecimalNumbersInterpreter =
                new HexadecimalNumbersInterpreter(
                    new List<Expression>
                        {
                            new HexadecimalLettersExpression(),
                            new NumbersExpression(),
                        });

            const string Input = "Ff";
            var context = new Context(Input);

            hexadecimalNumbersInterpreter.Interpret(context);

            Console.WriteLine();
            Console.WriteLine("Final: {0} = {1}", Input, context.Output);
        }
    }
}
