using System;
namespace Matrixes.Logic
{
    internal class TypeOfMatrix
    {
        public static Type MatrixType<T>(Matrix<T> lhs, Matrix<T> rhs)
        {
            if ((lhs.GetType() == typeof(SquareMatrix<T>)) && (rhs.GetType() == typeof(SquareMatrix<T>))) 
                return typeof(SquareMatrix<T>);
            
            if ((lhs.GetType() == typeof(SymmetricMatrix<T>)) && (rhs.GetType() == typeof(SymmetricMatrix<T>)))
                return typeof(SymmetricMatrix<T>);

            if ((lhs.GetType() == typeof(DiagonalMatrix<T>)) && (rhs.GetType() == typeof(DiagonalMatrix<T>)))
                return typeof(DiagonalMatrix<T>);

            return typeof(SquareMatrix<T>);
        }
    }
}
