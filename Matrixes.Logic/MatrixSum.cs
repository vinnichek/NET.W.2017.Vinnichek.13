using System;
using Microsoft.CSharp.RuntimeBinder;
using System.Linq.Expressions;


namespace Matrixes.Logic
{
    public static class MatrixSum
    {
        public static Matrix<T> Sum<T>(this Matrix<T> lhs, Matrix<T> rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException($"{nameof(lhs)} is null.");
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null.");
            if (lhs.Size != rhs.Size) throw new ArgumentException($"{nameof(lhs)} and {nameof(rhs)} have different sizes and can't be summarized.");

            T[][] result = new T[lhs.Size][];
            for (int i = 0; i < result.Length; i++)
                result[i] = new T[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    if (j > i)
                    {
                        result[i][j] = (dynamic)lhs[j,i] + rhs[i, j];
                    }
                    else
                        result[i][j] = (dynamic)lhs[i, j] + rhs[i, j];
                }
            }
            return new SquareMatrix<T>(result);
        }
    }
}
