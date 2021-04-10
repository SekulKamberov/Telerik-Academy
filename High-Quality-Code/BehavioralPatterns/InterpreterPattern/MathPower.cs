namespace InterpreterPattern
{
    public static class MathPower
    {
        public static int Power(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else
            {
                return number * Power(number, power - 1);
            }
        }
    }
}
