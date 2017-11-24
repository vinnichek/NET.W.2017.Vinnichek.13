using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Matrixes.Logic
{
    public class SquareMatrix<T> : Matrix<T>
    {
        #region Fields and Events
        private T[,] innerArray;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="array">Array of matrix elements.</param>
        public SquareMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException($"{nameof(array)} is null.");

            var sqrt = Math.Sqrt(array.Length);

            if (Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) > Double.Epsilon)
                throw new ArgumentException("Square root of number of elements must be integer.");

            Size = (int)Math.Sqrt(array.Length);

            innerArray = new T[Size, Size];

            for (int i = 0, h = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    innerArray[i, j] = array[h];
                    h++;
                }
            }
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="array">Array of matrix elements.</param>
        public SquareMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            foreach (T[] row in array)
                if (row.Length != array.Length)
                    throw new ArgumentException("Input array must be square.");

            Size = array.Length;

            innerArray = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    innerArray[i, j] = array[i][j];
        }
        #endregion

        #region Override Methods
        public override T GetValue(int i, int j)
        {
            CheckIndexes(i, j);
            return innerArray[i, j];
        }

        public override void SetValue(int i, int j, T value)
        {
            CheckIndexes(i, j);
            if (ReferenceEquals(value, null)) throw new ArgumentNullException($"{nameof(value)} is null.");
            innerArray[i, j] = value;
        }
        #endregion
    }
}
