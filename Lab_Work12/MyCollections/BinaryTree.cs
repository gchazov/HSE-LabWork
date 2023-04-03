using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class BinaryTree<T>
        where T: IComparable
    {
        private Node<T> ?Root { get; set; } //корень дерева
        public int Count { get; set; } //кол-во узлов дерева
        
        //добавление элемента в дерево
        public bool Add(T data)
        {
            if (data == null)
            {
                return false;
            }

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return true; ;
            }

            var addResult = Root.Add(data);
            if (addResult)
            {
                Count++;
            }

            return addResult;
        }
    }
}
