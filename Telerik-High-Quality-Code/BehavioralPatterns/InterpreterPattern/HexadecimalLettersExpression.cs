namespace InterpreterPattern
{
    using System;

    public class HexadecimalLettersExpression : Expression
    {
        public override void Interpret(Context context)
        {
            if (context.Input.Length == 0)
            {
                return;
            }

            char lastChar = context.Input[context.Input.Length - 1].ToString().ToUpper()[0];
            bool isLetter = 'A' <= lastChar && lastChar <= 'Z';

            if (isLetter == false)
            {
                return;
            }
            else
            {
                context.Output += (lastChar - 55) * MathPower.Power(16, context.Power);
                this.RemoveLastIndex(context);
                context.Power += 1;
            }
        }
    }
}
