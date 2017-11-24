using System;
using System.Collections;
using System.Collections.Generic;

namespace Matrixes.Logic
{
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Fields
        private int size;
        #endregion

        #region Properties
        /// <summary>
        /// Size of matrix.
        /// </summary>
        public int Size
        {
            get => size;
            set
            {
                if (value <= 0) 
                    throw new ArgumentException($"{nameof(value)} can't be less or equal 0."); ;
                size = value;
            }
        }

        /// <summary>
        /// Change element event.
        /// </summary>
        public event EventHandler<ChangeElementEventArgs> NewElement = delegate { };
        #endregion

        #region Public and Protected Methods
        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Row number.</param>
        /// <param name="j">Column number.</param>
        public T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return GetValue(i, j);
            }
            set
            {
                CheckIndexes(i, j);
                SetValue(i, j, value);
                OnChangeElement(new ChangeElementEventArgs(GetType().ToString(), i, j));
            }
        }

        /// <summary>
        /// Invoke ChangeElement event.
        /// </summary>
        /// <param name="args">Arguments of event.</param>
        protected virtual void OnChangeElement(ChangeElementEventArgs args)
        {
            NewElement?.Invoke(this, args);
        }

        /// <summary>
        /// Get value from i,j position of matrix.
        /// </summary>
        /// <param name="i">Number of row.</param>
        /// <param name="j">Number of column.</param>
        /// <returns>Value from i,j position.</returns>
        public abstract T GetValue(int i, int j);

        /// <summary>
        /// Set value to i,j position of matrix.
        /// </summary>
        /// <param name="i">Number of row.</param>
        /// <param name="j">Number of column.</param>
        /// <param name="value">New value.</param>
        public abstract void SetValue(int i, int j, T value);

        /// <summary>
        /// Return enumerator.
        /// </summary>
        /// <returns>Enumerator which iterates through collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    yield return this.GetValue(i, j);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); 

        public override int GetHashCode() => base.GetHashCode();

        protected void CheckSize(int size)
        {
            if (size <= 0) throw new ArgumentException($"{nameof(size)} can't be less than or equal 0.");
        }

        protected void CheckIndexes(int i, int j)
        {
            if (i >= Size || i < 0) throw new ArgumentException($"{nameof(i)} index is invalid.");
            if (j >= Size || j < 0) throw new ArgumentException($"{nameof(j)} index is invalid.");
        }
        #endregion
    }
}

