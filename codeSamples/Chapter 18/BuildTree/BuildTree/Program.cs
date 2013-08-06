using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace BuildTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<char> charTree = new Tree<char>('M');
            InsertIntoTree<char>(charTree,'X','A','M','Z','Z','N');
            charTree.WalkTree();

            Tree<int> intTree = new Tree<int>(1);
            //InsertIntoTree<int>(intTree);   ///program catches as exception, as expected.
            InsertIntoTree<int>(intTree, 2,5,3,234,6,42,342,523,76,956);   
            intTree.WalkTree(); 
        }

        static void InsertIntoTree<TItem>(Tree<TItem> tree, params TItem[] data) where TItem : IComparable<TItem>
        {
            if(data.Length == 0)
                throw new ArgumentException("Must provide at least one data value");

            foreach (TItem datum in data)
            {
                tree.Insert((datum));
            }
        }
    }
}
