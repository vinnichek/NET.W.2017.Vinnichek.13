using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BST
{
    public sealed class BinarySearchTree<T> : IEnumerable<T>, IEnumerable
    {
        #region Private fields
        private readonly Comparison<T> comparer;
        private Node<T> root;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of BinarySearchTree.>
        /// </summary>
        public BinarySearchTree() : this((Comparison<T>)null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="BinarySearchTree{T}"/>
        /// </summary>
        /// <param name="comparer"> Compares two instances. </param>
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare) { }

        /// <summary>
        /// Initialize a new instance of BinarySearchTree."/>
        /// </summary>
        public BinarySearchTree(Comparison<T> comparison)
        {
            root = null;
            comparer = comparison ?? Comparer<T>.Default.Compare;
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Find element in the tree.
        /// </summary>
        /// <param name="element"> Element to find. </param>
        /// <returns> True if the element exists. </returns>
        public bool Contains(T element) => Contains(root, element);

        /// <summary>
        /// Clear the tree.
        /// </summary>
        public void Clear()
        {
            root = null;
        }

        /// <summary>
        /// Adds an element in the tree.
        /// </summary>
        /// <param name="element"> Element to add. </param>
        public void Add(T element)
        {
            if (ReferenceEquals(element, null)) 
                throw new ArgumentNullException($"{nameof(element)} is null.");

            root = AddElement(root, element);
        }

        /// <summary>
        /// Add collection to the tree.
        /// </summary>
        /// <param name="collection"> Collection to add. </param>
        public void Add(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
            {
                Add(item);
            }
        }
                
        /// <summary>
        /// Preorder traversal.
        /// </summary>
        /// <returns> IEnumerable for preorder. </returns>
        public IEnumerable<T> PreOrder() => PreOrder(root);

        /// <summary>
        /// Postorder traversal.
        /// </summary>
        /// <returns> IEnumerable for postorder.</returns>
        public IEnumerable<T> PostOrder() => PostOrder(root);

        /// <summary>
        /// Inorder traversal.
        /// </summary>
        /// <returns> IEnumerable for inorder. </returns>
        public IEnumerable<T> InOrder() => InOrder(root);
        #endregion

        #region Iterator
        /// <summary>
        /// Iterator.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Private Methods
        private Node<T> AddElement(Node<T> node, T x)
        {
            if (node == null)
            {
                return new Node<T>(x);
            }

            int temp = comparer(x, node.Value);

            if (temp < 0)
                node.Left = AddElement(node.Left, x);
            else if (temp > 0)
                node.Right = AddElement(node.Right, x);

            return node;
        }

        private bool Contains(Node<T> node, T element)
        {
            if (node == null)
                return false;

            int temp = comparer(node.Value, element);

            if (temp == 0)
                return true;
            else if (temp < 0)
                return Contains(node.Right, element);
            else
                return Contains(node.Left, element);
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
                foreach (var n in PreOrder(node.Left))
                    yield return n;

            if (node.Right != null)
                foreach (var n in PreOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var n in InOrder(node.Left))
                    yield return n;

            yield return node.Value;

            if (node.Right != null)
                foreach (var n in InOrder(node.Right))
                    yield return n;
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
                foreach (var n in PostOrder(node.Left))
                    yield return n;

            if (node.Right != null)
                foreach (var n in PostOrder(node.Right))
                    yield return n;

            yield return node.Value;
        }
        #endregion

        #region Node
        internal sealed class Node<T>
        {
            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public T Value { get; set; }

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
        #endregion
    }
}
