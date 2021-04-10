namespace InterpreterPattern
{
    public class NumbersExpression : Expression
    {
        public override void Interpret(Context context)
        {
            if (context.Input.Length == 0)
            {
                return;
            }

            char lastChar = context.Input[context.Input.Length - 1];
            bool isNumber = char.IsDigit(lastChar);

            if (isNumber == false)
            {
                return;
            }

            context.Output += (lastChar - 48) * MathPower.Power(16, context.Power);
            context.Power += 1;
            this.RemoveLastIndex(context);
        }
    }
}
