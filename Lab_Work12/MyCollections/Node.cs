using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //определение узла бинарного дерева
    public class Node<T> : IComparable
        where T : IComparable //для правильной реализации
    {
        public T? Data { get; set; } //информационное поле
        public Node<T>? Left { get; set; } //левый потомок
        public Node<T>? Right { get; set; } //правый потомок

        public Node(T data) //конструктор с параметром
        {
            Data = data;
        }

        //конструктор с параметрами
        public Node(T data, Node<T> Left, Node<T> Right)
        {
            Data = data;
            Left = Left;
            Right = Right;
        }

        //ОПИСАНИЕ добавления элемента в дерево
        public bool Add(T data)
        {
            if (data == null)
            {
                return false;
            }

            var compareResult = data.CompareTo(Data);

            if (compareResult < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    return Left.Add(data);
                }
            }
            else if (compareResult == 0)
            {
                return false;
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(data);

                }
                else
                {
                    return Right.Add(data);
                }
            }

            return true;
        }

        //для вывода на экран
        public override string ToString()
        {
            return Data.ToString();
        }

        //компаратор для узла
        public int CompareTo(object? obj)
        {
            if (obj is Node<T> item) return Data.CompareTo(item);
            else throw new ArgumentException();
        }

        
    }
}