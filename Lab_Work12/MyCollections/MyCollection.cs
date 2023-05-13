using AnimalLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class MyCollection<T>: ICollection
        where T: class, IInit<T>, ICloneable, new()
    {

        public DoublyLinkedList<T>[]Table { get; private set; } 
        public MyCollection()
        {
            Table = (DoublyLinkedList<T>[]?)Array.Empty<object>();
        }

        public MyCollection(int size)
        {
            Table = new DoublyLinkedList<T>[size];
        }

        public MyCollection(MyCollection<T> origin)
        {
            MyCollection<T> clone = new(origin.Table.Length);
            for (int i = 0; i < origin.Table.Length; i++)
            {
                clone.Table[i] = origin.Table[i].Clone();
            }
        }

        public void Add(T data) //добавление одного элемента в хт
        {
            Table[data.GetBase().GetHashCode()%Table.Length].AddLast(data);
        }

        public void AddRange(params T[] values) //добавление нескольких...
        {
            for (int i = 0; i < values.Length; i++)
                Table[values[i].GetBase().GetHashCode() % Table.Length].
                    AddLast(values[i]);
        }

        public bool FindElement(T data) //поиск элемента в коллекции
        {
            int index = data.GetBase().GetHashCode() % Table.Length;
            DoublyLinkedList<T> current = Table[index];
            foreach (var item in current)
            {
                if (current.Equals(item))
                    return true;
            }
            return false;
        }

        public T DeleteElement(T data) //поиск элемента в коллекции
        {
            if (!this.FindElement(data)) return null;
            //TODO
            return (T)data;
        }


        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
