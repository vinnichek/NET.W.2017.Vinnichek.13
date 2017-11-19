﻿using System;
using System.Collections.Generic;

namespace Matrixes.Logic
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        #region Fields and Events
        private T[] arrayOfDiagonalElements;
        public event MethodSet OnSetValue;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="arrayOfDiagonalElements">Array of diagonal elements.</param>
        public DiagonalMatrix(T[] arrayOfDiagonalElements)
        {
            if (arrayOfDiagonalElements == null)
                throw new ArgumentNullException($"{nameof(arrayOfDiagonalElements)} is null.");

            Size = arrayOfDiagonalElements.Length;

            this.arrayOfDiagonalElements = arrayOfDiagonalElements;
        }
        #endregion

        #region Override Methods
        public override T GetValue(int i, int j)
        {
            CheckIndexes(i, j);

            if (i != j)
                return default(T);

            return arrayOfDiagonalElements[i];
        }

        public override void SetValue(int i, int j, T value)
        {
            CheckIndexes(i, j);
            if (ReferenceEquals(value, null))
                throw new ArgumentNullException($"{nameof(value)} is null.");

            arrayOfDiagonalElements[i] = value;

            OnSetValue(i, j, value);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                        yield return default(T);
                    else
                        yield return arrayOfDiagonalElements[i];
                }
            }
        }
        #endregion
    }
}
