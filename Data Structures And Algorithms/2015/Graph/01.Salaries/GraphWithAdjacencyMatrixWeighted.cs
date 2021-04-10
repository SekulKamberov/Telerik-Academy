namespace _01.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithAdjacencyMatrixWeighted
    {
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private bool[,] matrix;
        private bool[] visitedEdges;
        private List<int> sortedEdges;
        private int[] workersSalaries;

        public GraphWithAdjacencyMatrixWeighted(int n)
        {
            this.n = n;
            this.matrix = new bool[n, n];
            this.ParseEdges();
        }

        public int SumOfSalaries()
        {
            this.workersSalaries = new int[this.n];
            this.SortTopologicaly();
            int sum = 0;

            for (int i = this.sortedEdges.Count - 1; i >= 0; i--)
            {
                var workerIndex = this.sortedEdges[i];
                var salary = this.EvaluateSalary(workerIndex);
                sum += salary;
            }

            return sum;
        }

        public void PrintTopologicalSort()
        {
            if (this.sortedEdges != null)
            {
                foreach (int node in this.sortedEdges)
                {
                    Console.Write("{0} ", node + 1);
                }
            }
        }

        public void Print()
        {
            Console.Write("\t");
            for (int i = 0; i < this.n; i++)
            {
                Console.Write("{0}\t", i + 1);
            }

            Console.WriteLine();

            for (int v1 = 0; v1 < this.matrix.GetLength(0); v1++)
            {
                Console.Write("{0}|\t", v1 + 1);
                for (int v2 = 0; v2 < this.matrix.GetLength(1); v2++)
                {
                    Console.Write("{0}\t", this.matrix[v1, v2] == true ? 'Y' : 'N');
                }

                Console.WriteLine();
            }
        }

        private int EvaluateSalary(int workerIndex)
        {
            int salary = 0;
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                if (this.matrix[workerIndex, i])
                {
                    salary += this.workersSalaries[i];
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            this.workersSalaries[workerIndex] = salary;

            return salary;
        }

        private void SortTopologicaly()
        {
            this.visitedEdges = new bool[this.n];
            this.sortedEdges = new List<int>();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                if (this.visitedEdges[i] == false)
                {
                    this.FindNodeWithoutIncomingEdgesDFS(i);
                }
            }

            this.sortedEdges.Reverse();
        }

        private void FindNodeWithoutIncomingEdgesDFS(int startIndex)
        {
            this.visitedEdges[startIndex] = true;

            for (int k = 0; k < this.matrix.GetLength(0); k++)
            {
                if ((this.matrix[startIndex, k] != false) && (this.visitedEdges[k] == false))
                {
                    this.FindNodeWithoutIncomingEdgesDFS(k);
                }
            }

            this.sortedEdges.Add(startIndex);
        }

        private void ParseEdges()
        {
            for (int v1 = 0; v1 < this.matrix.GetLength(0); v1++)
            {
                var edge = Console.ReadLine();

                for (int v2 = 0; v2 < this.matrix.GetLength(0); v2++)
                {
                    bool isBoss = edge[v2] == 'Y';
                    this.matrix[v1, v2] = isBoss;
                }
            }
        }
    }
}