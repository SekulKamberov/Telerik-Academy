namespace LongestSequence
{
    using System;

    public class Sequence
    {
        private int[] numbers;

        public Sequence(int[] numbers)
        {
            this.numbers = numbers;
        }

        public int[] LongestIncreasingSet()
        {
            var sequencesCount = new int[this.numbers.Length];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCount[j];
                    if (previousNumber < currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                    }
                }

                sequencesCount[i] = maxSequenceCount;
            }

            return sequencesCount;
        }

        public int[] LongestIncreasingSetWithEquals()
        {
            var sequencesCount = new int[this.numbers.Length];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCount[j];
                    if (previousNumber <= currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                    }
                }

                sequencesCount[i] = maxSequenceCount;
            }

            return sequencesCount;
        }

        public int[] LongestDecreasingSet()
        {
            var sequencesCount = new int[this.numbers.Length];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCount[j];
                    if (previousNumber > currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                    }
                }

                sequencesCount[i] = maxSequenceCount;
            }

            return sequencesCount;
        }

        public int[] LongestDecreasingSetWithEquals()
        {
            var sequencesCount = new int[this.numbers.Length];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCount[j];
                    if (previousNumber >= currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                    }
                }

                sequencesCount[i] = maxSequenceCount;
            }

            return sequencesCount;
        }

        public int[,] LongestIncreasingSetAndPath()
        {
            var sequencesCountAndPath = new int[this.numbers.Length, 2];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                var previousNumberIndex = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCountAndPath[j, 0];
                    if (previousNumber < currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                        previousNumberIndex = j;
                    }
                }

                sequencesCountAndPath[i, 0] = maxSequenceCount;
                sequencesCountAndPath[i, 1] = previousNumberIndex;
            }

            return sequencesCountAndPath;
        }

        public int[,] LongestIncreasingSetAndPathWithEquals()
        {
            var sequencesCountAndPath = new int[this.numbers.Length, 2];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                var previousNumberIndex = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCountAndPath[j, 0];
                    if (previousNumber <= currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                        previousNumberIndex = j;
                    }
                }

                sequencesCountAndPath[i, 0] = maxSequenceCount;
                sequencesCountAndPath[i, 1] = previousNumberIndex;
            }

            return sequencesCountAndPath;
        }

        public int[,] LongestDecreasingSetAndPath()
        {
            var sequencesCountAndPath = new int[this.numbers.Length, 2];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                var previousNumberIndex = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCountAndPath[j, 0];
                    if (previousNumber > currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                        previousNumberIndex = j;
                    }
                }

                sequencesCountAndPath[i, 0] = maxSequenceCount;
                sequencesCountAndPath[i, 1] = previousNumberIndex;
            }

            return sequencesCountAndPath;
        }

        public int[,] LongestDecreasingSetAndPathWithEquals()
        {
            var sequencesCountAndPath = new int[this.numbers.Length, 2];

            for (int i = 0; i < this.numbers.Length; i++)
            {
                var maxSequenceCount = 1;
                var currentNumber = this.numbers[i];
                var previousNumberIndex = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = this.numbers[j];
                    var previousSequenceCount = sequencesCountAndPath[j, 0];
                    if (previousNumber >= currentNumber && previousSequenceCount >= maxSequenceCount)
                    {
                        maxSequenceCount = previousSequenceCount + 1;
                        previousNumberIndex = j;
                    }
                }

                sequencesCountAndPath[i, 0] = maxSequenceCount;
                sequencesCountAndPath[i, 1] = previousNumberIndex;
            }

            return sequencesCountAndPath;
        }
    }
}
