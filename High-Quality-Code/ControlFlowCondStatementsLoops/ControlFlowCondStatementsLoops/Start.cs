namespace ControlFlowCondStatementsLoops
{
    using System;

    public class Start
    {
        public static void Main()
        {
            // Task 2.1
            var potato = new Potato();
            if (potato != null && potato.IsPeeled && potato.IsFresh)
            {
                Cook(potato);
            }

            // Task 2.2
            var x = 10;
            var minX = 23;
            var maxX = 54;
            var y = 33;
            var minY = 1;
            var maxY = 546;
            var shouldVisitCell = true;

            var isXinRange = minX <= x && x <= maxX;
            var isYinRange = minY <= y && y <= maxY;

            if (isXinRange && isYinRange && shouldVisitCell)
            {
                VisitCell();
            }

            // Task 3
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 12, 13, 14, 15, 16, 15, 34, 43, 54, 11 };
            var expectedValue = 11;
            var isExpectedValue = false;

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0 && array[i] == expectedValue)
                {
                    isExpectedValue = true;
                    break;
                }
            }

            // More code here
            if (isExpectedValue)
            {
                Console.WriteLine("Value Found");
            }
        }

        private static void VisitCell()
        {
            throw new System.NotImplementedException();
        }

        private static void Cook(Potato potato)
        {
            throw new System.NotImplementedException();
        }
    }
}
