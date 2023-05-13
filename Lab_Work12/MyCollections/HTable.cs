using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class HTable<T>
        where T : class, IInit<T>
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
                while (current.Next != null)
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
                if (Table[i] == null) result += "\nЦепочка " + (i + 1).ToString() + " : Нет данных";
                else
                {
                    result += "\nЦепочка " + (i + 1).ToString() + ":";
                    HashPoint<T> point = Table[i];
                    while (point != null)
                    {
                        result += "\n\t" + point.ToString();
                        point = point.Next;
                    }
                    result += "\n";
                }
            }
            return result;
        }

        //поиск элемента
        public bool FindElementData(T data) //поиск элемента по значению
                                            //возвращает Null, если элемента нет
        {
            HashPoint<T> point = new(data);
            int pointIndex = Math.Abs(point.GetHashCode()) % Size;
            if (Table[pointIndex] != null 
                && Table[pointIndex].Key.Equals(data)) return true;
            else
            {
                point = Table[pointIndex];
                while (point != null)
                {
                    if (point.Key.Equals(data)) return true;
                    point = point.Next;
                }
                return false;
            }
        }

        //удаление элемента
        public T DeleteElement(T data)
        {
            HashPoint<T> point = new HashPoint<T>(data);
            int code = Math.Abs(point.GetHashCode()) % Size;
            point = Table[code];
            if (Table[code] == null) return null;
            if (Table[code] != null && Table[code].Key.Equals(data))
            {
                point = Table[code];
                Table[code] = Table[code].Next;
                return point.Value;
            }
            while (point.Next != null && !point.Next.Key.Equals(data))
                point = point.Next;
            if (point.Next != null)
            {
                data = point.Next.Value;
                point.Next = point.Next.Next;
                return data;
            }
            return null;
        }
    }
}
