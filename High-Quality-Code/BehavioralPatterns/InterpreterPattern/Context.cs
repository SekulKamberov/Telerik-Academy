namespace InterpreterPattern
{
    public class Context
    {
        public Context(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }

        public int Output { get; set; }

        public int Power { get; set; }
    }
}