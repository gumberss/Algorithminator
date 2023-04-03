using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.Algorithms.DFS
{
    // https://leetcode.com/problems/unique-paths-iii/description/
    internal class Dfs
    {
        public void Test()
        {
            var grid = new int[][] {
                new int[] { 0,0,1 },
                new int[] { 0,0,2 },
            };


            var placesCount = grid
                .SelectMany(x => x)
                .Where(x => new[] { 0, 1, 2 }.Contains(x))
                .Count();


            var uniquePaths = DepthSearch(grid, StartPosition(grid), new int[0][], 2)
                .Where(x => x.Length == placesCount)
                .Count();
        }


        public int[] StartPosition(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) return new[] { i, j };
                }
            }
            return null;
        }

        public int PositionValue(int[][] grid, int[] position)
        {
            return grid[position[0]][position[1]];
        }

        public bool HasObstacle(int[][] grid, int[] position)
            => grid[position[0]][position[1]] == -1;

        public bool AlreadyVisited(int[][] grid, int[] position)
            => grid[position[0]][position[1]] == 1;

        public bool CanMove(int[][] grid, int[] position)
            => position[0] <= grid.Length - 1 && position[0] >= 0
            && position[1] <= grid[0].Length - 1 && position[1] >= 0
            && !HasObstacle(grid, position)
            && !AlreadyVisited(grid, position);

        public int[][] NextPositions(int[] currentPosition)
        {
            var moveUpPosition = new[] { currentPosition[0], currentPosition[1] - 1 };
            var moveRightPosition = new[] { currentPosition[0] + 1, currentPosition[1] };
            var moveDownPosition = new[] { currentPosition[0], currentPosition[1] + 1 };
            var moveLeftPosition = new[] { currentPosition[0] - 1, currentPosition[1] };

            return new int[][] { moveUpPosition, moveRightPosition, moveDownPosition, moveLeftPosition };
        }

        public int[][] ClonePositionArray(int[][] arr)
            => arr.Select(x => x != null ? new int[] { x[0], x[1] } : x).ToArray();

        public int[][] CloneGridArray(int[][] arr)
        {
            var newArr = new int[arr.Length][];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = new int[arr[i].Length];

                for (int j = 0; j < arr[i].Length; j++)
                    newArr[i][j] = arr[i][j];
            }

            return newArr;
        }

        public int[][] Visit(int[][] grid, int[] position)
        {
            grid[position[0]][position[1]] = 1;
            return grid;
        }

        public int[][][] DepthSearch(int[][] grid, int[] position, int[][] visited, int destination)
        {
            var currentVisited = ClonePositionArray(visited).Append(position).ToArray();

            if (PositionValue(grid, position) == destination) return new[] { currentVisited };

            var visitedGrid = Visit(CloneGridArray(grid), position);

            var nextPositions = NextPositions(position);
            var results = new List<int[][][]>();
            foreach (var nextPosition in nextPositions)
            {
                if (CanMove(grid, nextPosition))
                {
                    var result = DepthSearch(visitedGrid, nextPosition, currentVisited, destination);
                    results.Add(result);
                }
            }

            return results.SelectMany(x => x).ToArray();
        }
    }
}
