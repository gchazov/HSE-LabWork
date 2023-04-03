using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //определение узла бинарного дерева
    public class Node<T>
        where T : IComparable //для правильной реализации
    {
        public T? Data { get; set; } //информационное поле
        public Node<T>? Left { get; private set; } //левый потомок
        public Node<T>? Right { get; private set; } //правый потомок

        public Node(T data) //конструктор с параметром
        {
            Data = data;
        }

        //конструктор с параметрами
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

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

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
