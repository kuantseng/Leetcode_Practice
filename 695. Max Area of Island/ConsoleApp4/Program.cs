using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][] {
            new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
            new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }};
            Console.WriteLine(MaxAreaOfIsland(input));
            Console.ReadKey();
        }

        public static int MaxAreaOfIsland(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int Max_Land = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //if (Array.Exists(grid[i], element => element == 1) ){                      
                    if (grid[i][j] == 1)
                    {
                        int count = 0;
                        Find_Next_Land(i, j, grid, ref count);
                        Max_Land = Math.Max(Max_Land, count);
                    }
                    //}
                }
            }

            return Max_Land;
        }

        public static void Find_Next_Land(int i, int j, int[][] grid, ref int area)
        {
            grid[i][j] = 0;
            area = area + 1;
            if (i > 0 && grid[i - 1][j] == 1)                   //Find  Up
            {
                Find_Next_Land(i - 1, j, grid, ref area);
            }
            if (i <= grid.Length - 2 && grid[i + 1][j] == 1)    //Find Down
            {
                Find_Next_Land(i + 1, j, grid, ref area);
            }
            if (j <= grid[0].Length - 2 && grid[i][j + 1] == 1) //Find Right
            {
                Find_Next_Land(i, j + 1, grid, ref area);
            }
            if (j > 0 && grid[i][j - 1] == 1)
            {
                Find_Next_Land(i, j - 1, grid, ref area);       //Find Left
            }
        }
    }
}
