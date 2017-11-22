using System;
using NUnit.Framework;
using Matrixes.Logic;

namespace Matrixes.Test
{
    [TestFixture]
    public class MatrixTests
    {
        [TestCase]
        public void TestSum_Of_Square_And_Diagonal_Matrix()
        {
            var squareMatrix = new SquareMatrix<int>(new int[] { 2, 4, 1, 4, 5, 5, 6, 3, 2 });
            var diagonalMatrix = new DiagonalMatrix<int>(new int[] { 2, 4, 1 });
            var expected = new SquareMatrix<int>(new int[] { 4, 4, 1, 4, 9, 5, 6, 3, 3 });

            Assert.AreEqual(MatrixSum.Sum(squareMatrix, diagonalMatrix), expected);
        }

        [TestCase]
        public void TestSum_Matrix_Type()
        {
            var squareMatrix = new SquareMatrix<int>(new int[] { 2, 4, 1, 4, 5, 5, 6, 3, 2 });
            var diagonalMatrix = new DiagonalMatrix<int>(new int[] { 2, 4, 1 });
            var symmetricMatrix = new SymmetricMatrix<int>(new int[3][] { new int[] { 1, 2, 3 }, new int[] { 2, 4, 5 }, new int[] { 3, 5, 6 } });

            Assert.AreEqual(typeof(SquareMatrix<int>), MatrixSum.Sum(squareMatrix, diagonalMatrix).GetType());
            Assert.AreEqual(typeof(DiagonalMatrix<int>), MatrixSum.Sum(diagonalMatrix, diagonalMatrix).GetType());
            Assert.AreEqual(typeof(SymmetricMatrix<int>), MatrixSum.Sum(symmetricMatrix, symmetricMatrix).GetType());
            Assert.AreEqual(typeof(SquareMatrix<int>), MatrixSum.Sum(diagonalMatrix, symmetricMatrix).GetType());
        }
    }
}
