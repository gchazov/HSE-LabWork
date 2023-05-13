using AnimalLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //ХЕШ-ТАБЛИЦА (МЕТОД ЦЕПОЧЕК)
    public class MyCollection<T> : ICollection<T>, IEnumerable<T>, ICloneable
        where T : class, IInit<T>, ICloneable, new()
    {
        private HashPoint<T>[] Table { get; set; } //таблица с цепочками

        public int Count { get; private set; } //СЧЁТЧИК ЭЛЕМЕНТОВ

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


        public void Add(T item)     //добавление элемента в хеш-таблицу
        {
            HashPoint<T> point = new(item);
            if (item == null) return;
            int index = Math.Abs(point.GetHashCode()) % Length;
            if (Table[index] == null)
            { 
                Table[index] = point;
                Count++;
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
                Count++;
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
                Count--;
                return true;
            }
            while (point.Next != null && !point.Next.Key.Equals(item))
                point = point.Next;
            if (point.Next != null)
            {
                item = point.Next.Value;
                point.Next = point.Next.Next;
                Count--;
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
            _ = new MyCollection<T>();
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
            for (int i = arrayIndex; i < Length; i++)
            {
                HashPoint<T> current = Table[i];
                while (current.Next != null)
                {
                    array.Append((T)current.Value.Clone());
                    current = current.Next;
                }
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
                HashPoint<T> current = Table[i];
                while (current != null)
                {
                    copy.Add(current.Value);   //здесь уже не клонируем по элементам
                    current = current.Next;
                }
            }
            return copy;
        }
    }
}
