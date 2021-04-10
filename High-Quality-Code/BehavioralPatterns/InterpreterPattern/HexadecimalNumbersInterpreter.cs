namespace InterpreterPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class HexadecimalNumbersInterpreter
    {
        private readonly IEnumerable<Expression> expressionTree;

        public HexadecimalNumbersInterpreter(IEnumerable<Expression> expressionTree)
        {
            this.expressionTree = expressionTree;
        }

        public void Interpret(Context context)
        {
            if (Regex.IsMatch(context.Input, "^[a-zA-Z0-9]+$") == false)
            {
                throw new ArgumentOutOfRangeException("Letters and numbers only.");
            }

            Console.WriteLine("Current context: Input={0} Output={1}", context.Input, context.Output);

            while (context.Input.Length != 0)
            {
                foreach (Expression expression in this.expressionTree)
                {
                    expression.Interpret(context);
                }

                Console.WriteLine("Current context: Input={0} Output={1}", context.Input, context.Output);
            }
        }
    }
}
