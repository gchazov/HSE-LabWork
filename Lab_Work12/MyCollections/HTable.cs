using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class HTable<T>
    {
        public HashPoint<T>[] Table { get; private set; } //массив пар
        public int Size { get; private set; } //размер
        public HTable(int size = 0) //конструктор с размером
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

        public HashPoint<T>? FindElementData(T data) //поиск элемента по значению
            //возвращает Null, если элемента нет
        {
            HashPoint<T> point = new(data);
            int pointIndex = Math.Abs(point.GetHashCode()) % Size;
            if (Table[pointIndex] == null)  return null;
            else
            {
                HashPoint<T> current = Table[pointIndex];
                while (current.Next != null)
                {
                    if (current.Equals(point)) return current;
                }
                return null;
            }
        }

        public HashPoint<T>? DeleteElement(T data) //удаление элемента из хеш-тейбл
        {
            if (Table.Length == 0) throw new ArgumentNullException();
            HashPoint<T> point = new(data);
            int index = Math.Abs(point.GetHashCode()) % Size;

            if (Table[index] == null) return null;
            if (Table[index].Next == null) 
            {
                Table[index] = null;
                return Table[index];
            }
            else
            {
                point = Table[index];
                while (point.Next != null && !point.Next.Equals(point))
                {
                    point = point.Next;
                    if (point.Next != null)
                    {
                        var result = new HashPoint<T>(data);
                        point.Next = point.Next.Next;
                        return result;
                    }
                }
                return null;
            }
        }

    }
}
