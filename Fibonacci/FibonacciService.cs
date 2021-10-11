using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithminator.Fibonacci
{
    //https://www.geeksforgeeks.org/program-for-nth-fibonacci-number/
    //https://www.youtube.com/watch?v=blM-m6iMHvM
    public class FibonacciService
    {
        //O(2^n)
        public double Slow(double n)
        {
            if (n <= 1) return n;

            return Slow(n - 1) + Slow(n - 2);
        }


        //O(log n)
        public double LogN(double n)
        {
            if (n == 0) return 0;

            double[,] matrix = new[,] { { 1D, 1D }, { 1D, 0D } };

            var result = Power(matrix, matrix, n - 1);

            return result[0, 0];
        }

        private double[,] Power(double[,] currentMatrix, double[,] multiplierMatrix, double n)
        {
            if (n == 0 || n == 1) return currentMatrix;

            var recursionMatrix = Power(currentMatrix, multiplierMatrix, (int)(n / 2));

            var newMatrix = Multiply(recursionMatrix, recursionMatrix);

            if (n % 2 != 0)
            {
                newMatrix = Multiply(newMatrix, multiplierMatrix);
            }

            return newMatrix;
        }

        double[,] Multiply(double[,] F, double[,] M)
        {
            double x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            double y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            double z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            double w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            return new double[,]
            {
                { x, y },
                { z, w }
            };
        }
    }
}
