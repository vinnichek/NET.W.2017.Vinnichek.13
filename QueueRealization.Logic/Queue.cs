using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueRealization.Logic
{
    /// <summary>
    /// Generic collection queue.
    /// </summary>
    /// <typeparam name="T">Type for substitution.</typeparam>
    public class Queue<T> : IEnumerable<T> 
    {
        #region Fields
        private T[] array;
        private int capacity;
        private const int defaultCapacity = 10;
        private int head;
        private int size;
        private int tail;
        private int version;
        #endregion

        #region Properties
        /// <summary>
        /// Returns true if queue is empty and false if not.
        /// </summary>
        public bool IsEmpty() => size == 0;
        #endregion

        #region Ctors
        /// <summary>
        /// Ctor without parameters.
        /// </summary>
        public Queue()
        {
            array = new T[defaultCapacity];
        }

        /// <summary>
        /// Ctor with parameters.
        /// </summary>
        /// <param name="capacity">Size of queue.</param>
        public Queue(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException($"{nameof(capacity)} is unsuitable.");

            this.capacity = capacity;
            array = new T[capacity];
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add element to the end of queue.
        /// </summary>
        /// <param name="newElement">Insertion element.</param>
        public void Enqueue(T newElement)
        {
            if (ReferenceEquals(newElement, null))
                throw new ArgumentNullException($"{nameof(newElement)} is null.");

            if (size == capacity)
            {
                Expansion();
            }

            array[tail] = newElement;
            tail = (tail + 1) % capacity;
            size++;
        }

        /// <summary>
        /// Remove element from the beginning of queue.
        /// </summary>
        /// <returns>Removed element.</returns>
        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            size--;
            return array[(head + 1) % capacity];
        }

        /// <summary>
        /// Specify whether the item is included in the queue.
        /// </summary>
        /// <param name="element">Element to check.</param>
        /// <returns>True if element included and false if not.</returns>
        public bool Contains(T element)
        {
            if (size == capacity) 
                throw new InvalidOperationException("Queue is empty.");
            if (ReferenceEquals(element, null)) 
                throw new ArgumentNullException($"{nameof(element)} is null.");

            for (int i = 0; i < size; i++)
            {
                if (element.Equals(array[i]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Remove all elements from queue.
        /// </summary>
        public void Clear() 
        {
            head = 0;
            tail = 0;
            size = 0;
        }

        /// <summary>
        /// Return last element from queue.
        /// </summary>
        /// <returns>Last element.</returns>
        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("Queue is empty.");

            return array[head];
        }

        /// <summary>
        /// Enumerator for queue.
        /// </summary>
        /// <returns>Object IEnumerator to iterate.</returns>
        public IteratorQueue GetEnumerator() => new IteratorQueue(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new IteratorQueue(this);

        IEnumerator IEnumerable.GetEnumerator() => new IteratorQueue(this);
        #endregion 

        #region struct IteratorQueue
        public struct IteratorQueue : IEnumerator<T>
        {
            private Queue<T> queue;
            private int index;
            private int version;

            public T Current
            {
                get
                {
                    if (index == -1 || index == queue.capacity) throw new ArgumentException($"{nameof(index)} is unsuitable.");
                    return queue.array[index];
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public IteratorQueue(Queue<T> queue)
            {
                this.queue = queue;
                this.index = queue.head - 1;
                this.version = queue.version; 
            }

            public bool MoveNext()
            {
                if (version != queue.version) throw new InvalidOperationException();

                if (queue.head <= queue.tail)
                {
                    return ++index < queue.size + queue.head;
                }

                else
                {
                    index = (index + 1) % queue.capacity;
                    return index != queue.tail;
                }
            }

            public void Dispose() { }

            public void Reset() => throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private void Expansion()
        {
            T[] newQueue = new T[capacity * 2];
            Array.Copy(array, 0, newQueue, 0, array.Length);
            array = newQueue;
            capacity = capacity * 2;
            head = 0;
            tail = size;
        }
        #endregion
    }
}
