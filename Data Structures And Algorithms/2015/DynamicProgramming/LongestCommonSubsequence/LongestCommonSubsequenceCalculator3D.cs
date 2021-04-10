namespace LongestCommonSubsequence
{
    using System.Linq;
    using System.Text;

    public static class LongestCommonSubsequenceCalculator3D
    {
        public static int[,,] DrawLongestCommonSequenceMatrix(string height, string width, string depth)
        {
            int x = height.Length;
            int y = width.Length;
            int z = depth.Length;
            int[,,] matrix3D = new int[x + 1, y + 1, z + 1];

            for (int i = 1; i < matrix3D.GetLength(0); i++)
            {
                for (int j = 1; j < matrix3D.GetLength(1); j++)
                {
                    for (int n = 1; n < matrix3D.GetLength(2); n++)
                    {
                        if (height[i - 1] == width[j - 1] && height[i - 1] == depth[n - 1])
                        {
                            matrix3D[i, j, n] = matrix3D[(i - 1), (j - 1), (n - 1)] + 1;
                        }
                        else
                        {
                            int max = matrix3D[i, j - 1, n];

                            if (max < matrix3D[i - 1, j, n])
                            {
                                max = matrix3D[i - 1, j, n];
                            }

                            if (max < matrix3D[i, j, n - 1])
                            {
                                max = matrix3D[i, j, n - 1];
                            }

                            matrix3D[i, j, n] = max;
                        }
                    }
                }
            }

            return matrix3D;
        }

        public static string ExtractSequence(int[,,] matrix, string height, string width, string depth)
        {
            int x = height.Length;
            int y = width.Length;
            int z = depth.Length;
            var stringBuilder = new StringBuilder();
            while (x != 0 && y != 0 && z != 0)
            {
                if (height[x - 1] == width[y - 1] && height[x - 1] == depth[z - 1])
                {
                    stringBuilder.Append(height[x - 1]);
                    x--;
                    y--;
                    z--;
                }
                else if (matrix[x, y, z] == matrix[x - 1, y, z])
                {
                    x--;
                }
                else if (matrix[x, y, z] == matrix[x, y - 1, z])
                {
                    y--;
                }
                else
                {
                    z--;
                }
            }

            return string.Join(string.Empty, stringBuilder.ToString().Reverse());
        }
    }
}