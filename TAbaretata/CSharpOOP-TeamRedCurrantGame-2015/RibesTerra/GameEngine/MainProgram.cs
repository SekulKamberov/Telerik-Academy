namespace GameEngine
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Models.Interfaces;
    using Models.Gear.Items;

    public class MainProgramClass
    {
        public static void Main()
        {
            Engine engine = InitializeEngine();
            StartOperations(engine);
        }

        private static void StartOperations(Engine engine)
        {
            Console.WriteLine(ConsoleMessageConstants.EnterNameMessage);
            string input = Console.ReadLine();
            while (input.ToLower() != "quit")
            {
                engine.ParseCommand(input);
                input = Console.ReadLine();
            }
        }

        private static Engine InitializeEngine()
        {
            return new Engine();
        }
    }
}
