using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class HTable<T>
    {
        public HashPoint<T>[] Table { get; set; } //массив пар
        public int Size { get; set; } //размер
        public HTable(int size) //конструктор с размером
        {
            Size = size;
            Table = new HashPoint<T>[Size];
        }

        public bool Add(T data) //добавление элемента в хеш-тейбл
        {
            HashPoint<T> point = new(data);
            if (data == null) return false;
            int index = Math.Abs(point.GetHashCode()) % Size;
            if (Table[index] == null) Table[index] = point;
            else
            {
                HashPoint<T> current = Table[index];
                if (current.Equals(point)) return false;
                while(current.Next != null)
                {
                    if (current.Equals(point)) return false;
                    current = current.Next;
                }
                current.Next = point;
            }
            return true;
        }

        public override string ToString() //печать таблицы
        {
            string result = "";
            for (int i = 0; i < Size; ++i)
            {
                if (Table[i] == null) result += i.ToString() + ":";
                else
                {
                    result += i.ToString() + ":";
                    HashPoint<T> point = Table[i];
                    while (point != null)
                    {
                        result += point.ToString() + "\t";
                        point = point.Next;
                    }
                    result += "\n";
                }
            }
            return result;
        }
    }
}
