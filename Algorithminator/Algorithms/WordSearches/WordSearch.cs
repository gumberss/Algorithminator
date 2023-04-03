using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.WordSearches
{
    public class WordSearch
    {
        public bool CanMake(string word, char[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == word[0])
                    {
                        var currentPosition = new Tuple<int, int>(i, j);
                        var currentVisitedPaths = new Tuple<int, int>[matrix.Length];

                        if (DeepSearch(word, matrix, currentPosition, currentVisitedPaths, 0))
                            return true;
                    }
                }
            }

            return false;
        }

        private bool DeepSearch(string word, char[,] matrix, Tuple<int, int> current, Tuple<int, int>[] visitedPaths, int point)
        {
            if (matrix.GetLength(0) == current.Item1
                || matrix.GetLength(1) == current.Item2
                || current.Item1 < 0
                || current.Item2 < 0
                )
                return false;

            if (word[point] != matrix[current.Item1, current.Item2]) return false;
            if (visitedPaths.Contains(current)) return false;

            if (word.Length -1 == point) return true;

            visitedPaths[point] = current;

            var possibleMoves = new Tuple<int, int>[]
           {
                new Tuple<int, int>(current.Item1 - 1, current.Item2),
                new Tuple<int, int>(current.Item1, current.Item2 - 1),
                new Tuple<int, int>(current.Item1 + 1, current.Item2),
                new Tuple<int, int>(current.Item1, current.Item2 + 1),
           };

            foreach (var move in possibleMoves)
            {
               var result =  DeepSearch(word, matrix, move, visitedPaths, point + 1);

                if (result) return result;
            }

            return false;
        }

    }
}
