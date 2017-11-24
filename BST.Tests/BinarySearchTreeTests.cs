using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BST.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Tests with String
        public sealed class CustomStringComparer : IComparer<string>
        {
            public int Compare(string x, string y) => x.Length - y.Length;
        }

        [TestCase]
        public void Enumerator_String_SortedArray()
        {
            string[] array = new string[] { "one", "three", "four" };

            var comparer = new CustomStringComparer();

            var tree = new BinarySearchTree<string>(comparer);
            tree.Add(array);

            int i = 0;
            foreach (var items in tree)
            {
                array[i++] = items;
            }

            string[] expectedArr = new string[] { "one", "four", "three" };

            Assert.AreEqual(expectedArr, array);
        }
        #endregion

        #region Test with Book
        sealed class Book : IComparable<Book>, IComparable
        {
            public int BookYear { get; set; }

            public int CompareTo(Book book) => this.BookYear - book.BookYear;
            public int CompareTo(object book) => CompareTo((Book)book);
        }

        [TestCase]
        public void Enumerator_Book_SortedArray()
        {
            var book1 = new Book() { BookYear = 1897 };

            var book2 = new Book() { BookYear = 1997 };

            var book3 = new Book() { BookYear = 2000 };


            var tree = new BinarySearchTree<Book>();
            tree.Add(book1);
            tree.Add(book2);
            tree.Add(book3);

            Book[] resBooks = new Book[3];

            int i = 0;
            foreach (var item in tree)
            {
                resBooks[i++] = item;
            }

            Book[] expBooks = { book2, book3, book1 };

            Assert.AreEqual(expBooks, resBooks);
        }
        #endregion

        #region Test with Struct
        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public sealed class CustomPointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y) => x.X * x.Y - y.X * y.Y;
        }

        [TestCase]
        public void Enumerator_Point_SortedArray()
        {
            var point1 = new Point() { X = 8, Y = 9 };

            var point2 = new Point() { X = 4, Y = 3 };

            var point3 = new Point() { X = 7, Y = 6 };

            var comparer = new CustomPointComparer();

            var tree = new BinarySearchTree<Point>(comparer.Compare);

            tree.Add(point1);
            tree.Add(point2);
            tree.Add(point3);


            var resArray = new Point[3];

            int i = 0;
            foreach (var item in tree)
            {
                resArray[i++] = item;
            }

            Point[] expArr = { point2, point3, point1 };

            Assert.AreEqual(expArr, resArray);
        }
        #endregion

        #region Tests with Int
        [TestCase]
        public void Enumerator_Int_SortedArray()
        {
            int[] array = new int[] { 12, 25, 78, 98, 7, 65, 35 };
            var tree = new BinarySearchTree<int>();
            tree.Add(array);

            int i = 0;
            foreach (var items in tree)
            {
                array[i++] = items;
            }

            int[] expectedArr = new int[] { 7, 12, 25, 35, 65, 78, 98 };

            Assert.AreEqual(expectedArr, array);
        }
        #endregion
    }
}
