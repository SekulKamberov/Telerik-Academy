namespace InterpreterPattern
{
    public abstract class Expression
    {
        public abstract void Interpret(Context context);

        protected void RemoveLastIndex(Context context)
        {
            if (context.Input.Length > 1)
            {
                context.Input = context.Input.Substring(0, context.Input.Length - 1);
            }
            else
            {
                context.Input = string.Empty;
            }
        }
    }
}
