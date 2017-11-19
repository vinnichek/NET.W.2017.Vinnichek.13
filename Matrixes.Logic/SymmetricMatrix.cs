using System;
using System.Collections.Generic;

namespace Matrixes.Logic
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        #region Fields and Events
        public event MethodSet OnSetValue;
        private T[][] triangleArray;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="array">Array of matrix elements.</param>
        public SymmetricMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException($"{nameof(array)} in null");

            for (int i = 0; i < array.Length; i++)
                if (array[i].Length != array.Length)
                    throw new ArgumentException($"{nameof(array)} must be square.");

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if (!array[i][j].Equals(array[j][i]))
                        throw new ArgumentException($"{nameof(array)} has no elements symmetric about the main diagonal.");

            Size = array.Length;

            triangleArray = new T[Size][];

            for (int i = 1; i <= Size; i++)
                triangleArray[i - 1] = new T[i];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < triangleArray[i].Length; j++)
                    triangleArray[i][j] = array[i][j];
        }
        #endregion

        #region Override Methods
        public override T GetValue(int i, int j)
        {
            CheckIndexes(i, j);

            if (j > i)
                return triangleArray[j][i];

            return triangleArray[i][j];
        }

        public override void SetValue(int i, int j, T value)
        {
            CheckIndexes(i, j);
            if (ReferenceEquals(value, null)) throw new ArgumentNullException($"{nameof(value)} is null.");

            if (i != j)
                throw new ArgumentException("Can't change non-diagonal element of matrix.");

            triangleArray[i][j] = value;

            OnSetValue(i, j, value);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j > i)
                        yield return triangleArray[j][i];
                    else
                        yield return triangleArray[i][j];
                }
            }
        }
        #endregion
    }
}
