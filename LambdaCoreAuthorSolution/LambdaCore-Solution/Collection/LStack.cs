namespace LambdaCore_Solution.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using LambdaCore_Solution.Interfaces;

    public class LStack<T> : IEnumerable<T> where T : IFragment 
    {
        private readonly LinkedList<T> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<T>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public T Push(T item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public T Pop()
        {
            T lastElement = this.innerList.Last.Value;
            this.innerList.RemoveLast();
            return lastElement;
        }

        public T Peek()
        {
            T peekedItem = this.innerList.Last.Value;
            return peekedItem;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
