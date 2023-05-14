using AnimalLibrary;
using System.Collections;
using System.Drawing;

namespace MyCollections
{
    //ХЕШ-ТАБЛИЦА (МЕТОД ЦЕПОЧЕК)
    public class MyCollection<T> : ICollection<T>, IEnumerable<T>, ICloneable
        where T : class, IInit<T>, ICloneable, new()
    {
        private HashPoint<T>[] Table { get; set; } //таблица с цепочками

        public int Count    //СЧЁТЧИК ЭЛЕМЕНТОВ
        {
            get
            {
                int counter = 0;
                foreach (var obj in this)
                {
                    if (obj != null) counter++;
                }
                return counter;
            }
            private set { }
        }

        public int Length { get; private set; } //СЧЁТЧИК ЦЕПОЧЕК

        public MyCollection()   //конструктор без парпамтеров
        {
            Table = Array.Empty<HashPoint<T>>();
            Count = 0;
            Length = 0;
        }

        public MyCollection(int capacity)   //пустая коллекция с ук. ёмкостью
        {
            Table = new HashPoint<T>[capacity];
            Length = capacity;
            Count = 0;
        }

        public MyCollection(MyCollection<T> origin)     //коллекция на основе другой коллекции
        {
            Table = new HashPoint<T>[origin.Length]; Length = origin.Length;
            for (int i = 0; i < origin.Length; ++i)
            {
                HashPoint<T> current = origin.Table[i];
                while(current != null)
                {
                    Add((T)current.Value.Clone());
                    current = current.Next;
                }
            }
        }

        public bool IsReadOnly => false;    //не только для чтения

        //индексатор
        public T? this[T key]
        {
            get
            { 
                if (key == null) throw new ArgumentNullException();
                HashPoint<T> current = Table[key.GetHashCode() % Length];
                while (current != null)
                {
                    if (current.Key.Equals(key)) return current.Value;
                    current = current.Next;
                }
                throw new ArgumentNullException();
            }

            set
            {
                if (key == null) throw new ArgumentNullException();
                HashPoint<T> current = Table[key.GetHashCode() % Length];

                if (current.Key.Equals(key))
                {
                    current.Key = value.GetBase();
                    current.Value = value;
                    return;
                }

                while (current.Next != null)
                {
                    if (current.Next.Key.Equals(key))
                    {
                        current.Next.Value = value;
                        current.Next.Key = value.GetBase();
                    }
                    current = current.Next;
                }
            }
        }


        public void Add(T item)     //добавление элемента в хеш-таблицу
        {
            HashPoint<T> point = new(item);
            if (item == null) return;
            int index = Math.Abs(point.GetHashCode()) % Length;
            if (Table[index] == null)
            { 
                Table[index] = point;
            }
            else
            {
                HashPoint<T> current = Table[index];
                if (current.Equals(point)) return;
                while (current.Next != null)
                {
                    if (current.Equals(point)) return;
                    current = current.Next;
                }
                current.Next = point;
            }
            return;
        }

        public void AddRange(params T[] values) //добавление нескольких элементов в хт
        {
            foreach (T item in values)
                Add(item);
        }

        public bool Remove(T item)  //добавление элемента
        {
            HashPoint<T> point = new HashPoint<T>(item);
            int code = Math.Abs(point.GetHashCode()) % Length;
            point = Table[code];
            if (Table[code] == null) return false;
            if (Table[code] != null && Table[code].Key.Equals(item))
            {
                point = Table[code];
                Table[code] = Table[code].Next;
                return true;
            }
            while (point.Next != null && !point.Next.Key.Equals(item))
                point = point.Next;
            if (point.Next != null)
            {
                item = point.Next.Value;
                point.Next = point.Next.Next;
                return true;
            }
            return false;
        }

        public void RemoveRange(params T[] values)  //удаление нескольких элементов
        {
            foreach (T item in values)
                Remove(item);
        }

        public void Clear()     //очистка коллекции
        {
            for (int i = 0; i < Length; i++)
            {
                Table[i] = null;
            }
        }

        public bool Contains(T item)    //проверка на содержание элемента в коллекции
           //(по ключу, само собой)
        {
            HashPoint<T> point = new(item);
            int pointIndex = Math.Abs(point.GetHashCode()) % Length;
            if (Table[pointIndex] != null
                && Table[pointIndex].Key.Equals(item)) return true;
            else
            {
                point = Table[pointIndex];
                while (point != null)
                {
                    if (point.Key.Equals(item)) return true;
                    point = point.Next;
                }
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)   //копирование в массив
            //начиная с определённой цепочки
        {
            if (arrayIndex < 0 || arrayIndex >= Length)
                throw new ArgumentOutOfRangeException();
            List<T> list = new List<T>();
            for (int i = arrayIndex; i < Length; i++)
            {
                HashPoint<T> current = Table[i];
                if (current == null) continue;
                while (current.Next != null)
                {
                    list.Add((T)current.Value.Clone());
                    current = current.Next;
                }
            }
            array = list.ToArray();
        }


        public IEnumerator<T> GetEnumerator()   //нумератор
        {
            for (int i = 0; i < Length; i++)
            {
                var current = Table[i];
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException(); //зачем нам необобщённый, если есть обобщёный?
        }

        public object Clone()   //глубокое клонирование
        {
            MyCollection<T> clone = new MyCollection<T>(Length);
            for (int i = 0; i < Length; ++i)
            {
                HashPoint<T> current = Table[i];
                while (current != null)
                {
                    clone.Add((T)current.Value.Clone()); //здесь клонируем даже элементы
                    current = current.Next;
                }
            }
            return clone;
        }

        public object ShallowCopy()     //поверхностное копирование
        {
            MyCollection<T> copy = new MyCollection<T>(Length);
            for (int i = 0; i < Length; ++i)
            {
                copy.Table[i] = Table[i];
            }
            return copy;
        }

        public override string ToString() //печать таблицы
        {
            string result = "";
            for (int i = 0; i < Length; ++i)
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
    }  
}
