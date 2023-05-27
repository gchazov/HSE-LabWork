using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AnimalLibrary;

namespace MyCollections
{
    //коллекция обобщённая, т.е. её можно использовать с разными типами данных
    public class DoublyLinkedList<T> : IEnumerable<T>
        where T  : class, ICloneable, new()
    {
        private DuplexItem<T>? Current { get; set; } //текущий эл.
        private DuplexItem<T>? Head { get; set; } //начальный элемент (головной)
        private DuplexItem<T>? Tail { get; set; } //крайний элемент (хвостовой)

        public bool isEmpty //проверка на пустоту списка
        {
            get
            {
                return Count == 0;
            }
        }

        public int Count { get; private set; } //размер коллекции (огр. доступ)

        //индексатор
        public T this[int index]
        {
            get
            {   //выбрасываем исключение если индекс меньше нуля
                if (index < 0) throw new ArgumentOutOfRangeException();
                DuplexItem<T> current = Head;
                for (int i = 0; i < index; i++)
                {
                    if (current.Next == null) //если выходим за границы колллекции
                        throw new ArgumentOutOfRangeException();
                    current = current.Next; //переход на следующий элемент
                }
                return current.Data;
            }

            set
            {   
                if (index >= 0 && index < Count)
                {
                    Current = Head;
                    for (int i = 0; i < Count; i++)
                    {
                        if (i == index)
                        {
                            Current.Data = value;
                            return;
                        }
                        Current = Current.Next; //переход на следующий элемент
                    }
                }
                else
                {
                    //выбрасываем исключение
                    throw new IndexOutOfRangeException();
                }
            }
        }

        

        public DoublyLinkedList()
        {
            Head = Current = Tail = null;
            Count = 0;
        } //пустая коллекция

        //конструктор с параметром (на основе элемента)
        public DoublyLinkedList(T data)
        {
            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        //добавление в самое начало
        public void AddFirst(T data)
        {
            DuplexItem<T> item = new DuplexItem<T>(data);
            
            //если коллекция пуста
            if (Head == null)
            {
                Head = Tail = item;
            }
            else
            {
                //делаем головным наш элемент
                item.Next = Head;
                Head = item;
                item.Next.Prev = Head;
            }
            Count++;
        }

        //добавление в самый конец
        public void AddLast(T data)
        {
            DuplexItem<T> item = new DuplexItem<T>(data);

            //если коллекция пуста
            if (Head == null)
            {
                Head = Tail = item;
            }
            else
            {
                Tail.Next = item;
                item.Prev = Tail;
                Tail = item;
            }
            Count++;
        }

        //добавление элемента в коллекцию
        public void Insert(T data, int index)
        {
            if (index < 1 || index > Count + 1) //вброс ошибки, если неправильный индекс
            {
                throw new InvalidOperationException();
            }
            else if (index == 1) //если начало
            {
                AddFirst(data);
            }
            else if (index == Count + 1) //если вконец
            {
                AddLast(data);
            }
            else //иначе ищем элемент с таким индексом
            {
                int count = 1;
                Current = Head;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                DuplexItem<T> newNode = new (data); //создаем объект
                //ставим правый указатель предыдущего элемента на наш объект
                Current.Prev.Next = newNode;
                //ставим левый указатель нашего объекта на пред. эл.
                newNode.Prev = Current.Prev;
                //левый указатель текущего на наш объект
                Current.Prev = newNode;
                //правый указатель нашего объекта на текущий
                newNode.Next = Current;
                Count++;
            }
        }

        //очищаем коллекцию
        public void Clear()
        {
            while (!isEmpty)
            {
                if (Head == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    DuplexItem<T> temp = Head;
                    if (Head.Next != null)
                    {
                        Head.Next.Prev = null;
                    }
                    Head = Head.Next;
                    Count--;
                }
            }
        }

        //удаление последнего элемента списка
        public DuplexItem<T> Pop()
        {
            if (Tail == null) throw new InvalidOperationException();
            else
            {
                DuplexItem<T> temporary = Tail; //временный узел
                if (Tail.Prev != null) Tail.Prev.Next = null;
                Tail = Tail.Prev;
                Count--;
                return temporary;
            }
        }

        //реверс коллекции
        public void Reverse()
        {
            DuplexItem<T> beg = Head; //элемент, с которого начинаем

            while (beg != null)
            {
                DuplexItem<T> temp = beg.Next; //след. элемент
                beg.Next = beg.Prev;
                beg.Prev = temp;

                if (beg.Prev == null)
                {
                    Head = beg;
                }

                beg = beg.Prev;
            }

        }


        //клонирование двунаправленного списка
        public DoublyLinkedList<T> Clone()
        {
            DoublyLinkedList <T> clone = new();
            foreach (T item in this)
            {
                clone.AddLast((T)item.Clone());
            }
            return clone;
        }

        //вывод на экран
        public void Show()
        {
            foreach (T item in this)
            {
                Console.WriteLine(item);
            }
        }

        //вывод на экран
        public override string ToString()
        {
            string result = "";
            foreach (T item in this)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }

        //нумератор для работы с циклом foreach
       

        //получение обобщённого нумератора
       public  IEnumerator<T> GetEnumerator()
        {
            var Current = Head;
            while (Current != null)
            {
                //возврат текущего
                yield return Current.Data;
                //переадресация на следующий
                Current = Current.Next;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
