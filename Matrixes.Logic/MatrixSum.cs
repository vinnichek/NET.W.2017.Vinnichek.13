using System;

namespace Matrixes.Logic
{
    public static class MatrixSum
    {
        public static Matrix<T> Sum<T>(this Matrix<T> lhs, Matrix<T> rhs)
        {
            if (ReferenceEquals(lhs, null)) throw new ArgumentNullException($"{nameof(lhs)} is null.");
            if (ReferenceEquals(rhs, null)) throw new ArgumentNullException($"{nameof(rhs)} is null.");
            if (lhs.Size != rhs.Size) throw new ArgumentException($"{nameof(lhs)} and {nameof(rhs)} have different sizes and can't be summarized.");

            Type matrixType = TypeOfMatrix.MatrixType(lhs, rhs);

            var result = new T[lhs.Size][];

            for (int i = 0; i < result.Length; i++)
                result[i] = new T[result.Length];
            
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    result[i][j] = (dynamic)lhs[i, j] + rhs[i, j];
                }
            }

            return (Matrix<T>)Activator.CreateInstance(matrixType, new object[] { result });
        }
    }
}
