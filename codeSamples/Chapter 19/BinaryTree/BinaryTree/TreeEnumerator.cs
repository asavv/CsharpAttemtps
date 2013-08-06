using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class TreeEnumerator<TItem> : IEnumerator<TItem> where TItem : IComparable<TItem>
    {
        private Tree<TItem> currentData = null;  // reference to the tree being enumerated
        private TItem currentItem = default(TItem);  // hold the value returned byt eh Current property
        private Queue<TItem> enumData = null;  // queue to be populated with the values extracted from the nodes in the tree

        public TreeEnumerator(Tree<TItem> data)
        {
            this.currentData = data;
        }

        private void populate(Queue<TItem> enumQueue, Tree<TItem> tree)
        {
            if (tree.LeftTree != null)
            {
                populate(enumQueue, tree.LeftTree);
            }

            enumQueue.Enqueue(tree.NodeData);

            if (tree.RightTree != null)
            {
                populate(enumQueue, tree.RightTree);
            }
        }

        TItem IEnumerator<TItem>.Current
        {
             get
            {
                if (this.enumData == null)
                    throw new InvalidOperationException
                        ("Use MoveNext before calling Current");

                return this.currentItem;
            }
        }

        void IDisposable.Dispose()
        {
            ////the enumerator does not use any resources that require explicit disposal,
            //// so this method does not need to do anything.
            //// But it still needs to be present.
            
            //throw new NotImplementedException();
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Updates the internal state in teh enumerator, for use by the Current Property, 
        /// returning true if there is a next value and false otherwise.
        /// </summary>
        /// <returns></returns>
        bool System.Collections.IEnumerator.MoveNext()
        {
           if(this.enumData == null)
            {
                this.enumData = new Queue<TItem>();
               populate(this.enumData,this.currentData);
            }

            if (this.enumData.Count > 0)
            {
                this.currentItem = this.enumData.Dequeue();
                return true;
            }
            return false;
        }

        void System.Collections.IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
    }
}
