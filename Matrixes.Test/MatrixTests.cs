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
            var expected = new SquareMatrix<int>(new int[] { 4, 4, 6, 4, 9, 3, 6, 3, 3 });
            var sum = MatrixSum.Sum(squareMatrix, diagonalMatrix);
            Assert.AreEqual(sum,expected);
        }
    }
}
