using System.Collections;

namespace LambdaCore_Skeleton.Collection
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class LStack : IEnumerable<IFragment>
    {
        private LinkedList<IFragment> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<IFragment>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public IFragment Push(IFragment item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public IFragment Pop()
        {
            IFragment lastElement = this.innerList.Last.Value;
            this.innerList.RemoveLast();
            return lastElement;
        }

        public IFragment Peek()
        {
            IFragment peekedItem = this.innerList.Last();
            return peekedItem;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count == 0;
        }

        public long Sum()
        {
            return this.innerList.Sum(x => x.PressureAffection);
        }
        //public void RemoveGivenCoreName(string coreName)
        //{
        //    var coreToRemove = innerList.FirstOrDefault(x => x.Name == coreName);
        //    if (coreToRemove == null)
        //    {
        //        throw new InvalidOperationException($"Failed to remove ICore {coreName}!");
        //    }
        //    this.innerList.Remove(coreToRemove);
        //}
        public IEnumerator<IFragment> GetEnumerator()
        {
            foreach (var item in innerList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}