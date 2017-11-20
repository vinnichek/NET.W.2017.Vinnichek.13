using System;
namespace Matrixes.Logic
{
    public class ChangeElementEventArgs : EventArgs
    {
        #region properties
        /// <summary>
        /// Info about event.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Number of row where element changed.
        /// </summary>
        public int I { get; }

        /// <summary>
        /// Number of column where element changed.
        /// </summary>
        public int J { get; }
        #endregion

        #region ctors
        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="message">Info about event.</param>
        /// <param name="i">Number of row where element changed.</param>
        /// <param name="j">Number of column where element changed.</param>
        public ChangeElementEventArgs(string message, int i, int j)
        {
            Message = message;
            I = i;
            J = j;
        }
        #endregion
    }
}
